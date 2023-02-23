using ApiAso.DTO.Base;

namespace ApiAso.DTO.Alcada
{
    public class AlcadaUsuarioConectadoDTO : BaseDTO
    {
        public int idAlcadaUsuarioConectado { get; set; }
        public int idAlcadaUsuario { get; set; }
        public string IPterminal { get; set; }
    }
}
