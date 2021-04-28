USE [master]
GO
/****** Object:  Database [AlquilerAutosAdrielLopez]    Script Date: 27/04/2021 23:28:45 ******/
CREATE DATABASE [AlquilerAutosAdrielLopez]
 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AlquilerAutosAdrielLopez].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET ARITHABORT OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET RECOVERY FULL 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET  MULTI_USER 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AlquilerAutosAdrielLopez', N'ON'
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET QUERY_STORE = OFF
GO
USE [AlquilerAutosAdrielLopez]
GO
/****** Object:  Table [dbo].[Alquileres]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquileres](
	[AlquilerId] [int] IDENTITY(1,1) NOT NULL,
	[AutoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaLimite] [datetime] NOT NULL,
	[Precio] [int] NOT NULL,
 CONSTRAINT [PK_Alquileres] PRIMARY KEY CLUSTERED 
(
	[AlquilerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autos]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[AutoId] [int] IDENTITY(1,1) NOT NULL,
	[MarcaId] [int] NOT NULL,
	[TipoDeVehiculoId] [int] NOT NULL,
	[Modelo] [nvarchar](20) NOT NULL,
	[CombustibleId] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDeDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Combustibles]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combustibles](
	[CombustibleId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCombustible] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Combustibles] PRIMARY KEY CLUSTERED 
(
	[CombustibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devoluciones]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devoluciones](
	[DevolucionId] [int] IDENTITY(1,1) NOT NULL,
	[AlquilerId] [int] NOT NULL,
	[FechaDevolucion] [datetime] NOT NULL,
 CONSTRAINT [PK_Devoluciones] PRIMARY KEY CLUSTERED 
(
	[DevolucionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDeDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [nvarchar](100) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreMarca] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeDocumentos]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeDocumentos](
	[TipoDeDocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDeDocumentos] PRIMARY KEY CLUSTERED 
(
	[TipoDeDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeVehiculos]    Script Date: 27/04/2021 23:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeVehiculos](
	[TipoDeVehiculoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDeVehiculos] PRIMARY KEY CLUSTERED 
(
	[TipoDeVehiculoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alquileres] ON 
GO
INSERT [dbo].[Alquileres] ([AlquilerId], [AutoId], [ClienteId], [EmpleadoId], [Fecha], [FechaLimite], [Precio]) VALUES (11, 13, 4, 7, CAST(N'2021-04-27T22:54:45.203' AS DateTime), CAST(N'2021-05-05T22:54:19.000' AS DateTime), 21000)
GO
INSERT [dbo].[Alquileres] ([AlquilerId], [AutoId], [ClienteId], [EmpleadoId], [Fecha], [FechaLimite], [Precio]) VALUES (12, 14, 5, 8, CAST(N'2021-04-27T22:55:00.833' AS DateTime), CAST(N'2021-06-10T22:54:49.000' AS DateTime), 322500)
GO
INSERT [dbo].[Alquileres] ([AlquilerId], [AutoId], [ClienteId], [EmpleadoId], [Fecha], [FechaLimite], [Precio]) VALUES (13, 15, 6, 7, CAST(N'2021-04-27T22:55:35.140' AS DateTime), CAST(N'2021-04-29T22:55:18.000' AS DateTime), 2500)
GO
INSERT [dbo].[Alquileres] ([AlquilerId], [AutoId], [ClienteId], [EmpleadoId], [Fecha], [FechaLimite], [Precio]) VALUES (14, 17, 6, 7, CAST(N'2021-04-27T22:56:15.250' AS DateTime), CAST(N'2021-05-21T22:56:00.000' AS DateTime), 104190)
GO
SET IDENTITY_INSERT [dbo].[Alquileres] OFF
GO
SET IDENTITY_INSERT [dbo].[Autos] ON 
GO
INSERT [dbo].[Autos] ([AutoId], [MarcaId], [TipoDeVehiculoId], [Modelo], [CombustibleId], [Activo], [Stock], [Precio]) VALUES (12, 1011, 1006, N'TT', 1005, 0, 6, CAST(7000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Autos] ([AutoId], [MarcaId], [TipoDeVehiculoId], [Modelo], [CombustibleId], [Activo], [Stock], [Precio]) VALUES (13, 1005, 1006, N'Focus', 1004, 0, 2, CAST(3000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Autos] ([AutoId], [MarcaId], [TipoDeVehiculoId], [Modelo], [CombustibleId], [Activo], [Stock], [Precio]) VALUES (14, 1009, 1006, N'X5', 1006, 0, 4, CAST(7500.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Autos] ([AutoId], [MarcaId], [TipoDeVehiculoId], [Modelo], [CombustibleId], [Activo], [Stock], [Precio]) VALUES (15, 1005, 1006, N'Fiesta', 1006, 0, 21, CAST(2500.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Autos] ([AutoId], [MarcaId], [TipoDeVehiculoId], [Modelo], [CombustibleId], [Activo], [Stock], [Precio]) VALUES (16, 1010, 1007, N'W201', 1004, 0, 3, CAST(8000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Autos] ([AutoId], [MarcaId], [TipoDeVehiculoId], [Modelo], [CombustibleId], [Activo], [Stock], [Precio]) VALUES (17, 1006, 1006, N'Sentra', 1004, 0, 4, CAST(4530.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Autos] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (4, N'Lionel', N'Messi', 1006, N'18093829', N'Avenida 32', 1014, 2006, NULL, NULL, NULL)
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (5, N'Juan Martin', N'Del Potro', 1007, N'28937982', N'Las Heras 392', 1005, 2004, NULL, NULL, NULL)
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (6, N'Gustav', N'Ahr', 1008, N'213212342', N'Buenos Aires 398', 1006, 2004, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Combustibles] ON 
GO
INSERT [dbo].[Combustibles] ([CombustibleId], [NombreCombustible]) VALUES (1005, N'Diesel')
GO
INSERT [dbo].[Combustibles] ([CombustibleId], [NombreCombustible]) VALUES (1006, N'Gasoil')
GO
INSERT [dbo].[Combustibles] ([CombustibleId], [NombreCombustible]) VALUES (1004, N'GNC')
GO
INSERT [dbo].[Combustibles] ([CombustibleId], [NombreCombustible]) VALUES (1007, N'Nafta')
GO
SET IDENTITY_INSERT [dbo].[Combustibles] OFF
GO
SET IDENTITY_INSERT [dbo].[Devoluciones] ON 
GO
INSERT [dbo].[Devoluciones] ([DevolucionId], [AlquilerId], [FechaDevolucion]) VALUES (7, 13, CAST(N'2021-04-27T22:56:28.260' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Devoluciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 
GO
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (7, N'Adriel', N'Lopez', 1006, N'42323371', N'Las Heras 149', 1005, 2004, NULL, N'22227441884', N'adrielisaias1@gmail.com')
GO
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (8, N'Marcelo', N'Gallardo', 1007, N'123235461', N'Junin 323', 1010, 2005, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Localidades] ON 
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1005, N'Lobos', 2004)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1006, N'Navarro', 2004)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1007, N'Roque Perez', 2004)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1009, N'Alta Gracia', 2005)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1010, N'Cordoba', 2005)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1011, N'Sacanta', 2005)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1012, N'Clorinda', 2011)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1013, N'Formosa', 2011)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1014, N'Rosario', 2006)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1015, N'Acebal', 2006)
GO
SET IDENTITY_INSERT [dbo].[Localidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 
GO
INSERT [dbo].[Marcas] ([MarcaId], [NombreMarca]) VALUES (1011, N'Audi')
GO
INSERT [dbo].[Marcas] ([MarcaId], [NombreMarca]) VALUES (1009, N'BMW')
GO
INSERT [dbo].[Marcas] ([MarcaId], [NombreMarca]) VALUES (1005, N'Ford')
GO
INSERT [dbo].[Marcas] ([MarcaId], [NombreMarca]) VALUES (1010, N'Mercedes Benz')
GO
INSERT [dbo].[Marcas] ([MarcaId], [NombreMarca]) VALUES (1006, N'Nissan')
GO
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
SET IDENTITY_INSERT [dbo].[Provincias] ON 
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2004, N'Buenos Aires')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2005, N'Cordoba')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2011, N'Formosa')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2006, N'Santa Fe')
GO
SET IDENTITY_INSERT [dbo].[Provincias] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeDocumentos] ON 
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (1007, N'Cedula de Identidad')
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (1006, N'DNI')
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (1009, N'Libreta Civica')
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (1008, N'Pasaporte')
GO
SET IDENTITY_INSERT [dbo].[TiposDeDocumentos] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeVehiculos] ON 
GO
INSERT [dbo].[TiposDeVehiculos] ([TipoDeVehiculoId], [Descripcion]) VALUES (1008, N'Auto 3 puertas')
GO
INSERT [dbo].[TiposDeVehiculos] ([TipoDeVehiculoId], [Descripcion]) VALUES (1006, N'Auto 5 puertas')
GO
INSERT [dbo].[TiposDeVehiculos] ([TipoDeVehiculoId], [Descripcion]) VALUES (1005, N'Camioneta 4X2')
GO
INSERT [dbo].[TiposDeVehiculos] ([TipoDeVehiculoId], [Descripcion]) VALUES (1004, N'Camioneta 4X4')
GO
INSERT [dbo].[TiposDeVehiculos] ([TipoDeVehiculoId], [Descripcion]) VALUES (1007, N'SUV')
GO
SET IDENTITY_INSERT [dbo].[TiposDeVehiculos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreCombustible]    Script Date: 27/04/2021 23:28:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreCombustible] ON [dbo].[Combustibles]
(
	[NombreCombustible] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreLocalidad]    Script Date: 27/04/2021 23:28:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreLocalidad] ON [dbo].[Localidades]
(
	[NombreLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreMarca]    Script Date: 27/04/2021 23:28:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreMarca] ON [dbo].[Marcas]
(
	[NombreMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreProvincia]    Script Date: 27/04/2021 23:28:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreProvincia] ON [dbo].[Provincias]
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_TipoDocumentoDesc]    Script Date: 27/04/2021 23:28:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_TipoDocumentoDesc] ON [dbo].[TiposDeDocumentos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_TipoVehiculoDesc]    Script Date: 27/04/2021 23:28:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_TipoVehiculoDesc] ON [dbo].[TiposDeVehiculos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Autos] ADD  CONSTRAINT [DF_Autos_Modelo]  DEFAULT ('') FOR [Modelo]
GO
ALTER TABLE [dbo].[Autos] ADD  CONSTRAINT [DF_Autos_Activo]  DEFAULT ('true') FOR [Activo]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Nombre]  DEFAULT ('') FOR [Nombre]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Apellido]  DEFAULT ('') FOR [Apellido]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_NroDocumento]  DEFAULT ('') FOR [NroDocumento]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Direccion]  DEFAULT ('') FOR [Direccion]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_TelefonoFijo]  DEFAULT ('') FOR [TelefonoFijo]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_TelefonoMovil]  DEFAULT ('') FOR [TelefonoMovil]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_CorreoElectronico]  DEFAULT ('') FOR [CorreoElectronico]
GO
ALTER TABLE [dbo].[Combustibles] ADD  CONSTRAINT [DF_Combustibles_NombreCombustible]  DEFAULT ('') FOR [NombreCombustible]
GO
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [DF_Empleados_Nombre]  DEFAULT ('') FOR [Nombre]
GO
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [DF_Empleados_Apellido]  DEFAULT ('') FOR [Apellido]
GO
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [DF_Empleados_NroDocumento]  DEFAULT ('') FOR [NroDocumento]
GO
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [DF_Empleados_Direccion]  DEFAULT ('') FOR [Direccion]
GO
ALTER TABLE [dbo].[Localidades] ADD  CONSTRAINT [DF_Localidades_NombreLocalidad]  DEFAULT ('') FOR [NombreLocalidad]
GO
ALTER TABLE [dbo].[Marcas] ADD  CONSTRAINT [DF_Marcas_NombreMarca]  DEFAULT ('') FOR [NombreMarca]
GO
ALTER TABLE [dbo].[Provincias] ADD  CONSTRAINT [DF_Provincias_NombreProvicia]  DEFAULT ('') FOR [NombreProvincia]
GO
ALTER TABLE [dbo].[TiposDeDocumentos] ADD  CONSTRAINT [DF_TiposDeDocumentos_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO
ALTER TABLE [dbo].[TiposDeVehiculos] ADD  CONSTRAINT [DF_TiposDeVehiculos_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Autos] FOREIGN KEY([AutoId])
REFERENCES [dbo].[Autos] ([AutoId])
GO
ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Autos]
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Clientes]
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Empleados] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleados] ([EmpleadoId])
GO
ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Empleados]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Combustibles] FOREIGN KEY([CombustibleId])
REFERENCES [dbo].[Combustibles] ([CombustibleId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Combustibles]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Marcas] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marcas] ([MarcaId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Marcas]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_TiposDeVehiculos] FOREIGN KEY([TipoDeVehiculoId])
REFERENCES [dbo].[TiposDeVehiculos] ([TipoDeVehiculoId])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_TiposDeVehiculos]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Localidades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDeDocumentos] FOREIGN KEY([TipoDeDocumentoId])
REFERENCES [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDeDocumentos]
GO
ALTER TABLE [dbo].[Devoluciones]  WITH CHECK ADD  CONSTRAINT [FK_Devoluciones_Alquileres] FOREIGN KEY([AlquilerId])
REFERENCES [dbo].[Alquileres] ([AlquilerId])
GO
ALTER TABLE [dbo].[Devoluciones] CHECK CONSTRAINT [FK_Devoluciones_Alquileres]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Localidades]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_TiposDeDocumentos] FOREIGN KEY([TipoDeDocumentoId])
REFERENCES [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_TiposDeDocumentos]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
USE [master]
GO
ALTER DATABASE [AlquilerAutosAdrielLopez] SET  READ_WRITE 
GO
