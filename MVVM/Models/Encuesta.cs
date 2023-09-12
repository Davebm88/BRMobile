namespace BRMobile.Models
{
    public class Encuesta
    {
        public int Id { get; set; }
        public string IdTienda { get; set; }
        public string Tienda { get; set; }
        public string Localidad { get; set; }
        public string Fecha { get; set; }
        public string FechaModificacion { get; set; }
        public int Cumplimiento { get; set; }
        public int Estatus { get; set; }
        public string Usuario { get; set; }
    }
}
