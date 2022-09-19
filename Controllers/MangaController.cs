using Microsoft.AspNetCore.Mvc;
using WEBAPI_Backend.Entidades;

namespace WEBAPI_Backend.Controllers
{
    [ApiController]
    [Route("api/manga")]
    public class MangaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Manga>> Get()
        {
            return new List<Manga>()
            {
                new Manga() {Id = 1, Name = "Berserk", Author = "Kentaro Miura"},
                new Manga() {Id = 2, Name = "Claymore", Author = "Norihiro Yagi"}
            };
        }
    }
}
