using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasteTrailApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenuDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
