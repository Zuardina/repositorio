using ApiAso.DTO.Base;

namespace ApiAso.DTO.Pessoa
{
    public class PessoaDTO : BaseDTO
    {
        public int idPessoa { get; set; }
        public int idPessoaProprietario { get; set; }
        public string RazaoSocial { get; set; }
        public string Documento { get; set; }
    }
}