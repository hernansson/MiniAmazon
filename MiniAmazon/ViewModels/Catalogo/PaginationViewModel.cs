using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.ViewModels.Catalogo
{
    public class PaginationViewModel
    {
        public IEnumerable<Producto> Productos;
        public bool TienePaginaAnterior;
        public int PaginaActual;
        public bool TienePaginaSiguiente;
        public int[] Paginas;
    }
}
