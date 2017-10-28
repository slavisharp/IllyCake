using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IllyCake.Web.Data.Migrations
{
    public partial class BlogPostState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "QuoteAuditTrails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Paragraphs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuidName",
                table: "ImageFiles",
                type: "nvarchar(127)",
                maxLength: 127,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LastState",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "BlogPosts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyWords",
                table: "BlogPosts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "BlogPosts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuoteImage",
                columns: table => new
                {
                    QuoteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteImage", x => new { x.QuoteId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_QuoteImage_ImageFiles_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteImage_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteImage_ImageId",
                table: "QuoteImage",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteImage");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "GuidName",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "LastState",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "MetaKeyWords",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "QuoteAuditTrails",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
