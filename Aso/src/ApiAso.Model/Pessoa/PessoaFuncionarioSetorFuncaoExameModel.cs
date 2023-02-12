using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaFuncionarioSetorFuncaoExameModel : BaseModel
    {
        public int idPessoaFuncionarioSetorFuncaoExame { get; set; }
        public int idPessoa { get; set; }
        public int idSetor { get; set; }
        public int idFuncao { get; set; }
        public int idExame { get; set; }
        public int idPeriodicidade { get; set; }
        public DateTime DataExame { get; set; }
    }
}
