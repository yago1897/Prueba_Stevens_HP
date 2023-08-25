using System;
using System.Collections.Generic;

namespace Services.Core.Data;

public partial class Autore
{
    public int IdAutor { get; set; }

    public string? NombreAutor { get; set; }

    public DateTime? AutorFechaNacimiento { get; set; }

    public string? CiudadAutor { get; set; }

    public string? EmailAutor { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
