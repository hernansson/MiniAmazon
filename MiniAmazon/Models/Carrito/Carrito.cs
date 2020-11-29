using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Shared;
using MiniAmazon.Models.Carrito;

namespace MiniAmazon.Models.Carrito
{
    public class Carrito: BaseObject
    {
        public Carrito()
        {
            CarritoItems = new List<CarritoItem>();
        }

        public long CarritoId { get; set; }
        public CarritoStatus CarritoStatus { get; set; }
        public IEnumerable<CarritoItem> CarritoItems { get; set; }

    }
}
