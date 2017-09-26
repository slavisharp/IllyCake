namespace IllyCake.Data
{
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Cake> Cakes { get; set; }

        public DbSet<ImageFile> ImageFiles { get; set; }

        public DbSet<CakeImage> CakeImages { get; set; }

        public DbSet<Paragraph> Paragraphs { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<QuoteAuditTrail> QuoteAuditTrails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Application User
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.IsDeleted);

            // Cake Images
            builder.Entity<CakeImage>()
                .HasKey(ci => new { ci.CakeId, ci.ImageId });
            builder.Entity<CakeImage>()
                .HasOne(ci => ci.Image)
                .WithMany(i => i.CakeImages)
                .HasForeignKey(ci => ci.ImageId);
            builder.Entity<CakeImage>()
                .HasOne(ci => ci.Cake)
                .WithMany(i => i.Images)
                .HasForeignKey(ci => ci.CakeId);

            //Quote Audit Trail
            builder.Entity<QuoteAuditTrail>()
                .HasOne(q => q.Quote)
                .WithMany(q => q.AuditTrails)
                .HasForeignKey(q => q.QuoteId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            var entries = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));
            foreach (var entry in entries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.Created == default(DateTime))
                {
                    entity.Created = DateTime.UtcNow;
                }
                else
                {
                    entity.Modified = DateTime.UtcNow;
                }
            }
        }
    }
}
