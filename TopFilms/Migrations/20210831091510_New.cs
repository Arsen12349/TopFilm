using Microsoft.EntityFrameworkCore.Migrations;

namespace TopFilms.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutFilm",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "YearFilm",
                table: "Films",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Team",
                table: "Films",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameFilm",
                table: "Films",
                newName: "About");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorFilm",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorFilm", x => new { x.ActorsId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_ActorFilm_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorFilm_FilmsId",
                table: "ActorFilm",
                column: "FilmsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorFilm");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Films",
                newName: "YearFilm");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Films",
                newName: "Team");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "Films",
                newName: "NameFilm");

            migrationBuilder.AddColumn<string>(
                name: "AboutFilm",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
