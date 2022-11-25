using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using WEBAPI_Backend.DTOs;
using WEBAPI_Backend.Entidades;

namespace WEBAPI_Backend.Controllers
{
    [ApiController]
    [Route("api/manga")]
    public class MangaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public MangaController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
           
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }


        [HttpGet]
        public async Task<ActionResult<List<MangaDto>>> Get()
        {
            var mangas = await dbContext.Mangas.ToListAsync();
            return mapper.Map<List<MangaDto>>(mangas);
        }


        [HttpGet("{id}:int", Name = "obtenermanga")] 
        public async Task<ActionResult<MangaDtoConClases>> Get(int id)
        {
            var manga = await dbContext.Mangas
                .Include(mangaDB => mangaDB.clases)
                .ThenInclude(mangaClaseDB => mangaClaseDB.Name)
                .FirstOrDefaultAsync(mangaDb => mangaDb.Id == id);
            if(manga == null)
            {
                return NotFound();
            }

            return mapper.Map<MangaDtoConClases>(manga);
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<List<MangaDto>>> Get([FromRoute] string nombre)
        {
            var mangas = await dbContext.Mangas.Where(mangaBD => mangaBD.Name.Contains(nombre)).ToListAsync();
            return mapper.Map<List<MangaDto>>(mangas);
        }


        [HttpPost]
        public async Task<ActionResult> Post(MangaDto mangaDto)
        {
            var existeMangaMismoNombre = await dbContext.Mangas.AnyAsync(x => x.Name == mangaDto.Name);
            if (existeMangaMismoNombre)
            {
                return BadRequest($"Ya existe un manga con este mismo nombere{mangaDto.Name}");
            }
            var manga = mapper.Map<MangaDto>(mangaDto);

            dbContext.Add(manga);

            await dbContext.SaveChangesAsync();

            var mangaDTO = mapper.Map<MangaDto>(manga);
            
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
