using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spacesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonnelSituation",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PowerSupply",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "PersonnelSituation",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "PowerSupply",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Room");
        }
    }
}
