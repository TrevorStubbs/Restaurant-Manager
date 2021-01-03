using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningLawInterviewRound1.Migrations
{
    public partial class RecipeIngredientsPrimaryKeyDefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "DishType", "Name" },
                values: new object[] { 1, 3, "Pie" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[] { 1, 10, "flour" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 1, "Pie with Icecream", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "RecipeId", "IngredientId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pie Recipe" });

            migrationBuilder.InsertData(
                table: "DishRecipes",
                columns: new[] { "DishId", "RecipeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MenuDishes",
                columns: new[] { "MenuId", "DishId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DeleteData(
                table: "DishRecipes",
                keyColumns: new[] { "DishId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuDishes",
                keyColumns: new[] { "MenuId", "DishId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
