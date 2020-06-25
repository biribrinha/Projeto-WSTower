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

        /// <summary>
        /// Lista todos as seleções
        /// </summary>
        /// <returns>Uma lista de seleções e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de seleções</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Selecoes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_selecaoRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma seleção através do ID
        /// </summary>
        /// <param name="id">ID da seleção que será buscado</param>
        /// <returns>Uma seleção buscada e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a seleção buscada</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Selecoes/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Selecao selecaoBuscada = _selecaoRepository.ListarPorId(id);

                if (selecaoBuscada != null)
                {
                    return Ok(selecaoBuscada);
                }

                return NotFound("Nenhuma seleção encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova selecao
        /// </summary>
        /// <param name="selecaoNova">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Selecoes
        [HttpPost]
        public IActionResult Post(Selecao selecaoNova)
        {
            try
            {
                _selecaoRepository.Cadastrar(selecaoNova);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma selecao existente
        /// </summary>
        /// <param name="id">ID da seleção que será atualizado</param>
        /// <param name="selecaoAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Eventos/id
        [HttpPut]
        public IActionResult Put(int id, Selecao selecaoAtualizada)
        {
            try
            {
                Selecao selecaoBuscada = _selecaoRepository.ListarPorId(id);

                if (selecaoBuscada != null)
                {
                    _selecaoRepository.Atualizar(id, selecaoAtualizada);

                    return StatusCode(204);
                }

                return NotFound("Nenhuma seleção encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma selecao
        /// </summary>
        /// <param name="id">ID da selecao que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Selecoes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Selecao selecaoBuscada = _selecaoRepository.ListarPorId(id);

                if (selecaoBuscada != null)
                {
                    _selecaoRepository.Remover(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhuma seleção encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
