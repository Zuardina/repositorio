using ApiAso.DTO.Base;

namespace ApiAso.DTO.Pessoa
{
    public class PessoaFuncionarioDTO: BaseDTO
    {
        public string CarteiraTrabalho { get; set; }
        public int idPessoaFuncionario { get; set; }
        public int idPessoa { get; set; }
   
    }
}
