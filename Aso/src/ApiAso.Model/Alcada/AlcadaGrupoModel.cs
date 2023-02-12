using ApiAso.Model.Base;

namespace ApiAso.Model.Alcada
{
    public class AlcadaGrupoModel : BaseModel
    {
        public int idAlcadaGrupo { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataValidade { get; set; }
        public int QuantidadeLogin { get; set; }
        public bool FlagBloqueado { get; set; }
    }
}
