using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpiSchedule.Migrations
{
    /// <inheritdoc />
    public partial class RejoinIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jobs_Id",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobNumber",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs",
                columns: new[] { "Id", "JobNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jobs_Id_JobNumber",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id",
                table: "Jobs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobNumber",
                table: "Jobs",
                column: "JobNumber");
        }
    }
}
