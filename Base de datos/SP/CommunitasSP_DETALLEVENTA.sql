use EI5447CommunitasBD
go

--detalle venta
--registrar detalle venta
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarDetalleVenta') 
DROP PROCEDURE SP_RegistrarDetalleVenta
go
CREATE PROC	SP_RegistrarDetalleVenta
@idventa int,
@idprod int,
@cantidad int, 
@precio money,
@subtotal money
as
begin
insert into detalleventa
values(
	@idventa, 
	@idprod, 
	@cantidad,
	@precio,
	@subtotal)
end
go


--mostrar orden y detalle
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME  = 'SP_MostrarVentaDetalle')
DROP PROCEDURE SP_MostrarVentaDetalle
go
CREATE PROC SP_MostrarVentaDetalle
as
begin
select 
	v.idventa,
	v.fecventa,
	c.nomcli,
	c.apepcli,
	c.apemcli,
	e.nomemp,
	e.apepemp,
	e.apememp,
	v.estventa,
	SUM(dv.canventa*dv.precuventa) as Subtotal
from venta v 
	inner join cliente c on v.idcli=c.idcli
	inner join empleado e on v.idemp=e.idemp
	inner join detalleventa dv on v.idventa=dv.idventa
group by 
	v.idventa,
	v.fecventa,
	c.nomcli,
	c.apepcli,
	c.apemcli,
	e.nomemp,
	e.apepemp,
	e.apememp,
	v.estventa
end
go
exec SP_MostrarVentaDetalle
go


IF EXISTS (SELECT * FROM sys.procedures WHERE NAME  = 'SP_MostrarDetalladoVenta')
DROP PROCEDURE SP_MostrarDetalladoVenta
go
CREATE PROC SP_MostrarDetalladoVenta
@codigo int
as
begin
select
	dv.idventa,
	p.idprod,
	p.titprod,
	dv.precuventa,
	dv.canventa
from detalleventa dv 
	inner join producto p on dv.idprod=p.idprod
where dv.idventa = @codigo
end
go
exec SP_MostrarDetalladoVenta 4
go