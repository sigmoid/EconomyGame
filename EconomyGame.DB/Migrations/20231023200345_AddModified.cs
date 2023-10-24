using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomyGame.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Agents",
                newName: "ModifiedOn");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ResourceTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ResourceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ResourceTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Resources",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Resources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgentUtilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AgentUtilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AgentUtilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgentSchematics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AgentSchematics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AgentSchematics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgentProductions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AgentProductions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AgentProductions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AgentConsumption",
                columns: table => new
                {
                    AgentConsumptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    AmountPerSecond = table.Column<decimal>(type: "decimal(20,4)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AgentConsumption = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentConsumption", x => x.AgentConsumptionId);
                    table.ForeignKey(
                        name: "FK_AgentConsumption_AgentSchematics_AgentConsumption",
                        column: x => x.AgentConsumption,
                        principalTable: "AgentSchematics",
                        principalColumn: "AgentSchematicId");
                    table.ForeignKey(
                        name: "FK_AgentConsumption_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "ResourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentConsumption_AgentConsumption",
                table: "AgentConsumption",
                column: "AgentConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_AgentConsumption_ResourceTypeId",
                table: "AgentConsumption",
                column: "ResourceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentConsumption");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ResourceTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ResourceTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ResourceTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgentUtilities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AgentUtilities");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AgentUtilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgentSchematics");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AgentSchematics");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AgentSchematics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgentProductions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AgentProductions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AgentProductions");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Agents",
                newName: "DateModified");
        }
    }
}
