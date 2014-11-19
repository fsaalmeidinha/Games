using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosDeGaragemModel.Log.DataAcess
{
    public class LogDA
    {
        public static void GravarLog(string acao, string mensagem, Exception ex)
        {
            string fullMsg = mensagem;

            while (ex != null)
            {
                mensagem += "\r\n" + ex.Message;
                ex = ex.InnerException;
            }

            using (LogEntities contexto = new LogEntities())
            {
                Log logSalvar = new Log()
                {
                    Acao = acao,
                    DataAcao = DateTime.UtcNow,
                    Mensagem = mensagem
                };

                contexto.SaveChanges();
            }
        }
    }
}
