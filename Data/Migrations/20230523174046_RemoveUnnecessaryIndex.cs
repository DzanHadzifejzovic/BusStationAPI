using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveUnnecessaryIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId1",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_ConductorId1",
                table: "BusLines");

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
                name: "ConductorId1",
                table: "BusLines");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "IX_BusLines_ConductorId",
                table: "BusLines",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines",
                column: "ConductorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_ConductorId",
                table: "BusLines");

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

            migrationBuilder.AlterColumn<int>(
                name: "ConductorId",
                table: "BusLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ConductorId1",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_BusLines_ConductorId1",
                table: "BusLines",
                column: "ConductorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId1",
                table: "BusLines",
                column: "ConductorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
