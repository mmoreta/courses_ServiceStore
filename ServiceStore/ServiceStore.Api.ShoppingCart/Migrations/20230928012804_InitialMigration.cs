using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceStore.Api.ShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartSessions",
                columns: table => new
                {
                    CartSessionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSessions", x => x.CartSessionId);
                });

            migrationBuilder.CreateTable(
                name: "CartSessionDetails",
                columns: table => new
                {
                    CartSessionDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SelectedBook = table.Column<string>(type: "text", nullable: false),
                    CartSessionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSessionDetails", x => x.CartSessionDetailId);
                    table.ForeignKey(
                        name: "FK_CartSessionDetails_CartSessions_CartSessionId",
                        column: x => x.CartSessionId,
                        principalTable: "CartSessions",
                        principalColumn: "CartSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartSessionDetails_CartSessionId",
                table: "CartSessionDetails",
                column: "CartSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartSessionDetails");

            migrationBuilder.DropTable(
                name: "CartSessions");
        }
    }
}
