using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Domain.Entidades
{
    public class Produto
    {
        [Key]
        public Guid Guid { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Guid FornecedorGuid { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public Produto(string nome, string descricao, Guid fornecedorGuid)
        {
            Guid = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            FornecedorGuid = fornecedorGuid;
        }

        public Produto(Guid guid, string nome, string descricao, Guid fornecedorGuid)
        {
            Guid = guid;
            Nome = nome;
            Descricao = descricao;
            FornecedorGuid = fornecedorGuid;
        }
    }
}
