using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class AddModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNum",
                table: "Hotels",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Hotels",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Air Conditioner" },
                    { 2, "Multiple Bedrooms " },
                    { 3, "VIP bed" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNum" },
                values: new object[,]
                {
                    { 1, "Irbid,Jordan", "Irbid", "Masadeh", "12536748" },
                    { 2, "Amman,Jordan", "Amman", "Ahmad", "7596454" },
                    { 3, "Alhuson,Jordan", "Alhuson", "Osama", "3157569" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "layout" },
                values: new object[,]
                {
                    { 1, "Sleeping Room", "1" },
                    { 2, "View Room", "6" },
                    { 3, "Top Room", "4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                table: "Hotels",
                newName: "phoneNum");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Hotels",
                newName: "address");
        }
    }
}
