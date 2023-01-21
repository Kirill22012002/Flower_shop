using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_shop.Migrations
{
    public partial class AddAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notification_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    operation_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datetime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    withdraw_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sha1_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codepro = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
