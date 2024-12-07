﻿// <auto-generated />
using System;
using FoodFlow.Modules.Movements.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodFlow.Modules.Movements.Persistence.Migrations
{
    [DbContext(typeof(MovementsDbContext))]
    partial class MovementsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("movements")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Import", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("TimePoint")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("WarehouseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("imports", "movements");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.ImportItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ImportId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ImportId");

                    b.ToTable("importitems", "movements");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Rest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ParoductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("WarehouseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("rests", "movements");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Warehouse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("SpotId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("warehouses", "movements");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.WriteOff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("WarehouseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("write_offs", "movements");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Import", b =>
                {
                    b.HasOne("FoodFlow.Modules.Movements.Core.Entities.Warehouse", "Warehouse")
                        .WithMany("Imports")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.ImportItem", b =>
                {
                    b.HasOne("FoodFlow.Modules.Movements.Core.Entities.Import", "Import")
                        .WithMany("Items")
                        .HasForeignKey("ImportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Import");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Rest", b =>
                {
                    b.HasOne("FoodFlow.Modules.Movements.Core.Entities.Warehouse", "Warehouse")
                        .WithMany("Rests")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.WriteOff", b =>
                {
                    b.HasOne("FoodFlow.Modules.Movements.Core.Entities.Warehouse", "Warehouse")
                        .WithMany("WriteOffs")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Import", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FoodFlow.Modules.Movements.Core.Entities.Warehouse", b =>
                {
                    b.Navigation("Imports");

                    b.Navigation("Rests");

                    b.Navigation("WriteOffs");
                });
#pragma warning restore 612, 618
        }
    }
}
