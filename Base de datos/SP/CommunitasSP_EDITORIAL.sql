-- seleccionamos la BD
use EI5447CommunitasBD
go

-- procedimiento editorial
-- Mostrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarEditorial') 
DROP PROCEDURE SP_MostrarEditorial 
go
CREATE PROC	SP_MostrarEditorial
as
begin
select * from editorial where esteditorial = 1
end
go
exec SP_MostrarEditorial
go

-- Mostrar Todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarEditorialTodo') 
DROP PROCEDURE SP_MostrarEditorialTodo  
go
CREATE PROC	SP_MostrarEditorialTodo
as
begin
select * from editorial
end
go
exec SP_MostrarEditorialTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarEditorial')  
DROP PROCEDURE SP_RegistrarEditorial
GO

CREATE PROC SP_RegistrarEditorial
@nombre VARCHAR(100),
@estado BIT
AS
BEGIN
    BEGIN TRAN SP_RegistrarEditorial
    BEGIN TRY
        INSERT INTO editorial
            (nomeditorial, esteditorial)
        VALUES
            (@nombre, @estado)

        COMMIT TRAN SP_RegistrarEditorial
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_RegistrarEditorial
    END CATCH
END
GO


-- Buscar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_BuscarEditorialXCodigo') 
DROP PROCEDURE SP_BuscarEditorialXCodigo  
go
CREATE PROC	SP_BuscarEditorialXCodigo
@codigo int
as
begin
select * from editorial where ideditorial=@codigo
end
go
exec SP_BuscarEditorialXCodigo 3
go

-- actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarEditorial') 
DROP PROCEDURE SP_ActualizarEditorial  
go
CREATE PROC	SP_ActualizarEditorial
@codigo int,
@nombre varchar(100),
@estado bit
as
begin
begin tran SP_ActualizarEditorial
begin try
update editorial set nomeditorial=@nombre, esteditorial=@estado where ideditorial=@codigo
commit tran SP_ActualizarEditorial
end try
begin catch
	rollback tran SP_ActualizarEditorial
end catch
end
go

-- eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarEditorial') 
DROP PROCEDURE SP_EliminarEditorial  
go
CREATE PROC	SP_EliminarEditorial
@codigo int
as
begin
begin tran SP_EliminarEditorial
begin try
update editorial set esteditorial=0 where ideditorial=@codigo
commit tran SP_EliminarEditorial
end try
begin catch
	rollback tran SP_EliminarEditorial
end catch
end
go


-- habilitar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_HabilitarEditorial') 
DROP PROCEDURE SP_HabilitarEditorial  
go
CREATE PROC	SP_HabilitarEditorial
@codigo int
as
begin
begin tran SP_HabilitarEditorial
begin try
update editorial set esteditorial=1 where ideditorial=@codigo
commit tran SP_HabilitarEditorial
end try
begin catch
	rollback tran SP_HabilitarEditorial
end catch
end
go

-- siguiente codigo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_CodigoEditorial') 
DROP PROCEDURE SP_CodigoEditorial
go
CREATE PROC	SP_CodigoEditorial
as
begin
declare @siguientecodigo int
declare @valoractual int
-- si la tabla esta vacia
if not exists (select 1 from editorial)
begin
set @siguientecodigo=1
end
else
begin
-- obtener el proximo valor del identity
select @siguientecodigo=IDENT_CURRENT('editorial')+1

-- comprobando que el identity es correcto
dbcc checkident ('editorial',noreseed) with no_infomsgs
select @valoractual=IDENT_CURRENT('editorial')+1

-- verificamos los valores
if @valoractual>@siguientecodigo
set @siguientecodigo=@valoractual
end
-- retornamos el resultado
select @siguientecodigo as SiguienteCodigo
end
go
exec SP_CodigoEditorial
go
