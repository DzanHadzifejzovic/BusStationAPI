using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class AddColumnsForRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0830fdc2-c8aa-44be-b6c0-fc0daf2f2544", "4dc7d803-5589-469e-af4a-7860f18db385", "Conductor", "CONDUCTOR" },
                    { "7a5e657f-8d96-4735-8efd-65f214c0d81c", "40ad9211-eae2-41ce-b065-15f4bc7be359", "Admin", "ADMIN" },
                    { "a99fc0cd-42fb-44e9-805c-5d1aaa98e924", "f9f31457-ca22-42ca-bb87-35d2a73117fc", "CounterWorker", "COUNTERWORKER" },
                    { "b22be252-4a6a-442d-a611-4f0471f6a74d", "22ed3a8b-3dea-4207-8da9-36d9e2ac4f55", "Driver", "DRIVER" },
                    { "ce048431-a159-4ba6-be94-d806ec33167c", "38887c2e-a568-45c9-8690-2d65de2fb24d", "Buyer", "BUYER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0830fdc2-c8aa-44be-b6c0-fc0daf2f2544");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a5e657f-8d96-4735-8efd-65f214c0d81c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99fc0cd-42fb-44e9-805c-5d1aaa98e924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22be252-4a6a-442d-a611-4f0471f6a74d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce048431-a159-4ba6-be94-d806ec33167c");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
        }
    }
}
