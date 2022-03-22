using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dados.Migrations
{
    public partial class adicionaidcarroreserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarroId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarroId",
                table: "Reserva");
        }
    }
}
