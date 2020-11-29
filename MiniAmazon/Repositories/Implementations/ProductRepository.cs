using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniAmazon.Database;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private MiniAmazonDbContext _context;

        public ProductRepository(MiniAmazonDbContext context)
        {
            _context = context;
        }

        public Producto EncontrarProductoID(long id)
        {
            var prod = _context.Productos.Find(id);
            return prod;
        }

        public IEnumerable<Producto> ListaProductos()
        {
            var prods = _context.Productos
                .Include(navigationPropertyPath: p => p.Categoria)  // Sin esto, me trae los productos pero sin categoria ni marca xq son clases dentro de la lista
                .Include(navigationPropertyPath: p => p.Marca);
            return prods;
        }

        public void GuardarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void BorrarProducto(Producto producto)
        {
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }

    }

}
