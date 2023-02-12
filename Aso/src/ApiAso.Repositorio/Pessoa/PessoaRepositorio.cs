using ApiAso.DTO.Pessoa;
using ApiAso.Model.Pessoa;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ApiAso.Repositorio.Pessoa
{
    public class PessoaRepositorio : IDisposable
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

        #region Pessoa
        public List<PessoaModel> ObterPessoa(PessoaDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlPessoa();
            sentencaSql.Append($" AND idPessoaProprietario = {filtro.idPessoaProprietario}");

            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorId:
                    if (filtro.idPessoa > 0)
                        sentencaSql.Append($" AND idPessoa = {filtro.idPessoa}");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.RazaoSocial))
                        sentencaSql.Append($" AND RazaoSocial = '{filtro.RazaoSocial}'");

                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.RazaoSocial))
                        sentencaSql.Append($" AND RazaoSocial LIKE '%{filtro.RazaoSocial}%'");

                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlPessoa()
        {
            return new StringBuilder($@"SELECT idPessoa
                                              ,idEmpresa
                                              ,idPessoaProprietario
                                              ,Codigo
                                              ,Documento
                                              ,SubDocumento
                                              ,RazaoSocial
                                              ,NomeFantasia
                                              ,TipoPessoa
                                              ,Logo
                                              ,FlagFilial
                                              ,FlagBloqueia
                                              ,FlagExcluido
                                              ,DataCadastro
                                          FROM Pessoa 
                                         WHERE FlagExcluido = 0
                                           AND idEmpresa = 57");
        }
        #endregion

        #region Pessoa Contato

        public List<PessoaContatoModel> ObterPessoaContato(PessoaContatoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlPessoaContato();
            if (filtro.idPessoa > 0)
                sentencaSql.Append($" AND idPessoa = {filtro.idPessoa}");
            else return null;
            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorId:
                    if (filtro.idPessoaContato > 0)
                        sentencaSql.Append($" AND idPessoaContato = {filtro.idPessoaContato}");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Contato))
                        sentencaSql.Append($" AND Contato = '{filtro.Contato}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Contato))
                        sentencaSql.Append($" AND Contato LIKE '%{filtro.Contato}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaContatoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlPessoaContato()
        {
            return new StringBuilder($@"SELECT idPessoaContato 
                                               ,idPessoa 
                                               ,idAppTipoContato 
                                               ,Valor 
                                               ,Contato 
                                               ,Observacao 
                                          FROM PessoaContato 
                                         WHERE FlagExcluido = 0 
                                         ");//Analisar se este WHERE é necessario "FlagExcluido" é uma referencia à base model 

                                            // AND idEmpresa = 57
        }
        #endregion

        #region Pessoa Endereco
        public List<PessoaEnderecoModel> ObterPessoaEndereco(PessoaEnderecoDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlPessoaEndereco();
            if (filtro.idPessoa > 0)
                sentencaSql.Append($" AND idPessoa = {filtro.idPessoa}");
            else
                return null;

            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorId:
                    if (filtro.idPessoaEndereco > 0)
                        sentencaSql.Append($" AND idPessoaEndereco = {filtro.idPessoaEndereco}");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.Cep))
                        sentencaSql.Append($" AND Cep = '{filtro.Cep}'");
                    if (!string.IsNullOrEmpty(filtro.Endereco))
                        sentencaSql.Append($" AND Endereco = '%{filtro.Endereco}%'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.Cep))
                        sentencaSql.Append($" AND Cep LIKE '%{filtro.Cep}%'");
                    if (!string.IsNullOrEmpty(filtro.Endereco))
                        sentencaSql.Append($" AND Endereco LIKE '%{filtro.Endereco}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaEnderecoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlPessoaEndereco()
        {
            return new StringBuilder($@"SELECT idPessoaEndereco 
                                              ,idPessoa 
                                              ,idTipoEndereco 
                                              ,Cep 
                                              ,Endereco 
                                              ,Numero 
                                              ,Complemento 
                                              ,Bairro 
                                              ,Cidade 
                                              ,UF 
                                              ,FlagRisco 
                                              ,FlagPrincipal 
                                          FROM PessoaEndereco 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57
        }
        #endregion

        #region Pessoa Funcionario

        public List<PessoaFuncionarioModel> ObterPessoaFuncionario(PessoaFuncionarioDTO filtro)
        {
            var sentencaSql = ObterSentencaSqlPessoaFuncionario();
            if (filtro.idPessoa > 0)
                sentencaSql.Append($" AND idPessoa = {filtro.idPessoa}");
            else return null;

            switch (filtro.PesquisaPor)
            {
                case Enumerador.ePesquisaPor.PorId:
                    if (filtro.idPessoaFuncionario > 0)
                        sentencaSql.Append($" AND idPessoaFuncionario = {filtro.idPessoaFuncionario}");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoIgualdade:
                    if (!string.IsNullOrEmpty(filtro.CarteiraTrabalho))
                        sentencaSql.Append($" AND CarteiraTrabalho = '{filtro.CarteiraTrabalho}'");
                    break;
                case Enumerador.ePesquisaPor.PorDescricaoPorComparacao:
                    if (!string.IsNullOrEmpty(filtro.CarteiraTrabalho))
                        sentencaSql.Append($" AND CarteiraTrabalho LIKE '%{filtro.CarteiraTrabalho}%'");
                    break;
            }

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaFuncionarioModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterSentencaSqlPessoaFuncionario()
        {
            return new StringBuilder($@"SELECT   NomePai 
                                            ,NomeMae 
                                            ,FatorRH 
                                            ,Observacao 
                                            ,CarteiraTrabalho 
                                            ,idPaisNascimento 
                                            ,idCorPele 
                                            ,idCorOlho 
                                            ,idOrgaoExpedidorRG 
                                            ,idUfRg 
                                            ,idTipoSanguineo 
                                            ,idEstadoCivil 
                                            ,idNascionalidade 
                                            ,idEscolaridade 
                                            ,idPessoaFuncionario 
                                            ,idPessoa 
                                            ,Sexo 
                                            ,Altura 
                                            ,DataNascimento 
                                            ,DataAdmissao 
                                            ,DataDemissao 
                                          FROM PessoaFuncionario 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57
        }
        #endregion

        #region Pessoa Funcionario Setor 
        public List<PessoaFuncionarioSetorModel> ObterPessoaFuncionarioSetor(PessoaFuncionarioSetorDTO filtro)
        {
            var sentencaSql = ObterPessoaFuncionarioSetor();
            if (filtro.idPessoa > 0)
                sentencaSql.Append($" AND idPessoa = {filtro.idPessoa}");
            else return null;
            if (filtro.idPessoaFuncionarioSetor > 0)
                sentencaSql.Append($" AND idPessoaFuncionarioSetor = {filtro.idPessoaFuncionarioSetor}");

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaFuncionarioSetorModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterPessoaFuncionarioSetor()
        {
            return new StringBuilder($@"SELECT  idPessoaFuncionarioSetor 
                                               ,idPessoa 
                                               ,idSetor 
                                          FROM PessoaFuncionarioSetor
                                         WHERE idSetor idSetor FidSetor lagExcluido = 0
                                         "); // AND idEmpresa = 57
        }
        #endregion

        #region Pessoa Funcionario Setor Funcao
        public List<PessoaFuncionarioSetorFuncaoModel> ObterPessoaFuncionarioSetorFuncao(PessoaFuncionarioSetorFuncaoDTO filtro)
        {
            var sentencaSql = ObterPessoaFuncionarioSetorFuncao();
            if (filtro.idPessoaFuncionario > 0)
                sentencaSql.Append($" AND idPessoaFuncionario = {filtro.idPessoaFuncionario}");

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaFuncionarioSetorFuncaoModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterPessoaFuncionarioSetorFuncao()
        {
            return new StringBuilder($@"SELECT  idPessoaFuncionarioSetorFuncao 
                                               ,idPessoaFuncionario 
                                               ,idFuncao 
                                               ,DataAdmissaoFuncao 
                                          FROM PessoaFuncionarioSetorFuncao 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57
        }
        #endregion

        #region Pessoa Funcionario Setor Funcao Exame 

        public List<PessoaFuncionarioSetorFuncaoExameModel> ObterPessoaFuncionarioSetorFuncaoExame(PessoaFuncionarioSetorFuncaoExameDTO filtro)
        {
            var sentencaSql = ObterPessoaFuncionarioSetorFuncaoExame();
            if (filtro.idPessoa > 0)
                sentencaSql.Append($" AND idPessoa = {filtro.idPessoa}");
            else return null;
            if (filtro.idPessoaFuncionarioSetorFuncaoExame > 0)
                sentencaSql.Append($" AND idPessoaFuncionarioSetorFuncaoExame = {filtro.idPessoaFuncionarioSetorFuncaoExame}");
            else return null;

            //Log.Infor($"Execução da sentença {sentencaSql.ToString()}")
            using (var conexao = new MySqlConnection(""))
            {
                return conexao.Query<PessoaFuncionarioSetorFuncaoExameModel>(sentencaSql.ToString(), commandType: CommandType.Text).ToList();
            }
        }

        private StringBuilder ObterPessoaFuncionarioSetorFuncaoExame()
        {
            return new StringBuilder($@"SELECT   idPessoaFuncionarioSetorFuncaoExame 
                                                ,idPessoa 
                                                ,idSetor 
                                                ,idFuncao 
                                                ,idExame 
                                                ,idPeriodicidade 
                                                ,DataExame 
                                          FROM PessoaFuncionarioSetorFuncaoExame 
                                         WHERE FlagExcluido = 0
                                         "); // AND idEmpresa = 57
        }
        #endregion

    }
}
