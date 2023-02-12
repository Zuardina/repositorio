using ApiAso.Model.Base;

namespace ApiAso.Model.App
{
    public class AppGeraCodigoModel : BaseModel
    {
        public int idAppGeraCodigo { get; set; }
        public int idEmpresa { get; set; }
        public string Proprietario { get; set; }
        public long Sequencia { get; set; }
    }
}
