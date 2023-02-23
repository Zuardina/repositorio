using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaFuncionarioSetorModel : BaseModel
    {
        public int idPessoaFuncionarioSetor { get; set; }
        public int idPessoa { get; set; }
        public int idSetor { get; set; }
    }
}