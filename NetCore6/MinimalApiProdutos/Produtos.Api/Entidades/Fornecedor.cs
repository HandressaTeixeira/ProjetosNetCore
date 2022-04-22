using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.Entidades
{
    public class Fornecedor
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Fornecedor(string nome, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
        }

        public Fornecedor(Guid guid, string nome, string email)
        {
            Id = guid;
            Nome = nome;
            Email = email;
        }
    }
}
