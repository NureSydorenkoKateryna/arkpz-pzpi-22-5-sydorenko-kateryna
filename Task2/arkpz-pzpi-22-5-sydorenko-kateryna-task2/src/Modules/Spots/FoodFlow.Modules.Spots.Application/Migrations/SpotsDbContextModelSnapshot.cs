﻿// <auto-generated />
using FoodFlow.Modules.Spots.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodFlow.Modules.Spots.Application.Migrations
{
    [DbContext(typeof(SpotsDbContext))]
    partial class SpotsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("spots")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodFlow.Modules.Spots.Application.Domain.Entities.Owner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("owners", "spots");
                });

            modelBuilder.Entity("FoodFlow.Modules.Spots.Application.Domain.Entities.Spot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentSpotId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentSpotId");

                    b.ToTable("spots", "spots");
                });

            modelBuilder.Entity("FoodFlow.Modules.Spots.Application.Domain.Entities.Spot", b =>
                {
                    b.HasOne("FoodFlow.Modules.Spots.Application.Domain.Entities.Owner", "Owner")
                        .WithMany("Spots")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFlow.Modules.Spots.Application.Domain.Entities.Spot", "ParentSpot")
                        .WithMany("ChildrenSpots")
                        .HasForeignKey("ParentSpotId");

                    b.Navigation("Owner");

                    b.Navigation("ParentSpot");
                });

            modelBuilder.Entity("FoodFlow.Modules.Spots.Application.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Spots");
                });

            modelBuilder.Entity("FoodFlow.Modules.Spots.Application.Domain.Entities.Spot", b =>
                {
                    b.Navigation("ChildrenSpots");
                });
#pragma warning restore 612, 618
        }
    }
}
