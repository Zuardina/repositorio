using ApiAso.DTO.Base;

namespace ApiAso.DTO.Tipo
{
    public class TipoDocumentoDTO : BaseDTO
    {
        public int idTipoDocumento { get; set; }
        public string Descricao { get; set; }
        public string Mascara { get; set; }
    }
}