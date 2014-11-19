using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JogosDeGaragemModel.Log.DataAcess;
using JogosDeGaragemModel.Geral;

namespace JogosDeGaragemModel.Archery.DataAcess
{
    public class StatusJogoDA
    {
        public static void AtualizarStatusJogo(StatusJogo statusJogo)
        {
            try
            {
                using (ArcheryEntities contexto = new ArcheryEntities())
                {
                    StatusJogo statusJogoBD = contexto.StatusJogos.FirstOrDefault(stats => stats.Email == statusJogo.Email);
                    if (statusJogoBD == null)
                    {
                        statusJogoBD = new StatusJogo()
                        {
                            Email = statusJogo.Email
                        };
                        contexto.StatusJogos.AddObject(statusJogoBD);
                    }

                    statusJogoBD.Flechas = statusJogo.Flechas;
                    statusJogoBD.Nivel = statusJogo.Nivel;
                    statusJogoBD.Pontuacao = statusJogo.Pontuacao;

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogDA.GravarLog(MethodHelper.GetCurrentMethod(), null, ex);
            }
        }

        public static void DeletarStatusJogo(string email)
        {
            try
            {
                using (ArcheryEntities contexto = new ArcheryEntities())
                {
                    StatusJogo statusJogoBD = contexto.StatusJogos.FirstOrDefault(stats => stats.Email == email);
                    if (statusJogoBD != null)
                    {
                        contexto.StatusJogos.DeleteObject(statusJogoBD);
                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                LogDA.GravarLog(MethodHelper.GetCurrentMethod(), null, ex);
            }
        }

        public static StatusJogo RecuperarStatusJogo(string email)
        {
            StatusJogo statusJogo = null;
            try
            {
                using (ArcheryEntities contexto = new ArcheryEntities())
                {
                    statusJogo = contexto.StatusJogos.FirstOrDefault(stats => stats.Email == email);
                }
            }
            catch (Exception ex)
            {
                LogDA.GravarLog(MethodHelper.GetCurrentMethod(), null, ex);
            }
            return statusJogo;
        }
    }
}
