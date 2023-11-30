INSERT INTO Clientes (Nombre, Direccion, Contacto, DNI, Email)
VALUES
    ('Cliente1', 'Dirección1', 'Contacto1',1235448,'a1@a.com'),
    ('Cliente2', 'Dirección2', 'Contacto2',1235464,'a2@a.com'),
    ('Cliente3', 'Dirección3', 'Contacto3',30231564,'a3@a.com'),
    ('Cliente4', 'Dirección4', 'Contacto4',123546,'a4@a.com'),
    ('Cliente5', 'Dirección5', 'Contacto5',215462,'a5@a.com'),
    ('Cliente6', 'Dirección6', 'Contacto6',1264564,'a6@a.com'),
    ('Cliente7', 'Dirección7', 'Contacto7',456421,'a7@a.com'),
    ('Cliente8', 'Dirección8', 'Contacto8',15646654,'a8@a.com'),
    ('Cliente9', 'Dirección9', 'Contacto9',54564646,'9a@a.com'),
    ('Cliente10', 'Dirección10', 'Contacto10',45612345,'a10@a.com');
go
INSERT INTO Productos (Nombre, Descripcion, PrecioCompra, PrecioVenta, PorcentajeGanancia, StockActual, StockMinimo, MarcaID, CategoriaID)
VALUES
    ('Laptop HP Pavilion', 'Laptop de 15 pulgadas con procesador Intel Core i5', 600.00, 800.00, 33.33, 50, 10, 1, 3),
    ('Smartphone Samsung Galaxy S21', 'Teléfono inteligente con pantalla AMOLED de 6.2 pulgadas', 700.00, 900.00, 28.57, 40, 8, 2, 1),
    ('Impresora Epson EcoTank', 'Impresora multifuncional de inyección de tinta con tanques de tinta recargables', 250.00, 350.00, 40.00, 30, 5, 3, 2);

go
INSERT INTO Marcas (Nombre)
VALUES
    ('HP'),
    ('SAMSUNG'),
    ('EPSON');

go
INSERT INTO Categorias (Nombre)
VALUES
    ('TELEFONIA'),
    ('IMPRESORAS'),
    ('ELECTRODOMESTICOS');

go



INSERT INTO Proveedores (Nombre, Direccion, Contacto, DNI, Email)
VALUES
    ('Proveedor1', 'DirecciónProveedor1', 'ContactoProveedor1', 123456789, 'proveedor1@example.com'),
    ('Proveedor2', 'DirecciónProveedor2', 'ContactoProveedor2', 987654321, 'proveedor2@example.com'),
    ('Proveedor3', 'DirecciónProveedor3', 'ContactoProveedor3', 456789123, 'proveedor3@example.com'),
    ('Proveedor4', 'DirecciónProveedor4', 'ContactoProveedor4', 654321987, 'proveedor4@example.com'),
    ('Proveedor5', 'DirecciónProveedor5', 'ContactoProveedor5', 789123456, 'proveedor5@example.com'),
    ('Proveedor6', 'DirecciónProveedor6', 'ContactoProveedor6', 321987654, 'proveedor6@example.com'),
    ('Proveedor7', 'DirecciónProveedor7', 'ContactoProveedor7', 567894321, 'proveedor7@example.com'),
    ('Proveedor8', 'DirecciónProveedor8', 'ContactoProveedor8', 543219876, 'proveedor8@example.com'),
    ('Proveedor9', 'DirecciónProveedor9', 'ContactoProveedor9', 678945321, 'proveedor9@example.com'),
    ('Proveedor10', 'DirecciónProveedor10', 'ContactoProveedor10', 987643219, 'proveedor10@example.com');

go






INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol)
VALUES
    ('admin', 'contraseñaAdmin', 'Administrador'),
    ('vendedor', 'contraseñaVendedor', 'Vendedor');
go

INSERT INTO Facturas (NumeroFactura, FechaEmision, VentaID)
VALUES
    ('FAC001', '2023-10-15', 1),  -- Asociar la factura a la venta 1
    ('FAC002', '2023-10-20', 2);  -- Asociar la factura a la venta 2

go
-- Insertar Detalles de Compra para Compra 1
INSERT INTO DetallesCompra (CompraID, ProductoID, Cantidad, PrecioCompra)
VALUES
    (1, 1, 5, 600.00),  -- Compra 1, Producto 1, 5 unidades a $600.00 cada una
    (1, 2, 10, 700.00); -- Compra 1, Producto 2, 10 unidades a $700.00 cada una

-- Insertar Detalles de Compra para Compra 2
INSERT INTO DetallesCompra (CompraID, ProductoID, Cantidad, PrecioCompra)
VALUES
    (2, 2, 15, 700.00), -- Compra 2, Producto 2, 15 unidades a $700.00 cada una
    (2, 3, 8, 250.00);  -- Compra 2, Producto 3, 8 unidades a $250.00 cada una
go

-- Insertar Detalles de Venta para Venta 1
INSERT INTO DetallesVenta (VentaID, ProductoID, Cantidad, PrecioVenta)
VALUES
    (1, 1, 3, 800.00),  -- Venta 1, Producto 1, 3 unidades a $800.00 cada una
    (1, 2, 5, 900.00);  -- Venta 1, Producto 2, 5 unidades a $900.00 cada una

-- Insertar Detalles de Venta para Venta 2
INSERT INTO DetallesVenta (VentaID, ProductoID, Cantidad, PrecioVenta)
VALUES
    (2, 2, 8, 900.00),  -- Venta 2, Producto 2, 8 unidades a $900.00 cada una
    (2, 3, 4, 350.00);  -- Venta 2, Producto 3, 4 unidades a $350.00 cada una




--
Create TRIGGER TR_modificar_Producto ON DetallesVenta
AFTER Insert
AS 
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
		DECLARE @ProductoID BIGINT
		DECLARE @cantidad INT
			
		SELECT @ProductoID = ProductoID, @cantidad = Cantidad FROM inserted
			
		UPDATE Productos 
		SET StockActual = StockActual - @cantidad 
		WHERE ProductoID = @ProductoID

			

		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END

