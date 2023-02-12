using ApiAso.Model.Base;

namespace ApiAso.Model.Tipo
{
    public class TipoContatoModel : BaseModel
    {
        public int idTipoContato { get; set; }
        public int idTipoContatoMascara { get; set; }
        public string Descricao { get; set; }
        public bool FlagValidacao { get; set; }
        public bool FlagObrigatorio { get; set; }
    }
}
