using Services.Core.Data;
using Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;

        }

        public async Task<IEnumerable<Libro>> GetLibros()
        {
            return await _libroRepository.GetAll();
        }

        public async Task<Libro> GetLibros(int id)
        {
            return await _libroRepository.GetById(id);
        }

        public async Task InsertLibros(Libro entity)
        {
            await _libroRepository.Add(entity);
        }

        public async Task<bool> ModificarLibros(Libro entity)
        {
            await _libroRepository.Update(entity);
            return true;
        }

        public async Task<bool> EliminarLibros(int id)
        {
            await _libroRepository.Delete(id);
            return true;
        }
    }
}
