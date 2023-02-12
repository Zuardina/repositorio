using ApiAso.DTO.Periodicidade;
using ApiAso.Model.Periodicidade;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Periodicidade
{
    public class PeriodicidadeRepositorio : IDisposable
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

        #region Periodicidade
        public List<PeriodicidadeModel> ObterPeriodicidade(PeriodicidadeDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlPeriodicidade();
            if (filtro.idPeriodicidade > 0)
                sentencaSql.Append($" AND idPeriodicidade = {filtro.idPeriodicidade}");
            else
            return null;
            switch (filtro.PesquisaPor)
            {

                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Periodicidade))
                        sentencaSql.Append($" AND Periodicidade = '{filtro.Periodicidade}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Periodicidade))
                        sentencaSql.Append($" AND Periodicidade LIKE '%{filtro.Periodicidade}%'");

                    break;
            }
            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PeriodicidadeModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlPeriodicidade()
        {
            return new StringBuilder($@"SELECT idPeriodicidade
                                              ,Periodicidade
                                          FROM Periodicidade
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
