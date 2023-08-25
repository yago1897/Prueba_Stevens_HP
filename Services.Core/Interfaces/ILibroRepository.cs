using Services.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetAll();
        Task<Libro> GetById(int id);

        Task Add(Libro entity);

        Task Update(Libro entity);
        Task Delete(int id);
    }
}
