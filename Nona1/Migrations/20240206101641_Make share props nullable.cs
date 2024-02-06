using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nona1.Migrations
{
    public partial class Makesharepropsnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Collabs_CollabId1",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "CollabId1",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CollabId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Collabs_CollabId1",
                table: "Items",
                column: "CollabId1",
                principalTable: "Collabs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Collabs_CollabId1",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "CollabId1",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollabId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Collabs_CollabId1",
                table: "Items",
                column: "CollabId1",
                principalTable: "Collabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
