using ApiPS.Interface;
using ApiPS.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace ApiPS.Interfaces.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _connectionString;
        public PessoaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConexaoNuvem");

        }

        public IEnumerable<Pessoas> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoas>("SELECT * FROM Pessoas");

            }
        }


        public int Add(Pessoas pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Pessoas (Nome, Telefone, CPF) OUTPUT INSERTED.Id VALUES (@Nome, @Telefone, @CPF) ";

                int id = connection.ExecuteScalar<int>(sql, pessoa);

                return id;
            }
        }


        public Pessoas GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlPessoa = "SELECT * FROM Pessoas WHERE Id = @Id";
                

                return connection.QueryFirstOrDefault<Pessoas>(sqlPessoa, new { Id = id });
            }
        }

        public void Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "Delete from Pessoas Where Id = @Id";
                string sqlD = "DELETE FROM Enderecos WHERE PessoaId = @Id";
                connection.Execute(sqlD, new { Id = id });
                connection.Execute(sql, new { Id = id });

            }
        }

        public void Editar(Pessoas pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Pessoas SET Nome = @Nome, Telefone = @Telefone, CPF = @CPF WHERE Id = @Id";
                connection.Execute(sql, new { pessoa.Nome, pessoa.Telefone, pessoa.CPF, pessoa.Id });
            }
        }




        }
}
