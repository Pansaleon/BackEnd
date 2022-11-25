using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosWebAPI.Entidades;

namespace PedidosWebAPI.Controllers
{
    [ApiController]
    [Route("api/comprador")]
    public class CompradorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CompradorController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comprador>>> Get()
        {
            return await dbContext.Compradores.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Comprador comprador)
        {
            dbContext.Add(comprador);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Comprador comprador, int id)
        {
            if(comprador.Id != id)
            {
                return BadRequest("No existe con algun comprador.");
            }
            dbContext.Update(comprador);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Compradores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Comprador()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }

}
