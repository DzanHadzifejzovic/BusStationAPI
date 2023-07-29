using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class removed_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLines_Buses_BusId",
                table: "BusLines");

            migrationBuilder.DropIndex(
                name: "IX_BusLines_BusId",
                table: "BusLines");

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
                name: "BusId",
                table: "BusLines");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a015ae-c81f-4ce1-8e8c-158d39fb7d19", "7c8d35ad-567b-4c8a-b74d-094d8ddf6def", "CounterWorker", "COUNTERWORKER" },
                    { "2c9d882e-cd7f-4d91-9ece-1b7bcbcb225c", "bb8dbf1b-a347-4e31-8e77-86f26ff1c3df", "Driver", "DRIVER" },
                    { "531ba2e0-3b57-428f-a893-264c981d1788", "96965c33-98f0-417c-8e50-42b7edf5f185", "Conductor", "CONDUCTOR" },
                    { "7de05597-99fd-400b-aabd-8efeb37189f7", "9e021cac-5d4c-4626-a4ba-eb226e5c6d9e", "Buyer", "BUYER" },
                    { "be5ea7be-3e1b-4fbf-88d9-21d10dce6c54", "43082473-48ac-4f41-ad53-54c8f1861427", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a015ae-c81f-4ce1-8e8c-158d39fb7d19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c9d882e-cd7f-4d91-9ece-1b7bcbcb225c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "531ba2e0-3b57-428f-a893-264c981d1788");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de05597-99fd-400b-aabd-8efeb37189f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be5ea7be-3e1b-4fbf-88d9-21d10dce6c54");

            migrationBuilder.AddColumn<int>(
                name: "BusId",
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

            migrationBuilder.CreateIndex(
                name: "IX_BusLines_BusId",
                table: "BusLines",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLines_Buses_BusId",
                table: "BusLines",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
