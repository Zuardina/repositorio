using ApiAso.DTO.Funcao;
using ApiAso.Model.Funcao;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Funcao
{
    public class FuncaoRepositorio : IDisposable
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

        #region Funcao
        public List<FuncaoModel> ObterFuncao(FuncaoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlFuncao();
            if (filtro.idFuncao > 0)
                sentencaSql.Append($" AND idFuncao = {filtro.idFuncao}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorId:
                    if (filtro.idFuncao > 0)
                        sentencaSql.Append($" AND idFuncao = {filtro.idFuncao}");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Funcao))
                        sentencaSql.Append($" AND idFuncao = '{filtro.idFuncao}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Funcao))
                        sentencaSql.Append($" AND Funcao LIKE '%{filtro.Funcao}%'");

                    break;
            }
            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<FuncaoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlFuncao()
        {
            return new StringBuilder($@"SELECT idFuncao
                                               ,Funcao
                                          FROM Funcao 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
