using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Servicies;

namespace MiniAmazon.Controllers
{
    public class CatalogoController : Controller
    {
        private ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }
        public IActionResult Index(string categoriaslug = "todas-categorias", string marcaslug = "todas-marcas")
        {
            ViewData["CategoriaSeleccionada"] = categoriaslug;
            ViewData["MarcaSeleccionada"] = marcaslug;

            var pagedProducts = _catalogoService.FetchProducts(categoriaslug, marcaslug);
            return View(pagedProducts);
        }
    }
}
