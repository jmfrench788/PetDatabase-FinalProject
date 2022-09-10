using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetServices_MVC.Data.Migrations
{
    public partial class Forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetTypeId",
                table: "Pets");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TypeId",
                table: "Pets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_TypeId",
                table: "Pets",
                column: "TypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_TypeId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_TypeId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetTypeId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
