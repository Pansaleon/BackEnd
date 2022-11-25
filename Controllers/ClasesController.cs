using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI_Backend.DTOs;
using WEBAPI_Backend.Entidades;

namespace WEBAPI_Backend.Controllers
{
    [ApiController]
    [Route("api/clases")]
    public class ClasesController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public ClasesController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        
        [HttpGet("/listadoClase")]
        public async Task<ActionResult<List<Clase>>> GetAll()
        {
            return await dbContext.Clases.ToListAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Clase>> GetById(int id)
        {
            return await dbContext.Clases.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult> Post(ClaseCreacionDto claseCreacionDto)
        {
            if (claseCreacionDto.MangasIds == null)
            {
                return BadRequest("No se puede crear una clase sin mangas.");
            }

            var mangasIds = await dbContext.Mangas
                .Where(mangaBD => claseCreacionDto.MangasIds.Contains(mangaBD.Id)).Select(x=> x.Id).ToListAsync();


            if (claseCreacionDto.MangasIds.Count != mangasIds.Count)
            {
                return BadRequest("No existe uno de los alumnos enviados");
            }
            var clase = mapper.Map<Clase>(claseCreacionDto);

            dbContext.Add(clase);
            await dbContext.SaveChangesAsync();
            var claseDto = mapper.Map<ClaseDto>(clase);

            return CreatedAtRoute("obtenerClase", new { id = clase.Id}, claseDto);
        }


        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Clase clase, int id)
        {
            var exist = await dbContext.Clases.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("La clase especificada no existe");
            }
            if (clase.Id != id)
            {
                return BadRequest("El id de la clase no coincide con el establecido en la url.");
            }
            dbContext.Update(clase);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Clases.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }
            dbContext.Remove(new Clase { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
