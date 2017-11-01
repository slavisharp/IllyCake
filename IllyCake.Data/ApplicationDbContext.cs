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

        public DbSet<BlogPostState> BlogPostStates { get; set; }

        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }

        public DbSet<ImageFile> ImageFiles { get; set; }

        public DbSet<HomePage> HomePages { get; set; }

        public DbSet<ImageFile> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderAuditTrail> OrderAuditTrails { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Paragraph> Paragraphs { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<QuoteAuditTrail> QuoteAuditTrails { get; set; }

        public DbSet<QuoteComment> QuoteComments { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Application User
            BuildApplicationUser(builder);

            // Product
            BuildProduct(builder);

            // Quote Images
            BuilQuoteImages(builder);

            // Quote Audit Trail
            BuildQuoteAuditTrails(builder);

            // Shopping Cart
            BuildShoppingCart(builder);

            // Order Audit Trail
            BuildOrderAuditTrails(builder);
        }

        #region Save Changes
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
        #endregion

        private static void BuildApplicationUser(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.IsDeleted);
        }

        private static void BuildProduct(ModelBuilder builder)
        {
            builder.Entity<ProductImage>()
                .HasKey(ci => new { ci.ProductId, ci.ImageId });
            builder.Entity<ProductImage>()
                .HasOne(ci => ci.Image)
                .WithMany(i => i.ProductImages)
                .HasForeignKey(ci => ci.ImageId);
            builder.Entity<ProductImage>()
                .HasOne(ci => ci.Product)
                .WithMany(i => i.Images)
                .HasForeignKey(ci => ci.ProductId);

            builder.Entity<ProductDiscountCoupon>()
                .HasKey(ci => new { ci.ProductId, ci.DiscountCouponId });
            builder.Entity<ProductDiscountCoupon>()
                .HasOne(ci => ci.DiscountCoupon)
                .WithMany(i => i.Products)
                .HasForeignKey(ci => ci.DiscountCouponId);
            builder.Entity<ProductDiscountCoupon>()
                .HasOne(ci => ci.Product)
                .WithMany(i => i.DiscountCoupons)
                .HasForeignKey(ci => ci.ProductId);

            builder.Entity<Product>()
                .HasOne(q => q.ThumbImage)
                .WithMany(q => q.ProductThumbImages)
                .HasForeignKey(q => q.ThumbImageId)
                .OnDelete(DeleteBehavior.Restrict);
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

        private static void BuildOrderAuditTrails(ModelBuilder builder)
        {
            builder.Entity<OrderAuditTrail>()
                .HasOne(o => o.Order)
                .WithMany(o => o.AuditTrails)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void BuildShoppingCart(ModelBuilder builder)
        {
            builder.Entity<ShoppingCart>()
                .HasIndex(s => s.SessionKey)
                .IsUnique(true);
        }
    }
}
