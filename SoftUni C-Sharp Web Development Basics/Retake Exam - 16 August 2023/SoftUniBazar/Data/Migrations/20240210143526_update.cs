using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniBazar.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdBuyer_Ads_AdId",
                table: "AdBuyer");

            migrationBuilder.DropForeignKey(
                name: "FK_AdBuyer_AspNetUsers_BuyerId",
                table: "AdBuyer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdBuyer",
                table: "AdBuyer");

            migrationBuilder.RenameTable(
                name: "AdBuyer",
                newName: "AdsBuyers");

            migrationBuilder.RenameIndex(
                name: "IX_AdBuyer_AdId",
                table: "AdsBuyers",
                newName: "IX_AdsBuyers_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdsBuyers",
                table: "AdsBuyers",
                columns: new[] { "BuyerId", "AdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdsBuyers_Ads_AdId",
                table: "AdsBuyers",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdsBuyers_AspNetUsers_BuyerId",
                table: "AdsBuyers",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsBuyers_Ads_AdId",
                table: "AdsBuyers");

            migrationBuilder.DropForeignKey(
                name: "FK_AdsBuyers_AspNetUsers_BuyerId",
                table: "AdsBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdsBuyers",
                table: "AdsBuyers");

            migrationBuilder.RenameTable(
                name: "AdsBuyers",
                newName: "AdBuyer");

            migrationBuilder.RenameIndex(
                name: "IX_AdsBuyers_AdId",
                table: "AdBuyer",
                newName: "IX_AdBuyer_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdBuyer",
                table: "AdBuyer",
                columns: new[] { "BuyerId", "AdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdBuyer_Ads_AdId",
                table: "AdBuyer",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdBuyer_AspNetUsers_BuyerId",
                table: "AdBuyer",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
