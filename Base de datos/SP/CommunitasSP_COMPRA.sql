-- seleccionamos la BD
use EI5447CommunitasBD
go

-- compra
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarCompra') 
DROP PROCEDURE SP_MostrarCompra
go
CREATE PROC	SP_MostrarCompra
as
begin
select
	c.idcompra,
	c.feccompra,
	c.totalcompra,
	c.estcompra,
	c.idprov,
	p.razsocprov
from compra c
inner join proveedor p on c.idprov=p.idprov
where c.estcompra= 1
end
go
exec SP_MostrarCompra
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarCompraTodo') 
DROP PROCEDURE SP_MostrarCompraTodo
go
CREATE PROC	SP_MostrarCompraTodo
as
begin
select
	c.idcompra,
	c.feccompra,
	c.totalcompra,
	c.estcompra,
	c.idprov,
	p.razsocprov
from compra c
inner join proveedor p on c.idprov=p.idprov
end
go
exec SP_MostrarCompraTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarCompra') 
DROP PROCEDURE SP_RegistrarCompra
go
CREATE PROC	SP_RegistrarCompra
	@fechacompra DATETIME,
    @total MONEY,
    @estado BIT,
	@idprov INT
as
begin
	begin tran SP_RegistrarCompra
	begin try
		insert into compra
				(feccompra,
				totalcompra,
				estcompra,
				idprov)
		values(
			@fechacompra,
			@total,
			@estado,
			@idprov)
		commit tran SP_RegistrarCompra
	end try
	begin catch
		rollback tran SP_RegistrarCompra
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarCompraXCodigo') 
DROP PROCEDURE SP_BuscarCompraXCodigo
go
CREATE PROC	SP_BuscarCompraXCodigo
@codigo int
as
begin
select 
	c.idcompra,
	c.feccompra,
	c.totalcompra,
	c.estcompra,
	c.idprov,
	p.razsocprov
from compra c
inner join proveedor p on c.idprov=p.idprov
where c.idcompra = @codigo
end
go
exec SP_BuscarCompraXCodigo 3
go

-- Actualizar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarCompra') 
DROP PROCEDURE SP_ActualizarCompra
go
CREATE PROC	SP_ActualizarCompra
	@codigo int,
    @feccomp DATETIME,
	@total MONEY,
    @estado BIT,
	@idprov INT
as
begin
	begin tran SP_ActualizarCompra
	begin try
		update compra
		set 			
			feccompra=@feccomp,
			totalcompra=@total,
			estcompra=@estado,
			idprov=@idprov
			where idcompra=@codigo
			commit tran SP_ActualizarCompra
	end try
	begin catch
		rollback tran SP_ActualizarCompra
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarCompra') 
DROP PROCEDURE SP_EliminarCompra
go
CREATE PROC	SP_EliminarCompra
@codigo int
as
begin
begin tran SP_EliminarCompra
begin try
update compra set estcompra=0 where idcompra=@codigo
commit tran SP_EliminarCompra
end try
begin catch
	rollback tran SP_EliminarCompra
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarCompra') 
DROP PROCEDURE SP_HabilitarCompra
go
CREATE PROC	SP_HabilitarCompra
@codigo int
as
begin
begin tran SP_HabilitarCompra
begin try
update compra set estcompra=1 where idcompra=@codigo
commit tran SP_HabilitarCompra
end try
begin catch
	rollback tran SP_HabilitarCompra
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoCompra') 
DROP PROCEDURE SP_CodigoCompra
go
CREATE PROC	SP_CodigoCompra
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from compra)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('compra')+1

-- comprobando que el identity es correcto
dbcc checkident ('compra',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('compra')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoCompra
go