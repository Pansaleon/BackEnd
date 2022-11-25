using System.ComponentModel.DataAnnotations;
using WEBAPI_Backend.Entidades;
using WEBAPI_Backend.Validaciones;

namespace WEBAPI_Backend.DTOs
{
    public class MangaDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener hasta 30 caracteres")]
        [PrimeraLetraMayuscula]
        public string Name { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener hasta 30 caracteres")]
        [PrimeraLetraMayuscula]
        public string Author { get; set; }


        public List<ClaseDto> clases { get; set; }

    }
}
