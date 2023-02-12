using ApiAso.DTO.Base;

namespace ApiAso.DTO.Tipo
{
    public class TipoContatoDTO : BaseDTO
    {
        public int idTipoContato { get; set; }
        public int idTipoContatoMascara { get; set; }
        public string Descricao { get; set; }
    }
}
