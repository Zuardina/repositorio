using ApiAso.DTO.Tipo;
using ApiAso.Model.Tipo;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Tipo
{
    public class TipoEnderecoRepositorio : IDisposable
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

        #region Endereco
        public List<TipoEnderecoModel> ObterTipoEndereco(TipoEnderecoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlTipoEndereco();
            if (filtro.idTipoEndereco > 0)
                sentencaSql.Append($" AND idTipoEndereco = {filtro.idTipoEndereco}");
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
                return conexao.Query<TipoEnderecoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlTipoEndereco()
        {
            return new StringBuilder($@"SELECT   idTipoEndereco 
                                                ,Descricao 
                                                ,FlagPrazoDeterminado 
                                          FROM Endereco 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
