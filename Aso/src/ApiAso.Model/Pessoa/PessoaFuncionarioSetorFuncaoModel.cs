using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaFuncionarioSetorFuncaoModel : BaseModel
    {
        public int idPessoaFuncionarioSetorFuncao { get; set; }
        public int idPessoaFuncionario { get; set; }
        public int idFuncao { get; set; }
        public DateTime DataAdmissaoFuncao { get; set; }
    }
}