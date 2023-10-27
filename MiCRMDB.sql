
CREATE DATABASE CRMDB;

use CRMDB
CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Direccion VARCHAR(255),
    Contacto VARCHAR(255)
);

go
CREATE TABLE Proveedores (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Direccion VARCHAR(255),
    Contacto VARCHAR(255)
);

go
CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Descripcion TEXT,
    PrecioCompra DECIMAL(10, 2),
    PrecioVenta DECIMAL(10, 2),
    PorcentajeGanancia DECIMAL(5, 2),
    StockActual INT,
    StockMinimo INT
);

go
CREATE TABLE Compras (
    CompraID INT IDENTITY(1,1) PRIMARY KEY,
    ProveedorID INT,
    FechaCompra DATE,
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
);

go
CREATE TABLE DetallesCompra (
    DetalleCompraID INT IDENTITY(1,1) PRIMARY KEY,
    CompraID INT,
    ProductoID INT,
    Cantidad INT,
    PrecioCompra DECIMAL(10, 2),
    FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

go
CREATE TABLE Ventas (
    VentaID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT,
    FechaVenta DATE,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

go
CREATE TABLE DetallesVenta (
    DetalleVentaID INT IDENTITY(1,1) PRIMARY KEY,
    VentaID INT,
    ProductoID INT,
    Cantidad INT,
    PrecioVenta DECIMAL(10, 2),
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

go
CREATE TABLE Facturas (
    FacturaID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura VARCHAR(255) UNIQUE,
    FechaEmision DATE,
    VentaID INT,
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID)
);

go
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(255) UNIQUE,
    Contraseña VARCHAR(255),
    Rol VARCHAR(255)
);


CREATE TABLE Marcas (
    MarcaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255)
);


CREATE TABLE Categorias (
    CategoriaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255)
);

ALTER TABLE Productos
ADD MarcaID INT,
    CategoriaID INT;


ALTER TABLE Productos
ADD CONSTRAINT FK_Marca
    FOREIGN KEY (MarcaID)
    REFERENCES Marcas(MarcaID);

ALTER TABLE Productos
ADD CONSTRAINT FK_Categoria
    FOREIGN KEY (CategoriaID)
    REFERENCES Categorias(CategoriaID);
