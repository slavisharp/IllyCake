namespace IllyCake.Data
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using IllyCake.Data.Models;
    using System.Threading;
    using System.Threading.Tasks;

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
            BuildApplicationUser(builder);

            // Cake Images
            BuildCakeImages(builder);

            // Quote Images
            BuilQuoteImages(builder);

            // Quote Audit Trail
            BuildQuoteAuditTrails(builder);
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
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

        private static void BuildApplicationUser(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.IsDeleted);
        }

        private static void BuildCakeImages(ModelBuilder builder)
        {
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
        }

        private void BuilQuoteImages(ModelBuilder builder)
        {
            builder.Entity<QuoteImage>()
                .HasKey(ci => new { ci.QuoteId, ci.ImageId });
            builder.Entity<QuoteImage>()
                .HasOne(ci => ci.Image)
                .WithMany(i => i.QuoteImages)
                .HasForeignKey(ci => ci.ImageId);
            builder.Entity<QuoteImage>()
                .HasOne(ci => ci.Quote)
                .WithMany(i => i.Images)
                .HasForeignKey(ci => ci.QuoteId);
        }

        private static void BuildQuoteAuditTrails(ModelBuilder builder)
        {
            builder.Entity<QuoteAuditTrail>()
                .HasOne(q => q.Quote)
                .WithMany(q => q.AuditTrails)
                .HasForeignKey(q => q.QuoteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
