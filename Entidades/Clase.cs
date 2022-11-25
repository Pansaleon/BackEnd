namespace WEBAPI_Backend.Entidades
{
    public class Clase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int MangaId { get; set; }
        public Manga manga { get; set; }
    }
}
