-- cerrar todas las conexiones a la base de datos
use master
go
IF EXISTS(SELECT * from sys.databases WHERE name='EI5447CommunitasBD')  
BEGIN 
alter database EI5447CommunitasBD set single_user 
with rollback immediate
END 
go

-- buscamos si existe la base de datos
IF EXISTS(SELECT * from sys.databases WHERE name='EI5447CommunitasBD')  
BEGIN 
	-- seleccionamos el master 
	use master
	--eliminamos la base de datos 
    drop DATABASE EI5447CommunitasBD
END 
go

-- creacion de la base de datos
create database EI5447CommunitasBD
go

-- seleccionamos la base de datos
use EI5447CommunitasBD
go

-- creacion de tablas
-- simples
--pais
create table pais(
	idpais integer primary key identity(1,1),
	nompais VARCHAR(100) not null,
	estpais BIT not null DEFAULT 1
)
go

--categoria
create table categoria(
	idcategoria integer primary key identity(1,1),
	nomcategoria VARCHAR(100) not null,
	estcategoria BIT not null DEFAULT 1
)
go

--editorial
create table editorial(
	ideditorial integer primary key identity(1,1),
	nomeditorial VARCHAR(100) not null,
	esteditorial BIT not null DEFAULT 1
)
go

--proveedor
create table proveedor(
	idprov integer primary key identity(1,1),
	razsocprov VARCHAR(200) not null,
	rucprov CHAR(11) not null unique,
	telfprov VARCHAR(30) not null,
	corprov VARCHAR(100) not null,
	direcprov VARCHAR(100) not null,
	estprov BIT not null DEFAULT 1
)
go

--tipo de pago
create table tipopago(
	idtippag integer primary key identity(1,1),
	nomtippag VARCHAR(100) not null,
	esttippag BIT not null DEFAULT 1
)
go

--tipo de documento
create table tipodocumento(
	idtipdoc integer primary key identity(1,1),
	nomtipdoc VARCHAR(100) not null,
	esttipdoc BIT not null DEFAULT 1
)
go

--rol
create table rol(
	idrol integer primary key identity(1,1),
	nomrol VARCHAR(100) not null,
	estrol BIT not null DEFAULT 1
)
go

--distrito
create table distrito(
	iddis int primary key identity(1,1),
	nomdis VARCHAR(80) not null, 
	estdis BIT not null DEFAULT 1
)
go

--cruzadas
--cliente
create table cliente(
	idcli integer primary key identity(1,1),
	nomcli VARCHAR(80) not null,
	apepcli VARCHAR(80) not null,
	apemcli VARCHAR(80) not null,
	numdoccli VARCHAR(20) not null unique,
	fecnaccli DATE not null,
	dircli VARCHAR(100) not null,	
	telcli VARCHAR(30) not null,
	corcli VARCHAR(100) not null,
	estcli BIT not null DEFAULT 1,
	idtipdoc int not null, 
	iddis int not null, 
	foreign key (idtipdoc) references tipodocumento(idtipdoc),
	foreign key (iddis) references distrito(iddis)
)
go

--empleado
create table empleado(
	idemp integer primary key identity(1,1),
	nomemp VARCHAR(80) not null,
	apepemp VARCHAR(80) not null,
	apememp VARCHAR(80) not null,
	numdocemp VARCHAR(20) not null unique,
	fecnacemp DATE not null,
	diremp VARCHAR(100) not null, 
	telemp VARCHAR(30) not null,
	coremp VARCHAR(100) not null,
	fecinemp DATE not null, 
	usuemp VARCHAR(100) not null,
	claemp VARCHAR(100) not null,
	sueldoemp MONEY not null CHECK(sueldoemp > 0), 
	numhoremp INT not null, 
	estemp BIT not null DEFAULT 1,
	idtipdoc int not null,
	idrol int not null,
	iddis int not null, 
	foreign key (idtipdoc) references tipodocumento(idtipdoc),
	foreign key (idrol) references rol(idrol),
	foreign key (iddis) references distrito(iddis)
)
go

