using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetServices_MVC.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetServices_CurrentServiceId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_CurrentServiceId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CurrentServiceId",
                table: "Pets");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ServiceId",
                table: "Pets",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetServices_ServiceId",
                table: "Pets",
                column: "ServiceId",
                principalTable: "PetServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetServices_ServiceId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ServiceId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "CurrentServiceId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CurrentServiceId",
                table: "Pets",
                column: "CurrentServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetServices_CurrentServiceId",
                table: "Pets",
                column: "CurrentServiceId",
                principalTable: "PetServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
