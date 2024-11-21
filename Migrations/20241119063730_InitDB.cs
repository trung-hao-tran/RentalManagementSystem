using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilityProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    UnitNumber = table.Column<int>(type: "int", nullable: false),
                    BlockNumber = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UtilityProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_UtilityProfile_UtilityProfileId",
                        column: x => x.UtilityProfileId,
                        principalTable: "UtilityProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UtilityModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    UtilityProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilityModel_UtilityProfile_UtilityProfileId",
                        column: x => x.UtilityProfileId,
                        principalTable: "UtilityProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renters_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "BlockNumber", "Price", "UnitNumber", "UtilityProfileId" },
                values: new object[,]
                {
                    { 1, "A", 100f, 1, null },
                    { 2, "A", 100f, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "Id", "Name", "PropertyId" },
                values: new object[,]
                {
                    { 1, "Hao", 1 },
                    { 2, "Hoa", 1 },
                    { 3, "Hai", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UtilityProfileId",
                table: "Properties",
                column: "UtilityProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_PropertyId",
                table: "Renters",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilityModel_UtilityProfileId",
                table: "UtilityModel",
                column: "UtilityProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropTable(
                name: "UtilityModel");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "UtilityProfile");
        }
    }
}
