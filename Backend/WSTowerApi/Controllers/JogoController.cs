using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTowerApi.Domains;
using WSTowerApi.Interfaces;
using WSTowerApi.Repositories;

namespace WSTowerApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de seleções</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Jogo
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogoRepository.ListarJogos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um jogo buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogos/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.ListarPorId(id);

                if (jogoBuscado != null)
                {
                    return Ok(jogoBuscado);
                }

                return NotFound("Nenhum jogo encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um jogo através do estadio
        /// </summary>
        /// <param name="estadio">estadio do jogo que será buscado</param>
        /// <returns>Um jogo buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um jogo buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogos/id
        [HttpGet("{Estadio}")]
        public IActionResult GetEstadio(string estadio)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.ListarPorEstadio(estadio);

                if (jogoBuscado != null)
                {
                    return Ok(jogoBuscado);
                }

                return NotFound("Nenhum jogo encontrado para o estadio informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um jogo através da data
        /// </summary>
        /// <param name="dataJogo">data do jogo que será buscado</param>
        /// <returns>Um jogo buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um jogo buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogos/id
        [HttpGet("{Data}")]
        public IActionResult GetData(DateTime dataJogo)
        {
            try
            {
                Jogo jogosBuscados = _jogoRepository.ListarPorData(dataJogo);

                if (jogosBuscados != null)
                {
                    return Ok(jogosBuscados);
                }

                return NotFound("Nenhum jogo encontrado para a data informada");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogos
        [HttpPost]
        public IActionResult Post(Jogo novoJogo)
        {
            try
            {
                _jogoRepository.CadastrarJogo(novoJogo);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Jogos/id
        [HttpPut]
        public IActionResult Put(int id, Jogo jogoAtualizado)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.ListarPorId(id);

                if (jogoBuscado != null)
                {
                    _jogoRepository.AtualizarJogo(id, jogoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum jogo encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Jogos/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.ListarPorId(id);

                if (jogoBuscado != null)
                {
                    _jogoRepository.RemoverJogo(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum jogo encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos os jogos com as informações das Selecoes
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        [HttpGet("Selecao")]
        public IActionResult GetSelecao()
        {
            return Ok(_jogoRepository.ListarJogosPorSelecao());
        }
    }
}