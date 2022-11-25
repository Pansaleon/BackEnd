using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosWebAPI.Entidades;
using System;

namespace PedidosWebAPI.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ProductoController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await dbContext.Productos.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Producto producto)
        {
            dbContext.Add(producto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Producto producto, int id)
        {
            if (producto.Id != id)
            {
                return BadRequest("No existe con algun comprador.");
            }
            dbContext.Update(producto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Productos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Producto()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
