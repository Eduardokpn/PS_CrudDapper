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
        /// <summary>
        /// Adiciona um novo endereço para uma pessoa no banco de dados.
        /// </summary>
        /// <param name="endereco">O objeto <see cref="Enderecos"/> contendo os dados do endereço a ser cadastrado.</param>
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

        /// <summary>
        /// Obtém os endereços de uma pessoa pelo ID da pessoa.
        /// </summary>
        /// <param name="id">O ID da pessoa cujos endereços serão recuperados.</param>
        /// <returns>Uma lista de objetos <see cref="Enderecos"/> contendo os endereços da pessoa.</returns>
        public IEnumerable<Enderecos> GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlEnderecos = "SELECT * FROM Enderecos WHERE PessoaId = @PessoaId";
                var enderecos = connection.Query<Enderecos>(sqlEnderecos, new { PessoaId = id });

                return enderecos;
            }
        }
        /// <summary>
        /// Exclui o endereço de uma pessoa pelo ID da pesso e o ID do endereço no banco de dados.
        /// </summary>
        /// <param name="pessoaId">O ID da pessoa cujos endereços serão excluidos.</param> <param name="id">O ID do endereço selecionado.</param>
        public void Excluir(int id, int pessoaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "Delete from Enderecos Where Id = @Id AND PessoaId = @PessoaId ";
                connection.Execute(sql, new { Id = id, PessoaId = pessoaId });
            }
        }
        /// <summary>
        /// Edita os dados do endereço de uma pessoa no banco de dados.
        /// </summary>
        /// <param name="endereco">O objeto <see cref="Enderecos"/> contendo os dados do endereço a ser editados</param>
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
