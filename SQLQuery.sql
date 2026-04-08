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



/// Tabla Usuarios

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



/// Procedimiento para mostrar usuarios

CREATE PROC MostrarUsuarios

AS

	SELECT * FROM Usuarios

GO



/// Procedimiento para insertar usuarios

CREATE PROC InsertarUsuario

	@Usuario VARCHAR(50),

	@Contrasena VARCHAR(50),

	@Rol VARCHAR(20)

AS

	INSERT INTO Usuarios (Usuario, Contrasena, Rol)

	VALUES (@Usuario, @Contrasena, @Rol)

GO



/// Procedimiento para editar usuarios

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



/// Procedimiento para eliminar usuarios

CREATE PROC EliminarUsuario

	@IdUsuario INT

AS

	DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario

GO



---===========================================================================

--- TABLA CLIENTES

---===========================================================================



/// Tabla Clientes

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



/// Procedimiento para mostrar clientes

CREATE PROC MostrarClientes

AS

	SELECT * FROM Clientes

GO



/// Procedimiento para insertar clientes

CREATE PROC InsertarCliente

	@Nombre VARCHAR(100),

	@Telefono VARCHAR(20),

	@Informacion VARCHAR(250)

AS

	INSERT INTO Clientes (Nombre, Telefono, Informacion)

	VALUES (@Nombre, @Telefono, @Informacion)

GO



/// Procedimiento para editar clientes

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



/// Procedimiento para eliminar clientes

CREATE PROC EliminarCliente

	@IdCliente INT

AS

	DELETE FROM Clientes WHERE IdCliente = @IdCliente

GO



---===========================================================================

--- TABLA PRODUCTOS

---===========================================================================



/// Tabla Productos

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



/// Procedimiento para mostrar productos

CREATE PROC MostrarProductosActivos

AS

	SELECT * FROM Productos WHERE Activo = 1

GO







CREATE PROC MostrarProductosDESACTIVADOS

AS

	SELECT * FROM Productos WHERE Activo = 0

GO



/// Procedimiento para insertar productos

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



/// Procedimiento para editar productos

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



/// Procedimiento para eliminar productos

CREATE PROC EliminarProducto

	@IdProducto INT

AS

	DELETE FROM Productos WHERE IdProducto = @IdProducto

GO



---===========================================================================

--- TABLA VENTAS

---===========================================================================



/// Tabla Ventas

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



/// Procedimiento para mostrar ventas

CREATE PROC MostrarVentas

AS

	SELECT * FROM Ventas

GO



/// Procedimiento para insertar venta

CREATE PROC InsertarVenta

	@IdCliente INT,

	@Fecha DATETIME,

	@MontoTotal DECIMAL(12, 2),

	@Estado VARCHAR(20)

AS

	INSERT INTO Ventas (IdCliente, Fecha, MontoTotal, Estado)

	VALUES (@IdCliente, @Fecha, @MontoTotal, @Estado)

GO



/// Procedimiento para editar venta

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



/// Procedimiento para eliminar venta

CREATE PROC EliminarVenta

	@IdVenta INT

AS

	DELETE FROM Ventas WHERE IdVenta = @IdVenta

GO



---===========================================================================

--- TABLA VENTA DETALLE

---===========================================================================



/// Tabla VentaDetalle

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



/// Procedimiento para mostrar detalle de venta

CREATE PROC MostrarVentaDetalle

	@IdVenta INT

AS

	SELECT * FROM VentaDetalle WHERE IdVenta = @IdVenta

GO



/// Procedimiento para insertar detalle de venta

CREATE PROC InsertarVentaDetalle

	@IdVenta INT,

	@IdProducto INT,

	@Cantidad INT,

	@PrecioUnitario DECIMAL(10, 2)

AS

	INSERT INTO VentaDetalle (IdVenta, IdProducto, Cantidad, PrecioUnitario)

	VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario)

GO



/// Procedimiento para eliminar detalle de venta

CREATE PROC EliminarVentaDetalle

	@IdVentaDetalle INT

AS

	DELETE FROM VentaDetalle WHERE IdVentaDetalle = @IdVentaDetalle

GO



---===========================================================================

--- TABLA AUDITORIA

---===========================================================================



/// Tabla Auditoria

CREATE TABLE Auditoria

(

	AuditoriaID INT IDENTITY(1,1) NOT NULL,

	IdUsuario   INT NOT NULL,

	Accion      VARCHAR(50),

	Fecha       DATETIME DEFAULT GETDATE(),

	PRIMARY KEY CLUSTERED (AuditoriaID ASC)

)

GO



/// Procedimiento para insertar auditoria

CREATE PROC InsertarAuditoria

	@IdUsuario INT,

	@Accion VARCHAR(50)

AS

	INSERT INTO Auditoria (IdUsuario, Accion)

	VALUES (@IdUsuario, @Accion)

GO



/// Procedimiento para mostrar auditoria

CREATE PROC MostrarAuditoria

AS

	SELECT * FROM Auditoria

GO



---===========================================================================

--- FOREIGN KEYS

---===========================================================================



/// FK: VentaDetalle → Productos

ALTER TABLE VentaDetalle  

	WITH CHECK ADD CONSTRAINT FK_VentaDetalle_Producto 

	FOREIGN KEY(IdProducto) REFERENCES Productos(IdProducto)

GO

ALTER TABLE VentaDetalle CHECK CONSTRAINT FK_VentaDetalle_Producto

GO



/// FK: VentaDetalle → Ventas

ALTER TABLE VentaDetalle  

	WITH CHECK ADD CONSTRAINT FK_VentaDetalle_Venta 

	FOREIGN KEY(IdVenta) REFERENCES Ventas(IdVenta)

GO

ALTER TABLE VentaDetalle CHECK CONSTRAINT FK_VentaDetalle_Venta

GO



/// FK: Ventas → Clientes

ALTER TABLE Ventas  

	WITH CHECK ADD CONSTRAINT FK_Venta_Cliente 

	FOREIGN KEY(IdCliente) REFERENCES Clientes(IdCliente)

GO

ALTER TABLE Ventas CHECK CONSTRAINT FK_Venta_Cliente

GO



/// FK: Auditoria → Usuarios

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

--- CONSULTAS DE VERIFICACIÓN

---===========================================================================



SELECT * FROM Usuarios

GO



exec MostrarAuditoria





en base a este query necesito que verifiques todos los metodo de la capa datos y me digas cuales son los procedimientos que debo crear en sql para ponerlos en la capa datos de Visual 
