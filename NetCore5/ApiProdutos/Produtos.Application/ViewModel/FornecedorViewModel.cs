using System.ComponentModel.DataAnnotations;

namespace Produtos.Application.ViewModel
{
    public class InserirFornecedorViewModel
    {
        [Required(ErrorMessage = "Nome do fornecedor é obrigatório")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email do fornecedor é obrigatório")]
        [MaxLength(150, ErrorMessage = "E-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }
    }

    public class AtualizarFornecedorViewModel
    {

        [Required(ErrorMessage = "Id do fornecedor é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do fornecedor é obrigatório")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail do fornecedor é obrigatório")]
        [MaxLength(150, ErrorMessage = "E-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }
    }
}
