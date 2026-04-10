CREATE DATABASE SistemaColmado
GO

USE SistemaColmado
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---===========================================================================
--- TABLA USUARIOS
---===========================================================================

-- Tabla Usuarios
CREATE TABLE Usuarios
(
	IdUsuario   INT IDENTITY(1,1) NOT NULL,
	Usuario     VARCHAR(50) NOT NULL,
	Contrasena  VARCHAR(50) NOT NULL,
	Rol         VARCHAR(20) NOT NULL,
	PRIMARY KEY CLUSTERED (IdUsuario ASC),
	UNIQUE NONCLUSTERED (Usuario ASC)
)
GO

-- Procedimiento para mostrar todos los usuarios
CREATE PROC MostrarUsuarios
AS
	SELECT * FROM Usuarios
GO

-- Procedimiento para insertar un usuario
CREATE PROC InsertarUsuario
	@Usuario VARCHAR(50),
	@Contrasena VARCHAR(50),
	@Rol VARCHAR(20)
AS
	INSERT INTO Usuarios (Usuario, Contrasena, Rol)
	VALUES (@Usuario, @Contrasena, @Rol)
GO

-- Procedimiento para editar un usuario
CREATE PROC EditarUsuario
	@IdUsuario INT,
	@Usuario VARCHAR(50),
	@Contrasena VARCHAR(50),
	@Rol VARCHAR(20)
AS
	UPDATE Usuarios 
	SET Usuario = @Usuario, Contrasena = @Contrasena, Rol = @Rol
	WHERE IdUsuario = @IdUsuario
GO

-- Procedimiento para eliminar un usuario
CREATE PROC EliminarUsuario
	@IdUsuario INT
AS
	DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario
GO

-- Procedimiento para validar credenciales de login
CREATE PROC ValidarLogin
    @Usuario VARCHAR(50),
    @Contrasena VARCHAR(50)
AS
    SELECT IdUsuario, Rol FROM Usuarios 
    WHERE Usuario = @Usuario AND Contrasena = @Contrasena;
GO

-- Procedimiento para obtener el rol e id de un usuario
CREATE PROC ObtenerDetalleUsuario
    @Usuario VARCHAR(50)
AS
    SELECT IdUsuario, Rol FROM Usuarios WHERE Usuario = @Usuario;
GO

---===========================================================================
--- TABLA CLIENTES
---===========================================================================

-- Tabla Clientes
CREATE TABLE Clientes
(
	IdCliente   INT IDENTITY(1,1) NOT NULL,
	Nombre      VARCHAR(100) NOT NULL,
	Telefono    VARCHAR(20) NOT NULL,
	Informacion VARCHAR(250) NULL,
	Saldo       INT NOT NULL DEFAULT 0,
	Activo      BIT NOT NULL DEFAULT 1,
	PRIMARY KEY CLUSTERED (IdCliente ASC)
)
GO

ALTER TABLE Clientes ADD CONSTRAINT CK_Saldo CHECK (Saldo >= 0);

-- Procedimiento para mostrar todos los clientes activos
CREATE PROC MostrarClientes
AS
	SELECT * FROM Clientes WHERE Activo = 1
GO

-- Procedimiento para insertar un cliente
CREATE PROC InsertarCliente
	@Nombre VARCHAR(100),
	@Telefono VARCHAR(20),
	@Informacion VARCHAR(250)
AS
	INSERT INTO Clientes (Nombre, Telefono, Informacion)
	VALUES (@Nombre, @Telefono, @Informacion)
GO

-- Procedimiento para editar un cliente
CREATE PROC EditarCliente
	@IdCliente INT,
	@Nombre VARCHAR(100),
	@Telefono VARCHAR(20),
	@Informacion VARCHAR(250),
	@Saldo INT,
	@Activo BIT
AS
	UPDATE Clientes 
	SET Nombre = @Nombre, Telefono = @Telefono, Informacion = @Informacion, 
	    Saldo = @Saldo, Activo = @Activo
	WHERE IdCliente = @IdCliente
GO

-- Procedimiento para eliminar un cliente
CREATE PROC EliminarCliente
	@IdCliente INT
AS
	DELETE FROM Clientes WHERE IdCliente = @IdCliente
GO

-- Procedimiento para agregar saldo a un cliente
CREATE PROC AgregarSaldoCliente
    @IdCliente INT,
    @Monto INT
AS
    UPDATE Clientes SET Saldo = Saldo + @Monto WHERE IdCliente = @IdCliente;
GO

-- Procedimiento para desactivar un cliente
CREATE PROC DesactivarCliente
    @IdCliente INT
