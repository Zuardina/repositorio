using ApiAso.DTO.Base;

namespace ApiAso.DTO.Produto
{
    public class ProdutoDTO : BaseDTO
    {
        public int idProduto { get; set; }
        public string Produto { get; set; }
    }
}
