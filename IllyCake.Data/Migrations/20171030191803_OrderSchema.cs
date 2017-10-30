using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IllyCake.Web.Data.Migrations
{
    public partial class OrderSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ImageFiles_TumbImageId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomePage_ImageFiles_MainImageId",
                table: "HomePage");

            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_ImageFiles_ImageId",
                table: "Paragraphs");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteImage_ImageFiles_ImageId",
                table: "QuoteImage");

            migrationBuilder.DropTable(
                name: "CakeImages");

            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFiles",
                table: "ImageFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePage",
                table: "HomePage");

            migrationBuilder.DropIndex(
                name: "IX_HomePage_MainImageId",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "HomePage");

            migrationBuilder.RenameTable(
                name: "ImageFiles",
                newName: "ImageFile");

            migrationBuilder.RenameTable(
                name: "HomePage",
                newName: "HomePages");

            migrationBuilder.AddColumn<int>(
                name: "BackgroundImageId",
                table: "HomePages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomePage",
                table: "BlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFile",
                table: "ImageFile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePages",
                table: "HomePages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogPostStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogPostId = table.Column<int>(type: "int", nullable: false),
                    BlogPostId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateSet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostStates_BlogPosts_BlogPostId1",
                        column: x => x.BlogPostId1,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrivateNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalItemsPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalOrderPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuoteComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuiteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuoteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteComments_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SessionKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAuditTrails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAuditTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAuditTrails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderAuditTrails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ShowOnHomePage = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    OrderId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ProductImages_ImageFile_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomePages_BackgroundImageId",
                table: "HomePages",
                column: "BackgroundImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostStates_BlogPostId1",
                table: "BlogPostStates",
                column: "BlogPostId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAuditTrails_OrderId",
                table: "OrderAuditTrails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAuditTrails_UserId",
                table: "OrderAuditTrails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShoppingCartId",
                table: "OrderItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageId",
                table: "ProductImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteComments_QuoteId",
                table: "QuoteComments",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_SessionKey",
                table: "ShoppingCarts",
                column: "SessionKey",
                unique: true,
                filter: "[SessionKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ImageFile_TumbImageId",
                table: "BlogPosts",
                column: "TumbImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomePages_ImageFile_BackgroundImageId",
                table: "HomePages",
                column: "BackgroundImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_ImageFile_ImageId",
                table: "Paragraphs",
                column: "ImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteImage_ImageFile_ImageId",
                table: "QuoteImage",
                column: "ImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ImageFile_TumbImageId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomePages_ImageFile_BackgroundImageId",
                table: "HomePages");

            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_ImageFile_ImageId",
                table: "Paragraphs");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteImage_ImageFile_ImageId",
                table: "QuoteImage");

            migrationBuilder.DropTable(
                name: "BlogPostStates");

            migrationBuilder.DropTable(
                name: "OrderAuditTrails");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "QuoteComments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFile",
                table: "ImageFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePages",
                table: "HomePages");

            migrationBuilder.DropIndex(
                name: "IX_HomePages_BackgroundImageId",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "BackgroundImageId",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShowOnHomePage",
                table: "BlogPosts");

            migrationBuilder.RenameTable(
                name: "ImageFile",
                newName: "ImageFiles");

            migrationBuilder.RenameTable(
                name: "HomePages",
                newName: "HomePage");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "HomePage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HomePage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MainImageId",
                table: "HomePage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "HomePage",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HomePage",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFiles",
                table: "ImageFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePage",
                table: "HomePage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CakeImages",
                columns: table => new
                {
                    CakeId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CakeImages", x => new { x.CakeId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_CakeImages_Cakes_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CakeImages_ImageFiles_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomePage_MainImageId",
                table: "HomePage",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CakeImages_ImageId",
                table: "CakeImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ImageFiles_TumbImageId",
                table: "BlogPosts",
                column: "TumbImageId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomePage_ImageFiles_MainImageId",
                table: "HomePage",
                column: "MainImageId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_ImageFiles_ImageId",
                table: "Paragraphs",
                column: "ImageId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteImage_ImageFiles_ImageId",
                table: "QuoteImage",
                column: "ImageId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
