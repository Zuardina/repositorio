namespace ApiAso.Model.Alcada
{
    public class AlcadaUsuarioConectadoModel
    {
        public int idAlcadaUsuarioConectado { get; set; }
        public int idAlcadaUsuario { get; set; }
        public string IPterminal { get; set; }
        public DateTime DataAcessoInicial { get; set; }
        public DateTime DataAcessoFinal { get; set; }
    }
}