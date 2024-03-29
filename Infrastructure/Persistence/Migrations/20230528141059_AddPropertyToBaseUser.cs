using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class AddPropertyToBaseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

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
        }
    }
}
