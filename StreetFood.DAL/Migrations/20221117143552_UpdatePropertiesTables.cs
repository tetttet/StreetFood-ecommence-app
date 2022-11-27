using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetFood.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertiesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Orders_OrderId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Contents_ContentId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_ContentId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_OrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Dishes");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                column: "DishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_IngredientId",
                table: "Contents",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Ingredients_IngredientId",
                table: "Contents",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Ingredients_IngredientId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DishId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Contents_IngredientId",
                table: "Contents");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ContentId",
                table: "Ingredients",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_OrderId",
                table: "Dishes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Orders_OrderId",
                table: "Dishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Contents_ContentId",
                table: "Ingredients",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id");
        }
    }
}
