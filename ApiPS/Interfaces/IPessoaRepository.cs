using ApiPS.Models;

namespace ApiPS.Interface
{
    public interface IPessoaRepository
    {
        /// <summary>
        /// Obtém todas as pessoas cadastradas no banco de dados.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="Pessoas"/> contendo todas as pessoas.</returns>
        IEnumerable<Pessoas> GetAll();

        /// <summary>
        /// Obtém os dados de uma pessoa pelo ID.
        /// </summary>
        /// <param name="id">O ID da pessoa a ser recuperada.</param>
        /// <returns>O objeto <see cref="Pessoas"/> correspondente ao ID informado, ou null se não encontrado.</returns>
        Pessoas GetById(int id);

        /// <summary>
        /// Adiciona uma nova pessoa ao banco de dados.
        /// </summary>
        /// <param name="pessoa">O objeto <see cref="Pessoas"/> contendo os dados da pessoa a ser cadastrada.</param>
        /// <returns>O ID gerado para a nova pessoa cadastrada.</returns>
        int Add(Pessoas pessoa);

        /// <summary>
        /// Exclui uma pessoa pelo ID no banco de dados.
        /// </summary>
        /// <param name="id">O ID da pessoa cujos endereços serão excluidos.</param> <param name="id">O ID do endereço selecionado.</param>
        void Excluir(int id);

        /// <summary>
        /// Edita os dados de uma pessoa no banco de dados.
        /// </summary>
        /// <param name="endereco">O objeto <see cref="Pessoas"/> contendo os dados da pessoa a ser editada</param>
        void Editar(Pessoas pessoa);


    }
}
