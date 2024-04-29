using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spacesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Room_Add_ClientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Room");
        }
    }
}
