-- seleccionamos la BD
use EI5447CommunitasBD
go

-- compra
-- Registrar Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_RegistrarCompra')
DROP PROCEDURE SP_RegistrarCompra
GO

CREATE PROC SP_RegistrarCompra
    @idprov INT,
    @total MONEY,
    @estado BIT,
    @idcompra INT OUTPUT
AS
BEGIN
    INSERT INTO compra
        (feccompra,
         totalcompra,
         estcompra,
         idprov)
    VALUES
        (GETDATE(),
         @total,
         @estado,
         @idprov)

    SET @idcompra = SCOPE_IDENTITY()
END
GO


-- Registrar Detalle Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_RegistrarDetalleCompra')
DROP PROCEDURE SP_RegistrarDetalleCompra
GO

CREATE PROC SP_RegistrarDetalleCompra
    @idcompra INT,
    @idprod INT,
    @cantidad INT,
    @precio MONEY
AS
BEGIN
    INSERT INTO detallecompra
        (idcompra,
         idprod,
         cancompra,
         precucomp,
         subtotcomp)
    VALUES
        (@idcompra,
         @idprod,
         @cantidad,
         @precio,
         @cantidad * @precio)
END
GO


-- Siguiente Codigo Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_CodigoCompra')
DROP PROCEDURE SP_CodigoCompra
GO

CREATE PROC SP_CodigoCompra
AS
BEGIN
    DECLARE @siguientecodigo INT
    DECLARE @valoractual INT

    IF NOT EXISTS (SELECT 1 FROM compra)
    BEGIN
        SET @siguientecodigo = 1
    END
    ELSE
    BEGIN
        SELECT @siguientecodigo = IDENT_CURRENT('compra') + 1

        DBCC CHECKIDENT ('compra', NORESEED) WITH NO_INFOMSGS

        SELECT @valoractual = IDENT_CURRENT('compra') + 1

        IF @valoractual > @siguientecodigo
            SET @siguientecodigo = @valoractual
    END

    SELECT @siguientecodigo AS SiguienteCodigo
END
GO


-- Mostrar Compra Detalle
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_MostrarCompraDetalle')
DROP PROCEDURE SP_MostrarCompraDetalle
GO

CREATE PROC SP_MostrarCompraDetalle
AS
BEGIN
    SELECT
        c.idcompra,
        c.feccompra,
        p.razsocprov,
        p.rucprov,
        c.estcompra,
        SUM(dc.subtotcomp) AS Subtotal
    FROM compra c
        INNER JOIN proveedor p
            ON c.idprov = p.idprov
        INNER JOIN detallecompra dc
            ON c.idcompra = dc.idcompra
    GROUP BY
        c.idcompra,
        c.feccompra,
        p.razsocprov,
        p.rucprov,
        c.estcompra
END
GO


-- Mostrar Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_MostrarCompra')
DROP PROCEDURE SP_MostrarCompra
GO

CREATE PROC SP_MostrarCompra
AS
BEGIN
    SELECT
        c.idcompra,
        c.feccompra,
        p.razsocprov,
        p.rucprov,
        c.estcompra
    FROM compra c
        INNER JOIN proveedor p
            ON c.idprov = p.idprov
END
GO


-- Mostrar Detalle Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_MostrarDetalleCompra')
DROP PROCEDURE SP_MostrarDetalleCompra
GO

CREATE PROC SP_MostrarDetalleCompra
    @codigo INT
AS
BEGIN
    SELECT
        dc.idcompra,
        p.idprod,
        p.titprod,
        dc.precucomp,
        dc.cancompra,
        dc.subtotcomp
    FROM detallecompra dc
        INNER JOIN producto p
            ON dc.idprod = p.idprod
    WHERE dc.idcompra = @codigo
END
GO


-- Anular Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_AnularCompra')
DROP PROCEDURE SP_AnularCompra
GO

CREATE PROC SP_AnularCompra
    @codigo INT
AS
BEGIN
    BEGIN TRAN SP_AnularCompra

    BEGIN TRY
        UPDATE compra
        SET estcompra = 0
        WHERE idcompra = @codigo

        COMMIT TRAN SP_AnularCompra
    END TRY

    BEGIN CATCH
        ROLLBACK TRAN SP_AnularCompra
    END CATCH
END
GO


-- Habilitar Compra
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_HabilitarCompra')
DROP PROCEDURE SP_HabilitarCompra
GO

CREATE PROC SP_HabilitarCompra
    @codigo INT
AS
BEGIN
    BEGIN TRAN SP_HabilitarCompra

    BEGIN TRY
        UPDATE compra
        SET estcompra = 1
        WHERE idcompra = @codigo

        COMMIT TRAN SP_HabilitarCompra
    END TRY

    BEGIN CATCH
        ROLLBACK TRAN SP_HabilitarCompra
    END CATCH
END
GO
