using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDetalles.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SistemaId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Tickets",
                table: "TicketsDetalles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prioridad",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sistema",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsDetalles_Tickets",
                table: "TicketsDetalles",
                column: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsDetalles_Tickets_Tickets",
                table: "TicketsDetalles",
                column: "Tickets",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsDetalles_Tickets_Tickets",
                table: "TicketsDetalles");

            migrationBuilder.DropIndex(
                name: "IX_TicketsDetalles_Tickets",
                table: "TicketsDetalles");

            migrationBuilder.DropColumn(
                name: "Tickets",
                table: "TicketsDetalles");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Prioridad",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Sistema",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SistemaId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
