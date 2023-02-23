using ApiAso.DTO.Base;

namespace ApiAso.DTO.Alcada
{
    public class AlcadaPerfilDTO : BaseDTO
    {
        public int idAlcadaPerfil { get; set; }
        public int idAlcadaUsuario { get; set; }
        public int idAlcadaGrupo { get; set; }
        public int idAlcadaPerfilUsuario { get; set; }
    }
}
