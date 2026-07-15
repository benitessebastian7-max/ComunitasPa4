use EI5447CommunitasBD
go

--detalle compra
--registrar detalle orden
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarDetalleCompra') 
DROP PROCEDURE SP_RegistrarDetalleCompra
go
CREATE PROC	SP_RegistrarDetalleCompra
@idcompra int,
@idprod int,
@cantidad int, 
@precio money,
@subtotal money
as
begin
insert into detallecompra 
values(
	@idcompra, 
	@idprod, 
	@cantidad,
	@precio,
	@subtotal)
end
go


--mostrar orden y detalle
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME  = 'SP_MostrarCompraDetalle')
DROP PROCEDURE SP_MostrarCompraDetalle
go
CREATE PROC SP_MostrarCompraDetalle
as
begin
select 
	c.idcompra,
	c.feccompra,
	p.idprov,
	p.razsocprov,
	c.estcompra,
	SUM(dc.cancompra*dc.precucomp) as Subtotal
from compra c 
	inner join proveedor p on c.idprov=p.idprov
	inner join detallecompra dc on c.idcompra=dc.idcompra
group by 
	c.idcompra,
	c.feccompra,
	p.idprov,
	p.razsocprov,
	c.estcompra
end
go
exec SP_MostrarCompraDetalle
go


IF EXISTS (SELECT * FROM sys.procedures WHERE NAME  = 'SP_MostrarDetalladoCompra')
DROP PROCEDURE SP_MostrarDetalle
go
CREATE PROC SP_MostrarDetalle
@codigo int
as
begin
select
	dc.idcompra,
	p.idprod,
	p.titprod,
	dc.precucomp,
	dc.cancompra
from detallecompra dc 
	inner join producto p on dc.idprod=p.idprod
where dc.idcompra = @codigo
end
go
exec SP_MostrarDetalle 1
go