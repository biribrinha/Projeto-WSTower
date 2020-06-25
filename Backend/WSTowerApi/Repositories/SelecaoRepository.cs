using WSTowerApi.Contexts;
using WSTowerApi.Domains;
using WSTowerApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WSTowerApi.Repositories
{
    public class SelecaoRepository : ISelecaoRepository
    {
        WSTowerApiContext ctx = new WSTowerApiContext();

        public void Atualizar(int id, Selecao selecaoNova)
        {
            Selecao selecaoBuscada = ctx.Selecao.Find(id);

            selecaoBuscada.Nome = selecaoNova.Nome;
            selecaoBuscada.Bandeira = selecaoNova.Bandeira;
            selecaoBuscada.Uniforme = selecaoNova.Uniforme;
            selecaoBuscada.Escalacao = selecaoNova.Escalacao;

            ctx.Selecao.Update(selecaoBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Selecao selecaoNova)
        {
            ctx.Selecao.Add(selecaoNova);

            ctx.SaveChanges();
        }

        public List<Selecao> ListarJogadoresOrdemAlfabetica(int idSelecao)
        {
            //Selecao selecaoSelecionada = new Selecao();
            //foreach (var jogador in selecaoSelecionada.Jogadores)
            //{
                
            //}

            return ctx.Selecao.Include(s => s.Jogador).OrderBy(s => s.Jogador).Where(s => s.Id == idSelecao).ToList();
        }

        public List<Selecao> ListarJogadoresOrdemDecrescente(int idSelecao)
        {
            return ctx.Selecao.Include(s => s.Jogador).OrderByDescending(s => s.Jogador.);
        }

        public List<Selecao> ListarJogadoresPorSelecao(int idSelecao)
        {
            return ctx.Selecao.Include(s => s.Jogador).Where(s => s.Id == idSelecao).ToList();
        }

        public Selecao ListarPorId(int id)
        {
            return ctx.Selecao.FirstOrDefault(s => s.Id == id);
        }

        public List<Selecao> ListarTodos()
        {
            return ctx.Selecao.ToList();
        }

        public void Remover(int id)
        {
            Selecao selecaoBuscada = ctx.Selecao.Find(id);

            ctx.Selecao.Remove(selecaoBuscada);

            ctx.SaveChanges();
        }
    }
}
