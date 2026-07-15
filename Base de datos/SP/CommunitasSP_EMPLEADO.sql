-- seleccionamos la BD
use EI5447CommunitasBD
go

-- cliente
-- Mostrar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarEmpleado') 
DROP PROCEDURE SP_MostrarEmpleado
go
CREATE PROC	SP_MostrarEmpleado
as
begin
select 
	e.idemp,
	e.nomemp,
	e.apepemp,
	e.apememp,
	e.numdocemp,
	e.fecnacemp,
	e.diremp,
	e.telemp,
	e.coremp,
	e.fecinemp,
	e.usuemp,
	e.claemp,
	e.sueldoemp,
	e.numhoremp,
	e.estemp,
	e.idtipdoc,
	e.idrol,
	e.iddis,
	td.nomtipdoc,
	r.nomrol,
	d.nomdis
from empleado e
inner join tipodocumento td on e.idtipdoc=td.idtipdoc
inner join rol r on e.idrol=r.idrol
inner join distrito d on e.iddis=d.iddis
where e.estemp = 1
end
go
exec SP_MostrarEmpleado
go

-- Mostrar Todos
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarEmpleadoTodo') 
DROP PROCEDURE SP_MostrarEmpleadoTodo
go
CREATE PROC	SP_MostrarEmpleadoTodo
as
begin
select
	e.idemp,
	e.nomemp,
	e.apepemp,
	e.apememp,
	e.numdocemp,
	e.fecnacemp,
	e.diremp,
	e.telemp,
	e.coremp,
	e.fecinemp,
	e.usuemp,
	e.claemp,
	e.sueldoemp,
	e.numhoremp,
	e.estemp,
	e.idtipdoc,
	e.idrol,
	e.iddis,
	td.nomtipdoc,
	r.nomrol,
	d.nomdis
from empleado e
inner join tipodocumento td on e.idtipdoc=td.idtipdoc
inner join rol r on e.idrol=r.idrol
inner join distrito d on e.iddis=d.iddis
end
go
exec SP_MostrarEmpleadoTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarEmpleado') 
DROP PROCEDURE SP_RegistrarEmpleado
go
CREATE PROC	SP_RegistrarEmpleado
	@nombre VARCHAR(80),
    @apep VARCHAR(80),
    @apem VARCHAR(80),
    @numerodoc VARCHAR(20),
    @fecnac DATE,
    @direccion VARCHAR(100),
    @telefono VARCHAR(30),
    @correo VARCHAR(100),
	@fechaingreso DATE,
	@usuario VARCHAR(100),
	@clave VARCHAR(100),
	@sueldo MONEY,
	@numhoras INT,
    @estado BIT,
    @idtipdoc INT,
	@idrol INT,
	@iddis INT
as
begin
	begin tran SP_RegistrarEmpleado
	begin try
		insert into empleado 
				(nomemp,
				apepemp,
				apememp,
				numdocemp,
				fecnacemp,
				diremp,
				telemp,
				coremp,
				fecinemp,
				usuemp,
				claemp,
				sueldoemp,
				numhoremp,
				estemp,
				idtipdoc,
				idrol,
				iddis)
		values(
			@nombre,
			@apep,
			@apem,
			@numerodoc,
			@fecnac,
			@direccion,
			@telefono,
			@correo,
			@fechaingreso,
			@usuario,
			@clave,
			@sueldo,
			@numhoras,
			@estado,
			@idtipdoc,
			@idrol,
			@iddis)
		commit tran SP_RegistrarEmpleado
	end try
	begin catch
		rollback tran SP_RegistrarEmpleado
	end catch
end
go

