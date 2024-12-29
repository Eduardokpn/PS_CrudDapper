namespace ApiPS.Models
{
    public class PessoaEnderecoViewModel
    {
        public Pessoas Pessoa { get; set; }
        public IEnumerable<Enderecos> Enderecos { get; set; }
    }
}
