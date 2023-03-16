using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.DDD.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventosAlmacenados",
                columns: table => new
                {
                    AlmacenadoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlmacenadoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgregadoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuerpoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosAlmacenados", x => x.AlmacenadoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventosAlmacenados");
        }
    }
}
