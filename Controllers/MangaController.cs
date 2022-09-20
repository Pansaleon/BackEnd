using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI_Backend.Entidades;

namespace WEBAPI_Backend.Controllers
{
    [ApiController]
    [Route("api/manga")]
    public class MangaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MangaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<List<Manga>>> Get()
        {
            return await dbContext.Mangas.ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult> Post(Manga manga)
        {
            dbContext.Add(manga);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
