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
        /// <summary>
        /// Obtém todas as pessoas cadastradas no banco de dados.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="Pessoas"/> contendo todas as pessoas.</returns>
        public IEnumerable<Pessoas> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoas>("SELECT * FROM Pessoas");

            }
        }

        /// <summary>
        /// Adiciona uma nova pessoa ao banco de dados.
        /// </summary>
        /// <param name="pessoa">O objeto <see cref="Pessoas"/> contendo os dados da pessoa a ser cadastrada.</param>
        /// <returns>O ID gerado para a nova pessoa cadastrada.</returns>
        public int Add(Pessoas pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Pessoas (Nome, Telefone, CPF) OUTPUT INSERTED.Id VALUES (@Nome, @Telefone, @CPF) ";

                int id = connection.ExecuteScalar<int>(sql, pessoa);

                return id;
            }
        }

        /// <summary>
        /// Obtém os dados de uma pessoa pelo ID.
        /// </summary>
        /// <param name="id">O ID da pessoa a ser recuperada.</param>
        /// <returns>O objeto <see cref="Pessoas"/> correspondente ao ID informado, ou null se não encontrado.</returns>
        public Pessoas GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlPessoa = "SELECT * FROM Pessoas WHERE Id = @Id";
                

                return connection.QueryFirstOrDefault<Pessoas>(sqlPessoa, new { Id = id });
            }
        }
        /// <summary>
        /// Exclui uma pessoa pelo ID no banco de dados.
        /// </summary>
        /// <param name="id">O ID da pessoa cujos endereços serão excluidos.</param> <param name="id">O ID do endereço selecionado.</param>
        public void Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "Delete from Pessoas Where Id = @Id";
                connection.Execute(sql, new { Id = id });

            }
        }
        /// <summary>
        /// Edita os dados de uma pessoa no banco de dados.
        /// </summary>
        /// <param name="endereco">O objeto <see cref="Pessoas"/> contendo os dados da pessoa a ser editada</param>
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
