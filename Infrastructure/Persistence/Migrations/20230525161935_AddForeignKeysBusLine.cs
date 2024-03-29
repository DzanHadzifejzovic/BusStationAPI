using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class AddForeignKeysBusLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
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

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04661d22-668b-4712-a1e9-4a36e4d2e3ae", "6fb88d71-a6ea-4f49-af1d-6aee5bdee76b", "CounterWorker", "COUNTERWORKER" },
                    { "478bdcaa-ca62-4a1d-868d-aa5d1df3cfe5", "b9f5a477-6868-4c9c-950b-6120f14b65f3", "Conductor", "CONDUCTOR" },
                    { "9a8a660b-9b5f-4b93-8eb7-070ca1a1e9ea", "d6aba9c9-bca6-4892-9a36-f42ba6d8d7f3", "Buyer", "BUYER" },
                    { "b780d4d5-e085-40b3-b123-a1cd102885e6", "09166b51-9e5a-4eb7-832c-0df20a6a66c6", "Admin", "ADMIN" },
                    { "c19c5e6c-1454-400b-b335-ed27b3120855", "ded39bdb-6c8a-49f2-9afc-57479f90d869", "Driver", "DRIVER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines",
                column: "ConductorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
                table: "BusLines",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
                table: "BusLines");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04661d22-668b-4712-a1e9-4a36e4d2e3ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478bdcaa-ca62-4a1d-868d-aa5d1df3cfe5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a8a660b-9b5f-4b93-8eb7-070ca1a1e9ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b780d4d5-e085-40b3-b123-a1cd102885e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c19c5e6c-1454-400b-b335-ed27b3120855");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
