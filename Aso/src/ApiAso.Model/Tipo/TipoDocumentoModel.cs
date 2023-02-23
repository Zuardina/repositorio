using ApiAso.Model.Base;

namespace ApiAso.Model.Tipo
{
    public class TipoDocumentoModel : BaseModel
    {
        public int idTipoDocumento { get; set; }
        public string Descricao { get; set; }
        public string Mascara { get; set; }
        public bool FlagObrigatorio { get; set; }
    }
}