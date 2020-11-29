using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAmazon.Models.Shared
{
    public class BaseObject
    {
        public long Id { get; set; }

        public DateTimeOffset FechaCreada { get; set; }

        public DateTimeOffset FechaModificada { get; set; }

        public bool vigente { get; set; }
    }
}
