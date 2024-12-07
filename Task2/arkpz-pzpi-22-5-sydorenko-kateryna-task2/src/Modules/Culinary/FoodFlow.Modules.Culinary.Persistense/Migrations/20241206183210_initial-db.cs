using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodFlow.Modules.Culinary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "culinary");

            migrationBuilder.CreateTable(
                name: "restaurants",
                schema: "culinary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpotId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    OwnerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "techcards",
                schema: "culinary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_techcards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "culinary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    RestaurantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalSchema: "culinary",
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_tech_cards",
                schema: "culinary",
                columns: table => new
                {
                    RestaurantId = table.Column<long>(type: "bigint", nullable: false),
                    TechCardId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_tech_cards", x => new { x.RestaurantId, x.TechCardId });
                    table.ForeignKey(
                        name: "FK_restaurant_tech_cards_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalSchema: "culinary",
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_restaurant_tech_cards_techcards_TechCardId",
                        column: x => x.TechCardId,
                        principalSchema: "culinary",
                        principalTable: "techcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                schema: "culinary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    TechCardId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredients_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "culinary",
                        principalTable: "products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ingredients_techcards_TechCardId",
                        column: x => x.TechCardId,
                        principalSchema: "culinary",
                        principalTable: "techcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_ProductId",
                schema: "culinary",
                table: "ingredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_TechCardId",
                schema: "culinary",
                table: "ingredients",
                column: "TechCardId");

            migrationBuilder.CreateIndex(
                name: "IX_products_RestaurantId",
                schema: "culinary",
                table: "products",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_tech_cards_TechCardId",
                schema: "culinary",
                table: "restaurant_tech_cards",
                column: "TechCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredients",
                schema: "culinary");

            migrationBuilder.DropTable(
                name: "restaurant_tech_cards",
                schema: "culinary");

            migrationBuilder.DropTable(
                name: "products",
                schema: "culinary");

            migrationBuilder.DropTable(
                name: "techcards",
                schema: "culinary");

            migrationBuilder.DropTable(
                name: "restaurants",
                schema: "culinary");
        }
    }
}
