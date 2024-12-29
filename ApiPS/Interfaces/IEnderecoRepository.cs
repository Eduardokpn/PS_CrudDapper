using ApiPS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ApiPS.Interface
{
    public interface IEnderecoRepository
    {
        void Add(Enderecos endereco);
        IEnumerable<Enderecos> GetById(int id);
        void Excluir(int id, int pessoaId);
        void Editar(Enderecos endereco);
        
    }
}
