#nullable disable

namespace Flower_shop.Migrations
{
    public partial class AddSibtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Images",
                newName: "Name");
        }
    }
}
