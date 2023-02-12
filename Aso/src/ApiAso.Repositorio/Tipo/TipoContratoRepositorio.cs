using ApiAso.DTO.Tipo;
using ApiAso.Model.Tipo;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Tipo
{
    public class TipoContratoRepositorio : IDisposable
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

        #region Contrato
        public List<TipoContratoModel> ObterTipoContrato(TipoContratoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlTipoContrato();
            if (filtro.idTipoContrato > 0)
                sentencaSql.Append($" AND idTipoContrato = {filtro.idTipoContrato}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Descricao))
                        sentencaSql.Append($" AND Descricao = '{filtro.Descricao}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Descricao))
                        sentencaSql.Append($" AND Descricao LIKE '%{filtro.Descricao}%'");

                    break;
            }
            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<TipoContratoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlTipoContrato()
        {
            return new StringBuilder($@"SELECT   idTipoContrato 
                                                .Descricao 
                                                .FlagPrazoDeterminado 
                                          FROM TipoContrato 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
