-- seleccionamos la BD
use EI5447CommunitasBD
go

-- cliente
-- Mostrar cliente
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarCliente') 
DROP PROCEDURE SP_MostrarCliente
go
CREATE PROC	SP_MostrarCliente
as
begin
select 
	c.idcli,
	c.nomcli,
	c.apepcli,
	c.apemcli,
	c.numdoccli,
	c.fecnaccli,
	c.dircli,
	c.telcli,
	c.corcli,
	c.estcli,
	c.idtipdoc,
	c.iddis,
	td.nomtipdoc,
	d.nomdis
from cliente c
inner join tipodocumento td on c.idtipdoc=td.idtipdoc
inner join distrito d on c.iddis=d.iddis
where c.estcli = 1
end
go
exec SP_MostrarCliente
go

-- Mostrar Todos los clientes
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarClienteTodo') 
DROP PROCEDURE SP_MostrarClienteTodo
go
CREATE PROC	SP_MostrarClienteTodo
as
begin
select
	c.idcli,
	c.nomcli,
	c.apepcli,
	c.apemcli,
	c.numdoccli,
	c.fecnaccli,
	c.dircli,
	c.telcli,
	c.corcli,
	c.estcli,
	c.idtipdoc,
	c.iddis,
	td.nomtipdoc,
	d.nomdis
from cliente c
inner join tipodocumento td on c.idtipdoc=td.idtipdoc
inner join distrito d on c.iddis=d.iddis
end
go
exec SP_MostrarClienteTodo
go

-- Registrar cliente
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarCliente') 
DROP PROCEDURE SP_RegistrarCliente
go
CREATE PROC	SP_RegistrarCliente
	@nombre VARCHAR(80),
    @apep VARCHAR(80),
    @apem VARCHAR(80),
    @numerodoc VARCHAR(20),
    @fecnac DATE,
    @direccion VARCHAR(100),
    @telefono VARCHAR(30),
    @correo VARCHAR(100),
    @estado BIT,
    @idtipdoc INT,
	@iddis INT
as
begin
	begin tran SP_RegistrarCliente
	begin try
		insert into cliente (nomcli,apepcli,apemcli,numdoccli,fecnaccli,dircli,telcli,corcli,estcli,idtipdoc,iddis)
		values(
			@nombre,
			@apep,
			@apem,
			@numerodoc,
			@fecnac,
			@direccion,
			@telefono,
			@correo,
			@estado,
			@idtipdoc,
			@iddis)
		commit tran SP_RegistrarCliente
	end try
	begin catch
		rollback tran SP_RegistrarCliente
	end catch
end
go

-- Buscar cliente por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarClienteXCodigo') 
DROP PROCEDURE SP_BuscarClienteXCodigo 
go
CREATE PROC	SP_BuscarClienteXCodigo
@codigo int
as
begin
select 
	c.idcli,
	c.nomcli,
	c.apepcli,
	c.apemcli,
	c.numdoccli,
	c.fecnaccli,
	c.dircli,
	c.telcli,
	c.corcli,
	c.estcli,
	c.idtipdoc,
	c.iddis,
	td.nomtipdoc,
	d.nomdis 
from cliente c 
inner join tipodocumento td on c.idtipdoc=td.idtipdoc
inner join distrito d on c.iddis=d.iddis
where @codigo = c.idcli
end
go
exec SP_BuscarClienteXCodigo 1
go

-- Actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarCliente') 
DROP PROCEDURE SP_ActualizarCliente
go
CREATE PROC	SP_ActualizarCliente
	@codigo int,
	@nombre VARCHAR(80),
    @apep VARCHAR(80),
    @apem VARCHAR(80),
    @numerodoc VARCHAR(20),
    @fecnac DATE,
    @direccion VARCHAR(100),
    @telefono VARCHAR(30),
    @correo VARCHAR(100),
    @estado BIT,
    @idtipdoc INT,
	@iddis INT
as
begin
	begin tran SP_ActualizarCliente
	begin try
		update cliente 
		set 			
			nomcli=@nombre,
			apepcli = @apep,
			apemcli = @apem,
			numdoccli = @numerodoc,
			fecnaccli = @fecnac,
			dircli = @direccion,
			telcli = @telefono,
			corcli= @correo,
			estcli=@estado,
			idtipdoc = @idtipdoc,
			iddis = @iddis
			where idcli=@codigo
			commit tran SP_ActualizarCliente
	end try
	begin catch
		rollback tran SP_ActualizarCliente
	end catch
end
go

-- Eliminar cliente
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarCliente') 
DROP PROCEDURE SP_EliminarCliente
go
CREATE PROC	SP_EliminarCliente
@codigo int
as
begin
begin tran SP_EliminarCliente
begin try
update cliente set estcli=0 where idcli=@codigo
commit tran SP_EliminarCliente
end try
begin catch
	rollback tran SP_EliminarCliente
end catch
end
go

-- habilitar cliente
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarCliente') 
DROP PROCEDURE SP_HabilitarCliente
go
CREATE PROC	SP_HabilitarCliente
@codigo int
as
begin
begin tran SP_HabilitarCliente
begin try
update cliente set estcli=1 where idcli=@codigo
commit tran SP_HabilitarCliente
end try
begin catch
	rollback tran SP_HabilitarCliente
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoCliente') 
DROP PROCEDURE SP_CodigoCliente
go
CREATE PROC	SP_CodigoCliente
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from cliente)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('cliente')+1

-- comprobando que el identity es correcto
dbcc checkident ('cliente',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('cliente')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoCliente
go
