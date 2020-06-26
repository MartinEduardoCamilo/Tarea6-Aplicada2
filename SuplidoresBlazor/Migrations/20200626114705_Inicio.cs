using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuplidoresBlazor.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    ordenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    suplidorId = table.Column<int>(nullable: false),
                    monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.ordenId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcion = table.Column<string>(nullable: true),
                    costo = table.Column<decimal>(nullable: false),
                    inventario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    suplidorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.suplidorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    ordenDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ordenId = table.Column<int>(nullable: false),
                    productoId = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.ordenDetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_ordenId",
                        column: x => x.ordenId,
                        principalTable: "Ordenes",
                        principalColumn: "ordenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 1, 100m, "Cacao", 0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 2, 100m, "Chocolate", 0 });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "suplidorId", "nombre" },
                values: new object[] { 1, "Rizek" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "suplidorId", "nombre" },
                values: new object[] { 2, "Supremo" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ordenId",
                table: "OrdenesDetalle",
                column: "ordenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
