USE [master]
GO
/****** Object:  Database [TPLAB3]    Script Date: 24/11/2023 21:20:05 ******/
CREATE DATABASE [TPLAB3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TPLAB3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TPLAB3.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TPLAB3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TPLAB3_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TPLAB3] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPLAB3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPLAB3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPLAB3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPLAB3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPLAB3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPLAB3] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPLAB3] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TPLAB3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPLAB3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPLAB3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPLAB3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPLAB3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPLAB3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPLAB3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPLAB3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPLAB3] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TPLAB3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPLAB3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPLAB3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPLAB3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPLAB3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPLAB3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPLAB3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPLAB3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TPLAB3] SET  MULTI_USER 
GO
ALTER DATABASE [TPLAB3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPLAB3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPLAB3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPLAB3] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TPLAB3] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TPLAB3]
GO
/****** Object:  Table [dbo].[Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Autopartes](
	[AutoparteID] [int] IDENTITY(1,1) NOT NULL,
	[stock] [int] NULL,
	[stock_minimo] [int] NULL,
	[descripcion] [varchar](100) NULL,
	[precio_unitario] [float] NULL,
	[FK_tipo_autoparteID] [int] NULL,
	[FK_modelo_autoparteID] [int] NULL,
 CONSTRAINT [pk_autopartes] PRIMARY KEY CLUSTERED 
(
	[AutoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Autos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NULL,
	[Capacidad] [decimal](10, 2) NULL,
	[NroPuertas] [int] NULL,
	[NroCilindros] [int] NULL,
	[FK_ModeloID] [int] NULL,
	[FK_ColorID] [int] NULL,
	[FK_Tipos_MotorID] [int] NULL,
	[FK_Tipo_TransmisionID] [int] NULL,
	[FK_Tipo_CombustibleID] [int] NULL,
	[FK_MarcaID] [int] NULL,
	[FK_TipoID] [int] NULL,
	[precio_unitario] [float] NULL,
 CONSTRAINT [pk_autos] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Barrios](
	[BarrioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[FK_LocalidadID] [int] NULL,
 CONSTRAINT [pk_barrios] PRIMARY KEY CLUSTERED 
(
	[BarrioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Razon_Social] [varchar](255) NULL,
	[Calle] [varchar](255) NULL,
	[Altura] [int] NULL,
	[CUIT_CUIL] [bigint] NULL,
	[FK_BarrioID] [int] NULL,
	[FK_TipoCliente] [int] NULL,
 CONSTRAINT [pk_clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Colores]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Colores](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [varchar](50) NULL,
 CONSTRAINT [pk_colores] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contactos](
	[ContactoID] [int] IDENTITY(1,1) NOT NULL,
	[Contacto] [varchar](255) NULL,
	[ClienteID] [int] NULL,
	[FK_Tipos_Contacto] [int] NULL,
 CONSTRAINT [pk_contactos] PRIMARY KEY CLUSTERED 
(
	[ContactoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Detalle_Factura_Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Factura_Autopartes](
	[DetalleFacturaAutoparteID] [int] IDENTITY(1,1) NOT NULL,
	[FK_FacturaAutoparteID] [int] NULL,
	[FK_AutoparteID] [int] NULL,
	[Subtotal] [float] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [pk_detalle_factura_autopartes] PRIMARY KEY CLUSTERED 
(
	[DetalleFacturaAutoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_Factura_Autos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Factura_Autos](
	[DetalleFacturaAutoID] [int] IDENTITY(1,1) NOT NULL,
	[FK_FacturaAutoID] [int] NULL,
	[FK_AutoID] [int] NULL,
	[Subtotal] [float] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [pk_detalle_factura_autos] PRIMARY KEY CLUSTERED 
(
	[DetalleFacturaAutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_Orden_Pedido_Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Orden_Pedido_Autopartes](
	[DetalleOrdenAutoparteID] [int] IDENTITY(1,1) NOT NULL,
	[FK_OrdenAutoparte] [int] NULL,
	[FK_AutoparteID] [int] NULL,
	[Subtotal] [float] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [pk_detalle_orden_autos] PRIMARY KEY CLUSTERED 
(
	[DetalleOrdenAutoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_Orden_Pedido_Autos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Orden_Pedido_Autos](
	[DetalleOrdenAutosID] [int] IDENTITY(1,1) NOT NULL,
	[FK_OrdenAuto] [int] NULL,
	[FK_AutoID] [int] NULL,
	[Subtotal] [float] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [pk_detalle_orden_pedido_autos] PRIMARY KEY CLUSTERED 
(
	[DetalleOrdenAutosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factura_Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura_Autopartes](
	[FacturaAutoparteID] [int] IDENTITY(1,1) NOT NULL,
	[FechaFactura] [date] NULL,
	[FechaPago] [date] NULL,
	[Intereses] [float] NULL,
	[Descuento] [float] NULL,
	[FK_ClienteID] [int] NULL,
	[FK_FormaPagoID] [int] NULL,
	[FK_FormaEnvioID] [int] NULL,
 CONSTRAINT [pk_factura_autopartes] PRIMARY KEY CLUSTERED 
(
	[FacturaAutoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factura_Autos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura_Autos](
	[FacturaAutoID] [int] IDENTITY(1,1) NOT NULL,
	[FechaFactura] [date] NULL,
	[FechaPago] [date] NULL,
	[Intereses] [float] NULL,
	[Descuento] [float] NULL,
	[FK_ClienteID] [int] NULL,
	[FK_FormaPagoID] [int] NULL,
	[FK_FormaEnvioID] [int] NULL,
 CONSTRAINT [pk_factura_autos] PRIMARY KEY CLUSTERED 
(
	[FacturaAutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Forma_Envio]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forma_Envio](
	[FormaEnvioID] [int] IDENTITY(1,1) NOT NULL,
	[FormaEnvio] [varchar](50) NULL,
 CONSTRAINT [pk_forma_envio] PRIMARY KEY CLUSTERED 
(
	[FormaEnvioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Forma_Pago]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forma_Pago](
	[FormaPagoID] [int] IDENTITY(1,1) NOT NULL,
	[FormaPago] [varchar](50) NULL,
 CONSTRAINT [pk_forma_pago] PRIMARY KEY CLUSTERED 
(
	[FormaPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[FK_ProvinciaID] [int] NULL,
 CONSTRAINT [pk_localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marcas](
	[MarcaID] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](50) NULL,
 CONSTRAINT [pk_marcas] PRIMARY KEY CLUSTERED 
(
	[MarcaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modelo_Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modelo_Autopartes](
	[Modelo_autoparteID] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [pk_modelo_autoparte] PRIMARY KEY CLUSTERED 
(
	[Modelo_autoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modelos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modelos](
	[ModeloID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [varchar](50) NULL,
 CONSTRAINT [pk_modelos] PRIMARY KEY CLUSTERED 
(
	[ModeloID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orden_Pedido_Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Pedido_Autopartes](
	[OrdenAutoparteID] [int] IDENTITY(1,1) NOT NULL,
	[FechaOrden] [date] NULL,
	[FechaPago] [date] NULL,
	[Intereses] [float] NULL,
	[Descuento] [float] NULL,
	[FK_ClienteID] [int] NULL,
	[FK_FormaPagoID] [int] NULL,
	[FK_FormaEnvioID] [int] NULL,
 CONSTRAINT [pk_orden_pedido_autopartes] PRIMARY KEY CLUSTERED 
(
	[OrdenAutoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orden_Pedido_Autos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Pedido_Autos](
	[OrdenAutosID] [int] IDENTITY(1,1) NOT NULL,
	[FechaOrden] [date] NULL,
	[FechaPago] [date] NULL,
	[Intereses] [float] NULL,
	[Descuento] [float] NULL,
	[FK_ClienteID] [int] NULL,
	[FK_FormaPagoID] [int] NULL,
	[FK_FormaEnvioID] [int] NULL,
 CONSTRAINT [pk_Orden_Autos] PRIMARY KEY CLUSTERED 
(
	[OrdenAutosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [pk_provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipo_Autopartes]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_Autopartes](
	[Tipo_autoparteID] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [pk_tipo_autoparte] PRIMARY KEY CLUSTERED 
(
	[Tipo_autoparteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos](
	[TipoID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NULL,
 CONSTRAINT [pk_tipos] PRIMARY KEY CLUSTERED 
(
	[TipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos_Cliente]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Cliente](
	[TipoClienteID] [int] IDENTITY(1,1) NOT NULL,
	[TipoCliente] [varchar](100) NULL,
 CONSTRAINT [pk_tipos_cliente] PRIMARY KEY CLUSTERED 
(
	[TipoClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos_Combustible]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Combustible](
	[Tipo_CombustibleID] [int] IDENTITY(1,1) NOT NULL,
	[TipoCombustible] [varchar](50) NULL,
 CONSTRAINT [pk_tipos_combustible] PRIMARY KEY CLUSTERED 
(
	[Tipo_CombustibleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos_Contactos]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Contactos](
	[TipoContactoID] [int] IDENTITY(1,1) NOT NULL,
	[TipoContacto] [varchar](50) NULL,
 CONSTRAINT [pk_tipos_contactos] PRIMARY KEY CLUSTERED 
(
	[TipoContactoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos_Motor]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Motor](
	[Motor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Motor] [varchar](50) NULL,
 CONSTRAINT [pk_tipos_motor] PRIMARY KEY CLUSTERED 
(
	[Motor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos_Transmision]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Transmision](
	[Tipo_TransmisionID] [int] IDENTITY(1,1) NOT NULL,
	[TipoTransmision] [varchar](50) NULL,
 CONSTRAINT [pk_tipos_transmision] PRIMARY KEY CLUSTERED 
(
	[Tipo_TransmisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Autopartes] ON 

INSERT [dbo].[Autopartes] ([AutoparteID], [stock], [stock_minimo], [descripcion], [precio_unitario], [FK_tipo_autoparteID], [FK_modelo_autoparteID]) VALUES (1, 10, 5, N'Neumático', 5000, 1, 1)
INSERT [dbo].[Autopartes] ([AutoparteID], [stock], [stock_minimo], [descripcion], [precio_unitario], [FK_tipo_autoparteID], [FK_modelo_autoparteID]) VALUES (2, 20, 10, N'Llantas', 10000, 1, 1)
INSERT [dbo].[Autopartes] ([AutoparteID], [stock], [stock_minimo], [descripcion], [precio_unitario], [FK_tipo_autoparteID], [FK_modelo_autoparteID]) VALUES (3, 30, 15, N'Amortiguadores', 20000, 1, 1)
INSERT [dbo].[Autopartes] ([AutoparteID], [stock], [stock_minimo], [descripcion], [precio_unitario], [FK_tipo_autoparteID], [FK_modelo_autoparteID]) VALUES (4, 40, 20, N'Frenos', 30000, 1, 1)
INSERT [dbo].[Autopartes] ([AutoparteID], [stock], [stock_minimo], [descripcion], [precio_unitario], [FK_tipo_autoparteID], [FK_modelo_autoparteID]) VALUES (5, 50, 25, N'Radio', 40000, 1, 1)
SET IDENTITY_INSERT [dbo].[Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Autos] ON 

INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (1, 2023, CAST(45.00 AS Decimal(10, 2)), 4, 12, 1, 1, 1, 1, 1, 1, 1, 20000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (2, 2023, CAST(45.00 AS Decimal(10, 2)), 4, 12, 2, 2, 2, 2, 2, 1, 2, 25000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (3, 2023, CAST(45.00 AS Decimal(10, 2)), 4, 12, 3, 3, 3, 3, 3, 2, 3, 30000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (4, 2023, CAST(45.00 AS Decimal(10, 2)), 4, 12, 4, 4, 4, 4, 1, 2, 4, 35000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (5, 2023, CAST(45.00 AS Decimal(10, 2)), 4, 12, 5, 5, 5, 5, 5, 2, 5, 40000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (6, 2023, CAST(50.00 AS Decimal(10, 2)), 4, 12, 1, 1, 1, 1, 1, 1, 1, 100000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (7, 2022, CAST(50.00 AS Decimal(10, 2)), 4, 12, 2, 2, 2, 2, 2, 1, 2, 200000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (8, 2021, CAST(50.00 AS Decimal(10, 2)), 4, 12, 3, 3, 3, 3, 3, 2, 3, 300000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (9, 2020, CAST(50.00 AS Decimal(10, 2)), 4, 12, 4, 4, 4, 4, 1, 2, 4, 400000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (10, 2019, CAST(50.00 AS Decimal(10, 2)), 4, 12, 5, 5, 5, 5, 5, 2, 5, 500000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (11, 2018, CAST(60.00 AS Decimal(10, 2)), 4, 12, 6, 1, 1, 1, 1, 3, 1, 600000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (12, 2017, CAST(60.00 AS Decimal(10, 2)), 4, 12, 7, 2, 2, 2, 2, 4, 3, 700000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (13, 2016, CAST(60.00 AS Decimal(10, 2)), 4, 12, 8, 3, 3, 3, 3, 4, 4, 800000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (14, 2015, CAST(60.00 AS Decimal(10, 2)), 4, 12, 9, 4, 4, 4, 1, 4, 5, 900000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (15, 2010, CAST(45.00 AS Decimal(10, 2)), 4, 12, 10, 1, 2, 2, 1, 5, 1, 50000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (18, 2010, CAST(45.00 AS Decimal(10, 2)), 4, 12, 11, 1, 2, 2, 1, 5, 1, 70000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (23, 2000, CAST(12.00 AS Decimal(10, 2)), 4, 12, 1, 1, 1, 1, 1, 1, 1, 10000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (25, 2023, CAST(45.00 AS Decimal(10, 2)), 4, 12, 6, 3, 4, 2, 5, 3, 1, 100000)
INSERT [dbo].[Autos] ([AutoID], [Año], [Capacidad], [NroPuertas], [NroCilindros], [FK_ModeloID], [FK_ColorID], [FK_Tipos_MotorID], [FK_Tipo_TransmisionID], [FK_Tipo_CombustibleID], [FK_MarcaID], [FK_TipoID], [precio_unitario]) VALUES (26, 2013, CAST(45.00 AS Decimal(10, 2)), 4, 12, 11, 5, 2, 2, 1, 5, 1, 100000)
SET IDENTITY_INSERT [dbo].[Autos] OFF
SET IDENTITY_INSERT [dbo].[Barrios] ON 

INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (1, N'Nueva Cordoba', 1)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (2, N'Barrio Jardin', 2)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (3, N'Jorge Newbary', 3)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (4, N'General Arenales', 3)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (5, N'Urca', 1)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (6, N'Recoleta', 2)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (7, N'Palermo', 3)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (8, N'Santo Tome', 3)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (9, N'San Martin Norte', 1)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (10, N'Godoy Cruz', 2)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (11, N'Villa Urquiza', 3)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (12, N'San Agustin', 3)
INSERT [dbo].[Barrios] ([BarrioID], [Nombre], [FK_LocalidadID]) VALUES (13, N'Lavalleja', 1)
SET IDENTITY_INSERT [dbo].[Barrios] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (1, N'Juan Pérez', N'Av. Rivadavia', 1234, 1234567, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (2, N'María González', N'Calle Sarmiento', 5432, 2232527, 2, 2)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (3, N'Pedro Rodríguez', N'Calle Moreno', 6789, 4532527, 3, 3)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (4, N'Rodrigo Juarez', N'Av. Santa Fe', 7890, 6532521, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (5, N'Roman Gímenez', N'Calle Córdoba', 9012, 6838520, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (6, N'Santíago Salas', N'Calle Moreno', 1234, 7832529, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (7, N'Polo Galindez', N'Calle Independencia', 5432, 9232222, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (8, N'Roco Rey', N'Calle Belgrano', 6789, 2222222, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (9, N'Mariano Moreno', N'Calle Mitre', 7890, 1212121, 1, 1)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (10, N'José Martínez', N'Calle Rivadavia', 9012, 2121212, 2, 2)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (11, N'Ronaldo Martins', N'Calle Sarmiento', 1234, 3131313, 2, 2)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (12, N'Leonel Smith', N'Calle Mayo', 5432, 3434343, 3, 3)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (13, N'Angel Ford', N'Calle Entre Ríos', 6789, 9494335, 3, 3)
INSERT [dbo].[Clientes] ([ClienteID], [Razon_Social], [Calle], [Altura], [CUIT_CUIL], [FK_BarrioID], [FK_TipoCliente]) VALUES (14, N'Clever Harrinson', N'Calle San Martín', 7890, 12345, 3, 3)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Colores] ON 

INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (1, N'Blanco')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (2, N'Negro')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (3, N'Rojo')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (4, N'Azul')
INSERT [dbo].[Colores] ([ColorID], [Color]) VALUES (5, N'Gris')
SET IDENTITY_INSERT [dbo].[Colores] OFF
SET IDENTITY_INSERT [dbo].[Contactos] ON 

INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (17, N'3572697583', 1, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (20, N'Mariagonzales@gmail.com', 2, 2)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (21, N'3572907583', 3, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (22, N'PedroRodriguez@gmail.com', 4, 2)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (23, N'3550236578', 6, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (24, N'cooperativa@gmail.com', 5, 2)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (25, N'3465876543', 8, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (26, N'IPEM158@gmail.com', 7, 2)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (27, N'3674645321', 9, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (28, N'ANONIMO@gmail.com', 10, 2)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (29, N'3645321256', 11, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (30, N'gobiernonacional@gmail.com', 12, 2)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (31, N'453657', 13, 1)
INSERT [dbo].[Contactos] ([ContactoID], [Contacto], [ClienteID], [FK_Tipos_Contacto]) VALUES (32, N'municipalidadoncativo@gmail.com', 14, 2)
SET IDENTITY_INSERT [dbo].[Contactos] OFF
SET IDENTITY_INSERT [dbo].[Detalle_Factura_Autopartes] ON 

INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (1, 1, 1, 5000, 2)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (2, 2, 2, 10000, 60)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (3, 3, 3, 20000, 5)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (4, 4, 4, 2500, 1)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (5, 5, 5, 8000, 3)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (6, 6, 5, 6500, 2)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (7, 7, 2, 7000, 3)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (8, 8, 1, 15000, 4)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (9, 9, 3, 2500, 1)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (10, 10, 5, 1150, 1)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (11, 11, 4, 3250, 2)
INSERT [dbo].[Detalle_Factura_Autopartes] ([DetalleFacturaAutoparteID], [FK_FacturaAutoparteID], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (12, 12, 1, 4500, 2)
SET IDENTITY_INSERT [dbo].[Detalle_Factura_Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Detalle_Factura_Autos] ON 

INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (1, 1, 1, 20000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (2, 2, 2, 25000, 65)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (3, 3, 3, 30000, 3)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (4, 4, 4, 20000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (5, 5, 5, 25000, 2)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (6, 6, 6, 30000, 3)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (7, 7, 7, 20000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (8, 8, 8, 25000, 2)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (9, 9, 9, 30000, 3)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (10, 10, 10, 20000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (11, 11, 11, 25000, 73)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (12, 12, 12, 30000, 3)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (14, 23, 25, 100000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (15, 23, 11, 600000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (16, 24, 14, 900000, 1)
INSERT [dbo].[Detalle_Factura_Autos] ([DetalleFacturaAutoID], [FK_FacturaAutoID], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (20, 25, 2, 25000, 1)
SET IDENTITY_INSERT [dbo].[Detalle_Factura_Autos] OFF
SET IDENTITY_INSERT [dbo].[Detalle_Orden_Pedido_Autopartes] ON 

INSERT [dbo].[Detalle_Orden_Pedido_Autopartes] ([DetalleOrdenAutoparteID], [FK_OrdenAutoparte], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (1, 1, 1, 5000, 20)
INSERT [dbo].[Detalle_Orden_Pedido_Autopartes] ([DetalleOrdenAutoparteID], [FK_OrdenAutoparte], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (2, 2, 2, 10000, 100)
INSERT [dbo].[Detalle_Orden_Pedido_Autopartes] ([DetalleOrdenAutoparteID], [FK_OrdenAutoparte], [FK_AutoparteID], [Subtotal], [Cantidad]) VALUES (3, 3, 3, 20000, 50)
SET IDENTITY_INSERT [dbo].[Detalle_Orden_Pedido_Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Detalle_Orden_Pedido_Autos] ON 

INSERT [dbo].[Detalle_Orden_Pedido_Autos] ([DetalleOrdenAutosID], [FK_OrdenAuto], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (1, 1, 1, 20000, 1)
INSERT [dbo].[Detalle_Orden_Pedido_Autos] ([DetalleOrdenAutosID], [FK_OrdenAuto], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (2, 2, 2, 25000, 2)
INSERT [dbo].[Detalle_Orden_Pedido_Autos] ([DetalleOrdenAutosID], [FK_OrdenAuto], [FK_AutoID], [Subtotal], [Cantidad]) VALUES (3, 3, 3, 30000, 3)
SET IDENTITY_INSERT [dbo].[Detalle_Orden_Pedido_Autos] OFF
SET IDENTITY_INSERT [dbo].[Factura_Autopartes] ON 

INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (1, CAST(N'2023-07-20' AS Date), CAST(N'2023-07-25' AS Date), 0.05, 0.6, 1, 1, 1)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (2, CAST(N'2023-07-21' AS Date), CAST(N'2023-07-26' AS Date), 0.07, 0, 2, 2, 2)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (3, CAST(N'2023-07-22' AS Date), CAST(N'2023-07-27' AS Date), 0.09, 0, 3, 3, 3)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (4, CAST(N'2023-07-20' AS Date), CAST(N'2023-07-25' AS Date), 0.05, 0, 4, 1, 1)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (5, CAST(N'2023-07-21' AS Date), CAST(N'2023-07-26' AS Date), 0.07, 0, 5, 2, 2)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (6, CAST(N'2023-07-22' AS Date), CAST(N'2023-07-27' AS Date), 0.09, 0, 6, 3, 3)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (7, CAST(N'2023-08-20' AS Date), CAST(N'2023-08-25' AS Date), 0.05, 0, 7, 1, 1)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (8, CAST(N'2023-08-21' AS Date), CAST(N'2023-08-26' AS Date), 0.07, 0, 8, 2, 2)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (9, CAST(N'2023-08-22' AS Date), CAST(N'2023-08-27' AS Date), 0.09, 0, 9, 3, 3)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (10, CAST(N'2023-09-20' AS Date), CAST(N'2023-09-25' AS Date), 0.05, 0, 10, 1, 1)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (11, CAST(N'2023-09-21' AS Date), CAST(N'2023-09-26' AS Date), 0.07, 0, 11, 2, 2)
INSERT [dbo].[Factura_Autopartes] ([FacturaAutoparteID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (12, CAST(N'2023-09-22' AS Date), CAST(N'2023-09-27' AS Date), 0.09, 0, 12, 3, 3)
SET IDENTITY_INSERT [dbo].[Factura_Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Factura_Autos] ON 

INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (1, CAST(N'2023-07-20' AS Date), CAST(N'2023-07-25' AS Date), 1, 1, 1, 1, 1)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (2, CAST(N'2023-07-21' AS Date), CAST(N'2023-07-26' AS Date), 0.07, 0, 2, 2, 2)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (3, CAST(N'2023-07-22' AS Date), CAST(N'2023-07-27' AS Date), 0.09, 0, 3, 3, 3)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (4, CAST(N'2023-07-20' AS Date), CAST(N'2023-07-25' AS Date), 0.05, 0, 5, 1, 1)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (5, CAST(N'2023-07-21' AS Date), CAST(N'2023-07-26' AS Date), 0.07, 0.05, 6, 2, 2)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (6, CAST(N'2023-07-22' AS Date), CAST(N'2023-07-27' AS Date), 0.09, 0, 8, 3, 3)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (7, CAST(N'2023-08-20' AS Date), CAST(N'2023-08-25' AS Date), 0.05, 0, 9, 1, 1)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (8, CAST(N'2023-08-21' AS Date), CAST(N'2023-08-26' AS Date), 0.07, 0, 11, 2, 2)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (9, CAST(N'2023-08-22' AS Date), CAST(N'2023-08-27' AS Date), 0.09, 0, 12, 3, 3)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (10, CAST(N'2023-09-20' AS Date), CAST(N'2023-09-25' AS Date), 0.05, 0.6, 1, 1, 1)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (11, CAST(N'2023-09-21' AS Date), CAST(N'2023-09-26' AS Date), 0.07, 0, 2, 2, 2)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (12, CAST(N'2023-09-22' AS Date), CAST(N'2023-09-27' AS Date), 0.09, 0, 3, 3, 3)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (23, CAST(N'2023-11-20' AS Date), CAST(N'2023-12-20' AS Date), 10, 5, 14, 1, 1)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (24, CAST(N'2023-11-21' AS Date), CAST(N'2023-12-21' AS Date), 0, 5, 13, 1, 1)
INSERT [dbo].[Factura_Autos] ([FacturaAutoID], [FechaFactura], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (25, CAST(N'2023-11-21' AS Date), CAST(N'2023-12-21' AS Date), 0, 5, 14, 1, 2)
SET IDENTITY_INSERT [dbo].[Factura_Autos] OFF
SET IDENTITY_INSERT [dbo].[Forma_Envio] ON 

INSERT [dbo].[Forma_Envio] ([FormaEnvioID], [FormaEnvio]) VALUES (1, N'Retiro en sucursal')
INSERT [dbo].[Forma_Envio] ([FormaEnvioID], [FormaEnvio]) VALUES (2, N'Envio a domicilio')
INSERT [dbo].[Forma_Envio] ([FormaEnvioID], [FormaEnvio]) VALUES (3, N'Envio a punto de retiro')
SET IDENTITY_INSERT [dbo].[Forma_Envio] OFF
SET IDENTITY_INSERT [dbo].[Forma_Pago] ON 

INSERT [dbo].[Forma_Pago] ([FormaPagoID], [FormaPago]) VALUES (1, N'Efectivo')
INSERT [dbo].[Forma_Pago] ([FormaPagoID], [FormaPago]) VALUES (2, N'Tarjeta de crédito')
INSERT [dbo].[Forma_Pago] ([FormaPagoID], [FormaPago]) VALUES (3, N'Tarjeta de débito')
INSERT [dbo].[Forma_Pago] ([FormaPagoID], [FormaPago]) VALUES (4, N'Crédito')
INSERT [dbo].[Forma_Pago] ([FormaPagoID], [FormaPago]) VALUES (5, N'Financiación')
SET IDENTITY_INSERT [dbo].[Forma_Pago] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([LocalidadID], [Nombre], [FK_ProvinciaID]) VALUES (1, N'Norte', 1)
INSERT [dbo].[Localidades] ([LocalidadID], [Nombre], [FK_ProvinciaID]) VALUES (2, N'Sur', 2)
INSERT [dbo].[Localidades] ([LocalidadID], [Nombre], [FK_ProvinciaID]) VALUES (3, N'Oeste', 3)
INSERT [dbo].[Localidades] ([LocalidadID], [Nombre], [FK_ProvinciaID]) VALUES (4, N'Este', 4)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([MarcaID], [Marca]) VALUES (1, N'Toyota')
INSERT [dbo].[Marcas] ([MarcaID], [Marca]) VALUES (2, N'Honda')
INSERT [dbo].[Marcas] ([MarcaID], [Marca]) VALUES (3, N'Nissan')
INSERT [dbo].[Marcas] ([MarcaID], [Marca]) VALUES (4, N'Volkswagen')
INSERT [dbo].[Marcas] ([MarcaID], [Marca]) VALUES (5, N'Ford')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
SET IDENTITY_INSERT [dbo].[Modelo_Autopartes] ON 

INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (1, N'Gas')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (2, N'Diesel')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (3, N'Electricos')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (4, N'Independiente')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (5, N'Autoportante')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (6, N'Monocasco')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (7, N'Hidraulico')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (8, N'Gas')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (9, N'Mecánico')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (10, N'Solo embrague')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (11, N'Doble embrague')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (12, N'Automática tradicional')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (13, N'Discos')
INSERT [dbo].[Modelo_Autopartes] ([Modelo_autoparteID], [descripcion]) VALUES (14, N'Tambor')
SET IDENTITY_INSERT [dbo].[Modelo_Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Modelos] ON 

INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (1, N'Corolla 2.0 XLI MT')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (2, N'Corolla 2.0 XEI MT')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (3, N'Civic EX/L ')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (4, N'Civic EX/M ')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (5, N'Civic EX/T ')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (6, N'Sentra')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (7, N'Golf Trendline')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (8, N'Golf Comfortline')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (9, N'Golf Highline')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (10, N'Fiesta XR2')
INSERT [dbo].[Modelos] ([ModeloID], [Modelo]) VALUES (11, N'Fiesta ST')
SET IDENTITY_INSERT [dbo].[Modelos] OFF
SET IDENTITY_INSERT [dbo].[Orden_Pedido_Autopartes] ON 

INSERT [dbo].[Orden_Pedido_Autopartes] ([OrdenAutoparteID], [FechaOrden], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (1, CAST(N'2023-07-20' AS Date), CAST(N'2023-07-25' AS Date), 0.6, 0, 1, 1, 1)
INSERT [dbo].[Orden_Pedido_Autopartes] ([OrdenAutoparteID], [FechaOrden], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (2, CAST(N'2023-07-21' AS Date), CAST(N'2023-07-26' AS Date), 0, 0.15, 2, 2, 2)
INSERT [dbo].[Orden_Pedido_Autopartes] ([OrdenAutoparteID], [FechaOrden], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (3, CAST(N'2023-07-22' AS Date), CAST(N'2023-07-27' AS Date), 0, 0, 3, 3, 3)
SET IDENTITY_INSERT [dbo].[Orden_Pedido_Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Orden_Pedido_Autos] ON 

INSERT [dbo].[Orden_Pedido_Autos] ([OrdenAutosID], [FechaOrden], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (1, CAST(N'2023-07-20' AS Date), CAST(N'2023-07-25' AS Date), 0.3, 0, 1, 1, 1)
INSERT [dbo].[Orden_Pedido_Autos] ([OrdenAutosID], [FechaOrden], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (2, CAST(N'2023-07-21' AS Date), CAST(N'2023-07-26' AS Date), 0.07, 0, 2, 2, 2)
INSERT [dbo].[Orden_Pedido_Autos] ([OrdenAutosID], [FechaOrden], [FechaPago], [Intereses], [Descuento], [FK_ClienteID], [FK_FormaPagoID], [FK_FormaEnvioID]) VALUES (3, CAST(N'2023-07-22' AS Date), CAST(N'2023-07-27' AS Date), 0.09, 0, 3, 3, 3)
SET IDENTITY_INSERT [dbo].[Orden_Pedido_Autos] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([ProvinciaID], [Nombre]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[Provincias] ([ProvinciaID], [Nombre]) VALUES (2, N'Córdoba')
INSERT [dbo].[Provincias] ([ProvinciaID], [Nombre]) VALUES (3, N'Santa Fe')
INSERT [dbo].[Provincias] ([ProvinciaID], [Nombre]) VALUES (4, N'Entre Ríos')
INSERT [dbo].[Provincias] ([ProvinciaID], [Nombre]) VALUES (5, N'Mendoza')
SET IDENTITY_INSERT [dbo].[Provincias] OFF
SET IDENTITY_INSERT [dbo].[Tipo_Autopartes] ON 

INSERT [dbo].[Tipo_Autopartes] ([Tipo_autoparteID], [descripcion]) VALUES (1, N'Motor')
INSERT [dbo].[Tipo_Autopartes] ([Tipo_autoparteID], [descripcion]) VALUES (2, N'Chasis')
INSERT [dbo].[Tipo_Autopartes] ([Tipo_autoparteID], [descripcion]) VALUES (3, N'Amortiguadores')
INSERT [dbo].[Tipo_Autopartes] ([Tipo_autoparteID], [descripcion]) VALUES (4, N'Caja de Cambios')
INSERT [dbo].[Tipo_Autopartes] ([Tipo_autoparteID], [descripcion]) VALUES (5, N'Frenos')
SET IDENTITY_INSERT [dbo].[Tipo_Autopartes] OFF
SET IDENTITY_INSERT [dbo].[Tipos] ON 

INSERT [dbo].[Tipos] ([TipoID], [Tipo]) VALUES (1, N'Auto')
INSERT [dbo].[Tipos] ([TipoID], [Tipo]) VALUES (2, N'Camioneta')
INSERT [dbo].[Tipos] ([TipoID], [Tipo]) VALUES (3, N'SUV')
INSERT [dbo].[Tipos] ([TipoID], [Tipo]) VALUES (4, N'Deportivo')
INSERT [dbo].[Tipos] ([TipoID], [Tipo]) VALUES (5, N'Sedan')
SET IDENTITY_INSERT [dbo].[Tipos] OFF
SET IDENTITY_INSERT [dbo].[Tipos_Cliente] ON 

INSERT [dbo].[Tipos_Cliente] ([TipoClienteID], [TipoCliente]) VALUES (1, N'Consumidor final')
INSERT [dbo].[Tipos_Cliente] ([TipoClienteID], [TipoCliente]) VALUES (2, N'Revendedor de autopartes')
INSERT [dbo].[Tipos_Cliente] ([TipoClienteID], [TipoCliente]) VALUES (3, N'Revendedor de autos')
INSERT [dbo].[Tipos_Cliente] ([TipoClienteID], [TipoCliente]) VALUES (4, N'Gobierno')
SET IDENTITY_INSERT [dbo].[Tipos_Cliente] OFF
SET IDENTITY_INSERT [dbo].[Tipos_Combustible] ON 

INSERT [dbo].[Tipos_Combustible] ([Tipo_CombustibleID], [TipoCombustible]) VALUES (1, N'Nafta')
INSERT [dbo].[Tipos_Combustible] ([Tipo_CombustibleID], [TipoCombustible]) VALUES (2, N'Diesel')
INSERT [dbo].[Tipos_Combustible] ([Tipo_CombustibleID], [TipoCombustible]) VALUES (3, N'GNC')
INSERT [dbo].[Tipos_Combustible] ([Tipo_CombustibleID], [TipoCombustible]) VALUES (4, N'Eléctrico')
INSERT [dbo].[Tipos_Combustible] ([Tipo_CombustibleID], [TipoCombustible]) VALUES (5, N'Híbrido')
SET IDENTITY_INSERT [dbo].[Tipos_Combustible] OFF
SET IDENTITY_INSERT [dbo].[Tipos_Contactos] ON 

INSERT [dbo].[Tipos_Contactos] ([TipoContactoID], [TipoContacto]) VALUES (1, N'Teléfono')
INSERT [dbo].[Tipos_Contactos] ([TipoContactoID], [TipoContacto]) VALUES (2, N'Email')
SET IDENTITY_INSERT [dbo].[Tipos_Contactos] OFF
SET IDENTITY_INSERT [dbo].[Tipos_Motor] ON 

INSERT [dbo].[Tipos_Motor] ([Motor_ID], [Motor]) VALUES (1, N'1.6L')
INSERT [dbo].[Tipos_Motor] ([Motor_ID], [Motor]) VALUES (2, N'1.8L')
INSERT [dbo].[Tipos_Motor] ([Motor_ID], [Motor]) VALUES (3, N'2.0L')
INSERT [dbo].[Tipos_Motor] ([Motor_ID], [Motor]) VALUES (4, N'2.5L')
INSERT [dbo].[Tipos_Motor] ([Motor_ID], [Motor]) VALUES (5, N'3.0L')
SET IDENTITY_INSERT [dbo].[Tipos_Motor] OFF
SET IDENTITY_INSERT [dbo].[Tipos_Transmision] ON 

INSERT [dbo].[Tipos_Transmision] ([Tipo_TransmisionID], [TipoTransmision]) VALUES (1, N'Manual')
INSERT [dbo].[Tipos_Transmision] ([Tipo_TransmisionID], [TipoTransmision]) VALUES (2, N'Automática')
INSERT [dbo].[Tipos_Transmision] ([Tipo_TransmisionID], [TipoTransmision]) VALUES (3, N'CVT')
INSERT [dbo].[Tipos_Transmision] ([Tipo_TransmisionID], [TipoTransmision]) VALUES (4, N'DCT')
INSERT [dbo].[Tipos_Transmision] ([Tipo_TransmisionID], [TipoTransmision]) VALUES (5, N'AMT')
SET IDENTITY_INSERT [dbo].[Tipos_Transmision] OFF
ALTER TABLE [dbo].[Autopartes]  WITH CHECK ADD  CONSTRAINT [FK_modelo_autopartes] FOREIGN KEY([FK_modelo_autoparteID])
REFERENCES [dbo].[Modelo_Autopartes] ([Modelo_autoparteID])
GO
ALTER TABLE [dbo].[Autopartes] CHECK CONSTRAINT [FK_modelo_autopartes]
GO
ALTER TABLE [dbo].[Autopartes]  WITH CHECK ADD  CONSTRAINT [FK_tipo_autopartes] FOREIGN KEY([FK_tipo_autoparteID])
REFERENCES [dbo].[Tipo_Autopartes] ([Tipo_autoparteID])
GO
ALTER TABLE [dbo].[Autopartes] CHECK CONSTRAINT [FK_tipo_autopartes]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_ColorID] FOREIGN KEY([FK_ColorID])
REFERENCES [dbo].[Colores] ([ColorID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_ColorID]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_MarcaID] FOREIGN KEY([FK_MarcaID])
REFERENCES [dbo].[Marcas] ([MarcaID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_MarcaID]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_ModeloID] FOREIGN KEY([FK_ModeloID])
REFERENCES [dbo].[Modelos] ([ModeloID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_ModeloID]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_TipoCombustibleID] FOREIGN KEY([FK_Tipo_CombustibleID])
REFERENCES [dbo].[Tipos_Combustible] ([Tipo_CombustibleID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_TipoCombustibleID]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_TipoID] FOREIGN KEY([FK_TipoID])
REFERENCES [dbo].[Tipos] ([TipoID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_TipoID]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Tipos_MotorID] FOREIGN KEY([FK_Tipos_MotorID])
REFERENCES [dbo].[Tipos_Motor] ([Motor_ID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Tipos_MotorID]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_TipoTransmisionID] FOREIGN KEY([FK_Tipo_TransmisionID])
REFERENCES [dbo].[Tipos_Transmision] ([Tipo_TransmisionID])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_TipoTransmisionID]
GO
ALTER TABLE [dbo].[Barrios]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Barrios] FOREIGN KEY([FK_LocalidadID])
REFERENCES [dbo].[Localidades] ([LocalidadID])
GO
ALTER TABLE [dbo].[Barrios] CHECK CONSTRAINT [FK_Localidades_Barrios]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Barrio_Cliente] FOREIGN KEY([FK_BarrioID])
REFERENCES [dbo].[Barrios] ([BarrioID])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Barrio_Cliente]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_TipoCliente_Cliente] FOREIGN KEY([FK_TipoCliente])
REFERENCES [dbo].[Tipos_Cliente] ([TipoClienteID])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_TipoCliente_Cliente]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Cliente] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contacto_Cliente]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Tipos_Contactos] FOREIGN KEY([FK_Tipos_Contacto])
REFERENCES [dbo].[Tipos_Contactos] ([TipoContactoID])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Tipos_Contactos]
GO
ALTER TABLE [dbo].[Detalle_Factura_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_autoparte_detalle] FOREIGN KEY([FK_AutoparteID])
REFERENCES [dbo].[Autopartes] ([AutoparteID])
GO
ALTER TABLE [dbo].[Detalle_Factura_Autopartes] CHECK CONSTRAINT [fk_autoparte_detalle]
GO
ALTER TABLE [dbo].[Detalle_Factura_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_factura_autoparte_detalle] FOREIGN KEY([FK_FacturaAutoparteID])
REFERENCES [dbo].[Factura_Autopartes] ([FacturaAutoparteID])
GO
ALTER TABLE [dbo].[Detalle_Factura_Autopartes] CHECK CONSTRAINT [fk_factura_autoparte_detalle]
GO
ALTER TABLE [dbo].[Detalle_Factura_Autos]  WITH CHECK ADD  CONSTRAINT [fk_auto_detalle] FOREIGN KEY([FK_AutoID])
REFERENCES [dbo].[Autos] ([AutoID])
GO
ALTER TABLE [dbo].[Detalle_Factura_Autos] CHECK CONSTRAINT [fk_auto_detalle]
GO
ALTER TABLE [dbo].[Detalle_Factura_Autos]  WITH CHECK ADD  CONSTRAINT [fk_factura_auto_detalle] FOREIGN KEY([FK_FacturaAutoID])
REFERENCES [dbo].[Factura_Autos] ([FacturaAutoID])
GO
ALTER TABLE [dbo].[Detalle_Factura_Autos] CHECK CONSTRAINT [fk_factura_auto_detalle]
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_autoparte_autopartes] FOREIGN KEY([FK_AutoparteID])
REFERENCES [dbo].[Autopartes] ([AutoparteID])
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autopartes] CHECK CONSTRAINT [fk_autoparte_autopartes]
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_detalle_orden_autoparte] FOREIGN KEY([FK_OrdenAutoparte])
REFERENCES [dbo].[Orden_Pedido_Autopartes] ([OrdenAutoparteID])
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autopartes] CHECK CONSTRAINT [fk_detalle_orden_autoparte]
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autos]  WITH CHECK ADD  CONSTRAINT [fk_auto_autos] FOREIGN KEY([FK_AutoID])
REFERENCES [dbo].[Autos] ([AutoID])
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autos] CHECK CONSTRAINT [fk_auto_autos]
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autos]  WITH CHECK ADD  CONSTRAINT [fk_detalle_orden_auto] FOREIGN KEY([FK_OrdenAuto])
REFERENCES [dbo].[Orden_Pedido_Autos] ([OrdenAutosID])
GO
ALTER TABLE [dbo].[Detalle_Orden_Pedido_Autos] CHECK CONSTRAINT [fk_detalle_orden_auto]
GO
ALTER TABLE [dbo].[Factura_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_cliente_factura_autoparte] FOREIGN KEY([FK_ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Factura_Autopartes] CHECK CONSTRAINT [fk_cliente_factura_autoparte]
GO
ALTER TABLE [dbo].[Factura_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_forma_envio_factura_autoparte] FOREIGN KEY([FK_FormaEnvioID])
REFERENCES [dbo].[Forma_Envio] ([FormaEnvioID])
GO
ALTER TABLE [dbo].[Factura_Autopartes] CHECK CONSTRAINT [fk_forma_envio_factura_autoparte]
GO
ALTER TABLE [dbo].[Factura_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_forma_pago_factura_autoparte] FOREIGN KEY([FK_FormaPagoID])
REFERENCES [dbo].[Forma_Pago] ([FormaPagoID])
GO
ALTER TABLE [dbo].[Factura_Autopartes] CHECK CONSTRAINT [fk_forma_pago_factura_autoparte]
GO
ALTER TABLE [dbo].[Factura_Autos]  WITH CHECK ADD  CONSTRAINT [fk_cliente_factura_auto] FOREIGN KEY([FK_ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Factura_Autos] CHECK CONSTRAINT [fk_cliente_factura_auto]
GO
ALTER TABLE [dbo].[Factura_Autos]  WITH CHECK ADD  CONSTRAINT [fk_forma_envio_factura_auto] FOREIGN KEY([FK_FormaEnvioID])
REFERENCES [dbo].[Forma_Envio] ([FormaEnvioID])
GO
ALTER TABLE [dbo].[Factura_Autos] CHECK CONSTRAINT [fk_forma_envio_factura_auto]
GO
ALTER TABLE [dbo].[Factura_Autos]  WITH CHECK ADD  CONSTRAINT [fk_forma_pago_factura_auto] FOREIGN KEY([FK_FormaPagoID])
REFERENCES [dbo].[Forma_Pago] ([FormaPagoID])
GO
ALTER TABLE [dbo].[Factura_Autos] CHECK CONSTRAINT [fk_forma_pago_factura_auto]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Provincias_Localidades] FOREIGN KEY([FK_ProvinciaID])
REFERENCES [dbo].[Provincias] ([ProvinciaID])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Provincias_Localidades]
GO
ALTER TABLE [dbo].[Orden_Pedido_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_cliente_autopartes] FOREIGN KEY([FK_ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Orden_Pedido_Autopartes] CHECK CONSTRAINT [fk_cliente_autopartes]
GO
ALTER TABLE [dbo].[Orden_Pedido_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_forma_envio_orden_autoparte] FOREIGN KEY([FK_FormaEnvioID])
REFERENCES [dbo].[Forma_Envio] ([FormaEnvioID])
GO
ALTER TABLE [dbo].[Orden_Pedido_Autopartes] CHECK CONSTRAINT [fk_forma_envio_orden_autoparte]
GO
ALTER TABLE [dbo].[Orden_Pedido_Autopartes]  WITH CHECK ADD  CONSTRAINT [fk_forma_pago_orden_autoparte] FOREIGN KEY([FK_FormaPagoID])
REFERENCES [dbo].[Forma_Pago] ([FormaPagoID])
GO
ALTER TABLE [dbo].[Orden_Pedido_Autopartes] CHECK CONSTRAINT [fk_forma_pago_orden_autoparte]
GO
ALTER TABLE [dbo].[Orden_Pedido_Autos]  WITH CHECK ADD  CONSTRAINT [fk_cliente_autos] FOREIGN KEY([FK_ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Orden_Pedido_Autos] CHECK CONSTRAINT [fk_cliente_autos]
GO
ALTER TABLE [dbo].[Orden_Pedido_Autos]  WITH CHECK ADD  CONSTRAINT [fk_forma_envio_orden_auto] FOREIGN KEY([FK_FormaEnvioID])
REFERENCES [dbo].[Forma_Envio] ([FormaEnvioID])
GO
ALTER TABLE [dbo].[Orden_Pedido_Autos] CHECK CONSTRAINT [fk_forma_envio_orden_auto]
GO
ALTER TABLE [dbo].[Orden_Pedido_Autos]  WITH CHECK ADD  CONSTRAINT [fk_forma_pago_orden_auto] FOREIGN KEY([FK_FormaPagoID])
REFERENCES [dbo].[Forma_Pago] ([FormaPagoID])
GO
ALTER TABLE [dbo].[Orden_Pedido_Autos] CHECK CONSTRAINT [fk_forma_pago_orden_auto]
GO
/****** Object:  StoredProcedure [dbo].[SP_AUTOSNOVENDIDOS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AUTOSNOVENDIDOS]
AS
BEGIN

SELECT
  M.Modelo AS 'Modelo de auto',
  MA.Marca AS 'Marca',
  TT.TipoTransmision AS 'Transmision',
  TC.TipoCombustible AS 'Combustible',
  A.Capacidad AS 'Capacidad',
  A.NroCilindros AS 'Nro Cilindros',
  A.NroPuertas AS 'Nro Puertas'
FROM Autos A
JOIN Modelos M
ON A.FK_ModeloID = M.ModeloID
JOIN Marcas MA
ON A.FK_MarcaID = MA.MarcaID
JOIN Tipos_Motor TM
ON A.FK_Tipos_MotorID = TM.Motor_ID
JOIN Tipos_Transmision TT
ON A.FK_Tipo_TransmisionID = TT.Tipo_TransmisionID
JOIN Tipos_Combustible TC
ON A.FK_Tipo_CombustibleID = TC.Tipo_CombustibleID
WHERE A.AutoID NOT IN (
  SELECT FK_AutoID
  FROM Detalle_Factura_Autos
)
ORDER BY [Modelo de auto]

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_AUTOS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_AUTOS]
AS
BEGIN
	SELECT a.*,m.*,c.*,ma.*,tm.*,tc.*,tt.*,t.*, ma.Marca + '-' + m.Modelo + '-' + cast(a.Año as varchar) +' Color: ' +c.Color AS alias
	FROM Autos a
	JOIN Modelos m on m.ModeloID = a.FK_ModeloID
	JOIN Colores c on c.ColorID = a.FK_ColorID
	JOIN Marcas ma on ma.MarcaID = a.FK_MarcaID
	JOIN Tipos_Motor tm on tm.Motor_ID = a.FK_Tipos_MotorID
	JOIN Tipos_Combustible tc on tc.Tipo_CombustibleID = a.FK_Tipo_CombustibleID
	JOIN Tipos_Transmision tt on tt.Tipo_TransmisionID = a.FK_Tipo_TransmisionID
	JOIN Tipos t on t.TipoID = a.FK_TipoID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_AUTOS_GRILLA]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_AUTOS_GRILLA]
AS
BEGIN
	SELECT a.AutoID,ma.Marca , m.Modelo ,a.Año ,c.Color
	FROM Autos a
	JOIN Modelos m on m.ModeloID = a.FK_ModeloID
	JOIN Colores c on c.ColorID = a.FK_ColorID
	JOIN Marcas ma on ma.MarcaID = a.FK_MarcaID
	JOIN Tipos_Motor tm on tm.Motor_ID = a.FK_Tipos_MotorID
	JOIN Tipos_Combustible tc on tc.Tipo_CombustibleID = a.FK_Tipo_CombustibleID
	JOIN Tipos_Transmision tt on tt.Tipo_TransmisionID = a.FK_Tipo_TransmisionID
	JOIN Tipos t on t.TipoID = a.FK_TipoID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_AUTOS_GRILLA_MARCA]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_AUTOS_GRILLA_MARCA]
@Marcaid int
AS
BEGIN
	SELECT a.AutoID,ma.Marca , m.Modelo ,a.Año ,c.Color
	FROM Autos a
	JOIN Modelos m on m.ModeloID = a.FK_ModeloID
	JOIN Colores c on c.ColorID = a.FK_ColorID
	JOIN Marcas ma on ma.MarcaID = a.FK_MarcaID
	JOIN Tipos_Motor tm on tm.Motor_ID = a.FK_Tipos_MotorID
	JOIN Tipos_Combustible tc on tc.Tipo_CombustibleID = a.FK_Tipo_CombustibleID
	JOIN Tipos_Transmision tt on tt.Tipo_TransmisionID = a.FK_Tipo_TransmisionID
	JOIN Tipos t on t.TipoID = a.FK_TipoID
	WHERE @Marcaid = ma.MarcaID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CLIENTES]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CONSULTAR_CLIENTES]
as
begin
SELECT c.*,b.*,tc.*,l.*,p.*,co.*,tcc.*, c.Razon_Social + ' - Cuit/Cuil: ' + CAST(c.CUIT_CUIL as varchar) as alias
FROM Clientes c
join Barrios b on b.BarrioID = c.FK_BarrioID
join Tipos_Cliente tc on tc.TipoClienteID = c.FK_TipoCliente
join Localidades l on l.LocalidadID = b.FK_LocalidadID
join Provincias p on p.ProvinciaID = l.FK_ProvinciaID
LEFT join Contactos co on co.ClienteID = c.ClienteID
LEFT join Tipos_Contactos tcc on tcc.TipoContactoID = co.FK_Tipos_Contacto
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CLIENTES2]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CONSULTAR_CLIENTES2]
as
begin
SELECT c.ClienteID,c.Razon_Social,c.Calle,c.Altura,c.CUIT_CUIL,b.Nombre,tc.TipoCliente,co.Contacto
FROM Clientes c
join Barrios b on b.BarrioID = c.FK_BarrioID
join Tipos_Cliente tc on tc.TipoClienteID = c.FK_TipoCliente
join Localidades l on l.LocalidadID = b.FK_LocalidadID
join Provincias p on p.ProvinciaID = l.FK_ProvinciaID
LEFT join Contactos co on co.ClienteID = c.ClienteID
LEFT join Tipos_Contactos tcc on tcc.TipoContactoID = co.FK_Tipos_Contacto
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_COLORES]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_CONSULTAR_COLORES]
as
begin
select * from Colores
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CONTACTOS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_CONTACTOS]
@id int
as
begin
SELECT c.*, tc.*
FROM Contactos c
join Tipos_Contactos tc on tc.TipoContactoID = c.FK_Tipos_Contacto
WHERE @id = c.ClienteID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLE_FACTURA_AUTO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_DETALLE_FACTURA_AUTO]
	@factura_nro int
AS
BEGIN
	SELECT df.*,a.*, m.*,ma.*,tt.*,co.*,tc.*,ti.*, tm.*
	FROM Detalle_Factura_Autos df
	JOIN Factura_Autos fa ON fa.FacturaAutoID = df.FK_FacturaAutoID
	JOIN Autos a on a.AutoID = df.FK_AutoID
	JOIN Modelos m on m.ModeloID = a.FK_ModeloID
	JOIN Marcas ma on ma.MarcaID = a.FK_MarcaID
	JOIN Tipos_Transmision tt on tt.Tipo_TransmisionID = a.FK_Tipo_TransmisionID
	JOIN Colores co on co.ColorID = a.FK_ColorID
	JOIN Tipos_Combustible tc on tc.Tipo_CombustibleID = a.FK_Tipo_CombustibleID
	JOIN Tipos ti on ti.TipoID = a.FK_TipoID
	JOIN Tipos_Motor tm on tm.Motor_ID = a.FK_Tipos_MotorID
	WHERE @factura_nro = fa.FacturaAutoID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLE_FACTURA_AUTO_GRILLA]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_DETALLE_FACTURA_AUTO_GRILLA]
    @factura_nro int
AS
BEGIN
    SELECT df.DetalleFacturaAutoID ID, ma.Marca, m.Modelo, a.Año,  df.Cantidad, df.Subtotal
    FROM Detalle_Factura_Autos df
    JOIN Factura_Autos fa ON fa.FacturaAutoID = df.FK_FacturaAutoID
    JOIN Autos a on a.AutoID = df.FK_AutoID
    JOIN Modelos m on m.ModeloID = a.FK_ModeloID
    JOIN Marcas ma on ma.MarcaID = a.FK_MarcaID
    JOIN Tipos_Transmision tt on tt.Tipo_TransmisionID = a.FK_Tipo_TransmisionID
    JOIN Colores co on co.ColorID = a.FK_ColorID
    JOIN Tipos_Combustible tc on tc.Tipo_CombustibleID = a.FK_Tipo_CombustibleID
    JOIN Tipos ti on ti.TipoID = a.FK_TipoID
    WHERE @factura_nro = df.FK_FacturaAutoID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FACTURA_AUTO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_FACTURA_AUTO]
	@factura_nro int
AS
BEGIN
	SELECT fa.*, c.*, fp.* , fe.*, df.*,b.*,tcl.*
	FROM Factura_Autos fa
	JOIN Clientes c on c.ClienteID = fa.FK_ClienteID
	JOIN Forma_Pago fp on fp.FormaPagoID = fa.FK_FormaPagoID
	JOIN Forma_Envio fe on fe.FormaEnvioID = fa.FK_FormaEnvioID
	JOIN Detalle_Factura_Autos df on df.FK_FacturaAutoID = fa.FacturaAutoID

	JOIN Barrios b on b.BarrioID = c.FK_BarrioID
	JOIN Tipos_Cliente tcl on tcl.TipoClienteID = c.FK_TipoCliente
	WHERE @factura_nro = fa.FacturaAutoID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FACTURA_AUTO_CBO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_FACTURA_AUTO_CBO]
AS
BEGIN
	SELECT fa.*, c.*, fp.* , fe.*, df.*,b.*,tcl.*,'ID Factura: '+ CAST(fa.FacturaAutoID as varchar) + 'Fecha: ' + CAST(fa.FechaFactura as varchar) + 'Razon Social: ' + c.Razon_Social + 'Cuit/Cuil: ' + CAST(c.CUIT_CUIL as varchar) AS 'alias'
	FROM Factura_Autos fa
	JOIN Clientes c on c.ClienteID = fa.FK_ClienteID
	JOIN Forma_Pago fp on fp.FormaPagoID = fa.FK_FormaPagoID
	JOIN Forma_Envio fe on fe.FormaEnvioID = fa.FK_FormaEnvioID
	JOIN Detalle_Factura_Autos df on df.FK_FacturaAutoID = fa.FacturaAutoID
	JOIN Barrios b on b.BarrioID = c.FK_BarrioID
	JOIN Tipos_Cliente tcl on tcl.TipoClienteID = c.FK_TipoCliente
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FACTURA_AUTO_UPDATE]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_FACTURA_AUTO_UPDATE]
as
begin

select  fa.*,dfa.*,cl.*,fe.*,fp.*,b.Nombre Barrio, b.BarrioID,l.LocalidadID, l.Nombre Localidad,p.ProvinciaID, p.Nombre Provincia,tc.*,a.*,m.*,c.*,ma.*,tm.*,tco.*,tt.*,t.*
from Factura_Autos fa 
Join Detalle_Factura_Autos dfa on dfa.FK_FacturaAutoID = fa.FacturaAutoID
Join Clientes cl on cl.ClienteID = fa.FK_ClienteID
Join Forma_Envio fe on fe.FormaEnvioID = fa.FK_FormaEnvioID
Join Forma_Pago fp on fp.FormaPagoID = fa.FK_FormaPagoID
Join Barrios b on b.BarrioID = cl.FK_BarrioID
Join Localidades l on l.LocalidadID = b.FK_LocalidadID
Join Provincias p on p.ProvinciaID = l.FK_ProvinciaID
Join Tipos_Cliente tc on tc.TipoClienteID = cl.FK_TipoCliente
Join Autos a on a.AutoID = dfa.FK_AutoID
JOIN Modelos m on m.ModeloID = a.FK_ModeloID
JOIN Colores c on c.ColorID = a.FK_ColorID
JOIN Marcas ma on ma.MarcaID = a.FK_MarcaID
JOIN Tipos_Motor tm on tm.Motor_ID = a.FK_Tipos_MotorID
JOIN Tipos_Combustible tco on tco.Tipo_CombustibleID = a.FK_Tipo_CombustibleID
JOIN Tipos_Transmision tt on tt.Tipo_TransmisionID = a.FK_Tipo_TransmisionID
JOIN Tipos t on t.TipoID = a.FK_TipoID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FACTURA_FECHA]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_FACTURA_FECHA]
	@desde datetime,
	@hasta datetime,
	@cliente int
AS
BEGIN
	SELECT Distinct fa.FacturaAutoID 'ID Factura',c.Razon_Social 'Cliente',fa.FechaFactura 'Fecha',fa.FechaPago 'Fecha Pago'
	FROM Factura_Autos fa
	JOIN Clientes c on c.ClienteID = fa.FK_ClienteID
	JOIN Forma_Pago fp on fp.FormaPagoID = fa.FK_FormaPagoID
	JOIN Forma_Envio fe on fe.FormaEnvioID = fa.FK_FormaEnvioID
	JOIN Detalle_Factura_Autos df on df.FK_FacturaAutoID = fa.FacturaAutoID
	JOIN Barrios b on b.BarrioID = c.FK_BarrioID
	JOIN Autos a on a.AutoID = df.FK_AutoID
	JOIN Tipos_Cliente tcl on tcl.TipoClienteID = c.FK_TipoCliente
	WHERE fa.FechaFactura between @desde and @hasta
	and @cliente = c.ClienteID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FORMAS_ENVIO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_FORMAS_ENVIO]
as
begin
SELECT * FROM Forma_Envio
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FORMAS_PAGO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_FORMAS_PAGO]
as
begin
SELECT * FROM Forma_Pago
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_MARCAS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_CONSULTAR_MARCAS]
as
begin
select * from Marcas
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_MODELOS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_CONSULTAR_MODELOS]
as
begin
select * from Modelos
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TIPO_COMBUSTIBLE]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_TIPO_COMBUSTIBLE]
as
begin
select * from Tipos_Combustible
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TIPO_MOTOR]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_TIPO_MOTOR]
as
begin
select * from Tipos_Motor
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TIPO_TRANSMISION]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_TIPO_TRANSMISION]
as
begin
select * from Tipos_Transmision
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TIPOS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_TIPOS]
as
begin
select * from Tipos
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_AUTO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_AUTO]
	@AutoId int
AS
BEGIN
	DELETE Autos
	WHERE AutoID = @AutoId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_facturasConImporteSuperiorPromedio]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_facturasConImporteSuperiorPromedio]
AS
BEGIN
    SELECT
        fa.FacturaAutoID AS 'Nro Cliente',
        FechaFactura AS 'Fecha',
        c.Razon_Social AS 'Razon Social',
        tc.TipoCliente AS 'Tipo De Cliente'
    FROM Factura_Autos fa
    JOIN Detalle_Factura_Autos dfa ON fa.FacturaAutoID = dfa.FK_FacturaAutoID
    JOIN Clientes c ON c.ClienteID = fa.FK_ClienteID
    JOIN Tipos_Cliente tc ON tc.TipoClienteID = c.FK_TipoCliente
	JOIN Forma_Pago fp ON fa.FK_FormaPagoID=fp.FormaPagoID
    WHERE
        tc.TipoCliente = 'Consumidor Final'
        AND fp.FormaPago = 'Efectivo'
    GROUP BY
        fa.FacturaAutoID,
        FechaFactura,
        c.Razon_Social,
        tc.TipoCliente
    HAVING
        SUM((dfa.Subtotal * dfa.Cantidad) * (1 + fa.Intereses) * (1 - fa.Descuento))
        >
        (
            SELECT AVG(TotalAmount)
            FROM (
                SELECT
                    SUM((dfa.Subtotal * dfa.Cantidad) * (1 + fa.Intereses) * (1 - fa.Descuento)) AS TotalAmount
                FROM Factura_Autos fa
                JOIN Detalle_Factura_Autos dfa ON fa.FacturaAutoID = dfa.FK_FacturaAutoID
				JOIN Clientes c ON c.ClienteID = fa.FK_ClienteID
				JOIN Tipos_Cliente tc ON tc.TipoClienteID = c.FK_TipoCliente
				JOIN Forma_Pago fp ON fa.FK_FormaPagoID=fp.FormaPagoID 
                WHERE tc.TipoCliente = 'Consumidor Final' AND fp.FormaPago = 'Efectivo'
                GROUP BY fa.FacturaAutoID
            ) AS AvgAmount
        )
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_AUTO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_AUTO]
@año int,
@capacidad decimal,
@nro_puertas int,
@nro_cilindros int,
@precio_unitario float,
@id_ModeloId int,
@id_ColorId int,
@id_Tipos_MotorId int,
@id_Tipos_TransmisionId int,
@id_Tipos_CombustibleId int,
@id_MarcaId int,
@id_TipoId int,
@AutoId int OUTPUT
AS
BEGIN
	INSERT INTO AUTOS (Año,Capacidad,NroPuertas,NroCilindros,
	FK_ModeloID,FK_ColorID,FK_Tipos_MotorID,FK_Tipo_TransmisionID,FK_Tipo_CombustibleID,
	FK_MarcaID,FK_TipoID,precio_unitario)
	VALUES (@año,@capacidad,@nro_puertas,@nro_cilindros,
	@id_ModeloId,@id_ColorId,@id_Tipos_MotorId,@id_Tipos_TransmisionId,
	@id_Tipos_CombustibleId,@id_MarcaId,@id_TipoId,@precio_unitario);
	SET @AutoId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
    @id_factura_auto int,
    @id_auto int, 
    @subtotal float, 
    @cantidad int
AS
BEGIN
    INSERT INTO Detalle_Factura_Autos(FK_FacturaAutoID,FK_AutoID, Subtotal, Cantidad)
    VALUES (@id_factura_auto, @id_auto, @subtotal, @cantidad);

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO]
    @fechapago date,
    @intereses float,
    @descuento float,
    @id_cliente int,
    @id_forma_pago int,
    @id_forma_envio int,
    @factura_nro int OUTPUT
AS
BEGIN
    INSERT INTO Factura_Autos(FechaFactura, FechaPago, Intereses,Descuento,FK_ClienteID,FK_FormaPagoID,FK_FormaEnvioID)
    VALUES (GETDATE(), @fechapago, @intereses, @descuento,@id_cliente,@id_forma_pago,@id_forma_envio);
    --Asignamos el valor del último ID autogenerado (obtenido --
    --mediante la función SCOPE_IDENTITY() de SQLServer)
    SET @factura_nro = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCA_AUTO_MAS_VENDIDAS]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_MARCA_AUTO_MAS_VENDIDAS]
@fechaDesde date,
@fechaHasta date
as
begin
	select m.Marca, count(df.Cantidad) as Cantidad
	from Factura_Autos fa
	join Detalle_Factura_Autos df on fa.FacturaAutoId=df.FK_FacturaAutoID
	join Autos a on df.FK_AutoID=a.AutoId
	join Marcas m on a.FK_MarcaID=MarcaID
	where fa.FechaFactura between @fechaDesde and @fechaHasta
	group by m.Marca
end
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_AUTO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_AUTO]
(@AutoId INT,
@Año INT,
@Capacidad DECIMAL,
@NroPuertas INT,
@ModeloId INT,
@ColorId INT,
@MotorId INT,
@TransmisionId INT,
@CombustibleId INT,
@MarcaId INT,
@TipoId INT,
@precio_unitario FLOAT)
AS
BEGIN
    UPDATE Autos
    SET
        Año = @Año,
        Capacidad = @Capacidad,
        NroPuertas = @NroPuertas,
        FK_ModeloID = @ModeloId,
        FK_ColorID = @ColorId,
        FK_Tipos_MotorID = @MotorId,
        FK_Tipo_TransmisionID = @TransmisionId,
        FK_Tipo_CombustibleID = @CombustibleId,
        FK_MarcaID = @MarcaId,
        FK_TipoID = @TipoId,
		precio_unitario = @precio_unitario
    WHERE AutoId = @AutoId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_MAESTRO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_MAESTRO]
	@fechapago date,
	@intereses float,
	@descuento float,
	@id_cliente int,
	@id_forma_pago int,
	@id_forma_envio int,
	@factura_nro int
AS
BEGIN
	UPDATE Factura_Autos SET FechaPago = @fechapago, Intereses = @intereses, Descuento = @descuento,FK_ClienteID = @id_cliente, FK_FormaPagoID = @id_forma_pago, FK_FormaEnvioID = @id_forma_envio, FechaFactura = GETDATE()
	WHERE FacturaAutoID = @factura_nro;
	
	DELETE Detalle_Factura_Autos
	WHERE FK_FacturaAutoID = @factura_nro;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MONTOTOTALVENTACLIENTE]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MONTOTOTALVENTACLIENTE]
@ClienteID int,
@fechaInicio date,
@fechaFin date
AS
BEGIN

DECLARE @montoTotal money

SELECT @montoTotal = SUM((dfa.Subtotal * dfa.Cantidad) * (1 + fa.Intereses) * (1 - fa.Descuento))
FROM Clientes c
JOIN Factura_Autos fa
ON c.ClienteID = fa.FK_ClienteID
JOIN Detalle_Factura_Autos dfa
ON fa.FacturaAutoID = dfa.FK_FacturaAutoID
WHERE c.ClienteID = @ClienteID
AND DATEDIFF(DAY, fa.FechaFactura, @fechaFin) >= 0
AND DATEDIFF(DAY, fa.FechaFactura, @fechaInicio) <= 0

SELECT @montoTotal 'Monto Total', @fechaInicio 'Fecha de inicio', @fechaFin 'Fecha de fin'

END
GO
/****** Object:  StoredProcedure [dbo].[sp_montoTotalVentasCliente]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_montoTotalVentasCliente]
@ClienteID int,
@fechaInicio date,
@tipo int,
@fechaFin date
AS
BEGIN

DECLARE @montoTotal money

SELECT
  @montoTotal = SUM(
    CASE
      WHEN @tipo = 1 THEN (dfapartes.Subtotal * dfapartes.Cantidad) * (1 + fapartes.Intereses) * (1 - fapartes.Descuento)
      WHEN @tipo = 2 THEN (dfa.Subtotal * dfa.Cantidad) * (1 + fa.Intereses) * (1 - fa.Descuento)
    END
  )
FROM Clientes c
JOIN Factura_Autos fa
ON c.ClienteID = fa.FK_ClienteID
JOIN Detalle_Factura_Autos dfa
ON fa.FacturaAutoID = dfa.FK_FacturaAutoID
JOIN Factura_Autopartes fapartes
ON fapartes.FK_ClienteID =  c.ClienteID
JOIN Detalle_Factura_Autopartes dfapartes
ON fapartes.FacturaAutoparteID = dfapartes.FK_FacturaAutoparteID
WHERE c.ClienteID = @ClienteID
AND DATEDIFF(DAY, fa.FechaFactura, @fechaFin) >= 0
AND DATEDIFF(DAY, fa.FechaFactura, @fechaInicio) <= 0

SELECT @montoTotal

END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_AUTO]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_AUTO]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(AutoID)+1  FROM Autos);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_ID]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_ID]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(FacturaAutoID)+1  FROM Factura_Autos);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_total_facturacion_auto]    Script Date: 24/11/2023 21:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_total_facturacion_auto] @periodo_inicio DATETIME,
@periodo_fin DATETIME
 
AS BEGIN

-- Definición de variables
DECLARE @total_facturacion DECIMAL(10, 2); DECLARE @promedio_facturacion DECIMAL(10, 2);

-- Consulta principal
SELECT
@periodo_inicio AS Inicio,
@periodo_fin AS Fin,
SUM(
(f_detalle.Cantidad * a.precio_unitario) +
(f.intereses * (f_detalle.Cantidad * a.precio_unitario) / 100) - (f.descuento * (f_detalle.Cantidad * a.precio_unitario) / 100)
) AS 'Total Facturado', AVG(
f_detalle.Cantidad * a.precio_unitario +
(f.intereses * (f_detalle.Cantidad * a.precio_unitario) / 100) - (f.descuento * (f_detalle.Cantidad * a.precio_unitario) / 100)
) AS 'Promedio Facturado' FROM
dbo.Factura_Autos f
JOIN dbo.Detalle_Factura_Autos f_detalle ON f.FacturaAutoID = f_detalle.FK_FacturaAutoID
JOIN dbo.Autos a ON f_detalle.FK_AutoID = a.AutoID

WHERE
f.FechaFactura >= @periodo_inicio AND f.FechaFactura <= @periodo_fin;

END;

GO
USE [master]
GO
ALTER DATABASE [TPLAB3] SET  READ_WRITE 
GO
