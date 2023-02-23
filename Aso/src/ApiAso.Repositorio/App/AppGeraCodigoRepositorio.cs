using ApiAso.DTO.App;
using ApiAso.Model.App;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.App
{
    public class AppGeraCodigoRepositorio : IDisposable
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

        #region App Gera Codigo
        public List<AppGeraCodigoModel> ObterAppGeraCodigo(AppGeraCodigoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAppGeraCodigo();
            if (filtro.idAppGeraCodigo > 0)
                sentencaSql.Append($" AND idAppGeraCodigo = {filtro.idAppGeraCodigo}");
            if
               (filtro.idEmpresa > 0)
                sentencaSql.Append($" AND idEmpresa = {filtro.idEmpresa}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Proprietario))
                        sentencaSql.Append($" AND Proprietario = '{filtro.Proprietario}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Proprietario))
                        sentencaSql.Append($" AND Proprietario LIKE '%{filtro.Proprietario}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AppGeraCodigoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlAppGeraCodigo()
        {
            return new StringBuilder($@"SELECT idAppGeraCodigo
                                              ,idEmpresa
                                              ,Proprietario
                                              ,Sequencia
                                          FROM AppGeraCodigo
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
