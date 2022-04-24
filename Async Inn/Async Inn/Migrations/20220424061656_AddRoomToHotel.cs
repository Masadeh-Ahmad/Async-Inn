using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class AddRoomToHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomNum = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => new { x.HotelId, x.RoomNum });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoom");
        }
    }
}
