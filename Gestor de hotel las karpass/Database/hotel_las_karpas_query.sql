-- Creación de base de datos --

CREATE DATABASE hotel

-- Creación de tablas (sin llaves foraneas)

CREATE TABLE hotel.dbo.Habitaciones (
	numeroHabitacion INT NOT NULL PRIMARY KEY,
	estadoOcupado BIT DEFAULT 0,
	idTipoHabitacion INT NOT NULL
	);

CREATE TABLE hotel.dbo.TiposHabitacion (
	idTipoHabitacion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombreTipo VARCHAR(63),
	capacidadMax INT,
	Precio DECIMAL(10, 2)
	);
	
CREATE TABLE hotel.dbo.Roles (
	idRol INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombreRol VARCHAR(255),
	permisoUsuarios INT NOT NULL DEFAULT 0,
	permisoClientes INT NOT NULL DEFAULT 0,
	permisoReservas INT NOT NULL DEFAULT 0,
	permisoCancelaciones INT NOT NULL DEFAULT 0,
	permisoReporteria INT NOT NULL DEFAULT 0
	);

CREATE TABLE hotel.dbo.Empleados (
	idEmpleado INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(127),
	primerApellido VARCHAR(127),
	segundoApellido VARCHAR(127),
	direccion VARCHAR(511),
	fechaNacimiento DATE,
	idRol INT NOT NULL,
	genero VARCHAR(31),
	telefono DECIMAL(15),
	correo VARCHAR(320),
	contrasena VARCHAR(255),
	ultimaModificacion DATETIME DEFAULT CURRENT_TIMESTAMP,
	fechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
	);

CREATE TABLE hotel.dbo.Clientes (
	identificacionCliente INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(127),
	primerApellido VARCHAR(127),
	segundoApellido VARCHAR(127),
	paisProcedencia VARCHAR(127),
	direccion VARCHAR(511),
	fechaNacimiento DATE,
	telefono DECIMAL(15),
	correo VARCHAR(320)
	);

CREATE TABLE hotel.dbo.Reservas (
	numeroReserva INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	identificacionCliente INT NOT NULL,
	inicioReserva DATE,
	finReserva DATE,
	cantPersonas INT,
	fechaCancelacion DATE,
	costoTotal DECIMAL(10,2),
	idEmpleado INT NOT NULL,
	cancelacionPendiente BIT DEFAULT 0,
	);

CREATE TABLE hotel.dbo.Reservashabitacion (
	numeroReservaHabitacion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	numeroHabitacion INT NOT NULL,
	numeroReserva INT NOT NULL,
	costoHabitacion DECIMAL(10,2)
	);

-- Creacion de llaves Foraneas --

ALTER TABLE hotel.dbo.Reservas
ADD CONSTRAINT FK_Clientes FOREIGN KEY (identificacionCliente) REFERENCES Clientes(identificacionCliente);

ALTER TABLE hotel.dbo.Reservas
ADD CONSTRAINT FK_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado);

ALTER TABLE hotel.dbo.ReservasHabitacion
ADD CONSTRAINT FK_Reservas FOREIGN KEY (numeroReserva) REFERENCES Reservas(numeroReserva);

ALTER TABLE hotel.dbo.ReservasHabitacion
ADD CONSTRAINT FK_Habitaciones FOREIGN KEY (numeroHabitacion) REFERENCES Habitaciones(numeroHabitacion);

ALTER TABLE hotel.dbo.Habitaciones
ADD CONSTRAINT FK_TiposHabitacion FOREIGN KEY (idTipoHabitacion) REFERENCES TiposHabitacion(idTipoHabitacion);

ALTER TABLE hotel.dbo.Empleados
ADD CONSTRAINT FK_Roles FOREIGN KEY (idRol) REFERENCES Roles(idRol);

-- Valores / Regsitros base necesarios --

INSERT INTO hotel.dbo.TiposHabitacion (nombreTipo, capacidadMax, Precio)
	VALUES
	('premium', 2, 160),
	('familiar', 4, 200),
	('pareja', 2, 120),
	('villa', 8, 300)

INSERT INTO hotel.dbo.Roles
	(nombreRol, permisoCancelaciones, permisoUsuarios, permisoClientes, permisoReporteria, permisoReservas)
	VALUES
	('administrador', 1, 1, 1, 1, 1),
	('recepcionista', 0, 0, 1, 2, 1),
	('control de plataforma', 0, 0, 2, 2, 2)

INSERT INTO hotel.dbo.Empleados
	(nombre, primerApellido, segundoApellido, fechaNacimiento, idRol, telefono, correo, contrasena, genero, direccion)
	VALUES
	('Administrador', 'Num', '1', '2000-01-01', 1, 50688888888, 'admin@gmail.com', 1234, 'masculino', 'Limón, Limón, Limón')

INSERT INTO hotel.dbo.Habitaciones
	(numeroHabitacion, idTipoHabitacion)
	VALUES
	(1, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 2),
	(6, 2),
	(7, 2),
	(8, 2),
	(9, 2),
	(10, 2),
	(11, 3),
	(12, 3),
	(13, 3),
	(14, 3),
	(15, 3),
	(16, 3),
	(17, 4),
	(18, 4),
	(19, 4),
	(20, 4)

-- Ejemplos para tablas --

INSERT INTO hotel.dbo.Clientes (nombre, primerApellido, segundoApellido, paisProcedencia, direccion, fechaNacimiento, telefono, correo)
VALUES 
  ('Juan', 'Martinez', 'Gomez', 'España', 'Calle Mayor 123', '1990-05-15', 34678901234, 'juan.martinez@example.com'),
  ('Maria', 'Garcia', 'Lopez', 'México', 'Avenida Reforma 456', '1985-10-20', 5255555555, 'maria.garcia@example.com'),
  ('Luis', 'Rodriguez', 'Hernandez', 'Colombia', 'Carrera 7 89-10', '1982-03-12', 573123456789, 'luis.rodriguez@example.com'),
  ('Ana', 'Perez', 'Gutierrez', 'Argentina', 'Avenida Corrientes 789', '1995-08-28', 5491123456789, 'ana.perez@example.com'),
  ('Carlos', 'Lopez', 'Diaz', 'Chile', 'Calle Santiago 321', '1978-12-03', 56987654321, 'carlos.lopez@example.com');

SELECT identificacionCliente, nombre + ' ' + primerApellido AS nombreCompleto FROM Clientes ORDER BY nombreCompleto ASC