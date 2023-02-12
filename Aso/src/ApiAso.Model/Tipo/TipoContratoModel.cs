using ApiAso.Model.Base;

namespace ApiAso.Model.Tipo
{
    public class TipoContratoModel : BaseModel
    {
        public int idTipoContrato { get; set; }
        public string Descricao { get; set; }
        public bool FlagPrazoDeterminado { get; set; }
    }
}
