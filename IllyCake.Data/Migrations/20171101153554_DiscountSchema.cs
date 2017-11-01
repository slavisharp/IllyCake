using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IllyCake.Web.Data.Migrations
{
    public partial class DiscountSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ImageFile_TumbImageId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_TumbImageId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TumbImageId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<int>(
                name: "ThumbImageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscountCouponId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThumbImageId",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DiscountCoupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCoupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscountCoupon",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DiscountCouponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscountCoupon", x => new { x.ProductId, x.DiscountCouponId });
                    table.ForeignKey(
                        name: "FK_ProductDiscountCoupon_DiscountCoupons_DiscountCouponId",
                        column: x => x.DiscountCouponId,
                        principalTable: "DiscountCoupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDiscountCoupon_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ThumbImageId",
                table: "Products",
                column: "ThumbImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCouponId",
                table: "Orders",
                column: "DiscountCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ThumbImageId",
                table: "BlogPosts",
                column: "ThumbImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountCoupon_DiscountCouponId",
                table: "ProductDiscountCoupon",
                column: "DiscountCouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ImageFile_ThumbImageId",
                table: "BlogPosts",
                column: "ThumbImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiscountCoupons_DiscountCouponId",
                table: "Orders",
                column: "DiscountCouponId",
                principalTable: "DiscountCoupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImageFile_ThumbImageId",
                table: "Products",
                column: "ThumbImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ImageFile_ThumbImageId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiscountCoupons_DiscountCouponId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImageFile_ThumbImageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDiscountCoupon");

            migrationBuilder.DropTable(
                name: "DiscountCoupons");

            migrationBuilder.DropIndex(
                name: "IX_Products_ThumbImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountCouponId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_ThumbImageId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "ThumbImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountCouponId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ThumbImageId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<int>(
                name: "TumbImageId",
                table: "BlogPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_TumbImageId",
                table: "BlogPosts",
                column: "TumbImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ImageFile_TumbImageId",
                table: "BlogPosts",
                column: "TumbImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
