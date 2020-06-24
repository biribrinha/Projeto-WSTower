using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Domains;
using WSTowerApi.Interfaces;
using WSTowerApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WSTowerApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SelecaoController : ControllerBase
    {
        private ISelecaoRepository _selecaoRepository;

        public SelecaoController()
        {
            _selecaoRepository = new SelecaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_selecaoRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_selecaoRepository.ListarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Selecao selecaoNova)
        {
            _selecaoRepository.Cadastrar(selecaoNova);

            return StatusCode(201);

        }

        [HttpPut]
        public IActionResult Put(int id, Selecao selecaoNova)
        {
            _selecaoRepository.Atualizar(id, selecaoNova);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _selecaoRepository.Remover(id);

            return StatusCode(204);
        }
    }
}
