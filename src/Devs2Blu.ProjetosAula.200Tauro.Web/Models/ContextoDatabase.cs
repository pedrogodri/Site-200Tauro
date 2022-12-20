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
            // Mapeamento de Relacionamento
            modelBuilder.Entity<Conteudo>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Conteudos)
                .HasForeignKey(p => p.CategoriaId);

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
