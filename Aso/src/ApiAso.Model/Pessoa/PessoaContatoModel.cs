using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaContatoModel : BaseModel
    {
        public int idPessoaContato { get; set; }
        public int idPessoa { get; set; }
        public int idAppTipoContato { get; set; }
        public string Valor { get; set; }
        public string Contato { get; set; }
        public string Observacao { get; set; }
    }
}