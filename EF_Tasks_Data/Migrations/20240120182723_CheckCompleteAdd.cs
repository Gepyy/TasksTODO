using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Tasks_Data.Migrations
{
    /// <inheritdoc />
    public partial class CheckCompleteAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckComplete",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckComplete",
                table: "Tasks");
        }
    }
}
