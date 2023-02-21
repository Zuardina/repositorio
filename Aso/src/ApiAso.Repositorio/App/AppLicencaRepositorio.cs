using ApiAso.DTO.App;
using ApiAso.Model.App;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.App
{
    public class AppLicencaRepositorio : IDisposable
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

        #region App pLicenca
        public List<AppLicencaModel> ObterAppLicenca(AppLicencaDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlAppLicenca();
            if (filtro.idAppLicenca > 0)
                sentencaSql.Append($" AND idAppLicenca = {filtro.idAppLicenca}");
            else if
               (filtro.idEmpresa > 0)
                sentencaSql.Append($" AND idEmpresa = {filtro.idEmpresa}");
            else
                return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Licenca))
                        sentencaSql.Append($" AND Licenca = '{filtro.Licenca}'");
                    if (!string.IsNullOrEmpty(filtro.NumeroTerminal))
                        sentencaSql.Append($" AND NumeroTerminal = '{filtro.NumeroTerminal}'");
                    if (!string.IsNullOrEmpty(filtro.UsuarioNoTerminal))
                        sentencaSql.Append($" AND UsuarioNoTerminal = '{filtro.UsuarioNoTerminal}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Licenca))
                        sentencaSql.Append($" AND Licenca LIKE '%{filtro.Licenca}%'");
                    if (!string.IsNullOrEmpty(filtro.NumeroTerminal))
                        sentencaSql.Append($" AND NumeroTerminal LIKE '%{filtro.NumeroTerminal}%'");
                    if (!string.IsNullOrEmpty(filtro.UsuarioNoTerminal))
                        sentencaSql.Append($" AND UsuarioNoTerminal LIKE '%{filtro.UsuarioNoTerminal}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<AppLicencaModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlAppLicenca()
        {
            return new StringBuilder($@"SELECT , idAppLicenca 
                                               , idEmpresa 
                                               , Licenca 
                                               , NumeroTerminal 
                                               , UsuarioNoTerminal 
                                               , DataExpiracao                                        
                                            FROM AppLicenca
                                            WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57"
        }
        #endregion

    }




}

