using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class added_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2861feb8-32d9-43dc-995f-5ac0d5cdae99", "6edf1105-26d2-4dee-be41-b3c5784b6cf8", "Conductor", "CONDUCTOR" },
                    { "332c3111-b722-41d8-a542-2b7ff95c983c", "7a3fff9c-ab8e-4e87-8ad3-971c2c49837d", "Admin", "ADMIN" },
                    { "85bcd439-8996-42fe-9405-51e35a24980c", "cf7a7bc1-ac21-4451-9a9e-633000cb6978", "CounterWorker", "COUNTERWORKER" },
                    { "91fae521-8e8d-44db-ad08-f16047cccc3b", "9cc78ad7-6571-4922-862a-6f47647d4c19", "Driver", "DRIVER" },
                    { "eff696d3-3500-40b3-bbc5-61e84dd33716", "0cc185a2-0637-4b33-87ed-ac358a7371d4", "Buyer", "BUYER" }
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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "2861feb8-32d9-43dc-995f-5ac0d5cdae99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332c3111-b722-41d8-a542-2b7ff95c983c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85bcd439-8996-42fe-9405-51e35a24980c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91fae521-8e8d-44db-ad08-f16047cccc3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff696d3-3500-40b3-bbc5-61e84dd33716");

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
    }
}
