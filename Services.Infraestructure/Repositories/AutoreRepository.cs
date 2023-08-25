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
    public class AutoreRepository : IAutoreRepository
    {

        private readonly PruebaStevensNexosContext _context;
        protected readonly DbSet<Autore> _entities;

        public AutoreRepository(PruebaStevensNexosContext context)
        {
            _context = context;
            _entities = context.Autores;
        }

        public async Task<IEnumerable<Autore>> GetAll()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autore> GetById(int id)
        {
            return await _context.Autores.FindAsync(id);
        }
        public async Task Add(Autore entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Autore entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            Autore autore = new Autore();
            autore = await GetById(id);
            _entities.Remove(autore);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<string>> GetByName(string nombre)
        {
            List<string> usuario;
            usuario = await _context.Autores.Where(x => x.NombreAutor.StartsWith(nombre)).Select(e => e.NombreAutor).Distinct().ToListAsync();
            return usuario;
        }
    }
}
