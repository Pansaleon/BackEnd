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

        public MangaController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Manga>>> Get()
        {
            return await dbContext.Mangas.Include(x=>x.clases).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Manga manga)
        {
            dbContext.Add(manga);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id}:int")] //api/mangas/1
        public async Task<ActionResult> Put(Manga manga, int id)
        {
            if(manga.Id != id)
            {
                return BadRequest("El id del manga no coincide con el establecido en la url.");
            }
            dbContext.Update(manga);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Mangas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Manga()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
