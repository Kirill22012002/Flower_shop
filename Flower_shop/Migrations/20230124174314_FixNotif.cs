using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_shop.Migrations
{
    public partial class FixNotif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test",
                table: "Notifications",
                newName: "ThreeDSecureMethodCompleted");

            migrationBuilder.RenameColumn(
                name: "Paid",
                table: "Notifications",
                newName: "ThreeDSecureChallengeCompleted");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizationAuthCode",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorizationDetailsRrn",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCardExpiryMonth",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCardExpiryYear",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCardFirst6",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCardLast4",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCardType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIssuerCountry",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodTitle",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentPaid",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentRefundable",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentTest",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ThreeDSecureApplied",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorizationAuthCode",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AuthorizationDetailsRrn",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentCardExpiryMonth",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentCardExpiryYear",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentCardFirst6",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentCardLast4",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentCardType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentIssuerCountry",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentMethodTitle",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentPaid",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentRefundable",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentTest",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ThreeDSecureApplied",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "ThreeDSecureMethodCompleted",
                table: "Notifications",
                newName: "Test");

            migrationBuilder.RenameColumn(
                name: "ThreeDSecureChallengeCompleted",
                table: "Notifications",
                newName: "Paid");
        }
    }
}
