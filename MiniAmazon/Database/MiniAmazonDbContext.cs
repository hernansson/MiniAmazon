
using Microsoft.EntityFrameworkCore;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Database
{
    public class MiniAmazonDbContext : DbContext
    {
        public  MiniAmazonDbContext(DbContextOptions<MiniAmazonDbContext> options) : base(options) { }
        
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        
    }

    
    

    
}
