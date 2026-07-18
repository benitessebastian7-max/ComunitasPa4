-- seleccionamos la BD
use EI5447CommunitasBD
go

-- inventario
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarInventario') 
DROP PROCEDURE SP_MostrarInventario
go
CREATE PROC	SP_MostrarInventario
as
begin
select
	i.idinv,
	i.idprod,
	i.stockdis,
	i.stockmin,
	i.fecact,
	i.estinv,
	p.titprod
from inventario i
inner join producto p on i.idprod=p.idprod
where i.estinv= 1
end
go
exec SP_MostrarInventario
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarInventarioTodo') 
DROP PROCEDURE SP_MostrarInventarioTodo
go
CREATE PROC	SP_MostrarInventarioTodo
as
begin
select
	i.idinv,
	i.idprod,
	i.stockdis,
	i.stockmin,
	i.fecact,
	i.estinv,
	p.titprod
from inventario i
inner join producto p on i.idprod=p.idprod
end
go
exec SP_MostrarInventarioTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarInventario') 
DROP PROCEDURE SP_RegistrarInventario
go
CREATE PROC	SP_RegistrarInventario
	@idprod int, 
	@stockdis int,
	@stockmin int,
	@fechaact DATETIME,
	@estado bit
as
begin
	begin tran SP_RegistrarInventario
	begin try
		insert into inventario
				(idprod,
				stockdis,
				stockmin,
				fecact,
				estinv)
		values(
				@idprod, 
				@stockdis,
				@stockmin,
				@fechaact,
				@estado)
		commit tran SP_RegistrarInventario
	end try
	begin catch
		rollback tran SP_RegistrarInventario
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarInventarioXCodigo') 
DROP PROCEDURE SP_BuscarInventarioXCodigo
go
CREATE PROC	SP_BuscarInventarioXCodigo
@codigo int
as
begin
select 
	i.idinv,
	i.idprod,
	i.stockdis,
	i.stockmin,
	i.fecact,
	i.estinv,
	p.titprod
from inventario i
inner join producto p on i.idprod=p.idprod
where i.idinv = @codigo
end
go
exec SP_BuscarInventarioXCodigo 5
go

-- Actualizar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarInventario') 
DROP PROCEDURE SP_ActualizarInventario
go
CREATE PROC	SP_ActualizarInventario
	@codigo int,
	@idprod int, 
	@stockdis int,
	@stockmin int,
	@fechaact DATETIME,
	@estado bit
as
begin
	begin tran SP_ActualizarInventario
	begin try
		update inventario
		set 			
			idprod = @idprod,
			stockdis = @stockdis,
			stockmin = @stockmin,
			fecact = @fechaact,
			estinv = @estado
		where idinv = @codigo
		commit tran SP_ActualizarInventario
	end try
	begin catch
		rollback tran SP_ActualizarInventario
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarInventario') 
DROP PROCEDURE SP_EliminarInventario
go
CREATE PROC	SP_EliminarInventario
@codigo int
as
begin
begin tran SP_EliminarInventario
begin try
update inventario set estinv=0 where idinv=@codigo
commit tran SP_EliminarInventario
end try
begin catch
	rollback tran SP_EliminarInventario
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarInventario') 
DROP PROCEDURE SP_HabilitarInventario
go
CREATE PROC	SP_HabilitarInventario
@codigo int
as
begin
begin tran SP_HabilitarInventario
begin try
update inventario set estinv=1 where idinv=@codigo
commit tran SP_HabilitarInventario
end try
begin catch
	rollback tran SP_HabilitarInventario
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoInventario') 
DROP PROCEDURE SP_CodigoInventario
go
CREATE PROC	SP_CodigoInventario
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from inventario)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('inventario')+1

-- comprobando que el identity es correcto
dbcc checkident ('inventario',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('inventario')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoInventario
go