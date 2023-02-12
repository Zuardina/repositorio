using ApiAso.DTO.Produto;
using ApiAso.Model.Produto;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Produto
{
    public class ProdutoRepositorio
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

        #region Produto
        public List<ProdutoModel> ObterProduto(ProdutoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlProduto();
            if (filtro.idProduto > 0)
                sentencaSql.Append($" AND idProduto = {filtro.idProduto}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Produto))
                        sentencaSql.Append($" AND Produto = '{filtro.Produto}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Produto))
                        sentencaSql.Append($" AND Produto LIKE '%{filtro.Produto}%'");

                    break;
            }
            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<ProdutoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlProduto()
        {
            return new StringBuilder($@"SELECT idProduto 
                                              ,Produto 
                                              ,Observacao 
                                          FROM Produto 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
