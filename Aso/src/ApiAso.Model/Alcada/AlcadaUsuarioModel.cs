using ApiAso.Model.Base;

namespace ApiAso.Model.Alcada
{
    public class AlcadaUsuarioModel : BaseModel
    {
        public int idAlcadaUsuario { get; set; }
        public int idEmpresa { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeLogin { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int QuantidadeLogin { get; set; }
        public bool FlagBloqueio { get; set; }
        public bool FlagMudaSenhaExpira { get; set; }
        public string Foto { get; set; }
        public DateTime DataTroca { get; set; }
        public DateTime DataValidade { get; set; }
    }
}