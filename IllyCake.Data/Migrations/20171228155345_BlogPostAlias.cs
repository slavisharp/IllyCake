using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IllyCake.Web.Data.Migrations
{
    public partial class BlogPostAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ImageFile_ThumbImageId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "BlogPosts",
                newName: "EmbedetVideo");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Products",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbImageId",
                table: "BlogPosts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "BlogPosts",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Alias",
                table: "BlogPosts",
                column: "Alias",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ImageFile_ThumbImageId",
                table: "BlogPosts",
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

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_Alias",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "EmbedetVideo",
                table: "BlogPosts",
                newName: "VideoUrl");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbImageId",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ImageFile_ThumbImageId",
                table: "BlogPosts",
                column: "ThumbImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
