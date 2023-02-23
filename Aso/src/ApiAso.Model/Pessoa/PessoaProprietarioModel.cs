using ApiAso.Model.Base;

namespace ApiAso.Model.Pessoa
{
    public class PessoaProprietarioModel : BaseModel
    {
        public int idPessoaProprietario { get; set; }
        public string Descricao { get; set; }
    }
}