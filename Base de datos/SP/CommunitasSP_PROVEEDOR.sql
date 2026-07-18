-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento proveedor
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarProveedor') 
DROP PROCEDURE SP_MostrarProveedor
go
CREATE PROC	SP_MostrarProveedor
as
begin
select * from proveedor where estprov= 1
end
go
exec SP_MostrarProveedor
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarProveedorTodo') 
DROP PROCEDURE SP_MostrarProveedorTodo
go
CREATE PROC	SP_MostrarProveedorTodo
as
begin
select * from proveedor
end
go
exec SP_MostrarProveedorTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarProveedor') 
DROP PROCEDURE SP_RegistrarProveedor
go
CREATE PROC	SP_RegistrarProveedor
@nombre varchar(100),
@ruc CHAR(11),
@telefono VARCHAR(30),
@correo varchar(100),
@direccion varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarProveedor
begin try
insert into proveedor(razsocprov, rucprov,telfprov, corprov, direcprov, estprov) 
values(@nombre, @ruc, @telefono, @correo, @direccion, @estado)
commit tran SP_RegistrarProveedor
end try
begin catch
	rollback tran SP_RegistrarProveedor
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarProveedorXCodigo') 
DROP PROCEDURE SP_BuscarProveedorXCodigo
go
CREATE PROC	SP_BuscarProveedorXCodigo
@codigo int
as
begin
select * from proveedor where idprov=@codigo
end
go
exec SP_BuscarProveedorXCodigo 2
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarProveedor') 
DROP PROCEDURE SP_ActualizarProveedor
go
CREATE PROC	SP_ActualizarProveedor
@codigo int,
@nombre varchar(100),
@ruc CHAR(11),
@telefono VARCHAR(30),
@correo varchar(100),
@direccion varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarProveedor
begin try
update proveedor 
set razsocprov=@nombre, rucprov=@ruc,telfprov=@telefono, corprov=@correo,direcprov=@direccion ,estprov=@estado where idprov=@codigo
commit tran SP_ActualizarProveedor
end try
begin catch
	rollback tran SP_ActualizarProveedor
	end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarProveedor') 
DROP PROCEDURE SP_EliminarProveedor
go
CREATE PROC	SP_EliminarProveedor
@codigo int
as
begin
begin tran SP_EliminarProveedor
begin try
update proveedor set estprov=0 where idprov=@codigo
commit tran SP_EliminarProveedor
end try
begin catch
	rollback tran SP_EliminarProveedor
end catch
end
go

-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarProveedor') 
DROP PROCEDURE SP_HabilitarProveedor
go
CREATE PROC	SP_HabilitarProveedor
@codigo int
as
begin
begin tran SP_HabilitarProveedor
begin try
update proveedor set estprov=1 where idprov=@codigo
commit tran SP_HabilitarProveedor
end try
begin catch
	rollback tran SP_HabilitarProveedor
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoProveedor') 
DROP PROCEDURE SP_CodigoProveedor
go
CREATE PROC	SP_CodigoProveedor
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from proveedor)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('proveedor')+1

-- comprobando que el identity es correcto
dbcc checkident ('proveedor',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('proveedor')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoProveedor
go