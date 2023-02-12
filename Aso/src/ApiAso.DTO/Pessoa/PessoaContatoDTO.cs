using ApiAso.DTO.Base;

namespace ApiAso.DTO.Pessoa
{
    public class PessoaContatoDTO : BaseDTO
    { 
        public int idPessoaContato { get; set; }
        public int idPessoa { get; set; }
        public string Contato { get; set; } 
    }
}
