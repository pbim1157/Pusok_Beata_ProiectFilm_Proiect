using Microsoft.EntityFrameworkCore.Migrations;

namespace Pusok_Beata_ProiectFilm.Migrations
{
    public partial class GenFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Film",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeGen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GenFilm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(nullable: false),
                    GenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenFilm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GenFilm_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenFilm_Gen_GenID",
                        column: x => x.GenID,
                        principalTable: "Gen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_ProducatorID",
                table: "Film",
                column: "ProducatorID");

            migrationBuilder.CreateIndex(
                name: "IX_GenFilm_FilmID",
                table: "GenFilm",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_GenFilm_GenID",
                table: "GenFilm",
                column: "GenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Producator_ProducatorID",
                table: "Film",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Producator_ProducatorID",
                table: "Film");

            migrationBuilder.DropTable(
                name: "GenFilm");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropTable(
                name: "Gen");

            migrationBuilder.DropIndex(
                name: "IX_Film_ProducatorID",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Film");
        }
    }
}
