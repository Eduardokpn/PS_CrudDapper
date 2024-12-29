using ApiPS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ApiPS.Interface
{
    public interface IEnderecoRepository
    {
        /// <summary>
        /// Adiciona um novo endereço para uma pessoa no banco de dados.
        /// </summary>
        /// <param name="endereco">O objeto <see cref="Enderecos"/> contendo os dados do endereço a ser cadastrado.</param>
        void Add(Enderecos endereco);
        
        /// <summary>
        /// Obtém os endereços de uma pessoa pelo ID da pessoa.
        /// </summary>
        /// <param name="id">O ID da pessoa cujos endereços serão recuperados.</param>
        /// <returns>Uma lista de objetos <see cref="Enderecos"/> contendo os endereços da pessoa.</returns>
        IEnumerable<Enderecos> GetById(int id);

        /// <summary>
        /// Exclui o endereço de uma pessoa pelo ID da pesso e o ID do endereço no banco de dados.
        /// </summary>
        /// <param name="pessoaId">O ID da pessoa cujos endereços serão excluidos.</param> <param name="id">O ID do endereço selecionado.</param>
        void Excluir(int id, int pessoaId);

        /// <summary>
        /// Edita os dados do endereço de uma pessoa no banco de dados.
        /// </summary>
        /// <param name="endereco">O objeto <see cref="Enderecos"/> contendo os dados do endereço a ser editados</param>
        void Editar(Enderecos endereco);

        
    }
}
