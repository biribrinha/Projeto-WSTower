using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTowerApi.Domains;
using WSTowerApi.Interfaces;
using WSTowerApi.Repositories;

namespace WSTowerApi.Controller
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private IJogadorRepository _jogadorRepository;

        public JogadorController()
        {
            _jogadorRepository = new JogadorRepository();
        }

        /// <summary>
        /// Lista todos os jogadores
        /// </summary>
        /// <returns>Uma lista de jogadores e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de seleções</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Jogadores
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogadorRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um jogador através do nome
        /// </summary>
        /// <param name="nome">nome do jogador que será buscado</param>
        /// <returns>Um jogo buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um jogo buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogador/id
        [HttpGet("{Nome}")]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                Jogador jogadorBuscado = _jogadorRepository.ListarPorNome(nome);

                if (jogadorBuscado != null)
                {
                    return Ok(jogadorBuscado);
                }

                return NotFound("Nenhum jogador encontrado com o nome informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca todos jogadores através de uma selecao
        /// </summary>
        /// <param name="id">Id da selecao que será buscado</param>
        /// <returns>Uma selecao buscada e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um jogo buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogador/id
        [HttpGet("{selecaoId}")]
        public IActionResult GetByIdSelecao(int id)
        {
            try
            {
                List<Jogador> jogadorBuscado = _jogadorRepository.ListarUmaSelecao(id);

                if (jogadorBuscado != null)
                {
                    return Ok(jogadorBuscado);
                }

                return NotFound("Nenhum jogador encontrado com a seleção informada");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo jogador
        /// </summary>
        /// <param name="novoJogador">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/jogos
        [HttpPost]
        public IActionResult Post(Jogador novoJogador)
        {
            try
            {
                _jogadorRepository.Cadastrar(novoJogador);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um jogador existente
        /// </summary>
        /// <param name="id">ID do jogador que será atualizado</param>
        /// <param name="jogadorAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Jogador/id
        [HttpPut ("{Id}")]
        public IActionResult Put(int id, Jogador jogadorAtualizado)
        {
            try
            {
                Jogador jogadorBuscado = _jogadorRepository.ListarPorId(id);

                if (jogadorBuscado != null)
                {
                    _jogadorRepository.Atualizar(id, jogadorAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum jogador encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um jogador
        /// </summary>
        /// <param name="id">ID do jogador que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Jogador/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Jogador jogadorBuscado = _jogadorRepository.ListarPorId(id);

                if (jogadorBuscado != null)
                {
                    _jogadorRepository.Remover(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum jogador encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
