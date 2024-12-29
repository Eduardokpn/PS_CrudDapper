using ApiPS.Interface;
using ApiPS.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ApiPS.Interfaces.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _connectionString;

        public EnderecoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConexaoNuvem");

        }

        public void Add(Enderecos endereco)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
            INSERT INTO Enderecos (PessoaId, Logradouro, CEP, Cidade, Estado) 
            VALUES (@PessoaId, @Logradouro, @CEP, @Cidade, @Estado)";


                connection.Execute(sql, endereco);
            }
        }

        public IEnumerable<Enderecos> GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlEnderecos = "SELECT * FROM Enderecos WHERE PessoaId = @PessoaId";
                var enderecos = connection.Query<Enderecos>(sqlEnderecos, new { PessoaId = id });

                return enderecos;
            }
        }

        public void Excluir(int id, int pessoaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "Delete from Enderecos Where Id = @Id AND PessoaId = @PessoaId ";
                connection.Execute(sql, new { Id = id, PessoaId = pessoaId });
            }
        }

        public void Editar(Enderecos endereco)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Enderecos SET Logradouro = @Logradouro, CEP = @CEP, Cidade = @Cidade, Estado = @Estado WHERE Id = @Id AND PessoaId = @PessoaId";
                connection.Execute(sql, new { endereco.Logradouro, endereco.CEP, endereco.Cidade, endereco.Estado, endereco.Id, endereco.PessoaId });
            }

        }


    }
}