AS
    UPDATE Clientes SET Activo = 0 WHERE IdCliente = @IdCliente;
GO

-- Procedimiento para reactivar un cliente
CREATE PROC ReactivarCliente
    @IdCliente INT
AS
    UPDATE Clientes SET Activo = 1 WHERE IdCliente = @IdCliente;
GO

-- Procedimiento para verificar si un telefono ya existe
CREATE PROC ExisteTelefono
    @Telefono VARCHAR(20)
AS
    SELECT COUNT(*) FROM Clientes WHERE Telefono = @Telefono;
GO

-- Procedimiento para verificar telefono duplicado al editar
CREATE PROC ExisteTelefonoEditar
    @Telefono VARCHAR(20),
    @IdCliente INT
AS
    SELECT COUNT(*) FROM Clientes WHERE Telefono = @Telefono AND IdCliente <> @IdCliente;
GO

-- Procedimiento para mostrar clientes desactivados
CREATE PROC MostrarClientesDesactivados
AS
    SELECT * FROM Clientes WHERE Activo = 0
GO

---===========================================================================
--- TABLA PRODUCTOS
---===========================================================================

-- Tabla Productos
CREATE TABLE Productos
(
	IdProducto  INT IDENTITY(1,1) NOT NULL,
	Nombre      VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	Marca       VARCHAR(50) NOT NULL,
	Precio      DECIMAL(10, 2) NOT NULL,
	Stock       INT NOT NULL DEFAULT 0,
	Activo      BIT NOT NULL DEFAULT 1,
	Codigo      VARCHAR(10) NOT NULL,
	PRIMARY KEY CLUSTERED (IdProducto ASC)
)
GO

ALTER TABLE Productos ADD CONSTRAINT CK_Precio CHECK (Precio >= 0);
ALTER TABLE Productos ADD CONSTRAINT CK_Stock  CHECK (Stock  >= 0);

-- Procedimiento para mostrar productos activos
CREATE PROC MostrarProductosActivos
AS
	SELECT * FROM Productos WHERE Activo = 1
GO

-- Procedimiento para mostrar productos desactivados
CREATE PROC MostrarProductosDESACTIVADOS
AS
	SELECT * FROM Productos WHERE Activo = 0
GO

-- Procedimiento para insertar un producto
CREATE PROC InsertarProducto
	@Nombre VARCHAR(100),
	@Descripcion VARCHAR(50),
	@Marca VARCHAR(50),
	@Precio DECIMAL(10, 2),
	@Stock INT,
	@Codigo VARCHAR(10)
AS
	INSERT INTO Productos (Nombre, Descripcion, Marca, Precio, Stock, Codigo)
	VALUES (@Nombre, @Descripcion, @Marca, @Precio, @Stock, @Codigo)
GO

-- Procedimiento para editar un producto
CREATE PROC EditarProducto
	@IdProducto INT,
	@Nombre VARCHAR(100),
	@Descripcion VARCHAR(50),
	@Marca VARCHAR(50),
	@Precio DECIMAL(10, 2),
	@Stock INT,
	@Activo BIT,
	@Codigo VARCHAR(10)
AS
	UPDATE Productos 
	SET Nombre = @Nombre, Descripcion = @Descripcion, Marca = @Marca, 
	    Precio = @Precio, Stock = @Stock, Activo = @Activo, Codigo = @Codigo
	WHERE IdProducto = @IdProducto
GO

-- Procedimiento para eliminar un producto (eliminacion logica)
CREATE PROC EliminarProducto
    @IdProducto INT
AS
    UPDATE Productos SET Activo = 0 WHERE IdProducto = @IdProducto
GO

-- Procedimiento para reactivar un producto
CREATE PROC ReactivarProducto
    @IdProducto INT
AS
    UPDATE Productos SET Activo = 1 WHERE IdProducto = @IdProducto;
GO

-- Procedimiento para verificar si un producto ya existe al insertar
CREATE PROC ExisteProducto
    @Nombre VARCHAR(100),
    @Marca VARCHAR(50)
AS
    SELECT COUNT(*) FROM Productos WHERE Nombre = @Nombre AND Marca = @Marca;
GO

-- Procedimiento para verificar producto duplicado al editar
CREATE PROC ExisteProductoEditar
    @Nombre VARCHAR(100),
    @Marca VARCHAR(50),
    @IdProducto INT
AS
    SELECT COUNT(*) FROM Productos 
    WHERE Nombre = @Nombre AND Marca = @Marca AND IdProducto <> @IdProducto;
GO

