using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria EncontrarCategoriaID(long id);
        IEnumerable<Categoria> ListaCategoria();
        void GuardarCategoria(Categoria cat);
        void BorrarCategoria(Categoria cat);
        void ActualizarCategoria(Categoria cat);
    }
}
