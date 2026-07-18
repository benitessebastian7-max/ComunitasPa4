-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento distrito
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarDistrito') 
DROP PROCEDURE SP_MostrarDistrito
go
CREATE PROC	SP_MostrarDistrito
as
begin
select * from distrito where estdis= 1
end
go
exec SP_MostrarDistrito
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarDistritoTodo') 
DROP PROCEDURE SP_MostrarDistritoTodo
go
CREATE PROC	SP_MostrarDistritoTodo
as
begin
select * from distrito
end
go
exec SP_MostrarDistritoTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarDistrito') 
DROP PROCEDURE SP_RegistrarDistrito
go
CREATE PROC	SP_RegistrarDistrito
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarDistrito
begin try
insert into distrito values(@nombre,@estado)
commit tran SP_RegistrarDistrito
end try
begin catch
	rollback tran SP_RegistrarDistrito
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarDistritoXCodigo') 
DROP PROCEDURE SP_BuscarDistritoXCodigo
go
CREATE PROC	SP_BuscarDistritoXCodigo
@codigo int
as
begin
select * from distrito where iddis=@codigo
end
go
exec SP_BuscarDistritoXCodigo 2
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarDistrito') 
DROP PROCEDURE SP_ActualizarDistrito
go
CREATE PROC	SP_ActualizarDistrito
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarDistrito
begin try
update distrito set nomdis=@nombre,estdis=@estado where iddis=@codigo
commit tran SP_ActualizarDistrito
end try
begin catch
	rollback tran SP_ActualizarDistrito
	end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarDistrito') 
DROP PROCEDURE SP_EliminarDistrito
go
CREATE PROC	SP_EliminarDistrito
@codigo int
as
begin
begin tran SP_EliminarDistrito
begin try
update distrito set estdis=0 where iddis=@codigo
commit tran SP_EliminarDistrito
end try
begin catch
	rollback tran SP_EliminarDistrito
end catch
end
go

-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarDistrito') 
DROP PROCEDURE SP_HabilitarDistrito
go
CREATE PROC	SP_HabilitarDistrito
@codigo int
as
begin
begin tran SP_HabilitarDistrito
begin try
update distrito set estdis=1 where iddis=@codigo
commit tran SP_HabilitarDistrito
end try
begin catch
	rollback tran SP_HabilitarDistrito
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoDistrito') 
DROP PROCEDURE SP_CodigoDistrito
go
CREATE PROC	SP_CodigoDistrito
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from distrito)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('distrito')+1

-- comprobando que el identity es correcto
dbcc checkident ('distrito',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('distrito')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoDistrito
go