-- Procedimiento para obtener las marcas disponibles
CREATE PROC ObtenerMarcas
AS
    SELECT DISTINCT Marca FROM Productos WHERE Activo = 1;
GO

-- Procedimiento para buscar productos por nombre o codigo
CREATE PROC BuscarProducto
    @Criterio VARCHAR(100)
AS
    SELECT IdProducto, Nombre, Codigo, Precio, Stock
    FROM Productos
    WHERE Activo = 1
    AND (Codigo LIKE '%' + @Criterio + '%' OR Nombre LIKE '%' + @Criterio + '%');
GO

---===========================================================================
--- TABLA VENTAS
---===========================================================================

-- Tabla Ventas
CREATE TABLE Ventas
(
	IdVenta     INT IDENTITY(1,1) NOT NULL,
	IdCliente   INT NULL,
	Fecha       DATETIME NOT NULL,
	MontoTotal  DECIMAL(12, 2) NOT NULL DEFAULT 0,
	Estado      VARCHAR(20) NOT NULL DEFAULT 'Completada',
	PRIMARY KEY CLUSTERED (IdVenta ASC)
)
GO

-- Procedimiento para mostrar todas las ventas
CREATE PROC MostrarVentas
AS
	SELECT * FROM Ventas
GO

-- Procedimiento para insertar una venta
CREATE PROC InsertarVenta
	@IdCliente INT,
	@Fecha DATETIME,
	@MontoTotal DECIMAL(12, 2),
	@Estado VARCHAR(20)
AS
	INSERT INTO Ventas (IdCliente, Fecha, MontoTotal, Estado)
	VALUES (@IdCliente, @Fecha, @MontoTotal, @Estado);
	SELECT SCOPE_IDENTITY();
GO

-- Procedimiento para editar una venta
CREATE PROC EditarVenta
	@IdVenta INT,
	@IdCliente INT,
	@MontoTotal DECIMAL(12, 2),
	@Estado VARCHAR(20)
AS
	UPDATE Ventas 
	SET IdCliente = @IdCliente, MontoTotal = @MontoTotal, Estado = @Estado
	WHERE IdVenta = @IdVenta
GO

-- Procedimiento para eliminar una venta
CREATE PROC EliminarVenta
	@IdVenta INT
AS
	DELETE FROM Ventas WHERE IdVenta = @IdVenta
GO

-- Procedimiento para mostrar historial de ventas con nombre de cliente
CREATE PROC MostrarHistorialVentas
AS
    SELECT v.IdVenta, 
           ISNULL(c.Nombre, 'Consumidor Final') AS Cliente, 
           v.Fecha, v.MontoTotal, v.Estado
    FROM Ventas v
    LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
    ORDER BY v.Fecha DESC;
GO

-- Procedimiento para mostrar ventas del dia actual
CREATE PROC ReporteVentasDelDia
AS
    SELECT v.IdVenta, 
           ISNULL(c.Nombre, 'Consumidor Final') AS Cliente, 
           v.Fecha, v.MontoTotal, v.Estado
    FROM Ventas v
    LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
    WHERE CAST(v.Fecha AS DATE) = CAST(GETDATE() AS DATE)
    AND v.Estado <> 'Anulada';
GO

-- Procedimiento para mostrar los 5 productos mas vendidos
CREATE PROC Top5ProductosMasVendidos
AS
    SELECT TOP 5 p.Nombre, p.Marca, SUM(vd.Cantidad) AS TotalVendido
    FROM VentaDetalle vd
    INNER JOIN Productos p ON vd.IdProducto = p.IdProducto
    INNER JOIN Ventas v ON vd.IdVenta = v.IdVenta
    WHERE v.Estado <> 'Anulada'
    GROUP BY p.Nombre, p.Marca
    ORDER BY TotalVendido DESC;
GO

-- Procedimiento para anular una venta
CREATE PROC AnularVenta
    @IdVenta INT
AS
    UPDATE Ventas SET Estado = 'Anulada' WHERE IdVenta = @IdVenta;
GO

-- Procedimiento para completar una venta pendiente
CREATE PROC CompletarVenta
    @IdVenta INT
AS
    UPDATE Ventas SET Estado = 'Completada' WHERE IdVenta = @IdVenta;
GO

---===========================================================================
--- TABLA VENTA DETALLE
---===========================================================================

-- Tabla VentaDetalle
CREATE TABLE VentaDetalle
(
	IdVentaDetalle INT IDENTITY(1,1) NOT NULL,
	IdVenta        INT NOT NULL,
	IdProducto     INT NOT NULL,
	Cantidad       INT NOT NULL,
	PrecioUnitario DECIMAL(10, 2) NOT NULL,
	Subtotal       AS (Cantidad * PrecioUnitario) PERSISTED,
	PRIMARY KEY CLUSTERED (IdVentaDetalle ASC)
)
GO

