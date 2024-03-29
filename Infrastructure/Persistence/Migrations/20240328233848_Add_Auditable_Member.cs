using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    public partial class Add_Auditable_Member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropPrimaryKey(
                name: "PK_BusLinesUsers",
                table: "BusLinesUsers");

            migrationBuilder.DropIndex(
                name: "IX_BusLinesUsers_BusLineId",
                table: "BusLinesUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40352c89-4183-4c86-a49e-9dd10c5dc2df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a3fe7c-5ce1-4f4d-a87f-a1323efeccc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e26bba7-25c0-441c-9e94-c1e4687884b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0e4650-cc1a-49a5-ba44-621b55ec7546");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdb55b2d-6474-41e5-a642-e463447edc4e");*/

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Buses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Buses",
                type: "datetime2",
                nullable: true);

            /*migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusLinesUsers",
                table: "BusLinesUsers",
                columns: new[] { "BusLineId", "UserId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f31ed3c-db88-49fd-a727-9dfa64b3de4d", "b2fc5437-6a38-4eb5-a6ac-1e2a59717644", "Conductor", "CONDUCTOR" },
                    { "138d8e99-609c-4694-bf4e-d3ece9eecb9b", "6da80338-59d7-488c-8fec-9ea06248ed34", "Admin", "ADMIN" },
                    { "21c3127a-784a-4d5a-9dc0-3fcd3093c919", "03e482aa-535f-4398-b87d-8599f31f0be5", "Driver", "DRIVER" },
                    { "286d48b5-5b2a-4734-b9a3-05bed7a2edba", "5e662bec-e6fe-472b-95bb-830cc9b4913a", "CounterWorker", "COUNTERWORKER" },
                    { "32c3f8e2-9f2b-4ff7-a0b4-916f77d8906e", "f6b38cf4-c30f-4a30-9e5a-5f3773ede646", "Conductor", "CONDUCTOR" },
                    { "46621cb6-fd0a-40d3-af33-fda4e9028baf", "4e79a893-3f97-4414-b6f7-564659b3e313", "Buyer", "BUYER" },
                    { "6d5496f8-caaf-413d-abf7-a26ee45fb573", "84cde322-f3e8-4c10-b4a6-7dd682a8ecb1", "Admin", "ADMIN" },
                    { "6dd18413-0cba-4b4e-bf23-435287d76bcf", "c266a851-6cf5-4faf-997c-a4427a706bbf", "CounterWorker", "COUNTERWORKER" },
                    { "7c4279dd-6421-4c0d-9f35-7e780e0c907d", "7240b336-6cec-4760-91d6-736fc58d2862", "Buyer", "BUYER" },
                    { "b2becde3-c82b-49f8-b731-764a3f32d4d4", "8a6883f6-9ca7-4442-8265-71256c116d21", "Driver", "DRIVER" }
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropPrimaryKey(
                name: "PK_BusLinesUsers",
                table: "BusLinesUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f31ed3c-db88-49fd-a727-9dfa64b3de4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "138d8e99-609c-4694-bf4e-d3ece9eecb9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21c3127a-784a-4d5a-9dc0-3fcd3093c919");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "286d48b5-5b2a-4734-b9a3-05bed7a2edba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c3f8e2-9f2b-4ff7-a0b4-916f77d8906e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46621cb6-fd0a-40d3-af33-fda4e9028baf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d5496f8-caaf-413d-abf7-a26ee45fb573");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dd18413-0cba-4b4e-bf23-435287d76bcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c4279dd-6421-4c0d-9f35-7e780e0c907d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2becde3-c82b-49f8-b731-764a3f32d4d4");
            */
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Buses");
            /*
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusLinesUsers",
                table: "BusLinesUsers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40352c89-4183-4c86-a49e-9dd10c5dc2df", "ee87fc39-09fa-41b1-b999-0be839dad2d1", "Conductor", "CONDUCTOR" },
                    { "44a3fe7c-5ce1-4f4d-a87f-a1323efeccc6", "fde796da-4413-4bef-84c0-a58864ee3d37", "Buyer", "BUYER" },
                    { "9e26bba7-25c0-441c-9e94-c1e4687884b4", "ac2581c4-39b7-4be0-88d5-11f533ce8277", "Admin", "ADMIN" },
                    { "de0e4650-cc1a-49a5-ba44-621b55ec7546", "84fb0aa3-048b-4c53-8063-41e487da22cb", "Driver", "DRIVER" },
                    { "fdb55b2d-6474-41e5-a642-e463447edc4e", "4d9b3ad6-0145-405d-8a9c-590a056087a4", "CounterWorker", "COUNTERWORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLinesUsers_BusLineId",
                table: "BusLinesUsers",
                column: "BusLineId");
            */
        }
    }
}
