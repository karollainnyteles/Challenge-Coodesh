using Microsoft.EntityFrameworkCore.Migrations;

namespace Coodesh.Challenge.Data.Migrations
{
    public partial class AddColumnSynchronizedArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SynchronizedArticles",
                table: "SynchronizationControl",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SynchronizedArticles",
                table: "SynchronizationControl");
        }
    }
}
