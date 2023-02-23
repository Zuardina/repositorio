using ApiAso.Model.Base;

namespace ApiAso.Model.Exame
{
    public class ExameModel : BaseModel
    {
        public int idExame { get; set; }
        public string Exame { get; set; }
        public string CID { get; set; }
    }
}