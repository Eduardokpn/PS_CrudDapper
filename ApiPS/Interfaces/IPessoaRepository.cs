using ApiPS.Models;

namespace ApiPS.Interface
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoas> GetAll();
        Pessoas GetById(int id);
        int Add(Pessoas pessoa);
        void Excluir(int id);
        void Editar(Pessoas pessoa);


    }
}
