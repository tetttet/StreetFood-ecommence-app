using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetFood.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesInIngredientTableAndPropertiesIntStockProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_IngredientId",
                table: "StockProducts",
                column: "IngredientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Ingredients_IngredientId",
                table: "StockProducts",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Ingredients_IngredientId",
                table: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_StockProducts_IngredientId",
                table: "StockProducts");
        }
    }
}
