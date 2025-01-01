using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafraCoin.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountAddressColumnOnFarmerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountAddress",
                table: "Farmers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountAddress",
                table: "Farmers");
        }
    }
}
