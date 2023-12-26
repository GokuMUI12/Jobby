using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class JobEmailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7bd289e-1564-46a7-ac32-1cf15e6fee0e", "f157ab3c-40a7-4199-aaba-215b27a65b46", "Freelancer", "Freelancer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa23c523-03ab-41a1-b094-eb32c9ab031e", "52abd092-04c1-4e51-a07d-3d520504ee10", "Employer", "Employer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7bd289e-1564-46a7-ac32-1cf15e6fee0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa23c523-03ab-41a1-b094-eb32c9ab031e");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Jobs");
        }
    }
}
