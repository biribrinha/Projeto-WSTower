using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Contexts;
using WSTowerApi.Domains;
using WSTowerApi.Interfaces;

namespace WSTowerApi.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        WSTowerApiContext ctx = new WSTowerApiContext();

        public List<Jogador> ListarTodos()
        {
            return ctx.Jogador.ToList();
        }

        public Jogador ListarPorNome(string nome)
        {
            return ctx.Jogador.FirstOrDefault(j => j.Nome == nome);
        }

        
        public List<Jogador> ListarUmaSelecao(int id)
        {

            return ctx.Jogador.Include(j => j.SelecaoId == id).ToList();
        }

        public Jogador ListarPorId(int id)
        {
            return ctx.Jogador.FirstOrDefault(j => j.Id == id);
        }

        public void Cadastrar(Jogador novoJogador)
        {
            ctx.Jogador.Add(novoJogador);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Jogador jogadorAtualizado)
        {
            Jogador jogadorBuscado = ctx.Jogador.Find(id);

            jogadorBuscado.Nome = jogadorAtualizado.Nome;
            jogadorBuscado.Nascimento = jogadorAtualizado.Nascimento;
            jogadorBuscado.Posicao = jogadorAtualizado.Posicao;
            jogadorBuscado.Qtdefaltas = jogadorAtualizado.Qtdefaltas;
            jogadorBuscado.QtdecartoesAmarelo = jogadorAtualizado.QtdecartoesAmarelo;
            jogadorBuscado.QtdecartoesVermelho = jogadorAtualizado.QtdecartoesVermelho;
            jogadorBuscado.Qtdegols = jogadorAtualizado.Qtdegols;
            jogadorBuscado.Informacoes = jogadorAtualizado.Informacoes;
            jogadorBuscado.NumeroCamisa = jogadorAtualizado.NumeroCamisa;
            jogadorBuscado.Foto = jogadorAtualizado.Foto;
            jogadorBuscado.SelecaoId = jogadorAtualizado.SelecaoId;

            ctx.Jogador.Update(jogadorBuscado);

            ctx.SaveChanges();
        }

        public void Remover(int id)
        {
            Jogador jogadorBuscado = ctx.Jogador.Find(id);
            
            ctx.Jogador.Remove(jogadorBuscado);

            ctx.SaveChanges();
        }

    }
}
