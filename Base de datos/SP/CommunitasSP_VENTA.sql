-- seleccionamos la BD
use EI5447CommunitasBD
go

-- venta
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarVenta') 
DROP PROCEDURE SP_MostrarVenta
go
CREATE PROC	SP_MostrarVenta
as
begin
select
	v.idventa,
	v.fecventa,
	v.totalventa,
	v.estventa,
	v.idemp,
	v.idcli,
	v.idtippag,
	e.nomemp,
	c.nomcli,
	tp.nomtippag
from venta v
inner join empleado e on v.idemp=e.idemp
inner join cliente c on v.idcli=c.idcli
inner join tipopago tp on v.idtippag=tp.idtippag
where v.estventa= 1
end
go
exec SP_MostrarVenta
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarVentaTodo') 
DROP PROCEDURE SP_MostrarVentaTodo
go
CREATE PROC	SP_MostrarVentaTodo
as
begin
select
	v.idventa,
	v.fecventa,
	v.totalventa,
	v.estventa,
	v.idemp,
	v.idcli,
	v.idtippag,
	e.nomemp,
	c.nomcli,
	tp.nomtippag
from venta v
inner join empleado e on v.idemp=e.idemp
inner join cliente c on v.idcli=c.idcli
inner join tipopago tp on v.idtippag=tp.idtippag
end
go
exec SP_MostrarVentaTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarVenta') 
DROP PROCEDURE SP_RegistrarVenta
go
CREATE PROC	SP_RegistrarVenta
	@fecha DATETIME, 
	@total MONEY,
	@estado BIT,
	@idemp int,
	@idcli int,
	@idtippag int
as
begin
	begin tran SP_RegistrarVenta
	begin try
		insert into venta
				(fecventa,
				totalventa,
				estventa,
				idemp,
				idcli,
				idtippag)
		values(
				@fecha, 
				@total,
				@estado,
				@idemp,
				@idcli,
				@idtippag)
		commit tran SP_RegistrarVenta
	end try
	begin catch
		rollback tran SP_RegistrarVenta
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarVentaXCodigo') 
DROP PROCEDURE SP_BuscarVentaXCodigo
go
CREATE PROC	SP_BuscarVentaXCodigo
@codigo int
as
begin
select 
	v.idventa,
	v.fecventa,
	v.totalventa,
	v.estventa,
	v.idemp,
	v.idcli,
	v.idtippag,
	e.nomemp,
	c.nomcli,
	tp.nomtippag
from venta v
inner join empleado e on v.idemp=e.idemp
inner join cliente c on v.idcli=c.idcli
inner join tipopago tp on v.idtippag=tp.idtippag
where v.idventa = @codigo
end
go
exec SP_BuscarVentaXCodigo 5
go

-- Actualizar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarVenta') 
DROP PROCEDURE SP_ActualizarVenta
go
CREATE PROC	SP_ActualizarVenta
	@codigo int,
	@fecha DATETIME, 
	@total MONEY,
	@estado BIT,
	@idemp int,
	@idcli int,
	@idtippag int
as
begin
	begin tran SP_ActualizarVenta
	begin try
		update venta
		set 			
			fecventa = @fecha,
			totalventa = @total,
			estventa = @estado,
			idemp = @idemp,
			idcli = @idcli,
			idtippag = @idtippag
		where idventa = @codigo
		commit tran SP_ActualizarVenta
	end try
	begin catch
		rollback tran SP_ActualizarVenta
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarVenta') 
DROP PROCEDURE SP_EliminarVenta
go
CREATE PROC	SP_EliminarVenta
@codigo int
as
begin
begin tran SP_EliminarVenta
begin try
update venta set estventa=0 where idventa=@codigo
commit tran SP_EliminarVenta
end try
begin catch
	rollback tran SP_EliminarVenta
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarVenta') 
DROP PROCEDURE SP_HabilitarVenta
go
CREATE PROC	SP_HabilitarVenta
@codigo int
as
begin
begin tran SP_HabilitarVenta
begin try
update venta set estventa=1 where idventa=@codigo
commit tran SP_HabilitarVenta
end try
begin catch
	rollback tran SP_HabilitarVenta
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoVenta') 
DROP PROCEDURE SP_CodigoVenta
go
CREATE PROC	SP_CodigoVenta
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from venta)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('venta')+1

-- comprobando que el identity es correcto
dbcc checkident ('venta',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('venta')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoVenta
go