-- seleccionamos la BD
use EI5447CommunitasBD
go

-- autor
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarAutor') 
DROP PROCEDURE SP_MostrarAutor
go
CREATE PROC	SP_MostrarAutor
as
begin
select
	a.idautor,
	a.nomautor,
	a.apepautor,
	a.apemautor,
	a.estautor,
	a.idpais,
	p.nompais
from autor a
inner join pais p on a.idpais=p.idpais
where a.estautor= 1
end
go
exec SP_MostrarAutor
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarAutorTodo') 
DROP PROCEDURE SP_MostrarAutorTodo
go
CREATE PROC	SP_MostrarAutorTodo
as
begin
select
	a.idautor,
	a.nomautor,
	a.apepautor,
	a.apemautor,
	a.estautor,
	a.idpais,
	p.nompais
from autor a
inner join pais p on a.idpais=p.idpais
end
go
exec SP_MostrarAutorTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarAutor') 
DROP PROCEDURE SP_RegistrarAutor
go
CREATE PROC	SP_RegistrarAutor
	@nombre VARCHAR(100), 
	@apep VARCHAR(100),
	@apem VARCHAR(100), 
	@estado BIT,
	@idpais int
as
begin
	begin tran SP_RegistrarAutor
	begin try
		insert into autor
				(nomautor,
				apepautor,
				apemautor,
				estautor,
				idpais)
		values(
				@nombre, 
				@apep,
				@apem,
				@estado, 
				@idpais)
		commit tran SP_RegistrarAutor
	end try
	begin catch
		rollback tran SP_RegistrarAutor
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarAutorXCodigo') 
DROP PROCEDURE SP_BuscarAutorXCodigo
go
CREATE PROC	SP_BuscarAutorXCodigo
@codigo int
as
begin
select 
	a.idautor,
	a.nomautor,
	a.apepautor,
	a.apemautor,
	a.estautor,
	a.idpais,
	p.nompais
from autor a
inner join pais p on a.idpais=p.idpais
where a.idautor = @codigo
end
go
exec SP_BuscarAutorXCodigo 5
go

-- Actualizar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarAutor') 
DROP PROCEDURE SP_ActualizarAutor
go
CREATE PROC	SP_ActualizarAutor
	@codigo int,
	@nombre VARCHAR(100), 
	@apep VARCHAR(100),
	@apem VARCHAR(100), 
	@estado BIT,
	@idpais int
as
begin
	begin tran SP_ActualizarAutor
	begin try
		update autor
		set 			
			nomautor = @nombre,
			apepautor = @apep,
			apemautor = @apem,
			estautor = @estado,
			idpais = @idpais
		where idautor = @codigo
		commit tran SP_ActualizarAutor
	end try
	begin catch
		rollback tran SP_ActualizarAutor
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarAutor') 
DROP PROCEDURE SP_EliminarAutor
go
CREATE PROC	SP_EliminarAutor
@codigo int
as
begin
begin tran SP_EliminarAutor
begin try
update autor set estautor=0 where idautor=@codigo
commit tran SP_EliminarAutor
end try
begin catch
	rollback tran SP_EliminarAutor
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarAutor') 
DROP PROCEDURE SP_HabilitarAutor
go
CREATE PROC	SP_HabilitarAutor
@codigo int
as
begin
begin tran SP_HabilitarAutor
begin try
update autor set estautor=1 where idautor=@codigo
commit tran SP_HabilitarAutor
end try
begin catch
	rollback tran SP_HabilitarAutor
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoAutor') 
DROP PROCEDURE SP_CodigoAutor
go
CREATE PROC	SP_CodigoAutor
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from autor)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('autor')+1

-- comprobando que el identity es correcto
dbcc checkident ('autor',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('autor')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoAutor
go