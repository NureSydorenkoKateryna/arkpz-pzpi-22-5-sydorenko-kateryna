﻿// <auto-generated />
using FoodFlow.Modules.Culinary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodFlow.Modules.Culinary.Persistence.Migrations
{
    [DbContext(typeof(CulinaryDbContext))]
    partial class CulinaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("culinary")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("TechCardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechCardId");

                    b.ToTable("ingredients", "culinary");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("products", "culinary");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Restaurant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpotId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("restaurants", "culinary");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.RestaurantTechCard", b =>
                {
                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<long>("TechCardId")
                        .HasColumnType("bigint");

                    b.HasKey("RestaurantId", "TechCardId");

                    b.HasIndex("TechCardId");

                    b.ToTable("restaurant_tech_cards", "culinary");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.TechCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("techcards", "culinary");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Ingredient", b =>
                {
                    b.HasOne("FoodFlow.Modules.Culinary.Core.Entities.Product", "Product")
                        .WithMany("Ingredients")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.HasOne("FoodFlow.Modules.Culinary.Core.Entities.TechCard", "TechCard")
                        .WithMany("Ingredients")
                        .HasForeignKey("TechCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("TechCard");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Product", b =>
                {
                    b.HasOne("FoodFlow.Modules.Culinary.Core.Entities.Restaurant", "Restaurant")
                        .WithMany("Products")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.RestaurantTechCard", b =>
                {
                    b.HasOne("FoodFlow.Modules.Culinary.Core.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantTechCards")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFlow.Modules.Culinary.Core.Entities.TechCard", "TechCard")
                        .WithMany("RestaurantTechCards")
                        .HasForeignKey("TechCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("TechCard");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Product", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.Restaurant", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("RestaurantTechCards");
                });

            modelBuilder.Entity("FoodFlow.Modules.Culinary.Core.Entities.TechCard", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("RestaurantTechCards");
                });
#pragma warning restore 612, 618
        }
    }
}