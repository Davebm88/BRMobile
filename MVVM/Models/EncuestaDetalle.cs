namespace BRMobile.Models
{
    public class EncuestaDetalle
    {
        public int Id { get; set; }
        public int IdEncuesta { get; set; }
        public int IdTienda { get; set; }
        public string Fecha { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int Cumplimiento { get; set; }
        public string Comentarios { get; set; }
        public string Acciones { get; set; }
        public string FechaModificacion { get; set; }
        public string Evidencia { get; set; }
    }
}
