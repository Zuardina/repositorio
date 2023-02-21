using ApiAso.DTO.App;
using ApiAso.Model.App;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.App
{
    public class AppTipoContatoMascaraRepositorio : IDisposable
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

        #region App Tipo Contato Mascara
        public List<AppTipoContatoMascaraModel> ObterAppTipoContatoMascara(AppTipoContatoMascaraDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAppTipoContatoMascara();
            if (filtro.idAppTipoContatoMascara > 0)
                sentencaSql.Append($" AND idAppTipoContatoMascara = {filtro.idAppTipoContatoMascara}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Descricao))
                        sentencaSql.Append($" AND Descricao = '{filtro.Descricao}'");
                    if (!string.IsNullOrEmpty(filtro.MascaraForm))
                        sentencaSql.Append($" AND MascaraForm = '{filtro.MascaraForm}'");
                    if (!string.IsNullOrEmpty(filtro.MascaraReact))
                        sentencaSql.Append($" AND MascaraReact = '{filtro.MascaraReact}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Descricao))
                        sentencaSql.Append($" AND Descricao LIKE '%{filtro.Descricao}%'");
                    if (!string.IsNullOrEmpty(filtro.MascaraForm))
                        sentencaSql.Append($" AND MascaraForm LIKE '%{filtro.MascaraForm}%'");
                    if (!string.IsNullOrEmpty(filtro.MascaraReact))
                        sentencaSql.Append($" AND MascaraReact LIKE '%{filtro.MascaraReact}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AppTipoContatoMascaraModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlAppTipoContatoMascara()
        {
            return new StringBuilder($@"SELECT  idAppTipoContatoMascara 
                                               ,Descricao 
                                               ,MascaraForm
                                               ,MascaraReact
                                            FROM  AppTipoContatoMascara
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}

