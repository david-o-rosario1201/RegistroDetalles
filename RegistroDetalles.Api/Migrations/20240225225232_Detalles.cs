using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDetalles.Api.Migrations
{
    /// <inheritdoc />
    public partial class Detalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketsDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    Emisor = table.Column<string>(type: "TEXT", nullable: false),
                    Mensaje = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsDetalles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsDetalles");
        }
    }
}
