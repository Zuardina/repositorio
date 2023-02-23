using ApiAso.Model.Base;

namespace ApiAso.Model.Produto
{
    public class ProdutoModel : BaseModel
    {
        public int idProduto { get; set; }
        public string Produto { get; set; }
        public string Observacao { get; set; }
    }
}