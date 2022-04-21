namespace Produtos.Domain.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public Produto(string nome, string descricao, int fornecedorId)
        {
            Nome = nome;
            Descricao = descricao;
            FornecedorId = fornecedorId;
        }

        public Produto(int id, string nome, string descricao, int fornecedorId)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            FornecedorId = fornecedorId;
        }
    }
}
