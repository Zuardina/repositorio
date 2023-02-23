using ApiAso.DTO.Alcada;
using ApiAso.Model.Alcada;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Alcada
{
    public class AlcadaUsuarioConectadoRepositorio : IDisposable
    {
        private bool flagDispose;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (flagDispose)
                return;

            if (disposing)
            {
            }

            flagDispose = true;
        }

        #region Alcada Usuario Conectado
        public List<AlcadaUsuarioConectadoModel> ObterAlcadaUsuarioConectado(AlcadaUsuarioConectadoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAlcadaUsuarioConectado();
            if (filtro.idAlcadaUsuarioConectado > 0)
                sentencaSql.Append($" AND idAlcadaUsuarioConectado = {filtro.idAlcadaUsuarioConectado}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.IPterminal))
                        sentencaSql.Append($" AND IPterminal = '{filtro.IPterminal}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.IPterminal))
                        sentencaSql.Append($" AND IPterminal LIKE '%{filtro.IPterminal}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AlcadaUsuarioConectadoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlAlcadaUsuarioConectado()
        {
            return new StringBuilder($@"SELECT   idAlcadaUsuarioConectado 
                                                ,idAlcadaUsuario 
                                                ,IPterminal 
                                                ,DataAcessoInicial 
                                                ,DataAcessoFinal 
                                            FROM  AlcadaUsuarioConectado
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
