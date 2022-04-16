using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;

namespace Produtos.Infra.Data.Contextos
{
    public class ContextoPrincipal : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuracoes.StringConexao);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Não adicionado configurações de chaves primarias, estrangeiras e um pra muitos 
             * porque o entity framwork identifica automaticamente*/


            //----------------------------------Produto------------------------------------------------

            //TODO: Verificar porque HasColumnType não esta sendo encontrado
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasMaxLength(250).IsRequired();

            //----------------------------------Fornecedor------------------------------------------------

            //TODO: Verificar porque HasColumnType não esta sendo encontrado
            modelBuilder.Entity<Fornecedor>().Property(x => x.Nome).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Fornecedor>().Property(x => x.Email).HasMaxLength(150).IsRequired();
        }

    }
}
