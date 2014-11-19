using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JogosDeGaragemModel.Archery.DataAcess;
using JogosDeGaragemModel.Archery;
using System.Web.Script.Serialization;

namespace MyFirstGame.Archery.Actions
{
    /// <summary>
    /// Summary description for RecuperarStatusJogo
    /// </summary>
    public class RecuperarStatusJogo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string email = context.Request.QueryString["Email"];
            string statusJogoJson = "";

            if (!String.IsNullOrEmpty(email))
            {
                StatusJogo statusJogo = StatusJogoDA.RecuperarStatusJogo(email);
                if (statusJogo != null)
                {
                    statusJogoJson = new JavaScriptSerializer().Serialize(new { statusJogo.Flechas, statusJogo.Nivel, statusJogo.Pontuacao });
                }
            }

            context.Response.Write(statusJogoJson);
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