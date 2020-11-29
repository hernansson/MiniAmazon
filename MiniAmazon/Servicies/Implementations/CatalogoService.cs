using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MiniAmazon.Repositories;
using MiniAmazon.Models.Productos;
using MiniAmazon.ViewModels.Catalogo;

namespace MiniAmazon.Servicies.Implementations
{
    public class CatalogoService : ICatalogoService
    {
        private IMarcaRepository _marcaRepository;
        private ICategoriaRepository _categoriaRepository;
        private IProductRepository _productoRepository;
        private readonly HttpContext _httpContext;
        private const int _productosPorPagina = 9; //hardcode
    

        public CatalogoService(IHttpContextAccessor httpContextAccessor,
            IMarcaRepository marcaRepository,
            ICategoriaRepository categoriaRepository,
            IProductRepository productRepository)
            {
                _marcaRepository = marcaRepository;
                _productoRepository = productRepository;
                _categoriaRepository = categoriaRepository;
                _httpContext = httpContextAccessor.HttpContext;
        }

        public PagedProductViewModelcs FetchProducts(string categoriaSlug, string marcaSlug)
        {
            var marcas = _marcaRepository.ListaMarcas().Where(marca => marca.vigente == true);
            var categorias = _categoriaRepository.ListaCategoria().Where(categoria => categoria.vigente == true);

            var paginaProducto = GetCurrentPage();
            IEnumerable<Producto> productos = new List<Producto>();
            int contadorProducto = 0;

            //TENEMOS 4 CASOS PARA FILTRAR

            if (categoriaSlug == "todas-categorias" && marcaSlug == "todas-marcas")
            {
                contadorProducto = _productoRepository.ListaProductos().Count();
                productos = _productoRepository.ListaProductos()
                    .Where(producto => producto.ProductoStatus == ProductoStatus.Activo)
                    .Skip((paginaProducto - 1) * _productosPorPagina)
                    .Take(_productosPorPagina);


            }

            if (categoriaSlug != "todas-categorias" && marcaSlug != "todas-marcas")
            {
                var productosFiltrados = _productoRepository.ListaProductos()
                    .Where(producto => producto.ProductoStatus == ProductoStatus.Activo &&
                                       producto.Categoria.Slug == categoriaSlug &&
                                       producto.Marca.Slug == marcaSlug);
                contadorProducto = productosFiltrados.Count();
                productos = productosFiltrados.Skip((paginaProducto - 1) * _productosPorPagina)
                                              .Take(_productosPorPagina);
            }

            if (categoriaSlug == "todas-categorias" && marcaSlug != "todas-marcas")
            {
                var productosFiltrados = _productoRepository.ListaProductos()
                                                            .Where(producto => producto.ProductoStatus == ProductoStatus.Activo &&
                                                                             producto.Marca.Slug == marcaSlug);
                contadorProducto = productosFiltrados.Count();
                productos = productosFiltrados.Skip((paginaProducto - 1) * _productosPorPagina)
                                             .Take(_productosPorPagina);

            }

            if (categoriaSlug != "todas-categorias" && marcaSlug == "todas-marcas")
            {
                var productosFiltrados = _productoRepository.ListaProductos()
                                                            .Where(producto => producto.ProductoStatus == ProductoStatus.Activo &&
                                                                             producto.Categoria.Slug == categoriaSlug);
                contadorProducto = productosFiltrados.Count();
                productos = productosFiltrados.Skip((paginaProducto - 1) * _productosPorPagina)
                                             .Take(_productosPorPagina);

            }

            var paginasTotales = (int)Math.Ceiling((decimal)contadorProducto / _productosPorPagina);
            int[] paginas = Enumerable.Range(1, paginasTotales).ToArray(); // un vector con la cantidad igual a la cantidad de paginas con X productos

            var pagedProduct = new PaginationViewModel
            {
                Productos = productos,
                TienePaginaAnterior = (paginaProducto > 1), //si la pagina en la que estas es mas que uno entonces tiene otra antes
                PaginaActual = paginaProducto,
                TienePaginaSiguiente = (paginaProducto < paginasTotales),
                Paginas=paginas

            };

            var pagedProducts = new PagedProductViewModelcs
            {
                PagedProducts = pagedProduct,
                Marcas = marcas,
                Categorias = categorias
            };
            return pagedProducts;
        }

        public int GetCurrentPage()                       // google fuerte-
        {
            var defaultPage = 1;
            if (_httpContext.Request.Path.HasValue)
            {
                var pathValues = _httpContext.Request.Path.Value.Split(separator: "/");
                var pageFragment = pathValues[pathValues.Length - 1];

                if (!string.IsNullOrWhiteSpace(pageFragment))
                {
                    var pageNumber = pageFragment.Last().ToString();
                    defaultPage = Convert.ToInt32(pageNumber);
                }
            }
            return defaultPage;
        }


    }
}
