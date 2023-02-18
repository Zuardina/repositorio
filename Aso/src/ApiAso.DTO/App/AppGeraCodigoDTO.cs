using ApiAso.DTO.Base;

namespace ApiAso.DTO.App
{
    public class AppGeraCodigoDTO : BaseDTO
    {
        public int idAppGeraCodigo { get; set; }
        public int idEmpresa { get; set; }
        public string Proprietario { get; set; }
    
    }
}
