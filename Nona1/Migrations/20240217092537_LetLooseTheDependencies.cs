using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nona1.Migrations
{
    public partial class LetLooseTheDependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollabId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CollabId1",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtistCollab",
                columns: table => new
                {
                    ArtistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollabsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistCollab", x => new { x.ArtistsId, x.CollabsId });
                    table.ForeignKey(
                        name: "FK_ArtistCollab_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistCollab_Collabs_CollabsId",
                        column: x => x.CollabsId,
                        principalTable: "Collabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistItem",
                columns: table => new
                {
                    ArtistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistItem", x => new { x.ArtistsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ArtistItem_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollabId1",
                table: "Items",
                column: "CollabId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistCollab_CollabsId",
                table: "ArtistCollab",
                column: "CollabsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistItem_ItemsId",
                table: "ArtistItem",
                column: "ItemsId");

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

            migrationBuilder.DropTable(
                name: "ArtistCollab");

            migrationBuilder.DropTable(
                name: "ArtistItem");

            migrationBuilder.DropIndex(
                name: "IX_Items_CollabId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CollabId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CollabId1",
                table: "Items");
        }
    }
}
