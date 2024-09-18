using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpiSchedule.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailedJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailedJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PressJobId = table.Column<int>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedJobs_Jobs_PressJobId",
                        column: x => x.PressJobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailedJobs_PressJobId",
                table: "DetailedJobs",
                column: "PressJobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailedJobs");
        }
    }
}
