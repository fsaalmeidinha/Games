using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JogosDeGaragemModel.Archery.DataAcess;
using JogosDeGaragemModel.Archery;

namespace MyFirstGame.Archery.Actions
{
    /// <summary>
    /// Summary description for AtualizarUsuario
    /// </summary>
    public class AtualizarUsuario : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string nome = context.Request.QueryString["Nome"];
            string email = context.Request.QueryString["Email"];

            if (!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(email))
            {
                Usuario usuario = new Usuario()
                {
                    Nome = nome,
                    Email = email
                };
                UsuarioDA.AtualizarUsuario(usuario);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}