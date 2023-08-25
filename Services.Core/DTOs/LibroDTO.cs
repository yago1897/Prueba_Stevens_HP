using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.DTOs
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }

        public string? LibroTitulo { get; set; }

        public string? LibroGenero { get; set; }

        public string? NumeroPaginas { get; set; }

        public int IdAutor { get; set; }
        public string? NombreAutor { get; set; }

        public string? LibroFecha { get; set; }
    }
}
