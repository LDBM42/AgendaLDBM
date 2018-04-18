Create database LDBMAgenda

use LDBMAgenda

create table Contactos(
ID int primary key identity,
Nombre varchar(100) not null,
Apellido varchar(100),
Télefono varchar(15) not null,
Notas varchar(max))

insert into Contactos values('Luis David','Betances Mosquea','829-937-7000','')

select * from Contactos
