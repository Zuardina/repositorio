using ApiAso.Model.Base;

namespace ApiAso.Model.Tipo
{
    public class TipoMotivoDesligamentoModel : BaseModel
    {
        public int idTipoMotivoDesligamento { get; set; }
        public int idEmpresa { get; set; }
        public string Descricao { get; set; }
    }
}