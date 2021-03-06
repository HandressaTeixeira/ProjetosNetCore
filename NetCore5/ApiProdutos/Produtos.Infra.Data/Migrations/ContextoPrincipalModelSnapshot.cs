// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Produtos.Infra.Data.Contextos;

namespace Produtos.Infra.Data.Migrations
{
    [DbContext(typeof(ContextoPrincipal))]
    partial class ContextoPrincipalModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Produtos.Domain.Entidades.Fornecedor", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Guid");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Produtos.Domain.Entidades.LogExcecao", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("Guid");

                    b.ToTable("LogExcecao");
                });

            modelBuilder.Entity("Produtos.Domain.Entidades.Produto", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<Guid>("FornecedorGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Guid");

                    b.HasIndex("FornecedorGuid");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Produtos.Domain.Entidades.Produto", b =>
                {
                    b.HasOne("Produtos.Domain.Entidades.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
