using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilityModel_UtilityProfile_UtilityProfileId",
                table: "UtilityModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilityModel",
                table: "UtilityModel");

            migrationBuilder.RenameTable(
                name: "UtilityModel",
                newName: "Utilities");

            migrationBuilder.RenameIndex(
                name: "IX_UtilityModel_UtilityProfileId",
                table: "Utilities",
                newName: "IX_Utilities_UtilityProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilities_UtilityProfile_UtilityProfileId",
                table: "Utilities",
                column: "UtilityProfileId",
                principalTable: "UtilityProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilities_UtilityProfile_UtilityProfileId",
                table: "Utilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities");

            migrationBuilder.RenameTable(
                name: "Utilities",
                newName: "UtilityModel");

            migrationBuilder.RenameIndex(
                name: "IX_Utilities_UtilityProfileId",
                table: "UtilityModel",
                newName: "IX_UtilityModel_UtilityProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilityModel",
                table: "UtilityModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilityModel_UtilityProfile_UtilityProfileId",
                table: "UtilityModel",
                column: "UtilityProfileId",
                principalTable: "UtilityProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
