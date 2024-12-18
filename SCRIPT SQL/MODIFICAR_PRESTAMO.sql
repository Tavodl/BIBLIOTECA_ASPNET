
CREATE OR ALTER PROCEDURE MODIFICAR_PRESTAMO
    @IDLECTOR INT,
    @IDLIBRO INT,
    @FECHAENTREGA DATE,
    @DEVUELTO BIT

    -- EXEC MODIFICAR_PRESTAMO 
    -- @IDLECTOR = 1, 
    -- @IDLIBRO = 3, 
    -- @FECHAENTREGA = '2024-11-11', 
    -- @DEVUELTO = 1;

AS
BEGIN
    UPDATE PRESTAMO
    SET FECHAENTREGA = @FECHAENTREGA,
        DEVUELTO = @DEVUELTO
    WHERE IDLECTOR = @IDLECTOR AND IDLIBRO = @IDLIBRO;
END;
