using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddNumOfCardsProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "NumberOfReservedCards",
                table: "BusLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3932bc79-306e-4eba-809c-5e66b333ba46", "c57cc1d1-580d-4da6-98c3-84aa367e1284", "Conductor", "CONDUCTOR" },
                    { "7dbd63fe-3aa5-4883-89c5-e0187ca9d060", "b688fa20-f7ea-4391-ba45-d70c2137ba79", "Driver", "DRIVER" },
                    { "abb5b6dc-0fb2-4830-8c23-7240e94ad78b", "44bbb592-7f39-4f77-9763-a1bd163214c3", "CounterWorker", "COUNTERWORKER" },
                    { "d31f4484-8f04-413c-95aa-97c15594774f", "741ac8eb-4043-4e34-b043-73ef27dbdf22", "Buyer", "BUYER" },
                    { "fdc94744-701a-4373-a0eb-99b401146390", "49a0578d-4393-4bbf-ae8c-82e275dd83bd", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3932bc79-306e-4eba-809c-5e66b333ba46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dbd63fe-3aa5-4883-89c5-e0187ca9d060");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abb5b6dc-0fb2-4830-8c23-7240e94ad78b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d31f4484-8f04-413c-95aa-97c15594774f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdc94744-701a-4373-a0eb-99b401146390");

            migrationBuilder.DropColumn(
                name: "NumberOfReservedCards",
                table: "BusLines");

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
    }
}
