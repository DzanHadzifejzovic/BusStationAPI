using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "113c7381-da8a-453a-8be7-1f6c504bf387");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ccd65f8-5ec0-48b4-8543-dfb495c5755a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ebd5cf4-7076-4036-b14f-e9cedc6b245a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0576d00-ef92-40b8-869e-390aede04360");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb768a0b-8e82-43bb-bc68-f52a9c774e38");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "113c7381-da8a-453a-8be7-1f6c504bf387", "dacd45da-e134-4269-b930-e49f18cd83c4", "Conductor", "CONDUCTOR" },
                    { "5ccd65f8-5ec0-48b4-8543-dfb495c5755a", "f6444e5d-2cf7-4973-8b4e-682f9302508e", "Buyer", "BUYER" },
                    { "8ebd5cf4-7076-4036-b14f-e9cedc6b245a", "98c81bca-b88f-4936-a15f-c71c5317a19b", "Driver", "DRIVER" },
                    { "c0576d00-ef92-40b8-869e-390aede04360", "78ce790f-a9ae-415d-9a01-9f672091dbd0", "CounterWorker", "COUNTERWORKER" },
                    { "cb768a0b-8e82-43bb-bc68-f52a9c774e38", "389543b0-2d93-4bb7-902a-96d91ba2166e", "Admin", "ADMIN" }
                });
        }
    }
}
