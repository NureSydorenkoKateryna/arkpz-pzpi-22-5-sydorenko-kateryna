using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodFlow.Modules.Spots.Application.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "spots");

            migrationBuilder.CreateTable(
                name: "owners",
                schema: "spots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spots",
                schema: "spots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    ParentSpotId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spots_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "spots",
                        principalTable: "owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spots_spots_ParentSpotId",
                        column: x => x.ParentSpotId,
                        principalSchema: "spots",
                        principalTable: "spots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_spots_OwnerId",
                schema: "spots",
                table: "spots",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_spots_ParentSpotId",
                schema: "spots",
                table: "spots",
                column: "ParentSpotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spots",
                schema: "spots");

            migrationBuilder.DropTable(
                name: "owners",
                schema: "spots");
        }
    }
}
