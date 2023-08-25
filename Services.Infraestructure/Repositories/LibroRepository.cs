using Microsoft.EntityFrameworkCore;
using Services.Core.Data;
using Services.Core.Interfaces;
using Services.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly PruebaStevensNexosContext _context;
        protected readonly DbSet<Libro> _entities;

        public LibroRepository(PruebaStevensNexosContext context)
        {
            _context = context;
            _entities = context.Libros;
        }

        public async Task<IEnumerable<Libro>> GetAll()
        {
            //return await _context.Libros.ToListAsync();
            return await _context.Libros.Include(dpt => dpt.IdAutorNavigation).ToListAsync();
        }

        public async Task<Libro> GetById(int id)
        {
            return await _context.Libros.FindAsync(id);
        }
        public async Task Add(Libro entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Libro entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Libro libro = new Libro();
            libro = await GetById(id);
            _entities.Remove(libro);
            await _context.SaveChangesAsync();
        }
    }
}
