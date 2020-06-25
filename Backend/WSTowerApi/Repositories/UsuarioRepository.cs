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
    public class UsuarioRepository : IUsuarioRepository
    {
        WSTowerApiContext ctx = new WSTowerApiContext();

        
        public Usuario Login(string email, string apelido, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario
              
            .FirstOrDefault(u => u.Email == email || u.Apelido == apelido && u.Senha == senha);

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }

            return null;
        }

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.Nome = usuarioAtualizado.Nome;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Apelido = usuarioAtualizado.Apelido;
            usuarioBuscado.Foto = usuarioAtualizado.Foto;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Remover(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            ctx.Usuario.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }
    }
}
