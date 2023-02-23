using ApiAso.DTO.Base;

namespace ApiAso.DTO.Alcada
{
    public class AlcadaUsuarioDTO : BaseDTO
    {
        public int idAlcadaUsuario { get; set; }
        public int idEmpresa { get; set; }
        public int QuantidadeLogin { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeLogin { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
