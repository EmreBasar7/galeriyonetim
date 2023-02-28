using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galeriyonetim.Migrations
{
    public partial class build_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "arac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracMarka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AracModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AracYılı = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arac", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arac");
        }
    }
}
