using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IllyCake.Web.Data.Migrations
{
    public partial class ProductSku : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "Products",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Alias",
                table: "Products",
                column: "Alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SKUCode",
                table: "Products",
                column: "SKUCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Alias",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SKUCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "Products");
        }
    }
}
