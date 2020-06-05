using Microsoft.EntityFrameworkCore.Migrations;

namespace ITShopDatabaseImplement.Migrations
{
    public partial class CreateStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Left",
                table: "RequestComponents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Left",
                table: "RequestComponents");
        }
    }
}
