using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INPUTOUTPUT");

            migrationBuilder.DropColumn(
                name: "ViTriTrangTrai",
                table: "OUTPUT");

            migrationBuilder.DropColumn(
                name: "ViTriTrangTrai",
                table: "INPUT");

            migrationBuilder.AddColumn<string>(
                name: "FeedName",
                table: "OUTPUT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedName",
                table: "INPUT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedName",
                table: "OUTPUT");

            migrationBuilder.DropColumn(
                name: "FeedName",
                table: "INPUT");

            migrationBuilder.AddColumn<string>(
                name: "ViTriTrangTrai",
                table: "OUTPUT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViTriTrangTrai",
                table: "INPUT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "INPUTOUTPUT",
                columns: table => new
                {
                    IdInput = table.Column<int>(type: "int", nullable: false),
                    IdOutput = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INPUTOUTPUT", x => new { x.IdInput, x.IdOutput });
                    table.ForeignKey(
                        name: "FK_INPUTOUTPUT_INPUT_IdInput",
                        column: x => x.IdInput,
                        principalTable: "INPUT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_INPUTOUTPUT_OUTPUT_IdOutput",
                        column: x => x.IdOutput,
                        principalTable: "OUTPUT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_INPUTOUTPUT_IdOutput",
                table: "INPUTOUTPUT",
                column: "IdOutput");
        }
    }
}
