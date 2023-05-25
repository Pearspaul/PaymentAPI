using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentAPI.Migrations
{
    public partial class PaymentTableEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantID",
                table: "payments");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "payments",
                newName: "SenderEmail");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverAccountNumber",
                table: "payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderAccountNumber",
                table: "payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverAccountNumber",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "SenderAccountNumber",
                table: "payments");

            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "payments",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "MerchantID",
                table: "payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
