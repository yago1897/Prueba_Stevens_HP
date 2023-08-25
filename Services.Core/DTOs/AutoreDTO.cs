using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.DTOs
{
    public class AutoreDTO
    {
        public int IdAutor { get; set; }

        public string? NombreAutor { get; set; }

        public DateTime? AutorFechaNacimiento { get; set; }

        public string? CiudadAutor { get; set; }

        public string? EmailAutor { get; set; }
    }
}
