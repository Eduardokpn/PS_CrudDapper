using System.ComponentModel.DataAnnotations;

namespace ApiPS.Models
{
    public class Pessoas
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [StringLength(15, ErrorMessage = "O Telefone deve ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF deve ter no máximo 14 caracteres.")]
        public string CPF { get; set; }
    }
}
