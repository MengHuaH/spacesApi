using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spacesApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderGoods_Add_DurationAndOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "OrderGoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "OrderGoods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "OrderGoods");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "OrderGoods");
        }
    }
}
