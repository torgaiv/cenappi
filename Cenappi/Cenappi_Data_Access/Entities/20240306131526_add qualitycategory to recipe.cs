using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenappi.Cenappi_Data_Access.Entities
{
    /// <inheritdoc />
    public partial class addqualitycategorytorecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualityCategoryKey",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QualityCategoryKey",
                table: "Recipe");
        }
    }
}
