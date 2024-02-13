using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class FixingDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_Contact_ContactId",
                table: "ApplicationUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_Contact_ContactId1",
                table: "ApplicationUserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "ApplicationUserContact",
                newName: "ApplicationUsersContacts");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContact_ContactId1",
                table: "ApplicationUsersContacts",
                newName: "IX_ApplicationUsersContacts_ContactId1");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContact_ContactId",
                table: "ApplicationUsersContacts",
                newName: "IX_ApplicationUsersContacts_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContact_ApplicationUserId1",
                table: "ApplicationUsersContacts",
                newName: "IX_ApplicationUsersContacts_ApplicationUserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersContacts",
                table: "ApplicationUsersContacts",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersContacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUsersContacts",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersContacts_Contacts_ContactId",
                table: "ApplicationUsersContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersContacts_Contacts_ContactId1",
                table: "ApplicationUsersContacts",
                column: "ContactId1",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersContacts_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUsersContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersContacts_Contacts_ContactId",
                table: "ApplicationUsersContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersContacts_Contacts_ContactId1",
                table: "ApplicationUsersContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersContacts",
                table: "ApplicationUsersContacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "ApplicationUsersContacts",
                newName: "ApplicationUserContact");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersContacts_ContactId1",
                table: "ApplicationUserContact",
                newName: "IX_ApplicationUserContact_ContactId1");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersContacts_ContactId",
                table: "ApplicationUserContact",
                newName: "IX_ApplicationUserContact_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersContacts_ApplicationUserId1",
                table: "ApplicationUserContact",
                newName: "IX_ApplicationUserContact_ApplicationUserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUserContact",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_Contact_ContactId",
                table: "ApplicationUserContact",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_Contact_ContactId1",
                table: "ApplicationUserContact",
                column: "ContactId1",
                principalTable: "Contact",
                principalColumn: "Id");
        }
    }
}
