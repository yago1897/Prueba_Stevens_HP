create database Prueba_Stevens_HP

use Prueba_Stevens_HP
go

create table Autores(
idAutor int identity primary key NOT NULL,
nombreAutor varchar(50) ,
autorFechaNacimiento datetime,
ciudadAutor varchar(50) ,
emailAutor varchar(50) 
)


create table Libros(
idLibro int identity primary key not null,
libroTitulo varchar(50),
libroGenero varchar(50),
numeroPaginas varchar(50),
idAutor int foreign key references Autores(idAutor) 
on delete cascade on update cascade,
libroFecha datetime
)