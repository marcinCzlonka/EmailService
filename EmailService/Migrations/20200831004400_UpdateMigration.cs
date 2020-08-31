using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailService.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Emails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EmailAddresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AttachmentId",
                table: "Emails",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Attachments_AttachmentId",
                table: "Emails",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Attachments_AttachmentId",
                table: "Emails");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Emails_AttachmentId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmailAddresses");
        }
    }
}
