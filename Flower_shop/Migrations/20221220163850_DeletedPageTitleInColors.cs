using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_shop.Migrations
{
    public partial class DeletedPageTitleInColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "Colors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
