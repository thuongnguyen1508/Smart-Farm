using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartFarm.Migrations
{
    public partial class AddTableDataOutput1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOutput_OUTPUT_OutputId",
                table: "DataOutput");

            migrationBuilder.DropColumn(
                name: "Method_Controll",
                table: "DataOutput");

            migrationBuilder.DropColumn(
                name: "Output_Id",
                table: "DataOutput");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "DataOutput");

            migrationBuilder.AlterColumn<int>(
                name: "OutputId",
                table: "DataOutput",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MethodControll",
                table: "DataOutput",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DataOutput",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOutput_OUTPUT_OutputId",
                table: "DataOutput",
                column: "OutputId",
                principalTable: "OUTPUT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOutput_OUTPUT_OutputId",
                table: "DataOutput");

            migrationBuilder.DropColumn(
                name: "MethodControll",
                table: "DataOutput");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DataOutput");

            migrationBuilder.AlterColumn<int>(
                name: "OutputId",
                table: "DataOutput",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Method_Controll",
                table: "DataOutput",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Output_Id",
                table: "DataOutput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "User_Id",
                table: "DataOutput",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_DataOutput_OUTPUT_OutputId",
                table: "DataOutput",
                column: "OutputId",
                principalTable: "OUTPUT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
