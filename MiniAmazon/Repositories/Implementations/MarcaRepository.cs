using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniAmazon.Database;
using MiniAmazon.Models.Productos;

namespace MiniAmazon.Repositories.Implementations
{
    public class MarcaRepository : IMarcaRepository
    {
        private MiniAmazonDbContext _context;

        public MarcaRepository(MiniAmazonDbContext context)
        {
            _context = context;
        }

        public Marca EncontrarMarcaID(Guid id)
        {
            var marca = _context.Marcas.Find(id);
            return marca;
        }

        public IEnumerable<Marca> ListaMarcas()
        {
            var marcas = _context.Marcas;
            return marcas;
        }
        public void GuardarMarca(Marca marca)
        {
            _context.Add(marca);
            _context.SaveChanges();
        }
        public void BorrarMarca(Marca marca)
        {
            _context.Remove(marca);
            _context.SaveChanges();
        }

        public void ActualizarMarca(Marca marca)
        {
            _context.Update(marca);
            _context.SaveChanges();
        }
    }
}
