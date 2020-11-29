using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Shared;

namespace MiniAmazon.Models.Productos
{
    public class Categoria : BaseObject
    {
        public string Nombre { get; set; }
        public string Slug { get; set; }
        public string Descripcion { get; set; }
        public string MetaDescripcion { get; set; }
        public CategoriaStatus CategoriaStatus { get; set; }
    }
}
