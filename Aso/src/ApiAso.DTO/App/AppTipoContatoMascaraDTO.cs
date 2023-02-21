using ApiAso.DTO.Base;

namespace ApiAso.DTO.App
{
    public class AppTipoContatoMascaraDTO :BaseDTO
    {
        public int idAppTipoContatoMascara { get; set; }
        public string Descricao { get; set; }
        public string MascaraForm { get; set; }
        public string MascaraReact { get; set; }
    }
}