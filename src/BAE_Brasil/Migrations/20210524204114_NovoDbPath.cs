using Microsoft.EntityFrameworkCore.Migrations;

namespace BAE_Brasil.Migrations
{
    public partial class NovoDbPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Degrees",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Degrees");
        }
    }
}
