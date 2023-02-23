using ApiAso.DTO.Base;

namespace ApiAso.DTO.Tipo
{
    public class TipoEnderecoDTO : BaseDTO
    {
        public int idTipoEndereco { get; set; }
        public string Descricao { get; set; }
    }
}