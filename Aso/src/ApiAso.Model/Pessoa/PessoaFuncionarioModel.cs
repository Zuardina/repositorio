using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaFuncionarioModel : BaseModel
    {
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string FatorRH { get; set; }
        public string Observacao { get; set; }
        public string CarteiraTrabalho { get; set; }
        public int idPaisNascimento { get; set; }
        public int idCorPele { get; set; }
        public int idCorOlho { get; set; }
        public int idOrgaoExpedidorRG { get; set; }
        public int idUfRg { get; set; }
        public int idTipoSanguineo { get; set; }
        public int idEstadoCivil { get; set; }
        public int idNascionalidade { get; set; }
        public int idEscolaridade { get; set; }
        public int idPessoaFuncionario { get; set; }
        public int idPessoa { get; set; }
        public char Sexo { get; set; }
        public decimal Altura { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
    }
}
