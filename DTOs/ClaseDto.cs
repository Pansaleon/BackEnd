using System.ComponentModel.DataAnnotations;
using WEBAPI_Backend.Entidades;

namespace WEBAPI_Backend.DTOs
{
    public class ClaseDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int MangaId { get; set; }

        public Manga manga { get; set; }
    }
}
