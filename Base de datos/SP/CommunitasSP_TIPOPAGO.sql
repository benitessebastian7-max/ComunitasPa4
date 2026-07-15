-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento TIPO DE PAGO
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarTipoPago') 
DROP PROCEDURE SP_MostrarTipoPago
go
CREATE PROC	SP_MostrarTipoPago
as
begin
select * from tipopago where esttippag= 1
end
go
exec SP_MostrarTipoPago
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarTipoPagoTodo') 
DROP PROCEDURE SP_MostrarTipoPagoTodo
go
CREATE PROC	SP_MostrarTipoPagoTodo
as
begin
select * from tipopago
end
go
exec SP_MostrarTipoPagoTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarTipoPago') 
DROP PROCEDURE SP_RegistrarTipoPago
go
CREATE PROC	SP_RegistrarTipoPago
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_RegistrarTipoPago
begin try
insert into tipopago values(@nombre,@estado)
commit tran SP_RegistrarTipoPago
end try
begin catch
	rollback tran SP_RegistrarTipoPago
end catch
end
go


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarTipoPagoXCodigo') 
DROP PROCEDURE SP_BuscarTipoPagoXCodigo
go
CREATE PROC	SP_BuscarTipoPagoXCodigo
@codigo int
as
begin
select * from tipopago where idtippag=@codigo
end
go
exec SP_BuscarTipoPagoXCodigo 2
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarTipoPago') 
DROP PROCEDURE SP_ActualizarTipoPago
go
CREATE PROC	SP_ActualizarTipoPago
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarTipoPago
begin try
update tipopago set nomtippag=@nombre,esttippag=@estado where idtippag=@codigo
commit tran SP_ActualizarTipoPago
end try
begin catch
	rollback tran SP_ActualizarTipoPago
	end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarTipoPago') 
DROP PROCEDURE SP_EliminarTipoPago
go
CREATE PROC	SP_EliminarTipoPago
@codigo int
as
begin
begin tran SP_EliminarTipoPago
begin try
update tipopago set esttippag=0 where idtippag=@codigo
commit tran SP_EliminarTipoPago
end try
begin catch
	rollback tran SP_EliminarTipoPago
end catch
end
go

-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarTipoPago') 
DROP PROCEDURE SP_HabilitarTipoPago
go
CREATE PROC	SP_HabilitarTipoPago
@codigo int
as
begin
begin tran SP_HabilitarTipoPago
begin try
update tipopago set esttippag=1 where idtippag=@codigo
commit tran SP_HabilitarTipoPago
end try
begin catch
	rollback tran SP_HabilitarTipoPago
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoTipoPago') 
DROP PROCEDURE SP_CodigoTipoPago
go
CREATE PROC	SP_CodigoTipoPago
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from tipopago)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('tipopago')+1

-- comprobando que el identity es correcto
dbcc checkident ('tipopago',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('tipopago')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoTipoPago
go