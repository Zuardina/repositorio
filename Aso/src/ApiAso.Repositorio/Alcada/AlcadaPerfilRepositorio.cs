using ApiAso.DTO.Alcada;
using ApiAso.DTO.App;
using ApiAso.Model.Alcada;
using ApiAso.Model.App;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Alcada
{
    public class AlcadaPerfilRepositorio : IDisposable
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

        #region Alcada Perfil
        public List<AlcadaPerfilModel> ObterAlcadaPerfil(AlcadaPerfilDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAlcadaPerfil();
            if (filtro.idAlcadaPerfil > 0)
                sentencaSql.Append($" AND idAlcadaPerfil = {filtro.idAlcadaPerfil}");
            else
                return null;

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AlcadaPerfilModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlAlcadaPerfil()
        {
            return new StringBuilder($@"SELECT  idAlcadaPerfil 
                                               ,idAlcadaUsuario 
                                               ,idAlcadaGrupo 
                                               ,idAlcadaPerfilUsuario 
                                            FROM  AlcadaPerfil
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