-- Procedimiento para mostrar el detalle de una venta
CREATE PROC MostrarVentaDetalle
	@IdVenta INT
AS
	SELECT p.Nombre, p.Marca, vd.Cantidad, vd.PrecioUnitario, vd.Subtotal
	FROM VentaDetalle vd
	INNER JOIN Productos p ON vd.IdProducto = p.IdProducto
	WHERE vd.IdVenta = @IdVenta
GO

-- Procedimiento para insertar un detalle de venta
CREATE PROC InsertarVentaDetalle
	@IdVenta INT,
	@IdProducto INT,
	@Cantidad INT,
	@PrecioUnitario DECIMAL(10, 2)
AS
	INSERT INTO VentaDetalle (IdVenta, IdProducto, Cantidad, PrecioUnitario)
	VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario)
GO

-- Procedimiento para eliminar un detalle de venta
CREATE PROC EliminarVentaDetalle
	@IdVentaDetalle INT
AS
	DELETE FROM VentaDetalle WHERE IdVentaDetalle = @IdVentaDetalle
GO

---===========================================================================
--- TABLA AUDITORIA
---===========================================================================

-- Tabla Auditoria
CREATE TABLE Auditoria
(
	AuditoriaID INT IDENTITY(1,1) NOT NULL,
	IdUsuario   INT NOT NULL,
	Accion      VARCHAR(50),
	Fecha       DATETIME DEFAULT GETDATE(),
	PRIMARY KEY CLUSTERED (AuditoriaID ASC)
)
GO

-- Procedimiento para insertar un registro de auditoria
CREATE PROC InsertarAuditoria
	@IdUsuario INT,
	@Accion VARCHAR(50)
AS
	INSERT INTO Auditoria (IdUsuario, Accion)
	VALUES (@IdUsuario, @Accion)
GO

-- Procedimiento para mostrar todos los registros de auditoria
CREATE PROC MostrarAuditoria
AS
	SELECT * FROM Auditoria
GO

-- Procedimiento para mostrar auditoria con nombre de usuario
CREATE PROC MostrarAuditoriaDetalle
AS
    SELECT a.AuditoriaID, u.Usuario, a.Accion, a.Fecha
    FROM Auditoria a
    INNER JOIN Usuarios u ON a.IdUsuario = u.IdUsuario
    ORDER BY a.Fecha DESC
GO
---===========================================================================
--- FOREIGN KEYS
---===========================================================================

-- FK: VentaDetalle hacia Productos
ALTER TABLE VentaDetalle  
	WITH CHECK ADD CONSTRAINT FK_VentaDetalle_Producto 
	FOREIGN KEY(IdProducto) REFERENCES Productos(IdProducto)
GO
ALTER TABLE VentaDetalle CHECK CONSTRAINT FK_VentaDetalle_Producto
GO

-- FK: VentaDetalle hacia Ventas
ALTER TABLE VentaDetalle  
	WITH CHECK ADD CONSTRAINT FK_VentaDetalle_Venta 
	FOREIGN KEY(IdVenta) REFERENCES Ventas(IdVenta)
GO
ALTER TABLE VentaDetalle CHECK CONSTRAINT FK_VentaDetalle_Venta
GO

-- FK: Ventas hacia Clientes
ALTER TABLE Ventas  
	WITH CHECK ADD CONSTRAINT FK_Venta_Cliente 
	FOREIGN KEY(IdCliente) REFERENCES Clientes(IdCliente)
GO
ALTER TABLE Ventas CHECK CONSTRAINT FK_Venta_Cliente
GO

-- FK: Auditoria hacia Usuarios
ALTER TABLE Auditoria  
	WITH CHECK ADD CONSTRAINT FK_Auditoria_IdUsuario 
	FOREIGN KEY(IdUsuario) REFERENCES Usuarios(IdUsuario)
GO
ALTER TABLE Auditoria CHECK CONSTRAINT FK_Auditoria_IdUsuario
GO

---===========================================================================
--- DATOS INICIALES
---===========================================================================

INSERT INTO Usuarios (Usuario, Contrasena, Rol) 
VALUES ('admin1', '12345', 'Administrador')
GO

---===========================================================================
--- CONSULTAS DE VERIFICACION
---===========================================================================

SELECT * FROM Usuarios
GO

EXEC MostrarAuditoria
GO
