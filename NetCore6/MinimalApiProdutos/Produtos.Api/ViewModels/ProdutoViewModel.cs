using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.ViewModels
{
    public class InserirProdutoViewModel
    {
        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descricao do produto é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "FornecedorId do produto é obrigatório")]
        public Guid FornecedorId { get; set; }
    }

    public class AtualizarProdutoViewModel
    {
        [Required(ErrorMessage = "Guid do produto é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descricao do produto é obrigatório")]
        [MaxLength(150, ErrorMessage = "Descricao deve ter no máximo 150 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "FornecedorId do produto é obrigatório")]
        public Guid FornecedorId { get; set; }
    }
}
