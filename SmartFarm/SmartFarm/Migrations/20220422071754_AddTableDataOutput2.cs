using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class AddTableDataOutput2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodControll",
                table: "DataOutput");

            migrationBuilder.AddColumn<bool>(
                name: "ThongSo",
                table: "DataOutput",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThongSo",
                table: "DataOutput");

            migrationBuilder.AddColumn<bool>(
                name: "MethodControll",
                table: "DataOutput",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
