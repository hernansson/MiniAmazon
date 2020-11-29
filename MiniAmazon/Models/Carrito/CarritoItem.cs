using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Shared;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Models.Carrito
{
    public class CarritoItem : BaseObject
    {
        public long  CarritoItemId { get; set; }
        public Carrito Carrito { get; set; }
        public long ProductId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
