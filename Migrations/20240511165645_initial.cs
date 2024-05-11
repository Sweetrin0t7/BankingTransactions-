using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankCrud.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ContaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Saldo = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ContaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    TransacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaOrigemId = table.Column<int>(type: "int", nullable: false),
                    ContaDestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.TransacaoId);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_ContaDestinoId",
                        column: x => x.ContaDestinoId,
                        principalTable: "Conta",
                        principalColumn: "ContaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_ContaOrigemId",
                        column: x => x.ContaOrigemId,
                        principalTable: "Conta",
                        principalColumn: "ContaId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaDestinoId",
                table: "Transacao",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaOrigemId",
                table: "Transacao",
                column: "ContaOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
