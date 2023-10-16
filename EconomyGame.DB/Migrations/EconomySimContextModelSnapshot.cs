﻿// <auto-generated />
using System;
using EconomyGame.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EconomyGame.DB.Migrations
{
    [DbContext(typeof(EconomySimContext))]
    partial class EconomySimContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EconomyGame.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentId"));

                    b.Property<int>("AgentSchematicId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.HasIndex("AgentSchematicId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("EconomyGame.Models.AgentProduction", b =>
                {
                    b.Property<int>("AgentProductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentProductionId"));

                    b.Property<int?>("AgentProduction")
                        .HasColumnType("int");

                    b.Property<decimal>("AmountPerSecond")
                        .HasColumnType("decimal(20,4)");

                    b.Property<int>("ResourceTypeId")
                        .HasColumnType("int");

                    b.HasKey("AgentProductionId");

                    b.HasIndex("AgentProduction");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("AgentProductions");
                });

            modelBuilder.Entity("EconomyGame.Models.AgentSchematic", b =>
                {
                    b.Property<int>("AgentSchematicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentSchematicId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentSchematicId");

                    b.ToTable("AgentSchematics");
                });

            modelBuilder.Entity("EconomyGame.Models.AgentUtility", b =>
                {
                    b.Property<int>("AgentUtilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentUtilityId"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int?>("AgentUtility")
                        .HasColumnType("int");

                    b.Property<int>("ResourceTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Utility")
                        .HasColumnType("decimal(20,4)");

                    b.HasKey("AgentUtilityId");

                    b.HasIndex("AgentId");

                    b.HasIndex("AgentUtility");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("AgentUtilities");
                });

            modelBuilder.Entity("EconomyGame.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Resource")
                        .HasColumnType("int");

                    b.Property<int>("ResourceTypeId")
                        .HasColumnType("int");

                    b.HasKey("ResourceId");

                    b.HasIndex("Resource");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("EconomyGame.Models.ResourceType", b =>
                {
                    b.Property<int>("ResourceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceTypeId");

                    b.ToTable("ResourceTypes");
                });

            modelBuilder.Entity("EconomyGame.Models.Agent", b =>
                {
                    b.HasOne("EconomyGame.Models.AgentSchematic", "Schematic")
                        .WithMany()
                        .HasForeignKey("AgentSchematicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schematic");
                });

            modelBuilder.Entity("EconomyGame.Models.AgentProduction", b =>
                {
                    b.HasOne("EconomyGame.Models.AgentSchematic", null)
                        .WithMany("Productions")
                        .HasForeignKey("AgentProduction");

                    b.HasOne("EconomyGame.Models.ResourceType", "ResourceType")
                        .WithMany()
                        .HasForeignKey("ResourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourceType");
                });

            modelBuilder.Entity("EconomyGame.Models.AgentUtility", b =>
                {
                    b.HasOne("EconomyGame.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EconomyGame.Models.AgentSchematic", null)
                        .WithMany("Utilities")
                        .HasForeignKey("AgentUtility");

                    b.HasOne("EconomyGame.Models.ResourceType", "ResourceType")
                        .WithMany()
                        .HasForeignKey("ResourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("ResourceType");
                });

            modelBuilder.Entity("EconomyGame.Models.Resource", b =>
                {
                    b.HasOne("EconomyGame.Models.Agent", null)
                        .WithMany("Resources")
                        .HasForeignKey("Resource");

                    b.HasOne("EconomyGame.Models.ResourceType", "ResourceType")
                        .WithMany()
                        .HasForeignKey("ResourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourceType");
                });

            modelBuilder.Entity("EconomyGame.Models.Agent", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("EconomyGame.Models.AgentSchematic", b =>
                {
                    b.Navigation("Productions");

                    b.Navigation("Utilities");
                });
#pragma warning restore 612, 618
        }
    }
}
