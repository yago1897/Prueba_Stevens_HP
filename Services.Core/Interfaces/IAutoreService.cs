using Services.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface IAutoreService
    {
        Task<IEnumerable<Autore>> GetAutores();
        Task<Autore> GetAutores(int id);

        Task InsertAutores(Autore entity);

        Task ModificarAutores(Autore entity);

        Task<bool> EliminarAutores(int id);

        Task<IEnumerable<string>> ConsultarPorNombre(string nombre);
    }
}
