USE [API_Proyecto3.Data]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/11/2023 13:47:07 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 27/11/2023 13:47:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Ingreso] [datetime2](7) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellidos] [nvarchar](max) NOT NULL,
	[FechaNacimiento] [datetime2](7) NULL,
	[NumCedula] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[PersonaContacto] [nvarchar](max) NULL,
	[ParqueoId] [int] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parqueo]    Script Date: 27/11/2023 13:47:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parqueo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiquete]    Script Date: 27/11/2023 13:47:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiquete](
	[TiqueteId] [int] IDENTITY(1,1) NOT NULL,
	[Ingreso] [datetime2](7) NOT NULL,
	[Salida] [datetime2](7) NULL,
	[Placa] [nvarchar](max) NOT NULL,
	[EnUso] [bit] NOT NULL,
	[Monto_Pagado] [int] NULL,
	[ParqueoId] [int] NOT NULL,
	[TarifaHora] [int] NULL,
	[TarifaMediaHora] [int] NULL,
 CONSTRAINT [PK_Tiquete] PRIMARY KEY CLUSTERED 
(
	[TiqueteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
