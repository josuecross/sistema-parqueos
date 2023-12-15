USE [master]
GO
/****** Object:  Database [API_Proyecto3.Data]    Script Date: 29/11/2023 22:39:26 ******/
CREATE DATABASE [API_Proyecto3.Data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'API_Proyecto3.Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\API_Proyecto3.Data.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'API_Proyecto3.Data_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\API_Proyecto3.Data_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [API_Proyecto3.Data] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [API_Proyecto3.Data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [API_Proyecto3.Data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET ARITHABORT OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [API_Proyecto3.Data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [API_Proyecto3.Data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [API_Proyecto3.Data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET  ENABLE_BROKER 
GO
ALTER DATABASE [API_Proyecto3.Data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [API_Proyecto3.Data] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [API_Proyecto3.Data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [API_Proyecto3.Data] SET  MULTI_USER 
GO
ALTER DATABASE [API_Proyecto3.Data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [API_Proyecto3.Data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [API_Proyecto3.Data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [API_Proyecto3.Data] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [API_Proyecto3.Data] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [API_Proyecto3.Data] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [API_Proyecto3.Data] SET QUERY_STORE = OFF
GO
USE [API_Proyecto3.Data]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/11/2023 22:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 29/11/2023 22:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Ingreso] [datetime2](7) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime2](7) NULL,
	[NumCedula] [nvarchar](10) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Telefono] [nvarchar](10) NULL,
	[PersonaContacto] [nvarchar](50) NULL,
	[ParqueoId] [int] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parqueo]    Script Date: 29/11/2023 22:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parqueo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[MaxVehiculos] [int] NOT NULL,
	[HoraApertura] [datetime2](7) NOT NULL,
	[HoraCierre] [datetime2](7) NOT NULL,
	[TotalVendido] [int] NOT NULL,
	[TarifaHora] [int] NOT NULL,
	[TarifaMediaHora] [int] NOT NULL,
 CONSTRAINT [PK_Parqueo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiquete]    Script Date: 29/11/2023 22:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiquete](
	[TiqueteId] [int] IDENTITY(1,1) NOT NULL,
	[Ingreso] [datetime2](7) NOT NULL,
	[Salida] [datetime2](7) NULL,
	[Placa] [nvarchar](15) NOT NULL,
	[EnUso] [bit] NOT NULL,
	[Monto_Pagado] [int] NULL,
	[ParqueoId] [int] NOT NULL,
	[TarifaHora] [int] NULL,
	[TarifaMediaHora] [int] NULL,
 CONSTRAINT [PK_Tiquete] PRIMARY KEY CLUSTERED 
(
	[TiqueteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231122051856_Migraton', N'6.0.23')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231122052323_Initial', N'6.0.23')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231123233627_APIDB-v2', N'6.0.23')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231124030719_APIDB-v3', N'6.0.23')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231124032348_APIDB-v4', N'6.0.23')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231125040231_APIDB-v5', N'6.0.23')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231129065229_InitialSchoolDB', N'6.0.23')
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 
GO
INSERT [dbo].[Empleado] ([EmpleadoId], [Ingreso], [Nombre], [Apellidos], [FechaNacimiento], [NumCedula], [Direccion], [Email], [Telefono], [PersonaContacto], [ParqueoId]) VALUES (1, CAST(N'2023-11-01T00:00:00.0000000' AS DateTime2), N'Antonios', N'Fernandezes', CAST(N'2006-07-01T00:00:00.0000000' AS DateTime2), N'111111j', N'200m despues de Cd. Perez, ', N'aaaaaaa@gmail.com', N'111111111', N'Alcidezes', 11)
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Parqueo] ON 
GO
INSERT [dbo].[Parqueo] ([Id], [Nombre], [MaxVehiculos], [HoraApertura], [HoraCierre], [TotalVendido], [TarifaHora], [TarifaMediaHora]) VALUES (10, N'Parqueo Para Pruebas', 1, CAST(N'2023-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-29T23:59:00.0000000' AS DateTime2), 30000, 1000, 500)
GO
INSERT [dbo].[Parqueo] ([Id], [Nombre], [MaxVehiculos], [HoraApertura], [HoraCierre], [TotalVendido], [TarifaHora], [TarifaMediaHora]) VALUES (11, N'Palmares centro', 1, CAST(N'2023-11-29T05:00:00.0000000' AS DateTime2), CAST(N'2023-11-29T20:00:00.0000000' AS DateTime2), 64000, 2000, 1000)
GO
INSERT [dbo].[Parqueo] ([Id], [Nombre], [MaxVehiculos], [HoraApertura], [HoraCierre], [TotalVendido], [TarifaHora], [TarifaMediaHora]) VALUES (12, N'Alajuela centro', 2, CAST(N'2023-11-29T12:00:00.0000000' AS DateTime2), CAST(N'2023-11-29T14:00:00.0000000' AS DateTime2), 85000, 5000, 2500)
GO
SET IDENTITY_INSERT [dbo].[Parqueo] OFF
GO
SET IDENTITY_INSERT [dbo].[Tiquete] ON 
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (48, CAST(N'2023-11-28T19:11:00.0000000' AS DateTime2), CAST(N'2023-11-28T22:11:40.5250000' AS DateTime2), N'23432', 0, 3000, 10, 1000, 500)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (49, CAST(N'2023-11-29T11:05:00.0000000' AS DateTime2), CAST(N'2023-11-29T19:20:57.9310000' AS DateTime2), N'jfsl', 0, 8000, 10, 1000, 500)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (50, CAST(N'2023-11-21T10:07:00.0000000' AS DateTime2), CAST(N'2023-11-21T19:20:56.4290000' AS DateTime2), N'24ds', 0, 18000, 11, 2000, 1000)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (51, CAST(N'2023-11-28T12:00:00.0000000' AS DateTime2), CAST(N'2023-11-28T19:20:54.2440000' AS DateTime2), N'd234', 0, 35000, 12, 5000, 2500)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (52, CAST(N'2023-06-15T15:09:00.0000000' AS DateTime2), CAST(N'2023-06-15T19:10:14.1700000' AS DateTime2), N'TiqueteJunio1', 0, 4000, 10, 1000, 500)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (53, CAST(N'2023-06-18T12:18:00.0000000' AS DateTime2), CAST(N'2023-06-18T19:19:11.6650000' AS DateTime2), N'TiqueteJunio2', 0, 14000, 11, 2000, 1000)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (54, CAST(N'2023-11-29T13:27:00.0000000' AS DateTime2), CAST(N'2023-11-29T21:28:34.6611736' AS DateTime2), N'TiqueteAgosto', 0, 40000, 12, 5000, 2500)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (55, CAST(N'2023-08-15T12:29:00.0000000' AS DateTime2), CAST(N'2023-08-15T14:35:51.1820000' AS DateTime2), N'TiqueteAgosto2', 0, 10000, 12, 5000, 2500)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (56, CAST(N'2023-09-29T06:00:00.0000000' AS DateTime2), CAST(N'2023-09-29T21:41:00.0000000' AS DateTime2), N'TiqueteSetiembr', 0, 32000, 11, 2000, 1000)
GO
INSERT [dbo].[Tiquete] ([TiqueteId], [Ingreso], [Salida], [Placa], [EnUso], [Monto_Pagado], [ParqueoId], [TarifaHora], [TarifaMediaHora]) VALUES (57, CAST(N'2023-11-29T06:46:00.0000000' AS DateTime2), CAST(N'2023-11-29T21:46:44.7051916' AS DateTime2), N'jkfskjweir', 0, 15000, 10, 1000, 500)
GO
SET IDENTITY_INSERT [dbo].[Tiquete] OFF
GO
/****** Object:  Index [IX_Empleado_ParqueoId]    Script Date: 29/11/2023 22:39:27 ******/
CREATE NONCLUSTERED INDEX [IX_Empleado_ParqueoId] ON [dbo].[Empleado]
(
	[ParqueoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tiquete_ParqueoId]    Script Date: 29/11/2023 22:39:27 ******/
CREATE NONCLUSTERED INDEX [IX_Tiquete_ParqueoId] ON [dbo].[Tiquete]
(
	[ParqueoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Parqueo] ADD  DEFAULT ((0)) FOR [TarifaHora]
GO
ALTER TABLE [dbo].[Parqueo] ADD  DEFAULT ((0)) FOR [TarifaMediaHora]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Parqueo_ParqueoId] FOREIGN KEY([ParqueoId])
REFERENCES [dbo].[Parqueo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Parqueo_ParqueoId]
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Parqueo_ParqueoId] FOREIGN KEY([ParqueoId])
REFERENCES [dbo].[Parqueo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Parqueo_ParqueoId]
GO
USE [master]
GO
ALTER DATABASE [API_Proyecto3.Data] SET  READ_WRITE 
GO
