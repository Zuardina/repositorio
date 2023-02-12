using ApiAso.Model.Base;

namespace ApiAso.Model.Contrato
{
    public class ContratoModel : BaseModel
    {
        public int idContrato { get; set; }
        public int idPessoa { get; set; }
        public int idTipoContrato { get; set; }
        public int idProduto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorUnitario { get; set; } 
    }
}
