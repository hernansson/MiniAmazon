using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Database;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Repositories.Implementations
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private MiniAmazonDbContext _context;

        public CategoriaRepository(MiniAmazonDbContext context)
        {
            _context = context;
        }

        public Categoria EncontrarCategoriaID(long id)
        {
            var cat = _context.Categorias.Find(id);
            return cat;
        }

        public IEnumerable<Categoria> ListaCategoria()
        {
            var cats = _context.Categorias;
            return cats;
        }

        public void GuardarCategoria(Categoria cat)
        {
            _context.Categorias.Add(cat);
            _context.SaveChanges();
        }

        public void BorrarCategoria (Categoria cat)
        {
            _context.Categorias.Remove(cat);
            _context.SaveChanges();
        }

        public void ActualizarCategoria(Categoria cat)
        {
            _context.Categorias.Update(cat);
            _context.SaveChanges();
        }
    }
}
