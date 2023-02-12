using ApiAso.DTO.Setor;
using ApiAso.Model.Setor;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Setor
{
    public class SetorRepositorio
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

        #region Setor
        public List<SetorModel> ObterSetor(SetorDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlSetor();
            if (filtro.idSetor > 0)
                sentencaSql.Append($" AND idSetor = {filtro.idSetor}");
            else
                return null;

            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Setor))
                        sentencaSql.Append($" AND Setor = '{filtro.Setor}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Setor))
                        sentencaSql.Append($" AND Setor LIKE '%{filtro.Setor}%'");

                    break;
            }
            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<SetorModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlSetor()
        {
            return new StringBuilder($@"SELECT idSetor
                                              ,Setor
                                          FROM Setor 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
