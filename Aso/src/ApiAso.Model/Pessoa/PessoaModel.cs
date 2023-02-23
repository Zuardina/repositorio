using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaModel : BaseModel
    {
        public int idPessoa { get; set; }
        public int idEmpresa { get; set; }
        public int idPessoaProprietario { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string SubDocumento { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string TipoPessoa { get; set; }
        public string Logo { get; set; }
        public bool FlagFilial { get; set; }
        public bool FlagBloqueia { get; set; }
    }
}