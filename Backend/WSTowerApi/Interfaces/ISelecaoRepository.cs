using WSTowerApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowerApi.Interfaces
{
    interface ISelecaoRepository
    {
        public List<Selecao> ListarTodos();
        public Selecao ListarPorId(int id);
        public void Cadastrar(Selecao selecaoNova);
        public void Remover(int id);
        public void Atualizar(int id, Selecao selecaoAtualizada);
        public List<Selecao> ListarJogadoresPorSelecao(int idSelecao);
        public List<Selecao> ListarJogadoresOrdemAlfabetica(int idSelecao);
        public List<Selecao> ListarJogadoresOrdemDecrescente(int idSelecao);
    }
}
