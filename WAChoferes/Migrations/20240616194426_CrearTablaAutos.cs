using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAChoferes.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaAutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    año = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");
        }
    }
}
