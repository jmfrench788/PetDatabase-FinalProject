using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetServices_MVC.Data.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptablePets_PetTypes_PetTypeId",
                table: "AdoptablePets");

            migrationBuilder.RenameColumn(
                name: "PetTypeId",
                table: "AdoptablePets",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptablePets_PetTypeId",
                table: "AdoptablePets",
                newName: "IX_AdoptablePets_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptablePets_PetTypes_TypeId",
                table: "AdoptablePets",
                column: "TypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptablePets_PetTypes_TypeId",
                table: "AdoptablePets");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "AdoptablePets",
                newName: "PetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptablePets_TypeId",
                table: "AdoptablePets",
                newName: "IX_AdoptablePets_PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptablePets_PetTypes_PetTypeId",
                table: "AdoptablePets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
