using ApiAso.Model.Base;

namespace ApiAso.Model.Tipo
{
    public class TipoEnderecoModel : BaseModel
    {
        public int idTipoEndereco{ get; set; }
        public string Descricao { get; set; }
        public bool FlagObrigatorio { get; set; }
    }
}
