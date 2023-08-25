using Services.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<Libro>> GetLibros();
        Task<Libro> GetLibros(int id);

        Task InsertLibros(Libro entity);

        Task<bool> ModificarLibros(Libro entity);

        Task<bool> EliminarLibros(int id);
    }
}
