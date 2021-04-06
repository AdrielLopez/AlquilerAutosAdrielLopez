USE [master]
GO
/****** Object:  Database [AlquilerAutosAdrielLopez]    Script Date: 24/03/2021 15:02:48 ******/
CREATE DATABASE [AlquilerAutosAdrielLopez]
 CONTAINMENT = NONE

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
/****** Object:  Table [dbo].[Autos]    Script Date: 24/03/2021 15:02:48 ******/
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
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[AutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[Combustibles]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[Empleados]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[Localidades]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[Marcas]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[Provincias]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[TiposDeDocumentos]    Script Date: 24/03/2021 15:02:48 ******/
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
/****** Object:  Table [dbo].[TiposDeVehiculos]    Script Date: 24/03/2021 15:02:48 ******/
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
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1, N'Lobos', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (2, N'Alta Gracia', 2)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2, N'Cordoba')
SET IDENTITY_INSERT [dbo].[Provincias] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreCombustible]    Script Date: 24/03/2021 15:02:48 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreCombustible] ON [dbo].[Combustibles]
(
	[NombreCombustible] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreLocalidad]    Script Date: 24/03/2021 15:02:48 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreLocalidad] ON [dbo].[Localidades]
(
	[NombreLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreMarca]    Script Date: 24/03/2021 15:02:48 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreMarca] ON [dbo].[Marcas]
(
	[NombreMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_NombreProvincia]    Script Date: 24/03/2021 15:02:48 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NombreProvincia] ON [dbo].[Provincias]
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_TipoDocumentoDesc]    Script Date: 24/03/2021 15:02:48 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_TipoDocumentoDesc] ON [dbo].[TiposDeDocumentos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_TipoVehiculoDesc]    Script Date: 24/03/2021 15:02:48 ******/
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
