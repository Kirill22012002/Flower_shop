using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_shop.Migrations
{
    public partial class FixAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "codepro",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "datetime",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "label",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "notification_type",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "operation_id",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "sender",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "withdraw_amount",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "sha1_hash",
                table: "Answers",
                newName: "Json");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Json",
                table: "Answers",
                newName: "sha1_hash");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "Answers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "codepro",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "datetime",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "label",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notification_type",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "operation_id",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sender",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "withdraw_amount",
                table: "Answers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
