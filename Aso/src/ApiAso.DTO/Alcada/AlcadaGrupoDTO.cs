using ApiAso.DTO.Base;

namespace ApiAso.DTO.Alcada
{
    public class AlcadaGrupoDTO : BaseDTO
    {
        public int idAlcadaGrupo { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }         
    }
}
