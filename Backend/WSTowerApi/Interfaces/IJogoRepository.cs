using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Domains;

namespace WSTowerApi.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> ListarJogos();

        public Jogo ListarPorId(int id);

        public List<Jogo> ListarPorData(DateTime dataJogo);

        public void CadastrarJogo(Jogo novoJogo);

        public void AtualizarJogo(int id, Jogo jogoAtualizado);

        public void RemoverJogo(int id);

        List<Jogo> ListarJogosPorSelecao();
     }
}
