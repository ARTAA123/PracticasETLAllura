namespace VideojuegosWebAPI.Models
{
    public class VideoJuegos
    {
        public int Id_Juego { get; set; }
        public int Serial_Number { get; set; }
        public DateTime Año_Publicacion { get; set; }
        public string Casa_Fabricante { get; set; }
        public List<Tipo_De_Juego>? Tipo_De_Juego { get; set; }

    }
}
