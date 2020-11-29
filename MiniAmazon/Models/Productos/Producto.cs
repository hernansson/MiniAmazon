using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Shared;

namespace MiniAmazon.Models.Productos
{
    public class Producto : BaseObject
    {
        public string Nombre { get; set; }
        public string Slug { get; set; }
        public string Descripcion { get; set; }
        public string MetaDescripcion { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public string ImgUrl { get; set; }
        public int CantStock { get; set; }
        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public long MarcaId { get; set; }
        public Marca Marca { get; set; }
        public ProductoStatus ProductoStatus { get; set; }
    }
}
