using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class plants_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
