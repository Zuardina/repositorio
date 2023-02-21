using ApiAso.DTO.Base;

namespace ApiAso.DTO.App
{
    public class AppLicencaDTO : BaseDTO
    {
        public int idAppLicenca { get; set; }
        public int idEmpresa { get; set; }
        public string Licenca { get; set; }
        public string NumeroTerminal { get; set; }
        public string UsuarioNoTerminal { get; set; }
    
    }
}
