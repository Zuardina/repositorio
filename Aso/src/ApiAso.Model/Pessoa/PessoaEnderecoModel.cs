using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaEnderecoModel : BaseModel
    {
        public int idPessoaEndereco { get; set; }
        public int idPessoa { get; set; }
        public int idTipoEndereco { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool FlagRisco { get; set; }
        public bool FlagPrincipal { get; set; }
    }
}