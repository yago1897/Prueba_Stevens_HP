using System;
using System.Collections.Generic;

namespace Services.Core.Data;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? LibroTitulo { get; set; }

    public string? LibroGenero { get; set; }

    public string? NumeroPaginas { get; set; }

    public int IdAutor { get; set; }

    public DateTime? LibroFecha { get; set; }

    public virtual Autore IdAutorNavigation { get; set; } = null!;
}
