using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenappi.Cenappi_Data_Access.Entities
{
    /// <inheritdoc />
    public partial class addmaincoreworkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Week_WeekId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Day_DayId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Week_Year_YearId",
                table: "Week");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_DayId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Recipe");

            migrationBuilder.RenameColumn(
                name: "QualityCategoryKey",
                table: "Recipe",
                newName: "TypeId");

            migrationBuilder.AddColumn<int>(
                name: "YearNumber",
                table: "Year",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "YearId",
                table: "Week",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDay",
                table: "Week",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDay",
                table: "Week",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "WeekId",
                table: "Day",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Day",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeTypeId",
                table: "Day",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Day_RecipeId",
                table: "Day",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipe_RecipeId",
                table: "Day",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Week_WeekId",
                table: "Day",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Week_Year_YearId",
                table: "Week",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipe_RecipeId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Week_WeekId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Week_Year_YearId",
                table: "Week");

            migrationBuilder.DropIndex(
                name: "IX_Day_RecipeId",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "YearNumber",
                table: "Year");

            migrationBuilder.DropColumn(
                name: "EndDay",
                table: "Week");

            migrationBuilder.DropColumn(
                name: "StartingDay",
                table: "Week");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "RecipeTypeId",
                table: "Day");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Recipe",
                newName: "QualityCategoryKey");

            migrationBuilder.AlterColumn<int>(
                name: "YearId",
                table: "Week",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeekId",
                table: "Day",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_DayId",
                table: "Recipe",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Week_WeekId",
                table: "Day",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Day_DayId",
                table: "Recipe",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Week_Year_YearId",
                table: "Week",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id");
        }
    }
}
