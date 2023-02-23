using ApiAso.DTO.Base;

namespace ApiAso.DTO.Tipo
{
    public class TipoContratoDTO : BaseDTO
    {
        public int idTipoContrato { get; set; }
        public string Descricao { get; set; }
    }
}