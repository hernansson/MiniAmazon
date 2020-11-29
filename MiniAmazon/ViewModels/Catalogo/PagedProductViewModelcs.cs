using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Productos;
using MiniAmazon.ViewModels.Catalogo;

namespace MiniAmazon.ViewModels.Catalogo
{
    public class PagedProductViewModelcs
    {
        public PaginationViewModel PagedProducts;
        public IEnumerable<Marca> Marcas;
        public IEnumerable<Categoria> Categorias;
    }
}
