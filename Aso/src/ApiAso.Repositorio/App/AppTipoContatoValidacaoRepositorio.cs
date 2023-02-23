using ApiAso.DTO.App;
using ApiAso.Model.App;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.App
{
    public class AppTipoContatoValidacaoRepositorio : IDisposable
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

        #region App Tipo Contato Validação
        public List<AppTipoContatoValidacaoModel> ObterAppTipoContatoValidacao(AppTipoContatoValidacaoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAppTipoContatoValidacao();
            if (filtro.idAppTipoContatoValidacao > 0)
                sentencaSql.Append($" AND idAppTipoContatoValidacao = {filtro.idAppTipoContatoValidacao}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Validacao))
                        sentencaSql.Append($" AND Validacao = '{filtro.Validacao}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Validacao))
                        sentencaSql.Append($" AND Validacao LIKE '%{filtro.Validacao}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AppTipoContatoValidacaoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlAppTipoContatoValidacao()
        {
            return new StringBuilder($@"SELECT  idAppTipoContatoValidacao 
                                               ,Validacao
                                            FROM  AppTipoContatoValidacao
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
