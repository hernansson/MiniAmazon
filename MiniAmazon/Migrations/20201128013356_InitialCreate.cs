using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniAmazon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreada = table.Column<DateTimeOffset>(nullable: false),
                    FechaModificada = table.Column<DateTimeOffset>(nullable: false),
                    vigente = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    MetaDescripcion = table.Column<string>(nullable: true),
                    CategoriaStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreada = table.Column<DateTimeOffset>(nullable: false),
                    FechaModificada = table.Column<DateTimeOffset>(nullable: false),
                    vigente = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    MetaDescripcion = table.Column<string>(nullable: true),
                    MarcaStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreada = table.Column<DateTimeOffset>(nullable: false),
                    FechaModificada = table.Column<DateTimeOffset>(nullable: false),
                    vigente = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    MetaDescripcion = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    CantStock = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<long>(nullable: false),
                    MarcaId = table.Column<long>(nullable: false),
                    ProductoStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
