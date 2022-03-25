using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class Dinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_INPUTOUTPUT",
                table: "INPUTOUTPUT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_INPUTOUTPUT",
                table: "INPUTOUTPUT",
                columns: new[] { "IdInput", "IdOutput" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_INPUTOUTPUT",
                table: "INPUTOUTPUT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_INPUTOUTPUT",
                table: "INPUTOUTPUT",
                column: "IdInput");
        }
    }
}
