using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class AddTableDataOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataOutput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Output_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<Guid>(nullable: false),
                    Method_Controll = table.Column<bool>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true),
                    OutputId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataOutput_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataOutput_OUTPUT_OutputId",
                        column: x => x.OutputId,
                        principalTable: "OUTPUT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataOutput_CustomerId",
                table: "DataOutput",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOutput_OutputId",
                table: "DataOutput",
                column: "OutputId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataOutput");
        }
    }
}
