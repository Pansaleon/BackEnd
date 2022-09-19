
using Microsoft.EntityFrameworkCore;
using WEBAPI_Backend.Entidades;

namespace WEBAPI_Backend
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Manga> Mangas { get; set; }
    }
}
