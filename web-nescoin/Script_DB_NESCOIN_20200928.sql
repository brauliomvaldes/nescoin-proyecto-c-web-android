USE [master]
GO
/****** Object:  Database [BD_NESCOIN]    Script Date: 28-09-2020 18:44:55 ******/
CREATE DATABASE [BD_NESCOIN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_NESCOIN', FILENAME = N'C:\BASES\BD_NESCOIN.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BD_NESCOIN_log', FILENAME = N'C:\BASES\BD_NESCOIN_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BD_NESCOIN] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_NESCOIN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_NESCOIN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_NESCOIN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_NESCOIN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_NESCOIN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_NESCOIN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_NESCOIN] SET  MULTI_USER 
GO
ALTER DATABASE [BD_NESCOIN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_NESCOIN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_NESCOIN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_NESCOIN] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BD_NESCOIN]
GO
/****** Object:  Table [dbo].[Tbl_Calificacion]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Calificacion](
	[id_calificacion] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](200) NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_Calificacion] PRIMARY KEY CLUSTERED 
(
	[id_calificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Ciudad]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Ciudad](
	[id_ciudad] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[id_pais] [numeric](18, 0) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_Ciudad] PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Comuna]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Comuna](
	[id_comuna] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[id_ciudad] [numeric](18, 0) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Comuna] PRIMARY KEY CLUSTERED 
(
	[id_comuna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Contacto]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Contacto](
	[id_contacto] [numeric](18, 0) NOT NULL,
	[id_usuario] [numeric](18, 0) NULL,
	[id_tipo_usuario] [numeric](18, 0) NULL,
	[estado] [bit] NULL,
	[id_calificacion] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Tbl_Contacto] PRIMARY KEY CLUSTERED 
(
	[id_contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Correo]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Correo](
	[id_correo] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Correo] PRIMARY KEY CLUSTERED 
(
	[id_correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Direccion]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Direccion](
	[id_direccion] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](2000) NULL,
	[numero] [varchar](255) NULL,
	[id_comuna] [numeric](18, 0) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Direccion] PRIMARY KEY CLUSTERED 
(
	[id_direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Forma_Pago]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Forma_Pago](
	[id_forma_pago] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Log]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Log](
	[id_log] [numeric](18, 0) NOT NULL,
	[fecha] [date] NULL,
	[hora] [time](7) NULL,
	[id_usuario] [numeric](18, 0) NULL,
	[id_tipo_log] [numeric](18, 0) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Log] PRIMARY KEY CLUSTERED 
(
	[id_log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_movimiento]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_movimiento](
	[id_movimiento] [numeric](18, 0) NOT NULL,
	[id_tipo_movimiento] [numeric](18, 0) NULL,
	[fecha_movimiento] [date] NULL,
	[descripcion] [varchar](255) NULL,
	[id_usuario] [numeric](18, 0) NULL,
	[id_calificacion] [numeric](18, 0) NULL,
	[comentario] [varchar](255) NULL,
	[id_forma_pago] [numeric](18, 0) NULL,
	[num_ref_movimiento] [numeric](18, 0) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_movimiento] PRIMARY KEY CLUSTERED 
(
	[id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Pais]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Pais](
	[id_pais] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Profesion]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Profesion](
	[id_profesion] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Profesion] PRIMARY KEY CLUSTERED 
(
	[id_profesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Telefono]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Telefono](
	[id_telefono] [numeric](18, 0) NOT NULL,
	[numero_telefono] [numeric](18, 0) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Telefono_1] PRIMARY KEY CLUSTERED 
(
	[id_telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Tipo_Cuenta]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Tipo_Cuenta](
	[id_tipo_cuenta] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Tipo_Cuenta] PRIMARY KEY CLUSTERED 
(
	[id_tipo_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_tipo_log]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_tipo_log](
	[id_tipo_log] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_tipo_log] PRIMARY KEY CLUSTERED 
(
	[id_tipo_log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_tipo_movimiento]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_tipo_movimiento](
	[id_tipo_movimiento] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](255) NULL,
	[descripcion] [varchar](1000) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_tipo_movimiento] PRIMARY KEY CLUSTERED 
(
	[id_tipo_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Tipo_usuario]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Tipo_usuario](
	[id_tipo_usuario] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tipo_usuario] PRIMARY KEY CLUSTERED 
(
	[id_tipo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario](
	[id_usuario] [numeric](18, 0) NOT NULL,
	[nick] [varchar](100) NULL,
	[nombre] [varchar](255) NULL,
	[apellido] [varchar](255) NULL,
	[fecha_creacion] [date] NULL,
	[fecha_actualizacion] [date] NULL,
	[contraseña] [varchar](255) NULL,
	[id_direccion] [numeric](18, 0) NOT NULL,
	[id_tipo_cuenta] [numeric](18, 0) NULL,
	[foto] [varchar](2000) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario_Correo]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario_Correo](
	[id_usuario] [numeric](18, 0) NOT NULL,
	[id_correo] [numeric](18, 0) NOT NULL,
	[principal] [bit] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Usuario_Correo] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario_Profesion]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario_Profesion](
	[id_usuario] [numeric](18, 0) NOT NULL,
	[id_profesion] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](1000) NULL,
	[promedio_calificacion] [float] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Usuario_Profesion] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_profesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario_Telefono]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario_Telefono](
	[id_usuario] [numeric](18, 0) NOT NULL,
	[id_telefono] [numeric](18, 0) NOT NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Tbl_Usuario_Telefono] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Vi_Trae_Vitrina]    Script Date: 28-09-2020 18:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Select * From Vi_Trae_Vitrina
CREATE View [dbo].[Vi_Trae_Vitrina]
As
Select a.id_usuario, a.nick, a.nombre, a.apellido, c.descripcion [Profesion], b.descripcion, a.foto, b.promedio_calificacion 
From BD_NESCOIN.dbo.Tbl_Usuario a Join BD_NESCOIN.dbo.Tbl_Usuario_Profesion b
	ON a.id_usuario = b.id_usuario 
							    Join BD_NESCOIN.dbo.Tbl_Profesion c
	on b.id_profesion = c.id_profesion 



GO
INSERT [dbo].[Tbl_Calificacion] ([id_calificacion], [nombre], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Excelente', N'Lo hico excelente', 1)
INSERT [dbo].[Tbl_Calificacion] ([id_calificacion], [nombre], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'Muy bueno', N'Lo hico muy bien, muy bueno', 1)
INSERT [dbo].[Tbl_Calificacion] ([id_calificacion], [nombre], [descripcion], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), N'Bueno', N'Buen trabajo', 1)
INSERT [dbo].[Tbl_Calificacion] ([id_calificacion], [nombre], [descripcion], [estado]) VALUES (CAST(4 AS Numeric(18, 0)), N'Regular', N'lo hico mas o menos nomas', 1)
INSERT [dbo].[Tbl_Calificacion] ([id_calificacion], [nombre], [descripcion], [estado]) VALUES (CAST(5 AS Numeric(18, 0)), N'Malo', N'Lo hizo mal', 1)
INSERT [dbo].[Tbl_Calificacion] ([id_calificacion], [nombre], [descripcion], [estado]) VALUES (CAST(1000 AS Numeric(18, 0)), N'Requetecontramalo', N'Para que hablar, nunca mas lo llamare', 1)
GO
INSERT [dbo].[Tbl_Ciudad] ([id_ciudad], [descripcion], [id_pais], [estado]) VALUES (CAST(13 AS Numeric(18, 0)), N'Santiago', CAST(1 AS Numeric(18, 0)), 1)
GO
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Cerrillos 1', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'La Reina', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), N'Pudahuel', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(4 AS Numeric(18, 0)), N'Cerro Navia', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(5 AS Numeric(18, 0)), N'Las Condes', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(6 AS Numeric(18, 0)), N'Quilicura', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(7 AS Numeric(18, 0)), N'Conchalí', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(8 AS Numeric(18, 0)), N'Lo Barnechea', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(9 AS Numeric(18, 0)), N'Quinta Normal', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(10 AS Numeric(18, 0)), N'El Bosque', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(11 AS Numeric(18, 0)), N'Lo Espejo', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(12 AS Numeric(18, 0)), N'Recoleta', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(13 AS Numeric(18, 0)), N'Estación Central', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(14 AS Numeric(18, 0)), N'Lo Prado', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(15 AS Numeric(18, 0)), N'Renca', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(16 AS Numeric(18, 0)), N'Huechuraba', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(17 AS Numeric(18, 0)), N'Macul', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(18 AS Numeric(18, 0)), N'San Miguel', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(19 AS Numeric(18, 0)), N'Independencia', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(20 AS Numeric(18, 0)), N'Maipú', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(21 AS Numeric(18, 0)), N'San Joaquín', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(22 AS Numeric(18, 0)), N'La Cisterna', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(23 AS Numeric(18, 0)), N'Ñuñoa', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(24 AS Numeric(18, 0)), N'San Ramón', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(25 AS Numeric(18, 0)), N'La Florida', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(26 AS Numeric(18, 0)), N'Pedro Aguirre Cerda', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(27 AS Numeric(18, 0)), N'Santiago (Centro)', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(28 AS Numeric(18, 0)), N'La Pintana', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(29 AS Numeric(18, 0)), N'Peñalolén', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(30 AS Numeric(18, 0)), N'Vitacura', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(31 AS Numeric(18, 0)), N'La Granja', CAST(13 AS Numeric(18, 0)), 1)
INSERT [dbo].[Tbl_Comuna] ([id_comuna], [descripcion], [id_ciudad], [estado]) VALUES (CAST(32 AS Numeric(18, 0)), N'Providencia', CAST(13 AS Numeric(18, 0)), 1)
GO
INSERT [dbo].[Tbl_Contacto] ([id_contacto], [id_usuario], [id_tipo_usuario], [estado], [id_calificacion]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Tbl_Contacto] ([id_contacto], [id_usuario], [id_tipo_usuario], [estado], [id_calificacion]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL, NULL)
GO
INSERT [dbo].[Tbl_Correo] ([id_correo], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'pablo@inacap.cl', 1)
INSERT [dbo].[Tbl_Correo] ([id_correo], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'pablo@gmail.com', 1)
GO
INSERT [dbo].[Tbl_Direccion] ([id_direccion], [descripcion], [numero], [id_comuna], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Los Araucanos', N'344', CAST(17 AS Numeric(18, 0)), NULL)
GO
INSERT [dbo].[Tbl_Forma_Pago] ([id_forma_pago], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Efectivo', 1)
INSERT [dbo].[Tbl_Forma_Pago] ([id_forma_pago], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'Cuenta rut banco estado', 1)
INSERT [dbo].[Tbl_Forma_Pago] ([id_forma_pago], [descripcion], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), N'Cuenta vista Santander', 1)
GO
INSERT [dbo].[Tbl_Log] ([id_log], [fecha], [hora], [id_usuario], [id_tipo_log], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(N'2020-01-01' AS Date), CAST(N'11:30:51' AS Time), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 1)
GO
INSERT [dbo].[Tbl_movimiento] ([id_movimiento], [id_tipo_movimiento], [fecha_movimiento], [descripcion], [id_usuario], [id_calificacion], [comentario], [id_forma_pago], [num_ref_movimiento], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(N'2020-01-12' AS Date), N'Se realizo instalacion de pizo flotante en 15 metros cuadrados', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'1000', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 1)
GO
INSERT [dbo].[Tbl_Pais] ([id_pais], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Chile', 1)
INSERT [dbo].[Tbl_Pais] ([id_pais], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'Argentina', 1)
INSERT [dbo].[Tbl_Pais] ([id_pais], [descripcion], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), N'Brasil', 1)
GO
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Carpintero', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'Mecanico', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), N'Fotografo', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(4 AS Numeric(18, 0)), N'Ingeniero en Redes', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(5 AS Numeric(18, 0)), N'Peluquero', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(6 AS Numeric(18, 0)), N'Programador', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(7 AS Numeric(18, 0)), N'Ceo Microsoft', 1)
INSERT [dbo].[Tbl_Profesion] ([id_profesion], [descripcion], [estado]) VALUES (CAST(8 AS Numeric(18, 0)), N'Director de SpaceX', 1)
GO
INSERT [dbo].[Tbl_Telefono] ([id_telefono], [numero_telefono], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(9655874558 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Tbl_Telefono] ([id_telefono], [numero_telefono], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(654856454 AS Numeric(18, 0)), NULL)
GO
INSERT [dbo].[Tbl_Tipo_Cuenta] ([id_tipo_cuenta], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Pago', NULL)
INSERT [dbo].[Tbl_Tipo_Cuenta] ([id_tipo_cuenta], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'Libre', NULL)
GO
INSERT [dbo].[Tbl_tipo_log] ([id_tipo_log], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Inicio Sesion', 1)
GO
INSERT [dbo].[Tbl_tipo_movimiento] ([id_tipo_movimiento], [nombre], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'no me acuerdo que va aqui', N'Prueba', 1)
GO
INSERT [dbo].[Tbl_Tipo_usuario] ([id_tipo_usuario], [descripcion], [estado]) VALUES (CAST(0 AS Numeric(18, 0)), N'Usuario base', NULL)
INSERT [dbo].[Tbl_Tipo_usuario] ([id_tipo_usuario], [descripcion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'Usuario hijo (con cuenta)', NULL)
INSERT [dbo].[Tbl_Tipo_usuario] ([id_tipo_usuario], [descripcion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'Usuario hijo (sin cuenta)', NULL)
GO
INSERT [dbo].[Tbl_Usuario] ([id_usuario], [nick], [nombre], [apellido], [fecha_creacion], [fecha_actualizacion], [contraseña], [id_direccion], [id_tipo_cuenta], [foto], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), N'bgates', N'Bill', N'Gates', CAST(N'2020-08-01' AS Date), CAST(N'2020-08-01' AS Date), N'e99a18c428cb38d5f260853678922e03', CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'bgates.png', 1)
INSERT [dbo].[Tbl_Usuario] ([id_usuario], [nick], [nombre], [apellido], [fecha_creacion], [fecha_actualizacion], [contraseña], [id_direccion], [id_tipo_cuenta], [foto], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), N'emusk', N'Ellon', N'Musk', CAST(N'2020-09-24' AS Date), CAST(N'2024-09-20' AS Date), N'e99a18c428cb38d5f260853678922e03', CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'emusk.jpg', 1)
INSERT [dbo].[Tbl_Usuario] ([id_usuario], [nick], [nombre], [apellido], [fecha_creacion], [fecha_actualizacion], [contraseña], [id_direccion], [id_tipo_cuenta], [foto], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), N'mzuckerberg', N'Mark', N'Zuckerberg', CAST(N'2020-09-24' AS Date), CAST(N'2020-09-24' AS Date), N'e99a18c428cb38d5f260853678922e03', CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'MZuckerberg.jpg', 1)
GO
INSERT [dbo].[Tbl_Usuario_Correo] ([id_usuario], [id_correo], [principal], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 1, 1)
INSERT [dbo].[Tbl_Usuario_Correo] ([id_usuario], [id_correo], [principal], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), 0, 1)
GO
INSERT [dbo].[Tbl_Usuario_Profesion] ([id_usuario], [id_profesion], [descripcion], [promedio_calificacion], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)), N'Empresario, informático y filántropo estadounidense, cofundador de Microsoft junto con Paul Allen', 5, 1)
INSERT [dbo].[Tbl_Usuario_Profesion] ([id_usuario], [id_profesion], [descripcion], [promedio_calificacion], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)), N'Físico, emprendedor, inventor y magnate sudafricano, nacionalizado canadiense y estadounidense', 3, 1)
INSERT [dbo].[Tbl_Usuario_Profesion] ([id_usuario], [id_profesion], [descripcion], [promedio_calificacion], [estado]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), N'Programador y empresario estadounidense, uno de los creadores y fundadores de Facebook', 4, 1)
GO
INSERT [dbo].[Tbl_Usuario_Telefono] ([id_usuario], [id_telefono], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Tbl_Usuario_Telefono] ([id_usuario], [id_telefono], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), NULL)
GO
ALTER TABLE [dbo].[Tbl_Pais] ADD  CONSTRAINT [DF_Tbl_Pais_estado]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Tbl_Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Ciudad_Pais] FOREIGN KEY([id_pais])
REFERENCES [dbo].[Tbl_Pais] ([id_pais])
GO
ALTER TABLE [dbo].[Tbl_Ciudad] CHECK CONSTRAINT [FK_Tbl_Ciudad_Pais]
GO
ALTER TABLE [dbo].[Tbl_Comuna]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Comuna_Tbl_Ciudad] FOREIGN KEY([id_ciudad])
REFERENCES [dbo].[Tbl_Ciudad] ([id_ciudad])
GO
ALTER TABLE [dbo].[Tbl_Comuna] CHECK CONSTRAINT [FK_Tbl_Comuna_Tbl_Ciudad]
GO
ALTER TABLE [dbo].[Tbl_Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Contacto_Tbl_Calificacion] FOREIGN KEY([id_calificacion])
REFERENCES [dbo].[Tbl_Calificacion] ([id_calificacion])
GO
ALTER TABLE [dbo].[Tbl_Contacto] CHECK CONSTRAINT [FK_Tbl_Contacto_Tbl_Calificacion]
GO
ALTER TABLE [dbo].[Tbl_Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Contacto_Tbl_Tipo_usuario] FOREIGN KEY([id_tipo_usuario])
REFERENCES [dbo].[Tbl_Tipo_usuario] ([id_tipo_usuario])
GO
ALTER TABLE [dbo].[Tbl_Contacto] CHECK CONSTRAINT [FK_Tbl_Contacto_Tbl_Tipo_usuario]
GO
ALTER TABLE [dbo].[Tbl_Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Contacto_Tbl_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Tbl_Contacto] CHECK CONSTRAINT [FK_Tbl_Contacto_Tbl_Usuario]
GO
ALTER TABLE [dbo].[Tbl_Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Direccion_Tbl_Comuna] FOREIGN KEY([id_comuna])
REFERENCES [dbo].[Tbl_Comuna] ([id_comuna])
GO
ALTER TABLE [dbo].[Tbl_Direccion] CHECK CONSTRAINT [FK_Tbl_Direccion_Tbl_Comuna]
GO
ALTER TABLE [dbo].[Tbl_Log]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Log_Tbl_tipo_log] FOREIGN KEY([id_tipo_log])
REFERENCES [dbo].[Tbl_tipo_log] ([id_tipo_log])
GO
ALTER TABLE [dbo].[Tbl_Log] CHECK CONSTRAINT [FK_Tbl_Log_Tbl_tipo_log]
GO
ALTER TABLE [dbo].[Tbl_Log]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Log_Tbl_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Tbl_Log] CHECK CONSTRAINT [FK_Tbl_Log_Tbl_Usuario]
GO
ALTER TABLE [dbo].[Tbl_movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_movimiento_Tbl_Calificacion] FOREIGN KEY([id_calificacion])
REFERENCES [dbo].[Tbl_Calificacion] ([id_calificacion])
GO
ALTER TABLE [dbo].[Tbl_movimiento] CHECK CONSTRAINT [FK_Tbl_movimiento_Tbl_Calificacion]
GO
ALTER TABLE [dbo].[Tbl_movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_movimiento_Tbl_Forma_Pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[Tbl_Forma_Pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[Tbl_movimiento] CHECK CONSTRAINT [FK_Tbl_movimiento_Tbl_Forma_Pago]
GO
ALTER TABLE [dbo].[Tbl_movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_movimiento_Tbl_tipo_movimiento] FOREIGN KEY([id_tipo_movimiento])
REFERENCES [dbo].[Tbl_tipo_movimiento] ([id_tipo_movimiento])
GO
ALTER TABLE [dbo].[Tbl_movimiento] CHECK CONSTRAINT [FK_Tbl_movimiento_Tbl_tipo_movimiento]
GO
ALTER TABLE [dbo].[Tbl_movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_movimiento_Tbl_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Tbl_movimiento] CHECK CONSTRAINT [FK_Tbl_movimiento_Tbl_Usuario]
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Tbl_Direccion] FOREIGN KEY([id_direccion])
REFERENCES [dbo].[Tbl_Direccion] ([id_direccion])
GO
ALTER TABLE [dbo].[Tbl_Usuario] CHECK CONSTRAINT [FK_Tbl_Usuario_Tbl_Direccion]
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Tbl_Tipo_Cuenta] FOREIGN KEY([id_tipo_cuenta])
REFERENCES [dbo].[Tbl_Tipo_Cuenta] ([id_tipo_cuenta])
GO
ALTER TABLE [dbo].[Tbl_Usuario] CHECK CONSTRAINT [FK_Tbl_Usuario_Tbl_Tipo_Cuenta]
GO
ALTER TABLE [dbo].[Tbl_Usuario_Correo]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Correo_Tbl_Correo] FOREIGN KEY([id_correo])
REFERENCES [dbo].[Tbl_Correo] ([id_correo])
GO
ALTER TABLE [dbo].[Tbl_Usuario_Correo] CHECK CONSTRAINT [FK_Tbl_Usuario_Correo_Tbl_Correo]
GO
ALTER TABLE [dbo].[Tbl_Usuario_Correo]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Correo_Tbl_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Tbl_Usuario_Correo] CHECK CONSTRAINT [FK_Tbl_Usuario_Correo_Tbl_Usuario]
GO
ALTER TABLE [dbo].[Tbl_Usuario_Profesion]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Profesion_Tbl_Profesion] FOREIGN KEY([id_profesion])
REFERENCES [dbo].[Tbl_Profesion] ([id_profesion])
GO
ALTER TABLE [dbo].[Tbl_Usuario_Profesion] CHECK CONSTRAINT [FK_Tbl_Usuario_Profesion_Tbl_Profesion]
GO
ALTER TABLE [dbo].[Tbl_Usuario_Profesion]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Profesion_Tbl_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Tbl_Usuario_Profesion] CHECK CONSTRAINT [FK_Tbl_Usuario_Profesion_Tbl_Usuario]
GO
ALTER TABLE [dbo].[Tbl_Usuario_Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Telefono_Tbl_Telefono] FOREIGN KEY([id_telefono])
REFERENCES [dbo].[Tbl_Telefono] ([id_telefono])
GO
ALTER TABLE [dbo].[Tbl_Usuario_Telefono] CHECK CONSTRAINT [FK_Tbl_Usuario_Telefono_Tbl_Telefono]
GO
ALTER TABLE [dbo].[Tbl_Usuario_Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Telefono_Tbl_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Tbl_Usuario_Telefono] CHECK CONSTRAINT [FK_Tbl_Usuario_Telefono_Tbl_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[PA_Trae_Vista_Vitrina]    Script Date: 28-09-2020 18:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[PA_Trae_Vista_Vitrina]
As


Select a.nombre + ' ' + a.apellido NombreUsuario, 
       c.descripcion [Profesion], b.descripcion
From BD_NESCOIN.dbo.Tbl_Usuario a join BD_NESCOIN.dbo.Tbl_Usuario_Profesion b
	ON a.id_usuario = b.id_usuario 
							    join BD_NESCOIN.dbo.Tbl_Profesion c
	on b.id_profesion = c.id_profesion 
GO
USE [master]
GO
ALTER DATABASE [BD_NESCOIN] SET  READ_WRITE 
GO
