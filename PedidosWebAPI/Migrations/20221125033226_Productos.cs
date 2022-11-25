using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosWebAPI.Migrations
{
    public partial class Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Compradores_CompradorId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "CompradorId",
                table: "Productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Compradores_CompradorId",
                table: "Productos",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Compradores_CompradorId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "CompradorId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Compradores_CompradorId",
                table: "Productos",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
