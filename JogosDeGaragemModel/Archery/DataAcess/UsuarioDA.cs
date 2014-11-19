using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JogosDeGaragemModel.Log.DataAcess;
using JogosDeGaragemModel.Geral;

namespace JogosDeGaragemModel.Archery.DataAcess
{
    public class UsuarioDA
    {
        public static void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                using (ArcheryEntities contexto = new ArcheryEntities())
                {
                    Usuario usuarioBD = contexto.Usuarios.FirstOrDefault(usr => usr.Email == usuario.Email);
                    if (usuarioBD == null)
                    {
                        usuarioBD = new Usuario()
                        {
                            Email = usuario.Email
                        };
                        contexto.Usuarios.AddObject(usuarioBD);
                    }

                    if (!String.IsNullOrEmpty(usuario.Nome))
                    {
                        usuarioBD.Nome = usuario.Nome;
                    }

                    if (usuario.PontuacaoMaximaJogo > 0)
                    {
                        usuarioBD.PontuacaoMaximaJogo = usuario.PontuacaoMaximaJogo;
                    }

                    if (usuario.PontuacaoTotal > 0)
                    {
                        usuarioBD.PontuacaoTotal = usuario.PontuacaoTotal;
                    }

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogDA.GravarLog(MethodHelper.GetCurrentMethod(), null, ex);
            }
        }
    }
}
