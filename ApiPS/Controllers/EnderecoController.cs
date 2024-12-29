using ApiPS.Interface;
using ApiPS.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ApiPS.Controllers
{


    public class EnderecoController : Controller
    {
        private readonly string _conectionString;
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoController(IConfiguration configuration, IEnderecoRepository enderecoRepository) 
        {
            _conectionString = configuration.GetConnectionString("ConexaoNuvem");
            _enderecoRepository = enderecoRepository;
        
        }

        [HttpPost]
        public IActionResult Cadastrar(Enderecos endereco)
        {
            _enderecoRepository.Add(endereco);
            return RedirectToAction("Editar", "Pessoa", new { id = endereco.PessoaId });
        }

        [HttpPost]
        public IActionResult Excluir(int id, int pessoaId)
        {
            _enderecoRepository.Excluir(id, pessoaId);
            return RedirectToAction("Editar", "Pessoa", new { Id = pessoaId });
        }

        [HttpPost]
        public IActionResult Editar(Enderecos endereco)
        {
            _enderecoRepository.Editar(endereco);
            return RedirectToAction("Editar", "Pessoa", new { Id = endereco.PessoaId });

        }

    }
}