--compra
create table compra(
	idcompra int primary key identity(1,1),
	feccompra DATETIME not null, 
	totalcompra MONEY not null,
	estcompra BIT not null default 1,
	idprov INT not null, 
	foreign key (idprov) references proveedor(idprov)
)
go

--producto
create table producto(
	idprod int primary key identity(1,1),
	isbnprod VARCHAR(20) not null unique, 
	titprod VARCHAR(250) not null,
	descprod VARCHAR(500) not null,
	preccompprod MONEY not null CHECK(preccompprod >= 0), 
	precventprod MONEY not null CHECK(precventprod >= 0), 
	fecpubprod DATE not null, 
	estprod BIT not null DEFAULT 1,
	idprov int not null,
	idcategoria int not null, 
	ideditorial int not null, 
	foreign key (idprov) references proveedor(idprov),
	foreign key (idcategoria) references categoria(idcategoria),
	foreign key (ideditorial) references editorial(ideditorial)
)
go

--autor
create table autor(
	idautor int primary key identity(1,1),
	nomautor VARCHAR(100) not null, 
	apepautor VARCHAR(100) not null, 
	apemautor VARCHAR(100) not null, 
	estautor BIT not null DEFAULT 1, 
	idpais INT not null, 
	foreign key (idpais) references pais(idpais)
)
go

--venta
create table venta(
	idventa INT primary key identity(1,1),
	fecventa DATETIME NOT NULL, 
	totalventa MONEY not null, 
	estventa BIT not null default 1, 
	idemp int not null,
	idcli int not null, 
	idtippag int not null,
	foreign key (idemp) references empleado(idemp),
	foreign key (idcli) references cliente(idcli),
	foreign key (idtippag) references tipopago(idtippag)
)
go

--detalle compra 
create table detallecompra(
	iddetcomp int primary key identity(1,1),
	idcompra int not null, 
	idprod int not null, 
	cancompra int not null CHECK(cancompra > 0), 
	precucomp money not null CHECK(precucomp >= 0),
	subtotcomp money not null CHECK(subtotcomp >= 0),
	foreign key (idcompra) references compra(idcompra),
	foreign key (idprod) references producto(idprod)
)
go

--detalle venta
create table detalleventa(
	iddetvent int primary key identity(1,1),
	idventa int not null, 
	idprod int not null, 
	canventa int not null CHECK(canventa > 0), 
	precuventa money not null CHECK(precuventa >= 0), 
	subtotventa money not null CHECK(subtotventa >= 0), 
	foreign key (idventa) references venta(idventa),
	foreign key (idprod) references producto(idprod)
)
go

--libro autor
create table libroautor(
	idlibroautor int primary key identity(1,1),
	idautor int not null, 
	idprod int not null,
	estlibroautor BIT NOT NULL default 1,
	foreign key (idautor) references autor(idautor),
	foreign key (idprod) references producto(idprod),
	CONSTRAINT UQ_libroautor UNIQUE(idautor,idprod)
)
go

--inventario
create table inventario(
    idinv INT PRIMARY KEY IDENTITY(1,1),
    idprod INT NOT NULL UNIQUE,
    stockdis INT NOT NULL CHECK(stockdis >= 0),
    stockmin INT NOT NULL CHECK(stockmin >= 0),
    fecact DATETIME NOT NULL,
    estinv BIT NOT NULL default 1,
    FOREIGN KEY (idprod) REFERENCES producto(idprod)
)
go

--insertar los datos
--tablas simples

--pais
INSERT INTO pais (nompais)
VALUES
('Perú'),
('España'),
('Argentina'),
('Colombia'),
('México'),
('Estados Unidos'),
('Reino Unido'),
('Francia'),
('Austria'),
('Israel'),
('Canadá');
GO

--categoria
INSERT INTO categoria(nomcategoria) 
VALUES
('Novela'),
('Programación'),
('Psicología'),
('Historia'),
('Infantil'),
('Ciencia Ficción');
GO

