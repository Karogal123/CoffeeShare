using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShare.Infrastructure.Migrations
{
    public partial class RecipeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoffeeId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CoffeeId",
                table: "Recipes",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Coffees_CoffeeId",
                table: "Recipes",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Coffees_CoffeeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CoffeeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CoffeeId",
                table: "Recipes");
        }
    }
}
