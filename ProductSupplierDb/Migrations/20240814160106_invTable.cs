using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSupplierDb.Migrations
{
    /// <inheritdoc />
    public partial class invTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InventoryId",
                table: "Transactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_InventoryId",
                table: "Suppliers",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryId",
                table: "Products",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventories_InventoryId",
                table: "Products",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Inventories_InventoryId",
                table: "Suppliers",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Inventories_InventoryId",
                table: "Transactions",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventories_InventoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Inventories_InventoryId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Inventories_InventoryId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_InventoryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_InventoryId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Products");
        }
    }
}
