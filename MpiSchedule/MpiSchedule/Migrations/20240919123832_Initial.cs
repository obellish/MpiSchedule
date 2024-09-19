using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MpiSchedule.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presses",
                columns: table => new
                {
                    PressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presses", x => x.PressId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PressId = table.Column<int>(type: "INTEGER", nullable: false),
                    Shift = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityRan = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceivedOrder = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WipItemNumber = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false, defaultValue: ""),
                    FinishedItemNumber = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false, defaultValue: ""),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Presses_PressId",
                        column: x => x.PressId,
                        principalTable: "Presses",
                        principalColumn: "PressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Presses",
                columns: new[] { "PressId", "Name" },
                values: new object[,]
                {
                    { 1, "FlatBed Melzer" },
                    { 2, "Rotary Melzer" },
                    { 3, "10\"" },
                    { 4, "10Tam" },
                    { 5, "14\"Tamarack" },
                    { 6, "16\"Tamarack" },
                    { 7, "Test press" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs",
                columns: new[] { "Id", "JobNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PressId",
                table: "Jobs",
                column: "PressId");

            migrationBuilder.CreateIndex(
                name: "IX_Presses_PressId",
                table: "Presses",
                column: "PressId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Presses");
        }
    }
}
