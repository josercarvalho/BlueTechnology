using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JC_BlueTec.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    datanascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cep = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    logradouro = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    complemento = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    bairro = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    localidade = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    uf = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
