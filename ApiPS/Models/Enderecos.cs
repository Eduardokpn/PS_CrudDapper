namespace ApiPS.Models
{
    public class Enderecos
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Logradouro { get; set; }
        public int CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}
