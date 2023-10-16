using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomyGame.DB.Migrations
{
    /// <inheritdoc />
    public partial class BasicSketch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentSchematicId",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AgentSchematics",
                columns: table => new
                {
                    AgentSchematicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentSchematics", x => x.AgentSchematicId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.ResourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AgentProductions",
                columns: table => new
                {
                    AgentProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    AmountPerSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AgentProduction = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentProductions", x => x.AgentProductionId);
                    table.ForeignKey(
                        name: "FK_AgentProductions_AgentSchematics_AgentProduction",
                        column: x => x.AgentProduction,
                        principalTable: "AgentSchematics",
                        principalColumn: "AgentSchematicId");
                });

            migrationBuilder.CreateTable(
                name: "AgentUtilities",
                columns: table => new
                {
                    AgentUtilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    Utility = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AgentUtility = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentUtilities", x => x.AgentUtilityId);
                    table.ForeignKey(
                        name: "FK_AgentUtilities_AgentSchematics_AgentUtility",
                        column: x => x.AgentUtility,
                        principalTable: "AgentSchematics",
                        principalColumn: "AgentSchematicId");
                    table.ForeignKey(
                        name: "FK_AgentUtilities_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentUtilities_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "ResourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    AgentOwnerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Resource = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_Agents_AgentOwnerId",
                        column: x => x.AgentOwnerId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Agents_Resource",
                        column: x => x.Resource,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "ResourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentSchematicId",
                table: "Agents",
                column: "AgentSchematicId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentProductions_AgentProduction",
                table: "AgentProductions",
                column: "AgentProduction");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUtilities_AgentId",
                table: "AgentUtilities",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUtilities_AgentUtility",
                table: "AgentUtilities",
                column: "AgentUtility");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUtilities_ResourceTypeId",
                table: "AgentUtilities",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AgentOwnerId",
                table: "Resources",
                column: "AgentOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Resource",
                table: "Resources",
                column: "Resource");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AgentSchematics_AgentSchematicId",
                table: "Agents",
                column: "AgentSchematicId",
                principalTable: "AgentSchematics",
                principalColumn: "AgentSchematicId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AgentSchematics_AgentSchematicId",
                table: "Agents");

            migrationBuilder.DropTable(
                name: "AgentProductions");

            migrationBuilder.DropTable(
                name: "AgentUtilities");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "AgentSchematics");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AgentSchematicId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentSchematicId",
                table: "Agents");
        }
    }
}
