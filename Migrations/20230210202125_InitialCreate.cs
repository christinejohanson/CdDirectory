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
            migrationBuilder.DropForeignKey(
                name: "FK_Cd_Artist_ArtistId",
                table: "Cd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artist_1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist_1",
                table: "Artist_1",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cd_Artist_1_ArtistId",
                table: "Cd",
                column: "ArtistId",
                principalTable: "Artist_1",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cd_Artist_1_ArtistId",
                table: "Cd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist_1",
                table: "Artist_1");

            migrationBuilder.RenameTable(
                name: "Artist_1",
                newName: "Artist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cd_Artist_ArtistId",
                table: "Cd",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
