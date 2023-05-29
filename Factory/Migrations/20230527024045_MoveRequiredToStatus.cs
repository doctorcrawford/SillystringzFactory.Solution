using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class MoveRequiredToStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evan",
                table: "Machines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Evan",
                table: "Machines",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
