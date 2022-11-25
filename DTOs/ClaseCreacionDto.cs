using System.ComponentModel.DataAnnotations;
using WEBAPI_Backend.Validaciones;
namespace WEBAPI_Backend.DTOs
{

    public class ClaseCreacionDto
    {
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public List<int> MangasIds { get; set; }
    }
}
