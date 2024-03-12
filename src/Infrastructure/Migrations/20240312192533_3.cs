using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spacesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderGoods_RoomId",
                table: "OrderGoods");

            migrationBuilder.DropIndex(
                name: "IX_OrderGoods_UserId",
                table: "OrderGoods");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGoods_RoomId",
                table: "OrderGoods",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGoods_UserId",
                table: "OrderGoods",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderGoods_RoomId",
                table: "OrderGoods");

            migrationBuilder.DropIndex(
                name: "IX_OrderGoods_UserId",
                table: "OrderGoods");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGoods_RoomId",
                table: "OrderGoods",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderGoods_UserId",
                table: "OrderGoods",
                column: "UserId",
                unique: true);
        }
    }
}
