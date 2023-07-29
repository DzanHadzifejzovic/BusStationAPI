using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddBusLineUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_ConductorId",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_DriverId",
                table: "BusLines");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "080b2956-cb3e-44eb-929e-8bde03b12afc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef8534a-715a-4ddf-a7a1-19ca46b22451");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1073563-d273-4709-9cb0-8736c0d0b1b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1bea13e-0adf-4236-8f5b-083377331f45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b45be30d-a063-4751-a235-b73ef3223674");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "BusLines");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "BusLines");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "BusLinesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLinesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusLinesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusLinesUsers_BusLines_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "BusLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "382f057f-c3d1-4e2b-ac5e-1491fdd90f43", "d60342ac-4435-45e9-afe1-278984fec642", "Driver", "DRIVER" },
                    { "5b9303f7-c218-4934-908f-0da8ff466ecf", "b17a2a18-1354-45f5-b7d6-e1424ac69e91", "Admin", "ADMIN" },
                    { "aad95fb5-e3d0-43e2-acf4-f518fb4b3d1f", "26b26bb6-4739-41ff-a3f1-b0e9b704c853", "CounterWorker", "COUNTERWORKER" },
                    { "c6b6ac85-9e9c-44fb-b8ce-76f80282f2f2", "330d67b7-296f-40af-a54f-fbcfbadba8c5", "Conductor", "CONDUCTOR" },
                    { "dcd1de7c-8447-4e42-94af-52e03b81a48a", "4d273bf7-ab1d-4f49-bb74-6088b2ff849c", "Buyer", "BUYER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLinesUsers_BusLineId",
                table: "BusLinesUsers",
                column: "BusLineId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLinesUsers_UserId",
                table: "BusLinesUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusLinesUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382f057f-c3d1-4e2b-ac5e-1491fdd90f43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9303f7-c218-4934-908f-0da8ff466ecf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aad95fb5-e3d0-43e2-acf4-f518fb4b3d1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b6ac85-9e9c-44fb-b8ce-76f80282f2f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcd1de7c-8447-4e42-94af-52e03b81a48a");

            migrationBuilder.AddColumn<string>(
                name: "ConductorId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "BusLines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "080b2956-cb3e-44eb-929e-8bde03b12afc", "5b2e9095-67b2-4fcc-af9f-2b150eafa220", "Admin", "ADMIN" },
                    { "5ef8534a-715a-4ddf-a7a1-19ca46b22451", "9520c1c7-f9d1-4f68-b514-522e3e360dba", "CounterWorker", "COUNTERWORKER" },
                    { "b1073563-d273-4709-9cb0-8736c0d0b1b8", "e5795d54-edb9-4145-b689-6ee8857177ca", "Conductor", "CONDUCTOR" },
                    { "b1bea13e-0adf-4236-8f5b-083377331f45", "83f0e0a3-e2ed-4cdb-9d33-245933f202f7", "Buyer", "BUYER" },
                    { "b45be30d-a063-4751-a235-b73ef3223674", "7a69b234-10eb-45d5-a2b5-bcbb82fa107a", "Driver", "DRIVER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLines_ConductorId",
                table: "BusLines",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLines_DriverId",
                table: "BusLines",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_ConductorId",
                table: "BusLines",
                column: "ConductorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_AspNetUsers_DriverId",
                table: "BusLines",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
