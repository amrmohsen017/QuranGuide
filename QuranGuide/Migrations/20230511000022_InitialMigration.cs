using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuranGuide.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "surahs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verses_count = table.Column<int>(type: "int", nullable: false),
                    revelation_type = table.Column<int>(type: "int", nullable: false),
                    chapter_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surahs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "verses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    surahId = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verses", x => new { x.id, x.surahId });
                    table.ForeignKey(
                        name: "FK_verses_surahs_surahId",
                        column: x => x.surahId,
                        principalTable: "surahs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_verses_surahId",
                table: "verses",
                column: "surahId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "verses");

            migrationBuilder.DropTable(
                name: "surahs");
        }
    }
}
