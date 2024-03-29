using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class RemoveBusLineIdInAspNetUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BusLines_BusLineId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BusLineId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca7ff7e-6004-49d1-8bba-3831b7bfb3ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "479f4b0a-2719-490e-9092-210e5dac7af2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b510db1-cdb4-4a21-a91d-385e10476fe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6667e04b-71c2-49d7-9bb1-4cb0adb8cc87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbb16081-0da3-42b1-badb-1f63b86a839d");

            migrationBuilder.DropColumn(
                name: "BusLineId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cbc462f-a4e2-4ab4-a223-bc12111868f8", "214cee2f-e2d0-4f0c-a277-853d95112561", "Admin", "ADMIN" },
                    { "4a28d60f-405a-4c4d-8834-1b0238a35f76", "16944e88-058a-456d-add6-10451da528e5", "Conductor", "CONDUCTOR" },
                    { "967f35ac-1c80-4488-be85-3f9a2fc91180", "2453abe4-d09c-4224-802d-d31db49b9afc", "Driver", "DRIVER" },
                    { "b6f4b741-3da5-4983-bc74-c5e3f287b127", "61d22780-49bd-4a8f-80f2-2c25ff2360ed", "Buyer", "BUYER" },
                    { "d1f0a16f-2b12-4474-a3bf-c3d719325b5b", "f9ecb6a5-5ae4-4aec-8a6b-4a694f47cfd6", "CounterWorker", "COUNTERWORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLines_DriverId",
                table: "BusLines",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines",
                column: "ConductorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
                table: "BusLines",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_DriverId",
                table: "BusLines");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cbc462f-a4e2-4ab4-a223-bc12111868f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a28d60f-405a-4c4d-8834-1b0238a35f76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967f35ac-1c80-4488-be85-3f9a2fc91180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6f4b741-3da5-4983-bc74-c5e3f287b127");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1f0a16f-2b12-4474-a3bf-c3d719325b5b");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "BusLines");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusLineId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ca7ff7e-6004-49d1-8bba-3831b7bfb3ff", "b96b374d-b5ba-4174-8905-d9fd181effde", "Admin", "ADMIN" },
                    { "479f4b0a-2719-490e-9092-210e5dac7af2", "e9ac4eb3-ea90-41dd-9136-a745e94c1ded", "Conductor", "CONDUCTOR" },
                    { "5b510db1-cdb4-4a21-a91d-385e10476fe8", "a281aa5a-89e1-4bd4-933e-cf635bb3785f", "CounterWorker", "COUNTERWORKER" },
                    { "6667e04b-71c2-49d7-9bb1-4cb0adb8cc87", "d62acc23-eacd-4eff-b540-1341e17baaf6", "Driver", "DRIVER" },
                    { "dbb16081-0da3-42b1-badb-1f63b86a839d", "a158e587-36ea-4287-b1f3-62a009a2b73a", "Buyer", "BUYER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusLineId",
                table: "AspNetUsers",
                column: "BusLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BusLines_BusLineId",
                table: "AspNetUsers",
                column: "BusLineId",
                principalTable: "BusLines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines",
                column: "ConductorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
