using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;

namespace Produtos.Infra.Data.Contextos
{
    public class ContextoPrincipal : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<LogExcecao> LogExcecao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuracoes.StringConexao);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //----------------------------------Produto------------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Guid).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasColumnType("VARCHAR(150)").IsRequired();

            //----------------------------------Fornecedor------------------------------------------------

            modelBuilder.Entity<Fornecedor>().Property(x => x.Guid).IsRequired();
            modelBuilder.Entity<Fornecedor>().Property(x => x.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            modelBuilder.Entity<Fornecedor>().Property(x => x.Email).HasColumnType("VARCHAR(150)").IsRequired();

            //----------------------------------LogExcecao------------------------------------------------
            
            modelBuilder.Entity<LogExcecao>().Property(x => x.Guid).IsRequired();
            modelBuilder.Entity<LogExcecao>().Property(x => x.Mensagem).HasColumnType("VARCHAR(500)").IsRequired();
            modelBuilder.Entity<LogExcecao>().Property(x => x.StackTrace).HasColumnType("VARCHAR(MAX)").IsRequired();
            modelBuilder.Entity<LogExcecao>().Property(x => x.Data).IsRequired();

        }

    }
}
