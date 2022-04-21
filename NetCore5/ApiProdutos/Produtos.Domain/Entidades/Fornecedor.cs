namespace Produtos.Domain.Entidades
{
    public class Fornecedor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Fornecedor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Fornecedor(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
