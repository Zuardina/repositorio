using ApiAso.DTO.Base;

namespace ApiAso.DTO.Pessoa
{
    public class PessoaEnderecoDTO : BaseDTO
    {
        public int idPessoaEndereco { get; set; }
        public int idPessoa { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
    }
}
