using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenappi.Cenappi_Data_Access.Entities
{
    /// <inheritdoc />
    public partial class addweekconfigtodayconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayConfigurator_WeekConfigurator_WeekConfiguratorId",
                table: "DayConfigurator");

            migrationBuilder.AlterColumn<int>(
                name: "WeekConfiguratorId",
                table: "DayConfigurator",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DayConfigurator_WeekConfigurator_WeekConfiguratorId",
                table: "DayConfigurator",
                column: "WeekConfiguratorId",
                principalTable: "WeekConfigurator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayConfigurator_WeekConfigurator_WeekConfiguratorId",
                table: "DayConfigurator");

            migrationBuilder.AlterColumn<int>(
                name: "WeekConfiguratorId",
                table: "DayConfigurator",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DayConfigurator_WeekConfigurator_WeekConfiguratorId",
                table: "DayConfigurator",
                column: "WeekConfiguratorId",
                principalTable: "WeekConfigurator",
                principalColumn: "Id");
        }
    }
}
