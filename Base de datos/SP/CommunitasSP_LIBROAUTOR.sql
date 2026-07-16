-- seleccionamos la BD
use EI5447CommunitasBD
go

-- libroautor
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarLibroAutor') 
DROP PROCEDURE SP_MostrarLibroAutor
go
CREATE PROC	SP_MostrarLibroAutor
as
begin
select
	la.idlibroautor,
	la.idautor,
	la.idprod,
	la.estlibroautor,
	a.nomautor,
	p.titprod
from libroautor la
inner join autor a on la.idautor=a.idautor
inner join producto p on la.idprod=p.idprod
where la.estlibroautor= 1
end
go
exec SP_MostrarLibroAutor
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarLibroAutorTodo') 
DROP PROCEDURE SP_MostrarLibroAutorTodo
go
CREATE PROC	SP_MostrarLibroAutorTodo
as
begin
select
	la.idlibroautor,
	la.idautor,
	la.idprod,
	la.estlibroautor,
	a.nomautor,
	p.titprod
from libroautor la
inner join autor a on la.idautor=a.idautor
inner join producto p on la.idprod=p.idprod
end
go
exec SP_MostrarLibroAutorTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarLibroAutor') 
DROP PROCEDURE SP_RegistrarLibroAutor
go
CREATE PROC	SP_RegistrarLibroAutor
	@idautor int,
	@idprod int,
	@estado bit
as
begin
	begin tran SP_RegistrarLibroAutor
	begin try
		insert into libroautor
				(idautor,
				idprod,
				estlibroautor)
		values(
				@idautor,
				@idprod,
				@estado)
		commit tran SP_RegistrarLibroAutor
	end try
	begin catch
		rollback tran SP_RegistrarLibroAutor
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarLibroAutorXCodigo') 
DROP PROCEDURE SP_BuscarLibroAutorXCodigo
go
CREATE PROC	SP_BuscarLibroAutorXCodigo
@codigo int
as
begin
select 
	la.idlibroautor,
	la.idautor,
	la.idprod,
	la.estlibroautor,
	a.nomautor,
	p.titprod
from libroautor la
inner join autor a on la.idautor=a.idautor
inner join producto p on la.idprod=p.idprod
where la.idlibroautor = @codigo
end
go
exec SP_BuscarLibroAutorXCodigo 5
go

-- Actualizar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarLibroAutor') 
DROP PROCEDURE SP_ActualizarLibroAutor
go
CREATE PROC	SP_ActualizarLibroAutor
	@codigo int,
	@idautor int,
	@idprod int,
	@estado bit
as
begin
	begin tran SP_ActualizarLibroAutor
	begin try
		update libroautor
		set 			
			idautor = @idautor,
			idprod = @idprod,
			estlibroautor = @estado
		where idlibroautor = @codigo
		commit tran SP_ActualizarLibroAutor
	end try
	begin catch
		rollback tran SP_ActualizarLibroAutor
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarLibroAutor') 
DROP PROCEDURE SP_EliminarLibroAutor
go
CREATE PROC	SP_EliminarLibroAutor
@codigo int
as
begin
begin tran SP_EliminarLibroAutor
begin try
update libroautor set estlibroautor=0 where idlibroautor=@codigo
commit tran SP_EliminarLibroAutor
end try
begin catch
	rollback tran SP_EliminarLibroAutor
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarLibroAutor') 
DROP PROCEDURE SP_HabilitarLibroAutor
go
CREATE PROC	SP_HabilitarLibroAutor
@codigo int
as
begin
begin tran SP_HabilitarLibroAutor
begin try
update libroautor set estlibroautor=1 where idlibroautor=@codigo
commit tran SP_HabilitarLibroAutor
end try
begin catch
	rollback tran SP_HabilitarLibroAutor
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoLibroAutor') 
DROP PROCEDURE SP_CodigoLibroAutor
go
CREATE PROC	SP_CodigoLibroAutor
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from libroautor)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('libroautor')+1

-- comprobando que el identity es correcto
dbcc checkident ('libroautor',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('libroautor')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoLibroAutor
go
