using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomyGame.DB.Migrations
{
    /// <inheritdoc />
    public partial class BasicSketchIII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Utility",
                table: "AgentUtilities",
                type: "decimal(20,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPerSecond",
                table: "AgentProductions",
                type: "decimal(20,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_AgentProductions_ResourceTypeId",
                table: "AgentProductions",
                column: "ResourceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentProductions_ResourceTypes_ResourceTypeId",
                table: "AgentProductions",
                column: "ResourceTypeId",
                principalTable: "ResourceTypes",
                principalColumn: "ResourceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentProductions_ResourceTypes_ResourceTypeId",
                table: "AgentProductions");

            migrationBuilder.DropIndex(
                name: "IX_AgentProductions_ResourceTypeId",
                table: "AgentProductions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Utility",
                table: "AgentUtilities",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPerSecond",
                table: "AgentProductions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,4)");
        }
    }
}
