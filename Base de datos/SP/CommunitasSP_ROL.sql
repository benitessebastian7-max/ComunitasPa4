-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento ROL
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarRol') 
DROP PROCEDURE SP_MostrarRol
go
CREATE PROC	SP_MostrarRol
as
begin
select * from rol where estrol= 1
end
go
exec SP_MostrarRol
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarRolTodo') 
DROP PROCEDURE SP_MostrarRolTodo
go
CREATE PROC	SP_MostrarRolTodo
as
begin
select * from rol
end
go
exec SP_MostrarRolTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarRol') 
DROP PROCEDURE SP_RegistrarRol
go
CREATE PROC	SP_RegistrarRol
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarRol
begin try
insert into rol values(@nombre,@estado)
commit tran SP_RegistrarRol
end try
begin catch
	rollback tran SP_RegistrarRol
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarRolXCodigo') 
DROP PROCEDURE SP_BuscarRolXCodigo
go
CREATE PROC	SP_BuscarRolXCodigo
@codigo int
as
begin
select * from rol where idrol=@codigo
end
go
exec SP_BuscarRolXCodigo 2
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarRol') 
DROP PROCEDURE SP_ActualizarRol
go
CREATE PROC	SP_ActualizarRol
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarRol
begin try
update rol set nomrol=@nombre,estrol=@estado where idrol=@codigo
commit tran SP_ActualizarRol
end try
begin catch
	rollback tran SP_ActualizarRol
	end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarRol') 
DROP PROCEDURE SP_EliminarRol
go
CREATE PROC	SP_EliminarRol
@codigo int
as
begin
begin tran SP_EliminarRol
begin try
update rol set estrol=0 where idrol=@codigo
commit tran SP_EliminarRol
end try
begin catch
	rollback tran SP_EliminarRol
end catch
end
go

-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarRol') 
DROP PROCEDURE SP_HabilitarRol
go
CREATE PROC	SP_HabilitarRol
@codigo int
as
begin
begin tran SP_HabilitarRol
begin try
update rol set estrol=1 where idrol=@codigo
commit tran SP_HabilitarRol
end try
begin catch
	rollback tran SP_HabilitarRol
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoRol') 
DROP PROCEDURE SP_CodigoRol
go
CREATE PROC	SP_CodigoRol
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from rol)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('rol')+1

-- comprobando que el identity es correcto
dbcc checkident ('rol',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('rol')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoRol
go