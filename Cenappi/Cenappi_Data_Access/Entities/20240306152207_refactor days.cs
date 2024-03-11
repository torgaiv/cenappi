using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenappi.Cenappi_Data_Access.Entities
{
    /// <inheritdoc />
    public partial class refactordays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayConfigurator_Day_DaysId",
                table: "DayConfigurator");

            migrationBuilder.DropIndex(
                name: "IX_DayConfigurator_DaysId",
                table: "DayConfigurator");

            migrationBuilder.DropColumn(
                name: "DaysId",
                table: "DayConfigurator");

            migrationBuilder.AddColumn<DateTime>(
                name: "Days",
                table: "DayConfigurator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "DayConfigurator");

            migrationBuilder.AddColumn<int>(
                name: "DaysId",
                table: "DayConfigurator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DayConfigurator_DaysId",
                table: "DayConfigurator",
                column: "DaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayConfigurator_Day_DaysId",
                table: "DayConfigurator",
                column: "DaysId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
