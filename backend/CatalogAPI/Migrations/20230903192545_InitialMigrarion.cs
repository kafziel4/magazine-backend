using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrarion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Size = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Image = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Feminine = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Feminine", "Image", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Zara", false, "product-1.jpg", "Camisa Larga com Bolsos", 70m, "M" },
                    { 2, "Zara", true, "product-2.jpg", "Casaco Reto com Lã", 85m, "M" },
                    { 3, "Zara", false, "product-3.jpg", "Jaqueta com Efeito Camurça", 60m, "M" },
                    { 4, "Zara", false, "product-4.jpg", "Sobretudo em Mescla de Lã", 160m, "M" },
                    { 5, "Zara", false, "product-5.jpg", "Camisa Larga Acolchoada de Veludo Cotelê", 110m, "M" },
                    { 6, "Zara", true, "product-6.jpg", "Casaco de Lã com Botões", 170m, "M" },
                    { 7, "Zara", true, "product-7.jpg", "Casaco com Botões", 75m, "M" },
                    { 8, "Zara", true, "product-8.jpg", "Colete Comprido com Cinto", 88m, "M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
