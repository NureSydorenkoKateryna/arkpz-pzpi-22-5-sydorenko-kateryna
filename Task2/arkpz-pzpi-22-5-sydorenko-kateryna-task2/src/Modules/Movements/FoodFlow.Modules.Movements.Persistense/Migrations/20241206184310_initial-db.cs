using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodFlow.Modules.Movements.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "movements");

            migrationBuilder.CreateTable(
                name: "warehouses",
                schema: "movements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SpotId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "imports",
                schema: "movements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TimePoint = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imports_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "movements",
                        principalTable: "warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rests",
                schema: "movements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParoductId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rests_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "movements",
                        principalTable: "warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "write_offs",
                schema: "movements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_write_offs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_write_offs_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "movements",
                        principalTable: "warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "importitems",
                schema: "movements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ImportId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_importitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_importitems_imports_ImportId",
                        column: x => x.ImportId,
                        principalSchema: "movements",
                        principalTable: "imports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_importitems_ImportId",
                schema: "movements",
                table: "importitems",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_imports_WarehouseId",
                schema: "movements",
                table: "imports",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_rests_WarehouseId",
                schema: "movements",
                table: "rests",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_write_offs_WarehouseId",
                schema: "movements",
                table: "write_offs",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "importitems",
                schema: "movements");

            migrationBuilder.DropTable(
                name: "rests",
                schema: "movements");

            migrationBuilder.DropTable(
                name: "write_offs",
                schema: "movements");

            migrationBuilder.DropTable(
                name: "imports",
                schema: "movements");

            migrationBuilder.DropTable(
                name: "warehouses",
                schema: "movements");
        }
    }
}
