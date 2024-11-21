using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class configureRelationshipAndAddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_UtilityProfile_UtilityProfileId",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "UtilityProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "UtilityProfileId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "BlockNumber", "Price", "UnitNumber", "UtilityProfileId" },
                values: new object[] { 3, "D", 100f, 69, null });

            migrationBuilder.InsertData(
                table: "UtilityProfile",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Basic Utilities" },
                    { 2, "Premium Utilities" }
                });

            migrationBuilder.InsertData(
                table: "UtilityModel",
                columns: new[] { "Id", "Name", "Price", "UtilityProfileId" },
                values: new object[,]
                {
                    { 1, "Water", 50L, 1 },
                    { 2, "Electricity", 100L, 1 },
                    { 3, "Gas", 80L, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_UtilityProfile_UtilityProfileId",
                table: "Properties",
                column: "UtilityProfileId",
                principalTable: "UtilityProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_UtilityProfile_UtilityProfileId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UtilityModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UtilityModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UtilityModel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UtilityProfile",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UtilityProfile",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "UtilityProfileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "UtilityProfileId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_UtilityProfile_UtilityProfileId",
                table: "Properties",
                column: "UtilityProfileId",
                principalTable: "UtilityProfile",
                principalColumn: "Id");
        }
    }
}
