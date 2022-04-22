using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Domain.Entidades
{
    public class Fornecedor
    {
        [Key]
        public Guid Guid { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Fornecedor(string nome, string email)
        {
            Guid = Guid.NewGuid();
            Nome = nome;
            Email = email;
        }

        public Fornecedor(Guid guid, string nome, string email)
        {
            Guid = guid;
            Nome = nome;
            Email = email;
        }
    }
}
