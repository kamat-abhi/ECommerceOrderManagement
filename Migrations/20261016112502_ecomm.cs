using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneTOMany.Migrations
{
    /// <inheritdoc />
    public partial class ecomm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Order",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics", "Electronic devices and accessories" },
                    { 2, "Clothing", "Clothing and fashion products" },
                    { 3, "Books", "Educational and programming books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "IsActive", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "High-performance laptop", "https://images.unsplash.com/photo-1496181133206-80ce9b88a853", true, 50000m, "Laptop", 0 },
                    { 2, 1, "Smartphone with modern features", "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9", true, 20000m, "Mobile", 0 },
                    { 3, 1, "USB computer keyboard", "https://images.unsplash.com/photo-1587829741301-dc798b83add3", true, 1500m, "Keyboard", 0 },
                    { 4, 1, "Wireless computer mouse", "https://images.unsplash.com/photo-1527814050087-3793815479db", true, 500m, "Mouse", 0 },
                    { 5, 1, "Over-ear audio headphones", "https://images.unsplash.com/photo-1505740420928-5e560c06d30e", true, 2500m, "Headphones", 0 },
                    { 6, 2, "Cotton casual T-shirt", "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab", true, 800m, "T-Shirt", 0 },
                    { 7, 2, "Denim jeans for everyday wear", "https://images.unsplash.com/photo-1542272604-787c3835535d", true, 1800m, "Jeans", 0 },
                    { 8, 3, "Learn C# programming fundamentals", "https://images.unsplash.com/photo-1532012197267-da84d127e765", true, 600m, "C# Programming", 0 },
                    { 9, 3, "Guide to ASP.NET Core development", "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c", true, 750m, "ASP.NET Core", 0 },
                    { 10, 3, "Learn SQL Server and database management", "https://images.unsplash.com/photo-1507842217343-583bb7270b66", true, 500m, "SQL Server Guide", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");
        }
    }
}
