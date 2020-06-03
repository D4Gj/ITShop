using Microsoft.EntityFrameworkCore.Migrations;

namespace ITShopDatabaseImplement.Migrations
{
    public partial class updOrderPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Summ",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summ",
                table: "OrderProducts");
        }
    }
}
