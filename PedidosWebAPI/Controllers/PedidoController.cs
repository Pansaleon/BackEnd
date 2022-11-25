using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosWebAPI.Entidades;

namespace PedidosWebAPI.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PedidoController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            return await dbContext.Pedidos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pedido pedido)
        {
            dbContext.Add(pedido);
            await dbContext.SaveChangesAsync();
            return Ok();
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Pedido pedido, int id)
        {
            if (pedido.Id != id)
            {
                return BadRequest("No existe con algun comprador.");
            }
            dbContext.Update(pedido);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Pedidos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Pedido()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