--editorial
INSERT INTO editorial(nomeditorial) 
VALUES
('Planeta'),
('Penguin Random House'),
('Alfaguara'),
('Anagrama'),
('O''Reilly Media');
GO

--proveedores
INSERT INTO proveedor(razsocprov,rucprov,telfprov,corprov,direcprov) 
VALUES
('Distribuidora Librera Perú SAC','20547896321','014567890','ventas@dlperu.com','Av. Argentina 1540'),
('Libros Unidos SAC','20635874125','017894563','ventas@librosunidos.pe','Av. Javier Prado 1500');
GO

INSERT INTO tipopago(nomtippag) 
VALUES
('Efectivo'),
('Tarjeta Débito'),
('Tarjeta Crédito'),
('Yape'),
('Plin');
GO

INSERT INTO tipodocumento(nomtipdoc) 
VALUES
('DNI'),
('Carné de Extranjería'),
('Pasaporte');
GO

INSERT INTO rol(nomrol) VALUES
('Administrador'),
('Vendedor'),
('Cajero');
GO

--distritos
insert into distrito(nomdis,estdis) values('Ancón',1);
insert into distrito(nomdis,estdis) values('Ate',1);
insert into distrito(nomdis,estdis) values('Barranco',1);
insert into distrito(nomdis,estdis) values('Breña',1);
insert into distrito(nomdis,estdis) values('Carabayllo',1);
insert into distrito(nomdis,estdis) values('Chaclacayo',1);
insert into distrito(nomdis,estdis) values('Chorrillos',1);
insert into distrito(nomdis,estdis) values('Cieneguilla',1);
insert into distrito(nomdis,estdis) values('Comas',1);
insert into distrito(nomdis,estdis) values('El Agustino',1);
insert into distrito(nomdis,estdis) values('Independencia',1);
insert into distrito(nomdis,estdis) values('Jesús María',1);
insert into distrito(nomdis,estdis) values('La Molina',1);
insert into distrito(nomdis,estdis) values('La Victoria',1);
insert into distrito(nomdis,estdis) values('Lima',1);
insert into distrito(nomdis,estdis) values('Lince',1);
insert into distrito(nomdis,estdis) values('Los Olivos',1);
insert into distrito(nomdis,estdis) values('Lurigancho',1);
insert into distrito(nomdis,estdis) values('Lurín',1);
insert into distrito(nomdis,estdis) values('Magdalena del Mar',1);
insert into distrito(nomdis,estdis) values('Miraflores',1);
insert into distrito(nomdis,estdis) values('Pachacámac',1);
insert into distrito(nomdis,estdis) values('Pucusana',1);
insert into distrito(nomdis,estdis) values('Pueblo Libre',1);
insert into distrito(nomdis,estdis) values('Puente Piedra',1);
insert into distrito(nomdis,estdis) values('Punta Hermosa',1);
insert into distrito(nomdis,estdis) values('Punta Negra',1);
insert into distrito(nomdis,estdis) values('Rímac',1);
insert into distrito(nomdis,estdis) values('San Bartolo',1);
insert into distrito(nomdis,estdis) values('San Borja',1);
insert into distrito(nomdis,estdis) values('San Isidro',1);
insert into distrito(nomdis,estdis) values('San Juan de Lurigancho',1);
insert into distrito(nomdis,estdis) values('San Juan de Miraflores',1);
insert into distrito(nomdis,estdis) values('San Luis',1);
insert into distrito(nomdis,estdis) values('San Martín de Porres',1);
insert into distrito(nomdis,estdis) values('San Miguel',1);
insert into distrito(nomdis,estdis) values('Santa Anita',1);
insert into distrito(nomdis,estdis) values('Santa María del Mar',1);
insert into distrito(nomdis,estdis) values('Santa Rosa',1);
insert into distrito(nomdis,estdis) values('Santiago de Surco',1);
insert into distrito(nomdis,estdis) values('Surquillo',1);
insert into distrito(nomdis,estdis) values('Villa El Salvador',1);
insert into distrito(nomdis,estdis) values('Villa María del Triunfo',1);
insert into distrito(nomdis,estdis) values('Callao',1);
insert into distrito(nomdis,estdis) values('Bellavista',1);
insert into distrito(nomdis,estdis) values('Carmen de La Legua-Reynoso',1);
insert into distrito(nomdis,estdis) values('La Perla',1);
insert into distrito(nomdis,estdis) values('La Punta',1);
insert into distrito(nomdis,estdis) values('Ventanilla',1);
insert into distrito(nomdis,estdis) values('Mi Perú',1);
go

