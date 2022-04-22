using Microsoft.EntityFrameworkCore;
using Produtos.Api.Entidades;

namespace Produtos.Api.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuracoes.StringConexao);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //----------------------------------Produto------------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasColumnType("VARCHAR(150)").IsRequired();

            //----------------------------------Fornecedor------------------------------------------------

            modelBuilder.Entity<Fornecedor>().Property(x => x.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            modelBuilder.Entity<Fornecedor>().Property(x => x.Email).HasColumnType("VARCHAR(150)").IsRequired();

        }

    }
}
