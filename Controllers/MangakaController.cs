using Microsoft.AspNetCore.Mvc;
using WEBAPI_Backend.Entidades;
using Microsoft.EntityFrameworkCore;
namespace WEBAPI_Backend.Controllers
{
        [ApiController]
        [Route("api/mangaka")]
        public class MangakaController : ControllerBase
        {
            private readonly ApplicationDbContext dbContext;

            public MangakaController(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            [HttpGet]

            public async Task<ActionResult<List<Mangaka>>> Get()
            {
            return await dbContext.Mangakas.ToListAsync();

            }
            [HttpPost]
            public async Task<ActionResult> Post(Mangaka mangaka)
            {
                dbContext.Add(mangaka);
                await dbContext.SaveChangesAsync();
                return Ok();
            }

        }
}
