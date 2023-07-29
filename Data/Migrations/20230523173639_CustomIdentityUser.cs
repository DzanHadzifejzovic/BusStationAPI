using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class CustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId1",
                table: "BusLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId1",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_DriverId1",
                table: "BusLines");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b40c4a1-bc1d-47df-a384-abb0d13e987d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f44f322-49b3-42cb-9999-11259452c46f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85af631a-b121-43c9-9c59-58c50ce2b80e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92131369-8c4e-4aa4-b2fd-43570f620af0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96ed2e58-4a69-4155-9bb5-7c5f340adaff");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "BusLines");

            migrationBuilder.DropColumn(
                name: "DriverId1",
                table: "BusLines");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Admin_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Admin_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Buyer_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Buyer_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Conductor_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Conductor_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CounterWorker_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CounterWorker_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId1",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DrivingCondition",
                table: "Buses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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
                    { "471b0f23-58ce-4dfe-895f-0cf111cb931a", "88d2c013-97b5-42cc-9e58-5e4b4b84e8b6", "Conductor", "CONDUCTOR" },
                    { "49b018ce-631d-4caa-8ca2-b651ac3325f7", "08049a92-6c63-4cca-921b-b1098f055913", "Buyer", "BUYER" },
                    { "918299ab-eb4a-42f6-9d77-10a1481eeccb", "346dc42b-88a5-440d-8808-745b8f3e9a08", "Driver", "DRIVER" },
                    { "b3e7aee9-ac3d-4d1b-9211-b29b01bc4410", "e4a15684-6f43-4c47-a29e-84033d78d274", "Admin", "ADMIN" },
                    { "bc6acb0e-8bf0-45be-9109-3a7d9bccbd9e", "43ac46e4-9d1b-4fab-86bd-f1c8b85e3abc", "CounterWorker", "COUNTERWORKER" }
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
                name: "FK_BusLines_AspNetUsers_ConductorId1",
                table: "BusLines",
                column: "ConductorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BusLines_BusLineId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId1",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BusLineId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471b0f23-58ce-4dfe-895f-0cf111cb931a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49b018ce-631d-4caa-8ca2-b651ac3325f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "918299ab-eb4a-42f6-9d77-10a1481eeccb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e7aee9-ac3d-4d1b-9211-b29b01bc4410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc6acb0e-8bf0-45be-9109-3a7d9bccbd9e");

            migrationBuilder.DropColumn(
                name: "DrivingCondition",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BusLineId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId1",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "BusLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DriverId1",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conductor_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conductor_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CounterWorker_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CounterWorker_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b40c4a1-bc1d-47df-a384-abb0d13e987d", "b784eaec-0cf7-4c6a-bfce-fd1dedfa767f", "CounterWorker", "COUNTERWORKER" },
                    { "4f44f322-49b3-42cb-9999-11259452c46f", "96e14a23-b866-46ba-badf-e23510b7c6e4", "Driver", "DRIVER" },
                    { "85af631a-b121-43c9-9c59-58c50ce2b80e", "0a304860-22c3-46b6-8c55-af26b9750cce", "Buyer", "BUYER" },
                    { "92131369-8c4e-4aa4-b2fd-43570f620af0", "d30feae1-063d-4290-9338-72445a07a72f", "Conductor", "CONDUCTOR" },
                    { "96ed2e58-4a69-4155-9bb5-7c5f340adaff", "f047aeba-e22e-4fde-80b3-3ad2f0a6ed82", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLines_DriverId1",
                table: "BusLines",
                column: "DriverId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId1",
                table: "BusLines",
                column: "ConductorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId1",
                table: "BusLines",
                column: "DriverId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
