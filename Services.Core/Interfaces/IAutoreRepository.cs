using Services.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
   public interface  IAutoreRepository
    {
        Task<IEnumerable<Autore>> GetAll();
        Task<Autore> GetById(int id);

        Task Add(Autore entity);

        Task Update(Autore entity);
        Task Delete(int id);

        Task<IEnumerable<string>> GetByName(string nombre);
    }
}
