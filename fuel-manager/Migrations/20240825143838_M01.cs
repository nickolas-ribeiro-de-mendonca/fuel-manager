using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fuel_manager.Migrations
{
    /// <inheritdoc />
    public partial class M01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consumos_Veiculos_VeiculoId",
                table: "consumos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_consumos",
                table: "consumos");

            migrationBuilder.RenameTable(
                name: "consumos",
                newName: "Consumos");

            migrationBuilder.RenameIndex(
                name: "IX_consumos_VeiculoId",
                table: "Consumos",
                newName: "IX_Consumos_VeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumos",
                table: "Consumos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumos_Veiculos_VeiculoId",
                table: "Consumos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumos_Veiculos_VeiculoId",
                table: "Consumos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumos",
                table: "Consumos");

            migrationBuilder.RenameTable(
                name: "Consumos",
                newName: "consumos");

            migrationBuilder.RenameIndex(
                name: "IX_Consumos_VeiculoId",
                table: "consumos",
                newName: "IX_consumos_VeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_consumos",
                table: "consumos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_consumos_Veiculos_VeiculoId",
                table: "consumos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
