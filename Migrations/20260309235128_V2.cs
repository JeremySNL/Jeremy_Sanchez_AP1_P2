using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jeremy_Sanchez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoPuntoId",
                table: "DetallesAsignaciones",
                newName: "TipoId");

            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "DetallesAsignaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "DetallesAsignaciones");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "DetallesAsignaciones",
                newName: "TipoPuntoId");
        }
    }
}
