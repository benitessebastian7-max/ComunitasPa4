-- seleccionamos la BD
use EI5447CommunitasBD
go

-- venta
-- Registrar Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_RegistrarVenta')
DROP PROCEDURE SP_RegistrarVenta
GO

CREATE PROC SP_RegistrarVenta
    @idcli INT,
    @idemp INT,
    @idtippag INT,
    @total MONEY,
    @estado BIT,
    @idventa INT OUTPUT
AS
BEGIN
    INSERT INTO venta
        (fecventa,
         totalventa,
         estventa,
         idcli,
         idemp,
         idtippag)
    VALUES
        (GETDATE(),
         @total,
         @estado,
         @idcli,
         @idemp,
         @idtippag)

    SET @idventa = SCOPE_IDENTITY()
END
GO


-- Registrar Detalle Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_RegistrarDetalleVenta')
DROP PROCEDURE SP_RegistrarDetalleVenta
GO

CREATE PROC SP_RegistrarDetalleVenta
    @idventa INT,
    @idprod INT,
    @cantidad INT,
    @precio MONEY
AS
BEGIN
    INSERT INTO detalleventa
        (idventa,
         idprod,
         canventa,
         precuventa,
         subtotventa)
    VALUES
        (@idventa,
         @idprod,
         @cantidad,
         @precio,
         @cantidad * @precio)
END
GO


-- Siguiente Codigo Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_CodigoVenta')
DROP PROCEDURE SP_CodigoVenta
GO

CREATE PROC SP_CodigoVenta
AS
BEGIN
    DECLARE @siguientecodigo INT
    DECLARE @valoractual INT

    IF NOT EXISTS (SELECT 1 FROM venta)
    BEGIN
        SET @siguientecodigo = 1
    END
    ELSE
    BEGIN
        SELECT @siguientecodigo = IDENT_CURRENT('venta') + 1

        DBCC CHECKIDENT ('venta', NORESEED) WITH NO_INFOMSGS

        SELECT @valoractual = IDENT_CURRENT('venta') + 1

        IF @valoractual > @siguientecodigo
            SET @siguientecodigo = @valoractual
    END

    SELECT @siguientecodigo AS SiguienteCodigo
END
GO


-- Mostrar Venta Detalle
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_MostrarVentaDetalle')
DROP PROCEDURE SP_MostrarVentaDetalle
GO

CREATE PROC SP_MostrarVentaDetalle
AS
BEGIN
    SELECT
        v.idventa,
        v.fecventa,
        v.estventa,
        c.nomcli,
        c.apepcli,
        c.apemcli,
        e.nomemp,
        e.apepemp,
        e.apememp,
        tp.nomtippag,
        SUM(dv.subtotventa) AS Subtotal
    FROM venta v
        INNER JOIN cliente c
            ON v.idcli = c.idcli
        INNER JOIN empleado e
            ON v.idemp = e.idemp
        INNER JOIN tipopago tp
            ON v.idtippag = tp.idtippag
        INNER JOIN detalleventa dv
            ON v.idventa = dv.idventa
    GROUP BY
        v.idventa,
        v.fecventa,
        v.estventa,
        c.nomcli,
        c.apepcli,
        c.apemcli,
        e.nomemp,
        e.apepemp,
        e.apememp,
        tp.nomtippag
END
GO


-- Mostrar Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_MostrarVenta')
DROP PROCEDURE SP_MostrarVenta
GO

CREATE PROC SP_MostrarVenta
AS
BEGIN
    SELECT
        v.idventa,
        v.fecventa,
        v.estventa,
        c.nomcli,
        c.apepcli,
        c.apemcli,
        e.nomemp,
        e.apepemp,
        e.apememp,
        tp.nomtippag
    FROM venta v
        INNER JOIN cliente c
            ON v.idcli = c.idcli
        INNER JOIN empleado e
            ON v.idemp = e.idemp
        INNER JOIN tipopago tp
            ON v.idtippag = tp.idtippag
END
GO


-- Mostrar Detalle Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_MostrarDetalleVenta')
DROP PROCEDURE SP_MostrarDetalleVenta
GO

CREATE PROC SP_MostrarDetalleVenta
    @codigo INT
AS
BEGIN
    SELECT
        dv.idventa,
        p.idprod,
        p.titprod,
        dv.precuventa,
        dv.canventa,
        dv.subtotventa
    FROM detalleventa dv
        INNER JOIN producto p
            ON dv.idprod = p.idprod
    WHERE dv.idventa = @codigo
END
GO


-- Anular Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_AnularVenta')
DROP PROCEDURE SP_AnularVenta
GO

CREATE PROC SP_AnularVenta
    @codigo INT
AS
BEGIN
    BEGIN TRAN SP_AnularVenta

    BEGIN TRY
        UPDATE venta
        SET estventa = 0
        WHERE idventa = @codigo

        COMMIT TRAN SP_AnularVenta
    END TRY

    BEGIN CATCH
        ROLLBACK TRAN SP_AnularVenta
    END CATCH
END
GO


-- Habilitar Venta
IF EXISTS (SELECT * FROM sys.procedures WHERE NAME = 'SP_HabilitarVenta')
DROP PROCEDURE SP_HabilitarVenta
GO

CREATE PROC SP_HabilitarVenta
    @codigo INT
AS
BEGIN
    BEGIN TRAN SP_HabilitarVenta

    BEGIN TRY
        UPDATE venta
        SET estventa = 1
        WHERE idventa = @codigo

        COMMIT TRAN SP_HabilitarVenta
    END TRY

    BEGIN CATCH
        ROLLBACK TRAN SP_HabilitarVenta
    END CATCH
END
GO
