#nullable disable

namespace Flower_shop.Migrations
{
    public partial class fixProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "TypeProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypesProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProduct", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductId",
                table: "Products",
                column: "TypeProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypesProduct_TypeProductId",
                table: "Products",
                column: "TypeProductId",
                principalTable: "TypesProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypesProduct_TypeProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "TypesProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeProductId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
