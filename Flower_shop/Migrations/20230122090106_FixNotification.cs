using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_shop.Migrations
{
    public partial class FixNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationStr",
                table: "Notifications",
                newName: "RefundedAmountValue");

            migrationBuilder.AddColumn<string>(
                name: "AmountCurrency",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountValue",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapturedAt",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeAmountCurrency",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeAmountValue",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentEvent",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentMethodSaved",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientAccountId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientGatewayId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefundedAmountCurrency",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Test",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountCurrency",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AmountValue",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CapturedAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IncomeAmountCurrency",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IncomeAmountValue",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentEvent",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentMethodSaved",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentMethodType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RecipientAccountId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RecipientGatewayId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RefundedAmountCurrency",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "RefundedAmountValue",
                table: "Notifications",
                newName: "NotificationStr");
        }
    }
}
