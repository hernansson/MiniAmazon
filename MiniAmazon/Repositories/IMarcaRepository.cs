using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Repositories
{
    public interface IMarcaRepository
    {
        Marca EncontrarMarcaID(Guid id);
        IEnumerable<Marca> ListaMarcas();
        void GuardarMarca(Marca marca);
        void BorrarMarca(Marca marca);
        void ActualizarMarca(Marca marca);
    }
}
