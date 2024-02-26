use master
Create DATABASE ATodoRueda
go
USE ATodoRueda
GO
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(255),
    Apellido NVARCHAR(255),
    Contrasena NVARCHAR(255),
    CorreoElectronico NVARCHAR(255) UNIQUE,
    Telefono NVARCHAR(50),
    Direccion NVARCHAR(255),
    FechaNacimiento DATE,
    FechaRegistro DATETIME,
    Rol INT,    
    Estado BIT,
    NumeroDocumento INT UNIQUE
);
GO
CREATE TABLE Vehiculos (
    Id INT PRIMARY KEY IDENTITY,
    Placa NVARCHAR(50) UNIQUE,
    Marca NVARCHAR(100),
    Modelo NVARCHAR(100),
    Color NVARCHAR(50),
    Tipo NVARCHAR(50),
    Estado BIT,
    Descripcion TEXT,
    Imagen NVARCHAR(255),
    IdUsuario INT,
    Anio INT,
    PrecioPorDia DECIMAL(10, 2),
    FechaReservaInicio DATETIME,
    FechaReservaFin DATETIME,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
);
GO
CREATE TABLE Reservas (
    Id INT PRIMARY KEY IDENTITY,
    VehiculoId INT,
    UsuarioId INT,
    FechaReserva DATETIME,
    FechaInicio DATETIME,
    FechaFin DATETIME,
    PrecioTotal DECIMAL(10, 2),
    Pagado BIT,
    Estado BIT,
    FOREIGN KEY (VehiculoId) REFERENCES Vehiculos(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO
CREATE TABLE Pagos (
    Id INT PRIMARY KEY IDENTITY,
    ReservaId INT,
    FechaPago DATETIME,
    Monto DECIMAL(10, 2),
    MetodoPago NVARCHAR(50),
    Estado BIT,
    FOREIGN KEY (ReservaId) REFERENCES Reservas(Id)
);
