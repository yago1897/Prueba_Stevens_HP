using System;
using System.Collections.Generic;

namespace Services.Infraestructure.Data;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string? IdIdentificacion { get; set; }

    public string? NombrePaciente { get; set; }

    public string? DireccionPaciente { get; set; }

    public string? Email { get; set; }
}
