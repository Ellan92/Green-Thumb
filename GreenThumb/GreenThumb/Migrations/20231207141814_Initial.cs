using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    garden_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Gardens_garden_id",
                        column: x => x.garden_id,
                        principalTable: "Gardens",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantGardens",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantGardens", x => new { x.PlantId, x.GardenId });
                    table.ForeignKey(
                        name: "FK_PlantGardens_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantGardens_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gardens",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "usergarden" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Resilient succulent plants adapted to arid climates, are known for their unique appearance featuring fleshy stems and spines", "Cactus" },
                    { 2, "Renowned for its exquisite flowers and fragrant aroma, the rose is a symbol of love and beauty, cultivated in various colors and varieties worldwide.", "Rose" },
                    { 3, "Recognizable for its large, yellow flower head, the sunflower is not only visually striking but also known for its heliotropic behavior, following the sun's movement.", "Sunflower" },
                    { 4, "Boasting a vast and diverse family, orchids are prized for their intricate and exotic blooms, making them popular choices in the world of ornamental plants and horticulture.", "Orchid" },
                    { 5, "Iconic for its vibrant autumn foliage, the maple tree is appreciated for its diverse species, including those valued for timber, syrup production, and ornamental landscaping.", "Maple Tree" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "garden_id", "password", "username" },
                values: new object[] { 1, null, "password", "user" });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "id", "plant_id", "text" },
                values: new object[,]
                {
                    { 1, 1, "Ensure correct lighting" },
                    { 2, 1, "Water cactus" },
                    { 3, 2, "Ensure correct lighting" },
                    { 4, 2, "Use well-draining soil" },
                    { 5, 2, "Water rose" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGardens_GardenId",
                table: "PlantGardens",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_garden_id",
                table: "Users",
                column: "garden_id",
                unique: true,
                filter: "[garden_id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "PlantGardens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Gardens");
        }
    }
}
