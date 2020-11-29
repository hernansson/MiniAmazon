using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Repositories
{
    public interface IProductRepository
    {
        Producto EncontrarProductoID(long id);
        IEnumerable<Producto> ListaProductos();
        void GuardarProducto(Producto prod);
        void BorrarProducto(Producto prod);
        void ActualizarProducto(Producto prod);
    }
}
