using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataRenterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hao" },
                    { 2, "Hoa" },
                    { 3, "Hai" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
