using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenappi.Cenappi_Data_Access.Entities
{
    /// <inheritdoc />
    public partial class addconfigurators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekConfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekConfigurator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayConfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysId = table.Column<int>(type: "int", nullable: false),
                    RecipeTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekConfiguratorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayConfigurator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayConfigurator_Day_DaysId",
                        column: x => x.DaysId,
                        principalTable: "Day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayConfigurator_WeekConfigurator_WeekConfiguratorId",
                        column: x => x.WeekConfiguratorId,
                        principalTable: "WeekConfigurator",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayConfigurator_DaysId",
                table: "DayConfigurator",
                column: "DaysId");

            migrationBuilder.CreateIndex(
                name: "IX_DayConfigurator_WeekConfiguratorId",
                table: "DayConfigurator",
                column: "WeekConfiguratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayConfigurator");

            migrationBuilder.DropTable(
                name: "WeekConfigurator");
        }
    }
}