--cliente
INSERT INTO cliente
(nomcli, apepcli, apemcli, numdoccli, fecnaccli, dircli, telcli, corcli, idtipdoc, iddis)
VALUES
('Luis','Ramírez','Torres','72894561','1994-05-18','Av. Larco 450','987654321','luis.ramirez@gmail.com',1,1),
('María','Fernández','Salas','74589632','1990-10-05','Av. Benavides 2150','945612378','mariafs@gmail.com',1,3),
('Carlos','Pérez','Gómez','70125896','1988-01-30','Av. Aviación 1234','934561278','cperez@gmail.com',1,5),
('Andrea','Castillo','Rojas','78451236','1998-07-20','Jr. Castilla 520','923451876','andrea.castillo@gmail.com',1,9),
('José','Flores','Vargas','73698521','1985-03-12','Av. Brasil 1890','912345678','jflores@gmail.com',1,10),
('Valeria','Quispe','Huamán','76452319','1997-12-02','Av. Angamos 960','956234781','vquispe@gmail.com',1,4),
('Diego','Mendoza','Paredes','71985632','1992-06-09','Av. Javier Prado 2100','967812345','dmendoza@gmail.com',1,2),
('Camila','Navarro','López','74123698','1999-09-14','Av. Primavera 875','981234567','camila.navarro@gmail.com',1,6);
GO

--empleado
INSERT INTO empleado
(nomemp, apepemp, apememp, numdocemp, fecnacemp, diremp, telemp, coremp,
fecinemp,usuemp, claemp, sueldoemp, numhoremp, idtipdoc, idrol, iddis)
VALUES
('Ricardo','Canales','López','72589634','1995-02-10','Av. Canadá 500','999111222','ricardo@communitas.pe','2024-01-15','rcanales', '123', 3500,48,1,1,5),
('Patricia','Díaz','Soto','74563218','1993-09-14','Av. Primavera 1200','988777666','patricia@communitas.pe','2024-03-01','pdiaz', '123',2200,48,1,2,3),
('Miguel','Rojas','Paredes','71236548','1998-06-21','Av. Arequipa 3500','977555444','mrojas@communitas.pe','2025-01-08','mrojas', '123',1900,48,1,3,2),
('Daniela','García','Cruz','75632149','1996-01-18','Av. San Borja Norte 410','966222111','dgarcia@communitas.pe','2023-11-10','dgarcia','123',2100,48,1,2,5),
('Fernando','Salazar','León','73458961','1989-08-03','Av. Tomás Marsano 2400','955444333','fsalazar@communitas.pe','2022-08-20','fsalazar','123',2400,48,1,1,4);
GO

--autor
INSERT INTO autor
(nomautor, apepautor, apemautor, idpais)
VALUES
('Gabriel','García','Márquez',4),
('Robert','Martin','',6),
('Viktor','Frankl','',9),
('Yuval Noah','Harari','',10),
('Antoine','de Saint-Exupéry','',8),
('Frank','Herbert','',6),
('Brian','Kernighan','',11),
('Martin','Kleppmann','',7),
('Daniel','Kahneman','',10),
('George','Orwell','',7);
GO

