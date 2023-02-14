using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CdDirectory.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist_1",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_1", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Cd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Releaseyear = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cd_Artist_1_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist_1",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lender_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    LenderName = table.Column<string>(type: "TEXT", nullable: true),
                    LoanDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CdId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lender_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lender_1_Cd_CdId",
                        column: x => x.CdId,
                        principalTable: "Cd",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cd_ArtistId",
                table: "Cd",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Lender_1_CdId",
                table: "Lender_1",
                column: "CdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lender_1");

            migrationBuilder.DropTable(
                name: "Cd");

            migrationBuilder.DropTable(
                name: "Artist_1");
        }
    }
}
