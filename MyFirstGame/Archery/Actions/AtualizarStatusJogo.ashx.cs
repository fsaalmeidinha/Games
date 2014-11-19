using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JogosDeGaragemModel.Archery.DataAcess;
using JogosDeGaragemModel.Archery;

namespace MyFirstGame.Archery.Actions
{
    /// <summary>
    /// Summary description for AtualizarStatusJogo
    /// </summary>
    public class AtualizarStatusJogo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string deletar = context.Request.QueryString["Deletar"];
            string email = context.Request.QueryString["Email"];

            if (!String.IsNullOrEmpty(deletar))
            {
                StatusJogoDA.DeletarStatusJogo(email);
            }
            else
            {
                string flechas = context.Request.QueryString["Flechas"];
                string pontuacao = context.Request.QueryString["Pontuacao"];
                string nivel = context.Request.QueryString["Nivel"];

                StatusJogo statusJogo = new StatusJogo()
                {
                    Email = email,
                    Flechas = Convert.ToInt32(flechas),
                    Nivel = Convert.ToInt32(nivel),
                    Pontuacao = Convert.ToInt32(pontuacao)
                };

                StatusJogoDA.AtualizarStatusJogo(statusJogo);
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