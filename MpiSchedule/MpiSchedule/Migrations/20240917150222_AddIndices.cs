using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpiSchedule.Migrations
{
    /// <inheritdoc />
    public partial class AddIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Presses_PressId",
                table: "Presses",
                column: "PressId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs",
                columns: new[] { "Id", "JobNumber" });
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
        }
    }
}
