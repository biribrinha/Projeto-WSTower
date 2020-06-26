using System;
using System.Collections.Generic;

namespace WSTowerApi.Domains
{
    public partial class Selecao
    {
        public Selecao()
        {
            Jogadores = new HashSet<Jogador>();
            JogoSelecaoCasaNavigation = new HashSet<Jogo>();
            JogoSelecaoVisitanteNavigation = new HashSet<Jogo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Bandeira { get; set; }
        public byte[] Uniforme { get; set; }
        public string Escalacao { get; set; }

        public virtual ICollection<Jogador> Jogadores { get; set; }
        public virtual ICollection<Jogo> JogoSelecaoCasaNavigation { get; set; }
        public virtual ICollection<Jogo> JogoSelecaoVisitanteNavigation { get; set; }

        public Jogador Jogador { get; set; }
    }
}
