using WSTowerApi.Contexts;
using WSTowerApi.Domains;
using WSTowerApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WSTowerApi.Repositories
{
    public class SelecaoRepository : ISelecaoRepository
    {
        WSTowerApiContext ctx = new WSTowerApiContext();

        private string stringConexao = "Data Source=DESKTOP-4EGEC9A\\SQLEXPRESS; Initial Catalog=Campeonato; Integrated Security=true;";

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
            List<Selecao> selecoes = new List<Selecao>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT S.Nome, S.Bandeira, J.Nome, J.Foto, J.Posicao FROM Selecao S" +
                                     "INNER JOIN Jogador J" +
                                     "ON S.Id = J.SelecaoID" +
                                     "WHERE S.Id = @ID" +
                                     "ORDER BY J.Nome ASC;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idSelecao);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Selecao selecao = new Selecao
                        {
                            Nome = rdr["Nome"].ToString(),
                            Bandeira = Convert.ToByte(rdr["Banderira"]),

                            Jogador = new Jogador
                            {
                                Nome = rdr["Nome"].ToString(),
                                Foto = rdr["Foto"].ToByte(),
                                Posicao = rdr["Posicao"],
                            }

                        };

                        selecoes.Add(selecao);
                    }
                }
            }

            return selecoes;
            //return ctx.Selecao.Include(s => s.Jogador).OrderBy(s => s.Jogador).Where(s => s.Id == idSelecao).ToList();
        }

        public List<Selecao> ListarJogadoresOrdemDecrescente(int idSelecao)
        {
            throw new NotImplementedException();
        }

        //public List<Selecao> ListarJogadoresOrdemDecrescente(int idSelecao)
        //{
        //    //return ctx.Selecao.Include(s => s.Jogador).OrderByDescending(s => s.Jogador.);
        //}

        public List<Selecao> ListarJogadoresPorSelecao(int idSelecao)
        {
            return ctx.Selecao.Include(s => s.Jogadores).Where(s => s.Id == idSelecao).ToList();
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
