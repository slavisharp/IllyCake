﻿// <auto-generated />
using IllyCake.Data;
using IllyCake.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IllyCake.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171228155648_ProductAlias")]
    partial class ProductAlias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IllyCake.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUsedInOrder");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Line2")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000);

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ApplicationUserAddress", b =>
                {
                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("AddressId");

                    b.HasKey("ApplicationUserId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("ApplicationUserAddresses");
                });

            modelBuilder.Entity("IllyCake.Data.Models.BlogPost", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("EmbedetVideo")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastState");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(160);

                    b.Property<string>("MetaKeyWords")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<bool>("ShowOnHomePage");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("ThumbImageId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.HasIndex("ThumbImageId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("IllyCake.Data.Models.BlogPostState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostId");

                    b.Property<string>("BlogPostId1");

                    b.Property<DateTime>("DateSet");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId1");

                    b.ToTable("BlogPostStates");
                });

            modelBuilder.Entity("IllyCake.Data.Models.DiscountCoupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Created");

                    b.Property<int>("DiscountPercentage");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DiscountCoupons");
                });

            modelBuilder.Entity("IllyCake.Data.Models.HomePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BackgroundImageId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundImageId");

                    b.ToTable("HomePages");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Extension")
                        .HasMaxLength(127);

                    b.Property<string>("GuidName")
                        .IsRequired()
                        .HasMaxLength(127);

                    b.Property<string>("MimeType")
                        .HasMaxLength(127);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UploadedDate");

                    b.HasKey("Id");

                    b.ToTable("ImageFile");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DateCompleted");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<int?>("DiscountCouponId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<string>("PrivateNotes")
                        .HasMaxLength(2000);

                    b.Property<decimal>("ShippingPrice");

                    b.Property<int>("Status");

                    b.Property<decimal>("TotalItemsPrice");

                    b.Property<decimal>("TotalOrderPrice");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("DiscountCouponId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("IllyCake.Data.Models.OrderAuditTrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionDate");

                    b.Property<int>("ActionType");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("OrderId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderAuditTrails");
                });

            modelBuilder.Entity("IllyCake.Data.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("DiscountAmmunt");

                    b.Property<decimal>("FinalPrice");

                    b.Property<DateTime?>("Modified");

                    b.Property<int?>("OrderId");

                    b.Property<string>("OrderId1");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100);

                    b.Property<int>("Quantity");

                    b.Property<int?>("ShoppingCartId");

                    b.Property<decimal>("Subtotal");

                    b.HasKey("Id");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogPostId")
                        .IsRequired();

                    b.Property<string>("CssClassList")
                        .HasMaxLength(100);

                    b.Property<string>("EmbedVideoHtml")
                        .HasMaxLength(1000);

                    b.Property<int?>("ImageId");

                    b.Property<int>("Position");

                    b.Property<int>("SpecialContentPosition");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("ImageId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(160);

                    b.Property<string>("MetaKeyWords")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<bool>("ShowOnHomePage");

                    b.Property<int>("ThumbImageId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ThumbImageId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Position");

                    b.Property<bool>("ShowOnHomePage");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductDiscountCoupon", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("DiscountCouponId");

                    b.HasKey("ProductId", "DiscountCouponId");

                    b.HasIndex("DiscountCouponId");

                    b.ToTable("ProductDiscountCoupon");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductImage", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ImageId");

                    b.HasKey("ProductId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVersions");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Quote", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DateCompleted");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<decimal?>("Price");

                    b.Property<string>("PrivateNotes");

                    b.Property<int>("Status");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("IllyCake.Data.Models.QuoteAuditTrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionDate");

                    b.Property<int>("ActionType");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("QuoteId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("QuoteId");

                    b.HasIndex("UserId");

                    b.ToTable("QuoteAuditTrails");
                });

            modelBuilder.Entity("IllyCake.Data.Models.QuoteComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("QuiteId")
                        .IsRequired();

                    b.Property<string>("QuoteId");

                    b.HasKey("Id");

                    b.HasIndex("QuoteId");

                    b.ToTable("QuoteComments");
                });

            modelBuilder.Entity("IllyCake.Data.Models.QuoteImage", b =>
                {
                    b.Property<string>("QuoteId");

                    b.Property<int>("ImageId");

                    b.HasKey("QuoteId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("QuoteImage");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SessionKey")
                        .HasMaxLength(50);

                    b.Property<decimal>("TotalAmount");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SessionKey")
                        .IsUnique()
                        .HasFilter("[SessionKey] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IllyCake.Data.Models.ApplicationUserAddress", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Addresses")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.BlogPost", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ImageFile", "ThumbImage")
                        .WithMany("BlogPosts")
                        .HasForeignKey("ThumbImageId");

                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany("BlogPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.BlogPostState", b =>
                {
                    b.HasOne("IllyCake.Data.Models.BlogPost", "BlogPost")
                        .WithMany()
                        .HasForeignKey("BlogPostId1");
                });

            modelBuilder.Entity("IllyCake.Data.Models.HomePage", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ImageFile", "BackgroundImage")
                        .WithMany("HomePages")
                        .HasForeignKey("BackgroundImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.Order", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.DiscountCoupon", "DiscountCoupon")
                        .WithMany("Orders")
                        .HasForeignKey("DiscountCouponId");

                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.OrderAuditTrail", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Order", "Order")
                        .WithMany("AuditTrails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.OrderItem", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId1");

                    b.HasOne("IllyCake.Data.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ShoppingCart", "GetShoppingCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Paragraph", b =>
                {
                    b.HasOne("IllyCake.Data.Models.BlogPost", "BlogPost")
                        .WithMany()
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ImageFile", "Image")
                        .WithMany("Paragraphs")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Product", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ImageFile", "ThumbImage")
                        .WithMany("ProductThumbImages")
                        .HasForeignKey("ThumbImageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductDiscountCoupon", b =>
                {
                    b.HasOne("IllyCake.Data.Models.DiscountCoupon", "DiscountCoupon")
                        .WithMany("Products")
                        .HasForeignKey("DiscountCouponId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.Product", "Product")
                        .WithMany("DiscountCoupons")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductImage", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ImageFile", "Image")
                        .WithMany("ProductImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.ProductVersion", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Product", "Product")
                        .WithMany("ProductVersions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.Quote", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany("Quotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.QuoteAuditTrail", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Quote", "Quote")
                        .WithMany("AuditTrails")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.QuoteComment", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Quote", "Quote")
                        .WithMany()
                        .HasForeignKey("QuoteId");
                });

            modelBuilder.Entity("IllyCake.Data.Models.QuoteImage", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ImageFile", "Image")
                        .WithMany("QuoteImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.Quote", "Quote")
                        .WithMany("Images")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.ShoppingCart", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
