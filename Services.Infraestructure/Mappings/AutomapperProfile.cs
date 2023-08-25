using AutoMapper;
using Services.Core.Data;
using Services.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Autore, AutoreDTO>().ReverseMap();

            CreateMap<Autore, AutoreDTO>();
            CreateMap<AutoreDTO, Autore>();

            CreateMap<Libro, LibroDTO>()
            .ForMember(destino => destino.NombreAutor,
                opt => opt.MapFrom(origen => origen.IdAutorNavigation.NombreAutor)
                )
            .ForMember(destino => destino.LibroFecha,
                opt => opt.MapFrom(origen => origen.LibroFecha.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<LibroDTO, Libro>()
            .ForMember(destino => destino.IdAutorNavigation,
                opt => opt.Ignore()
                )
            .ForMember(destino => destino.LibroFecha,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.LibroFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );

        }
    }
}
