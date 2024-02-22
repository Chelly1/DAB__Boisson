using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB.Data.Migrations
{
    public partial class kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boissons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecetteId1 = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoissonStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boissons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boissons_Recettes_RecetteId1",
                        column: x => x.RecetteId1,
                        principalTable: "Recettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RecetteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recettes_RecetteId",
                        column: x => x.RecetteId,
                        principalTable: "Recettes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecetteIngredients",
                columns: table => new
                {
                    Recette_Id = table.Column<int>(type: "int", nullable: false),
                    Ingredient_Id = table.Column<int>(type: "int", nullable: false),
                    Id_Recette_Ingrediant = table.Column<int>(type: "int", nullable: false),
                    RecetteId = table.Column<int>(type: "int", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    Dose = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetteIngredients", x => new { x.Ingredient_Id, x.Recette_Id });
                    table.ForeignKey(
                        name: "FK_RecetteIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecetteIngredients_Recettes_RecetteId",
                        column: x => x.RecetteId,
                        principalTable: "Recettes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boissons_RecetteId1",
                table: "Boissons",
                column: "RecetteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecetteId",
                table: "Ingredients",
                column: "RecetteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_IngredientId",
                table: "RecetteIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_RecetteId",
                table: "RecetteIngredients",
                column: "RecetteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boissons");

            migrationBuilder.DropTable(
                name: "RecetteIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recettes");
        }
    }
}
