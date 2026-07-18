-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento TIPO DE documento
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarTipoDocumento') 
DROP PROCEDURE SP_MostrarTipoDocumento
go
CREATE PROC	SP_MostrarTipoDocumento
as
begin
select * from tipodocumento where esttipdoc= 1
end
go
exec SP_MostrarTipoDocumento
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarTipoDocumentoTodo') 
DROP PROCEDURE SP_MostrarTipoDocumentoTodo
go
CREATE PROC	SP_MostrarTipoDocumentoTodo
as
begin
select * from tipodocumento
end
go
exec SP_MostrarTipoDocumentoTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarTipoDocumento') 
DROP PROCEDURE SP_RegistrarTipoDocumento
go
CREATE PROC	SP_RegistrarTipoDocumento
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarTipoDocumento
begin try
insert into tipodocumento values(@nombre,@estado)
commit tran SP_RegistrarTipoDocumento
end try
begin catch
	rollback tran SP_RegistrarTipoDocumento
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarTipoDocumentoXCodigo') 
DROP PROCEDURE SP_BuscarTipoDocumentoXCodigo
go
CREATE PROC	SP_BuscarTipoDocumentoXCodigo
@codigo int
as
begin
select * from tipodocumento where idtipdoc=@codigo
end
go
exec SP_BuscarTipoDocumentoXCodigo 2
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarTipoDocumento') 
DROP PROCEDURE SP_ActualizarTipoDocumento
go
CREATE PROC	SP_ActualizarTipoDocumento
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarTipoDocumento
begin try
update tipodocumento set nomtipdoc=@nombre,esttipdoc=@estado where idtipdoc=@codigo
commit tran SP_ActualizarTipoDocumento
end try
begin catch
	rollback tran SP_ActualizarTipoDocumento
	end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarTipoDocumento') 
DROP PROCEDURE SP_EliminarTipoDocumento
go
CREATE PROC	SP_EliminarTipoDocumento
@codigo int
as
begin
begin tran SP_EliminarTipoDocumento
begin try
update tipodocumento set esttipdoc=0 where idtipdoc=@codigo
commit tran SP_EliminarTipoDocumento
end try
begin catch
	rollback tran SP_EliminarTipoDocumento
end catch
end
go

-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarTipoDocumento') 
DROP PROCEDURE SP_HabilitarTipoDocumento
go
CREATE PROC	SP_HabilitarTipoDocumento
@codigo int
as
begin
begin tran SP_HabilitarTipoDocumento
begin try
update tipodocumento set esttipdoc=1 where idtipdoc=@codigo
commit tran SP_HabilitarTipoDocumento
end try
begin catch
	rollback tran SP_HabilitarTipoDocumento
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoTipoDocumento') 
DROP PROCEDURE SP_CodigoTipoDocumento
go
CREATE PROC	SP_CodigoTipoDocumento
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from tipodocumento)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('tipodocumento')+1

-- comprobando que el identity es correcto
dbcc checkident ('tipodocumento',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('tipodocumento')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoTipoDocumento
go