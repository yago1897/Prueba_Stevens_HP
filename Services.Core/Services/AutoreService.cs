using Services.Core.Data;
using Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Services
{
    public class AutoreService : IAutoreService
    {
        private readonly IAutoreRepository _autoreRepository;

        public AutoreService(IAutoreRepository autoreRepository)
        {
            _autoreRepository = autoreRepository;

        }

        public async Task<IEnumerable<Autore>> GetAutores()
        {
            return await _autoreRepository.GetAll();
        }

        public async Task<Autore> GetAutores(int id)
        {
            return await _autoreRepository.GetById(id);
        }

        public async Task InsertAutores(Autore entity)
        {
            await _autoreRepository.Add(entity);
        }

        public async Task ModificarAutores(Autore entity)
        {
            await _autoreRepository.Update(entity);

        }

        public async Task<bool> EliminarAutores(int id)
        {
            await _autoreRepository.Delete(id);
            return true;
        }

        public async Task<IEnumerable<string>> ConsultarPorNombre(string nombre)
        {
            return await _autoreRepository.GetByName(nombre);
        }

    }
}
