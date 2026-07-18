-- seleccionamos la BD
use EI5447CommunitasBD
go

-- producto
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarProducto') 
DROP PROCEDURE SP_MostrarProducto
go
CREATE PROC	SP_MostrarProducto
as
begin
select
	pr.idprod,
	pr.isbnprod,
	pr.titprod,
	pr.descprod,
	pr.preccompprod,
	pr.precventprod,
	pr.preccompprod,
	pr.fecpubprod,
	pr.estprod,
	pr.idprov,
	pr.idcategoria,
	pr.ideditorial,
	p.razsocprov,
	c.nomcategoria,
	e.nomeditorial
from producto pr
inner join proveedor p on pr.idprov=p.idprov
inner join categoria c on pr.idcategoria=c.idcategoria
inner join editorial e on pr.ideditorial=e.ideditorial
where pr.estprod= 1
end
go
exec SP_MostrarProducto
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarProductoTodo') 
DROP PROCEDURE SP_MostrarProductoTodo
go
CREATE PROC	SP_MostrarProductoTodo
as
begin
select
	pr.idprod,
	pr.isbnprod,
	pr.titprod,
	pr.descprod,
	pr.preccompprod,
	pr.precventprod,
	pr.preccompprod,
	pr.fecpubprod,
	pr.estprod,
	pr.idprov,
	pr.idcategoria,
	pr.ideditorial,
	p.razsocprov,
	c.nomcategoria,
	e.nomeditorial
from producto pr
inner join proveedor p on pr.idprov=p.idprov
inner join categoria c on pr.idcategoria=c.idcategoria
inner join editorial e on pr.ideditorial=e.ideditorial
end
go
exec SP_MostrarProductoTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarProducto') 
DROP PROCEDURE SP_RegistrarProducto
go
CREATE PROC	SP_RegistrarProducto
	@isbn VARCHAR(20), 
	@titulo VARCHAR(250),
	@descripcion VARCHAR(500),
	@preciocompra MONEY, 
	@precioventa MONEY, 
	@fechapublicacion DATE, 
	@estado BIT,
	@idprov int,
	@idcategoria int, 
	@ideditorial int 
as
begin
	begin tran SP_RegistrarProducto
	begin try
		insert into producto
				(isbnprod,
				titprod,
				descprod,
				preccompprod,
				precventprod,
				fecpubprod,
				estprod,
				idprov,
				idcategoria,
				ideditorial)
		values(
				@isbn, 
				@titulo,
				@descripcion,
				@preciocompra, 
				@precioventa, 
				@fechapublicacion, 
				@estado,
				@idprov,
				@idcategoria, 
				@ideditorial)
		commit tran SP_RegistrarProducto
	end try
	begin catch
		rollback tran SP_RegistrarProducto
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarProductoXCodigo') 
DROP PROCEDURE SP_BuscarProductoXCodigo
go
CREATE PROC	SP_BuscarProductoXCodigo
@codigo int
as
begin
select 
	pr.idprod,
	pr.isbnprod,
	pr.titprod,
	pr.descprod,
	pr.preccompprod,
	pr.precventprod,
	pr.preccompprod,
	pr.fecpubprod,
	pr.estprod,
	pr.idprov,
	pr.idcategoria,
	pr.ideditorial,
	p.razsocprov,
	c.nomcategoria,
	e.nomeditorial
from producto pr
inner join proveedor p on pr.idprov=p.idprov
inner join categoria c on pr.idcategoria=c.idcategoria
inner join editorial e on pr.ideditorial=e.ideditorial
where pr.idprod = @codigo
end
go
exec SP_BuscarProductoXCodigo 5
go

-- Actualizar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarProducto') 
DROP PROCEDURE SP_ActualizarProducto
go
CREATE PROC	SP_ActualizarProducto
	@codigo INT,
	@isbn VARCHAR(20), 
	@titulo VARCHAR(250),
	@descripcion VARCHAR(500),
	@preciocompra MONEY, 
	@precioventa MONEY, 
	@fechapublicacion DATE, 
	@estado BIT,
	@idprov int,
	@idcategoria int, 
	@ideditorial int 
as
begin
	begin tran SP_ActualizarProducto
	begin try
		update producto
		set 			
			isbnprod = @isbn,
			titprod = @titulo,
			descprod = @descripcion,
			preccompprod = @preciocompra,
			precventprod = @precioventa,
			fecpubprod = @fechapublicacion,
			estprod = @estado,
			idprov = @idprov,
			idcategoria = @idcategoria,
			ideditorial = @ideditorial
		where idprod = @codigo
		commit tran SP_ActualizarProducto
	end try
	begin catch
		rollback tran SP_ActualizarProducto
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarProducto') 
DROP PROCEDURE SP_EliminarProducto
go
CREATE PROC	SP_EliminarProducto
@codigo int
as
begin
begin tran SP_EliminarProducto
begin try
update producto set estprod=0 where idprod=@codigo
commit tran SP_EliminarProducto
end try
begin catch
	rollback tran SP_EliminarProducto
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarProducto') 
DROP PROCEDURE SP_HabilitarProducto
go
CREATE PROC	SP_HabilitarProducto
@codigo int
as
begin
begin tran SP_HabilitarProducto
begin try
update producto set estprod=1 where idprod=@codigo
commit tran SP_HabilitarProducto
end try
begin catch
	rollback tran SP_HabilitarProducto
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoProducto') 
DROP PROCEDURE SP_CodigoProducto
go
CREATE PROC	SP_CodigoProducto
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from producto)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('producto')+1

-- comprobando que el identity es correcto
dbcc checkident ('producto',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('producto')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoProducto
go