--producto
INSERT INTO producto
(isbnprod, titprod, descprod, preccompprod, precventprod, fecpubprod, idprov, idcategoria, ideditorial)
VALUES
('9780307476463','Cien años de soledad','Novela icónica del realismo mágico escrita por Gabriel García Márquez.',45.00,69.90,'1967-05-30',1,1,2),
('9780132350884','Clean Code','Guía de buenas prácticas para escribir código limpio y mantenible.',110.00,169.90,'2008-08-01',2,2,5),
('9788449337478','El hombre en busca de sentido','Obra de Viktor Frankl sobre la búsqueda del sentido de la vida.',38.00,59.90,'1946-01-01',1,3,1),
('9788420471839','Sapiens: De animales a dioses','Ensayo histórico sobre la evolución y desarrollo de la humanidad.',60.00,89.90,'2011-01-01',2,4,3),
('9788498381498','El Principito','Clásico de la literatura universal escrito por Antoine de Saint-Exupéry.',20.00,35.90,'1943-04-06',1,5,2),
('9780553386790','Dune','Novela de ciencia ficción considerada una de las mejores del género.',55.00,82.90,'1965-08-01',2,6,2),
('9780131103627','The C Programming Language','Libro de referencia sobre el lenguaje de programación C.',95.00,145.00,'1988-04-01',1,2,5),
('9781492056355','Designing Data-Intensive Applications','Libro especializado en arquitectura y sistemas de datos.',150.00,229.90,'2017-03-16',2,2,5),
('9780307887443','Thinking, Fast and Slow','Libro de psicología y economía conductual de Daniel Kahneman.',48.00,72.90,'2011-10-25',1,3,2),
('9788499890944','1984','Novela distópica escrita por George Orwell.',32.00,49.90,'1949-06-08',2,1,1);
GO

--libroAutor
INSERT INTO libroautor
(idautor,idprod)
VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,7),
(8,8),
(9,9),
(10,10);
GO

--inventario
INSERT INTO inventario
(idprod,stockdis,stockmin,fecact)
VALUES
(1,25,5,GETDATE()),
(2,15,3,GETDATE()),
(3,20,5,GETDATE()),
(4,18,4,GETDATE()),
(5,30,8,GETDATE()),
(6,12,3,GETDATE()),
(7,10,2,GETDATE()),
(8,8,2,GETDATE()),
(9,14,4,GETDATE()),
(10,22,5,GETDATE());
GO

--compra
INSERT INTO compra
(feccompra,totalcompra,idprov)
VALUES
('2026-07-01 10:15',1000.00,1),
('2026-07-05 16:30',915.00,2),
('2026-07-09 11:45',1210.00,1);
GO

--DetalleCompra
INSERT INTO detallecompra
(idcompra,idprod,cancompra,precucomp,subtotcomp)
VALUES

-- Compra 1
(1,1,10,45.00,450.00),
(1,5,10,20.00,200.00),
(1,10,10,35.00,350.00),

-- Compra 2
(2,2,5,110.00,550.00),
(2,3,5,38.00,190.00),
(2,9,5,35.00,175.00),

-- Compra 3
(3,4,10,60.00,600.00),
(3,6,5,55.00,275.00),
(3,8,2,150.00,300.00),
(3,7,1,35.00,35.00);

GO

--ventas
INSERT INTO venta
(fecventa,totalventa,idemp,idcli,idtippag)
VALUES
('2026-07-08 15:20',129.80,2,1,4),
('2026-07-08 17:05',169.90,4,2,2),
('2026-07-09 13:15',95.80,2,3,1),
('2026-07-10 11:00',302.80,4,5,3),
('2026-07-10 18:30',229.90,2,8,5);

GO

--detalleVentas
INSERT INTO detalleventa
(idventa,idprod,canventa,precuventa,subtotventa)
VALUES

-- Venta 1
(1,1,1,69.90,69.90),
(1,5,1,59.90,59.90),

-- Venta 2
(2,2,1,169.90,169.90),

-- Venta 3
(3,10,1,49.90,49.90),
(3,5,1,45.90,45.90),

-- Venta 4
(4,8,1,229.90,229.90),
(4,5,2,36.45,72.90),

-- Venta 5
(5,8,1,229.90,229.90);

GO
