-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento categoria
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarCategoria') 
DROP PROCEDURE SP_MostrarCategoria 
go
CREATE PROC	SP_MostrarCategoria
as
begin
select * from categoria where estcategoria = 1
end
go
exec SP_MostrarCategoria
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarCategoria') 
DROP PROCEDURE SP_MostrarCategoria  
go
CREATE PROC	SP_MostrarCategoria
as
begin
select * from categoria
end
go
exec SP_MostrarCategoria
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarCategoria') 
DROP PROCEDURE SP_RegistrarCategoria  
go
CREATE PROC	SP_RegistrarCategoria
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarCategoria
begin try
insert into categoria values(@nombre,@estado)
commit tran SP_RegistrarCategoria
end try
begin catch
	rollback tran SP_RegistrarCategoria
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarCategoriaXCodigo') 
DROP PROCEDURE SP_BuscarCategoriaXCodigo  
go
CREATE PROC	SP_BuscarCategoriaXCodigo
@codigo int
as
begin
select * from categoria where idcategoria=@codigo
end
go
exec SP_BuscarCategoriaXCodigo 5
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarCategoria') 
DROP PROCEDURE SP_ActualizarCategoria  
go
CREATE PROC	SP_ActualizarCategoria
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarCategoria
begin try
update categoria set nomcategoria=@nombre, estcategoria=@estado where idcategoria=@codigo
commit tran SP_ActualizarCategoria
end try
begin catch
	rollback tran SP_ActualizarCategoria
end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarCategoria') 
DROP PROCEDURE SP_EliminarCategoria  
go
CREATE PROC	SP_EliminarCategoria
@codigo int
as
begin
begin tran SP_EliminarCategoria
begin try
update categoria set estcategoria=0 where idcategoria=@codigo
commit tran SP_EliminarCategoria
end try
begin catch
	rollback tran SP_EliminarCategoria
end catch
end
go


-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarCategoria') 
DROP PROCEDURE SP_HabilitarCategoria  
go
CREATE PROC	SP_HabilitarCategoria
@codigo int
as
begin
begin tran SP_HabilitarCategoria
begin try
update categoria set estcategoria=1 where idcategoria=@codigo
commit tran SP_HabilitarCategoria
end try
begin catch
	rollback tran SP_HabilitarCategoria
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoCategoria') 
DROP PROCEDURE SP_CodigoCategoria  
go
CREATE PROC	SP_CodigoCategoria
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from categoria)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('categoria')+1

-- comprobando que el identity es correcto
dbcc checkident ('categoria',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('categoria')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoCategoria
go