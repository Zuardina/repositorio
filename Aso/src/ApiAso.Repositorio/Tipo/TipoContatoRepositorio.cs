using ApiAso.DTO.Tipo;
using ApiAso.Model.Tipo;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Tipo
{
    public class TipoContatoRepositorio : IDisposable
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

        #region Contato
        public List<TipoContatoModel> ObterTipoContato(TipoContatoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqTipoContato();
            if (filtro.idTipoContato > 0)
                sentencaSql.Append($" AND idTipoContato = {filtro.idTipoContato}");
            else if (filtro.idTipoContatoMascara > 0)
                sentencaSql.Append($" AND idTipoContatoMascara = {filtro.idTipoContatoMascara}");
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
                return conexao.Query<TipoContatoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqTipoContato()
        {
            return new StringBuilder($@"SELECT idTipoContato
                                               ,idTipoContatoMascara
                                               ,Descricao
                                          FROM TipoContato 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57

        }
        #endregion
    }
}
