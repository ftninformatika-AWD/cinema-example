using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaBasicExample.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Room = table.Column<int>(type: "integer", nullable: false),
                    ScreeningType = table.Column<string>(type: "text", nullable: false),
                    TicketPrice = table.Column<double>(type: "double precision", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "", 120, 3, "Eclipse of Shadows" },
                    { 2, "", 110, 2, "The Last Horizon" },
                    { 3, "", 130, 5, "Whispers of the Wind" },
                    { 4, "", 140, 4, "Crimson Tide Rising" },
                    { 5, "", 100, 1, "Echoes of Eternity" },
                    { 6, "", 150, 2, "Into the Depths" },
                    { 7, "", 125, 3, "Starlight Chronicles" },
                    { 8, "", 95, 4, "The Forgotten Realm" },
                    { 9, "", 105, 3, "Beyond the Veil" },
                    { 10, "", 11, 1, "Shattered Reflections" }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "Room", "ScheduledAt", "ScreeningType", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 1, 5, 10, 0, 0, 0, DateTimeKind.Utc), "2D", 10.0 },
                    { 2, 2, 2, new DateTime(2026, 1, 6, 12, 30, 0, 0, DateTimeKind.Utc), "3D", 12.5 },
                    { 3, 3, 3, new DateTime(2026, 1, 7, 15, 0, 0, 0, DateTimeKind.Utc), "IMAX", 15.0 },
                    { 4, 4, 4, new DateTime(2026, 1, 8, 18, 0, 0, 0, DateTimeKind.Utc), "4D", 20.0 },
                    { 5, 5, 5, new DateTime(2026, 1, 9, 20, 0, 0, 0, DateTimeKind.Utc), "2D", 10.0 },
                    { 6, 6, 6, new DateTime(2026, 2, 1, 11, 0, 0, 0, DateTimeKind.Utc), "3D", 12.5 },
                    { 7, 7, 7, new DateTime(2026, 2, 2, 13, 30, 0, 0, DateTimeKind.Utc), "IMAX", 15.0 },
                    { 8, 8, 8, new DateTime(2026, 2, 3, 16, 0, 0, 0, DateTimeKind.Utc), "4D", 20.0 },
                    { 9, 9, 1, new DateTime(2026, 2, 4, 19, 0, 0, 0, DateTimeKind.Utc), "2D", 10.0 },
                    { 10, 10, 2, new DateTime(2026, 2, 5, 21, 0, 0, 0, DateTimeKind.Utc), "3D", 12.5 },
                    { 11, 1, 3, new DateTime(2026, 3, 1, 10, 0, 0, 0, DateTimeKind.Utc), "IMAX", 15.0 },
                    { 12, 2, 4, new DateTime(2026, 3, 2, 12, 30, 0, 0, DateTimeKind.Utc), "4D", 20.0 },
                    { 13, 3, 5, new DateTime(2026, 3, 3, 15, 0, 0, 0, DateTimeKind.Utc), "2D", 10.0 },
                    { 14, 4, 6, new DateTime(2026, 3, 4, 18, 0, 0, 0, DateTimeKind.Utc), "3D", 12.5 },
                    { 15, 5, 7, new DateTime(2026, 3, 5, 20, 0, 0, 0, DateTimeKind.Utc), "IMAX", 15.0 },
                    { 16, 6, 8, new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4D", 20.0 },
                    { 17, 7, 1, new DateTime(2026, 4, 2, 13, 30, 0, 0, DateTimeKind.Utc), "2D", 10.0 },
                    { 18, 8, 2, new DateTime(2026, 4, 3, 16, 0, 0, 0, DateTimeKind.Utc), "3D", 12.5 },
                    { 19, 9, 3, new DateTime(2026, 4, 4, 19, 0, 0, 0, DateTimeKind.Utc), "IMAX", 15.0 },
                    { 20, 10, 4, new DateTime(2026, 4, 5, 21, 0, 0, 0, DateTimeKind.Utc), "4D", 20.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
