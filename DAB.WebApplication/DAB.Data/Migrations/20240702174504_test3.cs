using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RecetteIngredients",
                table: "RecetteIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecetteIngredients_RecetteId",
                table: "RecetteIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RecetteIngredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecetteIngredients",
                table: "RecetteIngredients",
                columns: new[] { "RecetteId", "IngredientId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RecetteIngredients",
                table: "RecetteIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RecetteIngredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecetteIngredients",
                table: "RecetteIngredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_RecetteId",
                table: "RecetteIngredients",
                column: "RecetteId");
        }
    }
}
