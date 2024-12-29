using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafraCoin.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraints2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investors_Users_Id",
                table: "Investors");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Investors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Investors_UserId",
                table: "Investors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investors_Users_UserId",
                table: "Investors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investors_Users_UserId",
                table: "Investors");

            migrationBuilder.DropIndex(
                name: "IX_Investors_UserId",
                table: "Investors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Investors");

            migrationBuilder.AddForeignKey(
                name: "FK_Investors_Users_Id",
                table: "Investors",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
