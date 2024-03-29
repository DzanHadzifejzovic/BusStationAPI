using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class change_delete_behavior_for_BusLineUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLinesUsers_AspNetUsers_UserId",
                table: "BusLinesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLinesUsers_BusLines_BusLineId",
                table: "BusLinesUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2861feb8-32d9-43dc-995f-5ac0d5cdae99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332c3111-b722-41d8-a542-2b7ff95c983c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85bcd439-8996-42fe-9405-51e35a24980c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91fae521-8e8d-44db-ad08-f16047cccc3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff696d3-3500-40b3-bbc5-61e84dd33716");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40352c89-4183-4c86-a49e-9dd10c5dc2df", "ee87fc39-09fa-41b1-b999-0be839dad2d1", "Conductor", "CONDUCTOR" },
                    { "44a3fe7c-5ce1-4f4d-a87f-a1323efeccc6", "fde796da-4413-4bef-84c0-a58864ee3d37", "Buyer", "BUYER" },
                    { "9e26bba7-25c0-441c-9e94-c1e4687884b4", "ac2581c4-39b7-4be0-88d5-11f533ce8277", "Admin", "ADMIN" },
                    { "de0e4650-cc1a-49a5-ba44-621b55ec7546", "84fb0aa3-048b-4c53-8063-41e487da22cb", "Driver", "DRIVER" },
                    { "fdb55b2d-6474-41e5-a642-e463447edc4e", "4d9b3ad6-0145-405d-8a9c-590a056087a4", "CounterWorker", "COUNTERWORKER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusLinesUsers_AspNetUsers_UserId",
                table: "BusLinesUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLinesUsers_BusLines_BusLineId",
                table: "BusLinesUsers",
                column: "BusLineId",
                principalTable: "BusLines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLinesUsers_AspNetUsers_UserId",
                table: "BusLinesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLinesUsers_BusLines_BusLineId",
                table: "BusLinesUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40352c89-4183-4c86-a49e-9dd10c5dc2df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a3fe7c-5ce1-4f4d-a87f-a1323efeccc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e26bba7-25c0-441c-9e94-c1e4687884b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0e4650-cc1a-49a5-ba44-621b55ec7546");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdb55b2d-6474-41e5-a642-e463447edc4e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2861feb8-32d9-43dc-995f-5ac0d5cdae99", "6edf1105-26d2-4dee-be41-b3c5784b6cf8", "Conductor", "CONDUCTOR" },
                    { "332c3111-b722-41d8-a542-2b7ff95c983c", "7a3fff9c-ab8e-4e87-8ad3-971c2c49837d", "Admin", "ADMIN" },
                    { "85bcd439-8996-42fe-9405-51e35a24980c", "cf7a7bc1-ac21-4451-9a9e-633000cb6978", "CounterWorker", "COUNTERWORKER" },
                    { "91fae521-8e8d-44db-ad08-f16047cccc3b", "9cc78ad7-6571-4922-862a-6f47647d4c19", "Driver", "DRIVER" },
                    { "eff696d3-3500-40b3-bbc5-61e84dd33716", "0cc185a2-0637-4b33-87ed-ac358a7371d4", "Buyer", "BUYER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusLinesUsers_AspNetUsers_UserId",
                table: "BusLinesUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusLinesUsers_BusLines_BusLineId",
                table: "BusLinesUsers",
                column: "BusLineId",
                principalTable: "BusLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
