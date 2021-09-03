using Microsoft.EntityFrameworkCore.Migrations;

namespace TopFilms.Migrations
{
    public partial class TopFilmsDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Films",
                type: "int",
                nullable: true);
                

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_DirectorId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Films");
        }
    }
}
