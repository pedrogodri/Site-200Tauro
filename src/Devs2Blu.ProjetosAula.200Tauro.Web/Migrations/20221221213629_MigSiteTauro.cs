using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Migrations
{
    public partial class MigSiteTauro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoSistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoSistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newsletter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conteudo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conteudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conteudo_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteudoId = table.Column<int>(type: "int", nullable: false),
                    EnderecoImagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagem_conteudo_ConteudoId",
                        column: x => x.ConteudoId,
                        principalTable: "conteudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Camisa" },
                    { 2, "Calça" },
                    { 3, "Calçado" },
                    { 4, "Casaco" }
                });

            migrationBuilder.InsertData(
                table: "ConfiguracaoSistema",
                columns: new[] { "Id", "Contato", "Endereco", "NomeSite" },
                values: new object[] { 1, "200Tauro@gmail.com", "Rua Bahia 21345", "200Tauro" });

            migrationBuilder.InsertData(
                table: "Newsletter",
                columns: new[] { "Id", "Ativo", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, true, "patrick.weber@gmail.com", "Patrick Weber" },
                    { 2, true, "gustavo.soares@gmail.com", "Gustavo Soares" },
                    { 3, true, "pedro.godri@gmail.com", "Pedro Godri" },
                    { 4, true, "alexandre.schwanke", "Alexandre Schwanke" }
                });

            migrationBuilder.InsertData(
                table: "conteudo",
                columns: new[] { "Id", "CategoriaId", "CreatedDate", "Descricao", "IsDeleted", "IsPublished", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 21, 18, 36, 29, 113, DateTimeKind.Local).AddTicks(9585), "Camisa para corrida", false, true, "Camiseta Adidas" },
                    { 2, 2, new DateTime(2022, 12, 21, 18, 36, 29, 113, DateTimeKind.Local).AddTicks(9593), "Calça para corrida", false, true, "Calça Tactel" },
                    { 3, 3, new DateTime(2022, 12, 21, 18, 36, 29, 113, DateTimeKind.Local).AddTicks(9594), "Tênis para caminhada", false, true, "Nike Shock" },
                    { 4, 4, new DateTime(2022, 12, 21, 18, 36, 29, 113, DateTimeKind.Local).AddTicks(9594), "Casaco térmico", false, true, "Casaco Adidas" }
                });

            migrationBuilder.InsertData(
                table: "Imagem",
                columns: new[] { "Id", "ConteudoId", "EnderecoImagem" },
                values: new object[,]
                {
                    { 1, 1, "https://img.elo7.com.br/product/original/17B1547/camisa-sublimacao-poliester.jpg" },
                    { 2, 2, "https://www.invictus.com.br/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/e/legion-azul-frente.jpg" },
                    { 3, 3, "https://laranjeiras.vteximg.com.br/arquivos/ids/164819/sapato-tip-toye.png?v=637265382501400000" },
                    { 4, 4, "https://cf.shopee.com.br/file/f17747dd62386f0febadf6f1418480fa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_conteudo_CategoriaId",
                table: "conteudo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ConteudoId",
                table: "Imagem",
                column: "ConteudoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoSistema");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Newsletter");

            migrationBuilder.DropTable(
                name: "conteudo");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
