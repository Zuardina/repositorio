using ApiAso.DTO.Alcada;
using ApiAso.Model.Alcada;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Alcada
{
    public class AlcadaUsuarioRepositorio : IDisposable
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

        #region Alcada Usuario 
        public List<AlcadaUsuarioModel> ObterAlcadaUsuario(AlcadaUsuarioDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAlcadaUsuario();
            if (filtro.idAlcadaUsuario > 0)
                sentencaSql.Append($" AND idAlcadaUsuario = {filtro.idAlcadaUsuario}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.NomeCompleto))
                        sentencaSql.Append($" AND NomeCompleto = '{filtro.NomeCompleto}'");
                    if (!string.IsNullOrEmpty(filtro.Email))
                        sentencaSql.Append($" AND Email = '{filtro.Email}'");
                    if (!string.IsNullOrEmpty(filtro.NomeLogin))
                        sentencaSql.Append($" AND NomeLogin = '{filtro.NomeLogin}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.NomeCompleto))
                        sentencaSql.Append($" AND NomeCompleto LIKE '%{filtro.NomeCompleto}%'");
                    if (!string.IsNullOrEmpty(filtro.Email))
                        sentencaSql.Append($" AND Email LIKE '%{filtro.Email}%'");
                    if (!string.IsNullOrEmpty(filtro.NomeLogin))
                        sentencaSql.Append($" AND NomeLogin LIKE '%{filtro.NomeLogin}%'");

                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AlcadaUsuarioModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }
        private StringBuilder ObterSentencaSqlAlcadaUsuario()
        {
            return new StringBuilder($@"SELECT   idAlcadaUsuario 
                                                ,idEmpresa 
                                                ,NomeCompleto 
                                                ,NomeLogin 
                                                ,Senha 
                                                ,Email 
                                                ,QuantidadeLogin 
                                                ,FlagBloqueio 
                                                ,FlagMudaSenhaExpira 
                                                ,Foto 
                                                ,DataTroca 
                                                ,DataValidade
                                            FROM  AlcadaUsuario
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion
    }
}
