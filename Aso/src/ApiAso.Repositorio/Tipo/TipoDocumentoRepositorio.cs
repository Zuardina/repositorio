using ApiAso.DTO.Tipo;
using ApiAso.Model.Tipo;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Tipo
{
    public class TipoDocumentoRepositorio : IDisposable
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

        #region Documento
        public List<TipoDocumentoModel> ObterTipoDocumento(TipoDocumentoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlTipoDocumento();
            if (filtro.idTipoDocumento > 0)
                sentencaSql.Append($" AND idTipoDocumento = {filtro.idTipoDocumento}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Descricao))
                        sentencaSql.Append($" AND Descricao = '{filtro.Descricao}'");
                    if (!string.IsNullOrEmpty(filtro.Mascara))
                        sentencaSql.Append($" AND Mascara = '{filtro.Mascara}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Descricao))
                        sentencaSql.Append($" AND Descricao LIKE '%{filtro.Descricao}%'");
                    if (!string.IsNullOrEmpty(filtro.Mascara))
                        sentencaSql.Append($" AND Mascara LIKE '%{filtro.Mascara}%'");

                    break;
            }
            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<TipoDocumentoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlTipoDocumento()
        {
            return new StringBuilder($@"SELECT idTipoDocumento
                                              ,Descricao 
                                              ,FlagPrazoDeterminado 
                                               FROM TipoDocumento 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
