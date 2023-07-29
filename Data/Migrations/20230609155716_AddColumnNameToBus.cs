using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddColumnNameToBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39673c86-1fce-4e38-92f7-f7b8c2b17a83", "bc3e0b55-63f7-484d-83e6-6815355a3e40", "Conductor", "CONDUCTOR" },
                    { "498c3935-6725-4a80-80cf-312981f5ad7d", "c218848a-b769-4a98-868e-4f602b4e19a1", "Buyer", "BUYER" },
                    { "79be0067-3022-4c24-98cb-4e501e8f5319", "949b91b7-6db7-4fa0-9f64-f96790f06ecb", "Admin", "ADMIN" },
                    { "a8e9db93-401a-44fd-916c-8ead20a8829b", "07356600-feac-428a-a1e9-d36c13d6acd6", "CounterWorker", "COUNTERWORKER" },
                    { "c0e5b066-d150-426e-ac1a-464236acc7a3", "36b84d23-5046-448a-bf99-e1a018387c44", "Driver", "DRIVER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39673c86-1fce-4e38-92f7-f7b8c2b17a83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "498c3935-6725-4a80-80cf-312981f5ad7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79be0067-3022-4c24-98cb-4e501e8f5319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e9db93-401a-44fd-916c-8ead20a8829b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e5b066-d150-426e-ac1a-464236acc7a3");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buses");

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
    }
}
