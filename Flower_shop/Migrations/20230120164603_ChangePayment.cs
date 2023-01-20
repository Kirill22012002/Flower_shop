using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_shop.Migrations
{
    public partial class ChangePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "MyPayments");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MyPayments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "MyPayments");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "MyPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
