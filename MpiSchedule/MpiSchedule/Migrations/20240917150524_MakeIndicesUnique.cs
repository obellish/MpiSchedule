using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpiSchedule.Migrations
{
    /// <inheritdoc />
    public partial class MakeIndicesUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presses_PressId",
                table: "Presses");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Presses_PressId",
                table: "Presses",
                column: "PressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs",
                columns: new[] { "Id", "JobNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presses_PressId",
                table: "Presses");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Presses_PressId",
                table: "Presses",
                column: "PressId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs",
                columns: new[] { "Id", "JobNumber" });
        }
    }
}