-- Buscar por codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarEmpleadoXCodigo') 
DROP PROCEDURE SP_BuscarEmpleadoXCodigo
go
CREATE PROC	SP_BuscarEmpleadoXCodigo
@codigo int
as
begin
select 
	e.idemp,
	e.nomemp,
	e.apepemp,
	e.apememp,
	e.numdocemp,
	e.fecnacemp,
	e.diremp,
	e.telemp,
	e.coremp,
	e.fecinemp,
	e.usuemp,
	e.claemp,
	e.sueldoemp,
	e.numhoremp,
	e.estemp,
	e.idtipdoc,
	e.idrol,
	e.iddis,
	td.nomtipdoc,
	r.nomrol,
	d.nomdis
from empleado e
inner join tipodocumento td on e.idtipdoc=td.idtipdoc
inner join rol r on e.idrol=r.idrol
inner join distrito d on e.iddis=d.iddis
end
go
exec SP_BuscarEmpleadoXCodigo 1
go

-- Actualizar Plato
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarEmpleado') 
DROP PROCEDURE SP_ActualizarEmpleado
go
CREATE PROC	SP_ActualizarEmpleado
	@codigo int,
	@nombre VARCHAR(80),
    @apep VARCHAR(80),
    @apem VARCHAR(80),
    @numerodoc VARCHAR(20),
    @fecnac DATE,
    @direccion VARCHAR(100),
    @telefono VARCHAR(30),
    @correo VARCHAR(100),
	@fechaingreso DATE,
	@usuario VARCHAR(100),
	@clave VARCHAR(100),
	@sueldo MONEY,
	@numhoras INT,
    @estado BIT,
    @idtipdoc INT,
	@idrol INT,
	@iddis INT
as
begin
	begin tran SP_ActualizarEmpleado
	begin try
		update empleado
		set 			
			nomemp=@nombre,
			apepemp=@apep,
			apememp=@apem,
			numdocemp=@numerodoc,
			fecnacemp=@fecnac,
			diremp=@direccion,
			telemp=@telefono,
			coremp=@correo,
			fecinemp=@fechaingreso,
			usuemp=@usuario,
			claemp=@clave,
			sueldoemp=@sueldo,
			numhoremp=@numhoras,
			estemp=@estado,
			idtipdoc=@idtipdoc,
			idrol=@idrol,
			iddis=@iddis
			where idemp=@codigo
			commit tran SP_ActualizarEmpleado
	end try
	begin catch
		rollback tran SP_ActualizarEmpleado
	end catch
end
go

-- Eliminar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarEmpleado') 
DROP PROCEDURE SP_EliminarEmpleado
go
CREATE PROC	SP_EliminarEmpleado
@codigo int
as
begin
begin tran SP_EliminarEmpleado
begin try
update empleado set estemp=0 where idemp=@codigo
commit tran SP_EliminarEmpleado
end try
begin catch
	rollback tran SP_EliminarEmpleado
end catch
end
go

-- habilitar 
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarEmpleado') 
DROP PROCEDURE SP_HabilitarEmpleado
go
CREATE PROC	SP_HabilitarEmpleado
@codigo int
as
begin
begin tran SP_HabilitarEmpleado
begin try
update empleado set estemp=1 where idemp=@codigo
commit tran SP_HabilitarEmpleado
end try
begin catch
	rollback tran SP_HabilitarEmpleado
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoEmpleado') 
DROP PROCEDURE SP_CodigoEmpleado
go
CREATE PROC	SP_CodigoEmpleado
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from empleado)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('empleado')+1

-- comprobando que el identity es correcto
dbcc checkident ('empleado',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('empleado')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoEmpleado
go

--validar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME = 'SP_ValidarEmpleado')
DROP PROCEDURE SP_ValidarEmpleado
go
CREATE PROC SP_ValidarEmpleado
@usuario varchar(100),
@clave varchar(100)
as
begin
select e.idemp, e.nomemp, e.apepemp, e.apememp, e.usuemp, r.idrol,
r.nomrol, e.estemp
from empleado e inner join rol r on e.idrol = r.idrol
where e.usuemp=@usuario and e.claemp=@clave
end
go
exec SP_ValidarEmpleado 'rcanales', '123'
go
