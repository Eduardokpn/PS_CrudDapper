using ApiPS.Interface;
using ApiPS.Interfaces.Repositories;
using ApiPS.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace ApiPS.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public PessoaController(IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Listar()
        {

            var pessoas = _pessoaRepository.GetAll();
            return View(pessoas);
        }

        public IActionResult Cadastrar()
        {
            return View(new Pessoas());
        }

        [HttpPost]
        public IActionResult Cadastrar(Pessoas pessoa)
        {
            var Id = _pessoaRepository.Add(pessoa);
            return RedirectToAction("Editar", new { id = Id });
            
        }


        [HttpPost]
        public IActionResult Excluir(int id)
        {
            _pessoaRepository.Excluir(id);
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(int id)
        {
                var pessoa = _pessoaRepository.GetById(id);
                var enderecos = _enderecoRepository.GetById(id);
                var viewModel = new PessoaEnderecoViewModel
                {
                    Pessoa = pessoa,
                    Enderecos = enderecos
                };
                return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(Pessoas pessoa)
        {
            _pessoaRepository.Editar(pessoa);
            return RedirectToAction("Listar");
        }












    }
}

