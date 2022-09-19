using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cadastroCliente.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadoCivils",
                columns: table => new
                {
                    estadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solteiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    casado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    divorciado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    viuvo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoCivils", x => x.estadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valorCompra = table.Column<double>(type: "float", nullable: false),
                    comprimento = table.Column<double>(type: "float", nullable: false),
                    largura = table.Column<double>(type: "float", nullable: false),
                    altura = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rg = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<int>(type: "int", nullable: false),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cep = table.Column<int>(type: "int", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadoCivilId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_estadoCivils_estadoCivilId",
                        column: x => x.estadoCivilId,
                        principalTable: "estadoCivils",
                        principalColumn: "estadoCivilId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_estadoCivilId",
                table: "Cliente",
                column: "estadoCivilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "estadoCivils");
        }
    }
}
