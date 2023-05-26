using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class AdjustListToEngineerMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineerMachine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EngineerMachine",
                columns: table => new
                {
                    EngineersEngineerId = table.Column<int>(type: "int", nullable: false),
                    MachinesMachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerMachine", x => new { x.EngineersEngineerId, x.MachinesMachineId });
                    table.ForeignKey(
                        name: "FK_EngineerMachine_Engineers_EngineersEngineerId",
                        column: x => x.EngineersEngineerId,
                        principalTable: "Engineers",
                        principalColumn: "EngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerMachine_Machines_MachinesMachineId",
                        column: x => x.MachinesMachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerMachine_MachinesMachineId",
                table: "EngineerMachine",
                column: "MachinesMachineId");
        }
    }
}
