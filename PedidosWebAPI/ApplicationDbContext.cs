using Microsoft.EntityFrameworkCore;
using PedidosWebAPI.Entidades;

namespace PedidosWebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<Comprador> Compradores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
