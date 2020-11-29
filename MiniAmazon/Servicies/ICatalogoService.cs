using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.ViewModels.Catalogo;

namespace MiniAmazon.Servicies
{
    public interface ICatalogoService
    {
        PagedProductViewModelcs FetchProducts(string categorySlug, string marcaSlug);
    }
}
