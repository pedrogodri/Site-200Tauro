using Microsoft.EntityFrameworkCore;
using Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models
{
    public class ContextoDatabase : DbContext
    {
        public ContextoDatabase(DbContextOptions<ContextoDatabase> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Categoria>()
             .HasData(
             new { Id = 1, Nome = "Camisa" },
             new { Id = 2, Nome = "Calça" },
             new { Id = 3, Nome = "Calçado" },
             new { Id = 4, Nome = "Casaco" }
             );

            modelBuilder.Entity<Conteudo>()
                .HasData(
                new { Id = 1, Titulo = "Camiseta Adidas", Descricao = "Camisa para corrida", CategoriaId = 1, IsPublished = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new { Id = 2, Titulo = "Calça Tactel", Descricao = "Calça para corrida", CategoriaId = 2, IsPublished = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new { Id = 3, Titulo = "Nike Shock", Descricao = "Tênis para caminhada", CategoriaId = 3, IsPublished = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new { Id = 4, Titulo = "Casaco Adidas", Descricao = "Casaco térmico", CategoriaId = 4, IsPublished = true, IsDeleted = false, CreatedDate = DateTime.Now }
                );

            modelBuilder.Entity<Imagem>()
                .HasData(
                new { Id = 1, ConteudoId = 1, EnderecoImagem = "https://img.elo7.com.br/product/original/17B1547/camisa-sublimacao-poliester.jpg" },
                new { Id = 2, ConteudoId = 2, EnderecoImagem = "https://www.invictus.com.br/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/e/legion-azul-frente.jpg" },
                new { Id = 3, ConteudoId = 3, EnderecoImagem = "https://laranjeiras.vteximg.com.br/arquivos/ids/164819/sapato-tip-toye.png?v=637265382501400000" },
                new { Id = 4, ConteudoId = 4, EnderecoImagem = "https://cf.shopee.com.br/file/f17747dd62386f0febadf6f1418480fa" }
                );

            modelBuilder.Entity<Newsletter>()
              .HasData(
              new { Id = 1, Nome = "Patrick Weber", Email = "patrick.weber@gmail.com", Ativo = true },
              new { Id = 2, Nome = "Gustavo Soares", Email = "gustavo.soares@gmail.com", Ativo = true },
              new { Id = 3, Nome = "Pedro Godri", Email = "pedro.godri@gmail.com", Ativo = true },
              new { Id = 4, Nome = "Alexandre Schwanke", Email = "alexandre.schwanke", Ativo = true }
              );

            modelBuilder.Entity<ConfiguracaoSistema>()
                .HasData(
                new { Id = 1, NomeSite = "200Tauro", Contato = "200Tauro@gmail.com", Endereco = "Rua Bahia 21345" }
                );

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<ConfiguracaoSistema> ConfiguracaoSistema { get; set; }
        public DbSet<Newsletter> Newsletter { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Conteudo> Conteudo { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        #endregion
    }
}
