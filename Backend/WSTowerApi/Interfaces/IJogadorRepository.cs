using WSTowerApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowerApi.Interfaces
{
    interface IJogadorRepository
    {
        public List<Jogador> ListarTodos();
        public Jogador ListarPorId(int id);
        public void Cadastrar(Jogador jogadorNovo);
        public void Remover(int id);
        public void Atualizar(int id, Jogador jogadorNovo);
    }
}
