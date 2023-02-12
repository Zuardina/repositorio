using ApiAso.Model.Base;

namespace ApiAso.Model.App
{
    public class AppLicencaModel : BaseModel
    {
        public int idAppLicenca { get; set; }
        public int idEmpresa { get; set; }
        public string Licenca { get; set; }
        public string NumeroTerminal { get; set; }
        public string UsuarioNoTerminal { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
