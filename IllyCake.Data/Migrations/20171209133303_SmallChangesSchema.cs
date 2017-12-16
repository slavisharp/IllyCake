using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IllyCake.Web.Data.Migrations
{
    public partial class SmallChangesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersion_Products_ProductId",
                table: "ProductVersion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVersion",
                table: "ProductVersion");

            migrationBuilder.RenameTable(
                name: "ProductVersion",
                newName: "ProductVersions");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVersion_ProductId",
                table: "ProductVersions",
                newName: "IX_ProductVersions_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVersions",
                table: "ProductVersions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersions_Products_ProductId",
                table: "ProductVersions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersions_Products_ProductId",
                table: "ProductVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVersions",
                table: "ProductVersions");

            migrationBuilder.RenameTable(
                name: "ProductVersions",
                newName: "ProductVersion");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVersions_ProductId",
                table: "ProductVersion",
                newName: "IX_ProductVersion_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVersion",
                table: "ProductVersion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersion_Products_ProductId",
                table: "ProductVersion",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
