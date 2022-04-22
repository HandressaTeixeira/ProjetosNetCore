using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.Entidades
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Guid FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public Produto(string nome, string descricao, Guid fornecedorId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            FornecedorId = fornecedorId;
        }

        public Produto(Guid guid, string nome, string descricao, Guid fornecedorId)
        {
            Id = guid;
            Nome = nome;
            Descricao = descricao;
            FornecedorId = fornecedorId;
        }
    }
}
