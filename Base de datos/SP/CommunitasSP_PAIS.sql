-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento pais
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarPais') 
DROP PROCEDURE SP_MostrarPais 
go
CREATE PROC	SP_MostrarPais
as
begin
select * from pais where estpais = 1
end
go
exec SP_MostrarPais
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarPaisTodo') 
DROP PROCEDURE SP_MostrarPaisTodo  
go
CREATE PROC	SP_MostrarPaisTodo
as
begin
select * from pais
end
go
exec SP_MostrarPaisTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarPais') 
DROP PROCEDURE SP_RegistrarPais  
go
CREATE PROC	SP_RegistrarPais
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarPais
begin try
insert into pais values(@nombre,@estado)
commit tran SP_RegistrarPais
end try
begin catch
	rollback tran SP_RegistrarPais
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarPaisXCodigo') 
DROP PROCEDURE SP_BuscarPaisXCodigo  
go
CREATE PROC	SP_BuscarPaisXCodigo
@codigo int
as
begin
select * from pais where idpais=@codigo
end
go
exec SP_BuscarPaisXCodigo 8
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarPais') 
DROP PROCEDURE SP_ActualizarPais  
go
CREATE PROC	SP_ActualizarPais
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarPais
begin try
update pais set nompais=@nombre, estpais=@estado where idpais=@codigo
commit tran SP_ActualizarPais
end try
begin catch
	rollback tran SP_ActualizarPais
end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarPais') 
DROP PROCEDURE SP_EliminarPais  
go
CREATE PROC	SP_EliminarPais
@codigo int
as
begin
begin tran SP_EliminarPais
begin try
update pais set estpais=0 where idpais=@codigo
commit tran SP_EliminarPais
end try
begin catch
	rollback tran SP_EliminarPais
end catch
end
go


-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarPais') 
DROP PROCEDURE SP_HabilitarPais  
go
CREATE PROC	SP_HabilitarPais
@codigo int
as
begin
begin tran SP_HabilitarPais
begin try
update pais set estpais=1 where idpais=@codigo
commit tran SP_HabilitarPais
end try
begin catch
	rollback tran SP_HabilitarPais
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoPais') 
DROP PROCEDURE SP_CodigoPais  
go
CREATE PROC	SP_CodigoPais
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from pais)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('pais')+1

-- comprobando que el identity es correcto
dbcc checkident ('pais',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('pais')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoPais
go