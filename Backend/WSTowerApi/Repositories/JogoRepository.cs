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
    public class JogoRepository : IJogoRepository
    {
        WSTowerApiContext ctx = new WSTowerApiContext();

        public List<Jogo> ListarJogos()
        {
            return ctx.Jogo.ToList();
        }

        public Jogo ListarPorId(int id)
        {
            return ctx.Jogo.FirstOrDefault(j => j.Id == id);
        }

        public Jogo ListarPorEstadio(string estadio)
        {
            return ctx.Jogo.FirstOrDefault(j => j.Estadio == estadio);
        }

        public Jogo ListarPorData(DateTime dataJogo)
        {
            return ctx.Jogo.FirstOrDefault(j => j.Data == dataJogo);
        }

        public List<Jogo> ListarJogosPorSelecao()
        {
            return ctx.Jogo.Include(e => e.SelecaoCasaNavigation).ToList();
        }


        public void CadastrarJogo(Jogo novoJogo)
        {
            ctx.Jogo.Add(novoJogo);

            ctx.SaveChanges();
        }

        public void AtualizarJogo(int id, Jogo jogoAtualizado)
        {
            Jogo jogoBuscado = ctx.Jogo.Find(id);

            jogoBuscado.SelecaoCasa = jogoAtualizado.SelecaoCasa;
            jogoBuscado.SelecaoVisitante = jogoAtualizado.SelecaoVisitante;
            jogoBuscado.PlacarCasa = jogoAtualizado.PlacarCasa;
            jogoBuscado.PlacarVisitante = jogoAtualizado.PlacarVisitante;
            jogoBuscado.PenaltisCasa = jogoAtualizado.PenaltisCasa;
            jogoBuscado.PenaltisVisitante = jogoAtualizado.PenaltisVisitante;
            jogoBuscado.Data = jogoAtualizado.Data;
            jogoBuscado.Estadio = jogoAtualizado.Estadio;

            ctx.Update(jogoBuscado);

            ctx.SaveChanges();
        }

        public void RemoverJogo(int id)
        {
            Jogo jogoBuscado = ctx.Jogo.Find(id);

            ctx.Remove(jogoBuscado);

            ctx.SaveChanges();
        }

    }
}
