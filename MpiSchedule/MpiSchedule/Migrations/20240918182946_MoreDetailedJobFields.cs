using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpiSchedule.Migrations
{
    /// <inheritdoc />
    public partial class MoreDetailedJobFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "DetailedJobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinishedItemNumber",
                table: "DetailedJobs",
                type: "TEXT",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LeadTimeDate",
                table: "DetailedJobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MaterialReceiveDate",
                table: "DetailedJobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "DetailedJobs",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PressMonth",
                table: "DetailedJobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedOrder",
                table: "DetailedJobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedShipDate",
                table: "DetailedJobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WipItemNumber",
                table: "DetailedJobs",
                type: "TEXT",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "FinishedItemNumber",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "LeadTimeDate",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "MaterialReceiveDate",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "PressMonth",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "ReceivedOrder",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "RequestedShipDate",
                table: "DetailedJobs");

            migrationBuilder.DropColumn(
                name: "WipItemNumber",
                table: "DetailedJobs");
        }
    }
}
