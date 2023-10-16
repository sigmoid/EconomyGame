using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomyGame.DB.Migrations
{
    /// <inheritdoc />
    public partial class BasicSketchII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Agents_AgentOwnerId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AgentOwnerId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AgentOwnerId",
                table: "Resources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentOwnerId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AgentOwnerId",
                table: "Resources",
                column: "AgentOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Agents_AgentOwnerId",
                table: "Resources",
                column: "AgentOwnerId",
                principalTable: "Agents",
                principalColumn: "AgentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
