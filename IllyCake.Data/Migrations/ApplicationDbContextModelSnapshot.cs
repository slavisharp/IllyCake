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
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<bool>("IsDeleted");

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

            modelBuilder.Entity("IllyCake.Data.Models.BlogPost", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastState");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(150);

                    b.Property<string>("MetaKeyWords")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TumbImageId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("VideoUrl")
                        .HasMaxLength(1000);

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("TumbImageId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Cake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Cakes");
                });

            modelBuilder.Entity("IllyCake.Data.Models.CakeImage", b =>
                {
                    b.Property<int>("CakeId");

                    b.Property<int>("ImageId");

                    b.HasKey("CakeId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("CakeImages");
                });

            modelBuilder.Entity("IllyCake.Data.Models.HomePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MainImageId");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("MainImageId");

                    b.ToTable("HomePage");
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

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("IllyCake.Data.Models.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogPostId")
                        .IsRequired();

                    b.Property<int?>("ImageId");

                    b.Property<int>("Position");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("VideoUrl")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("ImageId");

                    b.ToTable("Paragraphs");
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

            modelBuilder.Entity("IllyCake.Data.Models.QuoteImage", b =>
                {
                    b.Property<string>("QuoteId");

                    b.Property<int>("ImageId");

                    b.HasKey("QuoteId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("QuoteImage");
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

            modelBuilder.Entity("IllyCake.Data.Models.BlogPost", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ImageFile", "TumbImage")
                        .WithMany("BlogPosts")
                        .HasForeignKey("TumbImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ApplicationUser", "User")
                        .WithMany("BlogPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.CakeImage", b =>
                {
                    b.HasOne("IllyCake.Data.Models.Cake", "Cake")
                        .WithMany("Images")
                        .HasForeignKey("CakeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IllyCake.Data.Models.ImageFile", "Image")
                        .WithMany("CakeImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IllyCake.Data.Models.HomePage", b =>
                {
                    b.HasOne("IllyCake.Data.Models.ImageFile", "MainImage")
                        .WithMany("HomePages")
                        .HasForeignKey("MainImageId")
                        .OnDelete(DeleteBehavior.Cascade);
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
