using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class FixTypoForEngineers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Enngineers_EngineersEngineerId",
                table: "EngineerMachine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enngineers",
                table: "Enngineers");

            migrationBuilder.RenameTable(
                name: "Enngineers",
                newName: "Engineers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engineers",
                table: "Engineers",
                column: "EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineersEngineerId",
                table: "EngineerMachine",
                column: "EngineersEngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineersEngineerId",
                table: "EngineerMachine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engineers",
                table: "Engineers");

            migrationBuilder.RenameTable(
                name: "Engineers",
                newName: "Enngineers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enngineers",
                table: "Enngineers",
                column: "EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Enngineers_EngineersEngineerId",
                table: "EngineerMachine",
                column: "EngineersEngineerId",
                principalTable: "Enngineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
