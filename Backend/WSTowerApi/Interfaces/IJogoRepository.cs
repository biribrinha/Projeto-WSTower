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

        public Jogo ListarPorData(DateTime dataJogo);

        public Jogo ListarPorEstadio(string estadio);
        List<Jogo> ListarJogosPorSelecao();

        public void CadastrarJogo(Jogo novoJogo);

        public void AtualizarJogo(int id, Jogo jogoAtualizado);

        public void RemoverJogo(int id);

        
     }
}
