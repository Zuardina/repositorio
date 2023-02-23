using ApiAso.DTO.Alcada;
using ApiAso.Model.Alcada;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Alcada
{
    public class AlcadaGrupoRepositorio : IDisposable
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

        #region Alcada Grupo
        public List<AlcadaGrupoModel> ObterAlcadaGrupo(AlcadaGrupoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAlcadaGrupo();
            if (filtro.idAlcadaGrupo > 0)
                sentencaSql.Append($" AND idAlcadaGrupo = {filtro.idAlcadaGrupo}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.NomeCompleto))
                        sentencaSql.Append($" AND NomeCompleto = '{filtro.NomeCompleto}'");
                    if (!string.IsNullOrEmpty(filtro.Email))
                        sentencaSql.Append($" AND Email = '{filtro.Email}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.NomeCompleto))
                        sentencaSql.Append($" AND NomeCompleto LIKE '%{filtro.NomeCompleto}%'");
                    if (!string.IsNullOrEmpty(filtro.Email))
                        sentencaSql.Append($" AND Email LIKE '%{filtro.Email}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AlcadaGrupoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlAlcadaGrupo()
        {
            return new StringBuilder($@"SELECT  idAlcadaGrupo 
                                               ,Email 
                                               ,NomeCompleto 
                                               ,DataValidade 
                                               ,QuantidadeLogin 
                                               ,FlagBloqueado 
                                            FROM  AlcadaGrupo
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
