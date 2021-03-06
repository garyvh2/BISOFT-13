USE [master]
GO
/****** Object:  Database [GranjaCenfotec]    Script Date: 3/4/2018 10:26:56 PM ******/
CREATE DATABASE [GranjaCenfotec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GranjaCenfotec', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\GranjaCenfotec.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GranjaCenfotec_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\GranjaCenfotec_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GranjaCenfotec] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GranjaCenfotec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GranjaCenfotec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET ARITHABORT OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GranjaCenfotec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GranjaCenfotec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GranjaCenfotec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GranjaCenfotec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET RECOVERY FULL 
GO
ALTER DATABASE [GranjaCenfotec] SET  MULTI_USER 
GO
ALTER DATABASE [GranjaCenfotec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GranjaCenfotec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GranjaCenfotec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GranjaCenfotec] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GranjaCenfotec] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GranjaCenfotec', N'ON'
GO
ALTER DATABASE [GranjaCenfotec] SET QUERY_STORE = OFF
GO
USE [GranjaCenfotec]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GranjaCenfotec]
GO
/****** Object:  Table [dbo].[ANIMAL]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANIMAL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_TIPO_ANIMAL] [int] NULL,
	[NOMBRE] [varchar](50) NULL,
	[EDAD] [float] NULL,
	[FECHA_NACIMIENTO] [datetime] NULL,
	[ALIMENTO] [varchar](50) NULL,
 CONSTRAINT [PK_ANIMAL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[APPMESSAGES]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPMESSAGES](
	[ID] [int] NULL,
	[TEXT] [varchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXCEPTIONS]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXCEPTIONS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODE] [int] NULL,
	[MESSAGE] [varchar](250) NULL,
	[STACKTRACE] [varchar](500) NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [PK_EXCEPTIONS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LINEA_DETALLE]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LINEA_DETALLE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_TIPO] [int] NULL,
	[ID_PEDIDO] [int] NULL,
	[NOMBRE] [varchar](150) NULL,
	[CANTIDAD] [float] NULL,
	[TOTAL] [float] NULL,
 CONSTRAINT [PK_LINEA_DETALLE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MENSAJES]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MENSAJES](
	[ID] [numeric](18, 0) NOT NULL,
	[MENSAJE] [varchar](200) NULL,
 CONSTRAINT [PK_MENSAJES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PEDIDO]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PEDIDO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL] [varchar](255) NULL,
	[FECHA] [datetime] NULL,
	[COMERCIO] [varchar](50) NULL,
	[DIRECCION] [varchar](250) NULL,
	[TOTAL] [float] NULL,
	[ESTADO] [int] NOT NULL,
 CONSTRAINT [PK_PEDIDOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCCION]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCCION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_ANIMAL] [int] NULL,
	[ID_TIPO_PRODUCCION] [int] NULL,
	[CANTIDAD] [float] NULL,
	[FECHA_REGISTRO] [datetime] NULL,
	[TOTAL] [float] NULL,
 CONSTRAINT [PK_PRODUCCION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_ANIMAL]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_ANIMAL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[GENERO] [varchar](50) NULL,
 CONSTRAINT [PK_TIPO_ANIMAL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION](
	[ID_TIPO_ANIMAL] [int] NOT NULL,
	[ID_TIPO_PRODUCCION] [int] NOT NULL,
 CONSTRAINT [PK_TIPO_ANIMAL_n_TIPO_PRODUCCION] PRIMARY KEY CLUSTERED 
(
	[ID_TIPO_ANIMAL] ASC,
	[ID_TIPO_PRODUCCION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_PRODUCCION]    Script Date: 3/4/2018 10:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_PRODUCCION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[VALOR] [float] NULL,
 CONSTRAINT [PK_TIPO_PRODUCCION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ANIMAL] ON 

INSERT [dbo].[ANIMAL] ([ID], [ID_TIPO_ANIMAL], [NOMBRE], [EDAD], [FECHA_NACIMIENTO], [ALIMENTO]) VALUES (4, 1, N'Juan', 3, CAST(N'2015-03-04T00:00:00.000' AS DateTime), N'Trigo')
INSERT [dbo].[ANIMAL] ([ID], [ID_TIPO_ANIMAL], [NOMBRE], [EDAD], [FECHA_NACIMIENTO], [ALIMENTO]) VALUES (5, 2, N'Carlos', 2, CAST(N'2016-04-02T00:00:00.000' AS DateTime), N'Pasto')
INSERT [dbo].[ANIMAL] ([ID], [ID_TIPO_ANIMAL], [NOMBRE], [EDAD], [FECHA_NACIMIENTO], [ALIMENTO]) VALUES (6, 3, N'Gary', 4, CAST(N'2014-09-07T00:00:00.000' AS DateTime), N'Pasto')
SET IDENTITY_INSERT [dbo].[ANIMAL] OFF
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (2, N'La edad de los animales debe ser de minimo 6 meses')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (3, N'Un Animal Con el mismo codigo ya fue ingresado al sistema anteriormente')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (4, N'Un Animal con el mismo nombre ya fue ingresado al sistema anteriormente')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (5, N'Al registrar a un animal la fecha de nacimiento debe ser menor al día en curso')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (6, N'Ni valor ni cantidad de la produccion pueden ser 0')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (7, N'No se pueden registrar producciones si estas no pertenecen a animales existentes')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (8, N'Los cerdos solo pueden producir Carne')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (9, N'Las vacas solo pueden producir leche y los toros solo pueden producir carne')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (10, N'Las gallinas solo pueden producir huevos y los gallos solo pueden producir carne')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (11, N'Categoria de animal invalida')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (12, N'El documento que desea actualizar, no existe')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (13, N'No es posible realizar un pedido sin productos seleccionados')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (0, N'Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (14, N'No es posible eliminar algo que no existe')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (15, N'El estado de pedido ingresado no es valido. Disponible: 1: En Proceso, 2: En Transito, 3: Entregado')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (16, N'El estado inicial del pedido debe ser 1: En Proceso')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (17, N'No es posible cancelar un pedido ya entregado')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (18, N'No es posible actualizar un pedido ya entregado')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (19, N'Todos los campos son requeridos')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (20, N'El numero de pedido no es valido')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (21, N'Es imposible solicitar mas productos de los disponibles')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (22, N'No es posible ingresar multiples lines de detalle con el mismo tipo de producto')
SET IDENTITY_INSERT [dbo].[EXCEPTIONS] ON 

INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (1, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 36', CAST(N'2018-02-15T14:49:47.110' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (2, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Un Animal con el mismo nombre ya fue ingresado al sistema anteriormente', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 38', CAST(N'2018-02-15T14:58:08.447' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (3, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
La edad de los animales debe ser de minimo 6 meses', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 54', CAST(N'2018-02-15T15:36:26.150' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (4, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
No se pueden registrar producciones si estas no pertenecen a animales existentes', N'   at Cliente.ProduccionManagement.Create(Produccion produccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\ProduccionManagement.cs:line 43', CAST(N'2018-02-15T15:58:20.787' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (5, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Las gallinas solo pueden producir huevos y los gallos solo pueden producir carne', N'   at Cliente.ProduccionManagement.Create(Produccion produccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\ProduccionManagement.cs:line 86', CAST(N'2018-02-15T15:59:55.200' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (6, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Al registrar a un animal la fecha de nacimiento debe ser menor al día en curso', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 48', CAST(N'2018-02-15T16:00:44.487' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (7, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Ni valor ni cantidad de la produccion pueden ser 0', N'   at Cliente.ProduccionManagement.Create(Produccion produccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\ProduccionManagement.cs:line 94', CAST(N'2018-02-15T16:01:02.727' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (8, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Las vacas solo pueden producir leche y los toros solo pueden producir carne', N'   at Cliente.ProduccionManagement.Create(Produccion produccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\ProduccionManagement.cs:line 72', CAST(N'2018-02-15T16:01:35.787' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (9, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Un Animal Con el mismo codigo ya fue ingresado al sistema anteriormente', N'   at Cliente.AnimalManagement.Update(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 90', CAST(N'2018-02-18T22:49:46.187' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (10, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Un Animal Con el mismo codigo ya fue ingresado al sistema anteriormente', N'   at Cliente.AnimalManagement.Update(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 90', CAST(N'2018-02-18T22:51:04.587' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (11, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
La edad de los animales debe ser de minimo 6 meses', N'   at Cliente.AnimalManagement.Update(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 98', CAST(N'2018-02-18T22:52:49.473' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (12, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
La edad de los animales debe ser de minimo 6 meses', N'   at Cliente.AnimalManagement.Update(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 98', CAST(N'2018-02-18T22:53:18.603' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (13, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Al registrar a un animal la fecha de nacimiento debe ser menor al día en curso', N'   at Cliente.AnimalManagement.Update(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 92', CAST(N'2018-02-18T22:54:02.480' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (14, NULL, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Al registrar a un animal la fecha de nacimiento debe ser menor al día en curso', N'   at Cliente.AnimalManagement.Update(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 92', CAST(N'2018-02-18T22:55:10.773' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (15, NULL, N'Test', N'Stack', CAST(N'2018-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (16, 0, N'In catch block of Main method.
Caught: Message not found!
	Inner Exception: Unable to cast object of type ''Entidades.Pedido'' to type ''Entidades.Animal''.', N'   at AccesoDatos.Mapper.PedidoMapper.GetRetriveStatement(BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\AccesoDatos\Mapper\PedidoMapper.cs:line 40
   at AccesoDatos.CRUD.PedidoCrudFactory.Retrieve[T](BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\AccesoDatos\CRUD\PedidoCrudFactory.cs:line 56
   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoMana', CAST(N'2018-03-02T23:19:40.927' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (17, 0, N'In catch block of Main method.
Caught: Message not found!
	Inner Exception: Object reference not set to an instance of an object.', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 43', CAST(N'2018-03-02T23:24:30.543' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (18, 0, N'In catch block of Main method.
Caught: Message not found!
	Inner Exception: Invalid object name ''LINEA_PEDIDO''.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-02T23:41:42.127' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (19, 12, N'In catch block of Main method.
Caught: El documento que desea actualizar, no existe', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 97', CAST(N'2018-03-02T23:59:54.427' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (20, 12, N'In catch block of Main method.
Caught: El documento que desea actualizar, no existe', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 97', CAST(N'2018-03-03T00:02:02.647' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (21, 12, N'In catch block of Main method.
Caught: El documento que desea actualizar, no existe', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 97', CAST(N'2018-03-03T00:02:11.660' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (22, 13, N'In catch block of Main method.
Caught: No es posible realizar un pedido sin productos seleccionados', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 117', CAST(N'2018-03-03T00:02:16.457' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (23, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Object reference not set to an instance of an object.', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 102', CAST(N'2018-03-03T00:04:38.760' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (24, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Could not find stored procedure ''delete_linea_detalle''.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-03T00:17:32.073' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (25, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Could not find stored procedure ''delete_linea_detalle''.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-03T00:42:41.413' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (26, 14, N'In catch block of Main method.
Caught: No es posible eliminar algo que no existe', N'   at CoreAPI.PedidoManager.Delete(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 140', CAST(N'2018-03-03T00:50:49.990' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (27, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Unable to cast object of type ''Entidades.Pedido'' to type ''Entidades.Animal''.', N'   at AccesoDatos.Mapper.PedidoMapper.GetDeleteStatement(BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\AccesoDatos\Mapper\PedidoMapper.cs:line 71
   at AccesoDatos.CRUD.PedidoCrudFactory.Delete(BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\AccesoDatos\CRUD\PedidoCrudFactory.cs:line 50
   at CoreAPI.PedidoManager.Delete(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs', CAST(N'2018-03-03T00:50:57.577' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (28, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Unable to cast object of type ''Entidades.Pedido'' to type ''Entidades.Animal''.', N'   at AccesoDatos.Mapper.PedidoMapper.GetDeleteStatement(BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\AccesoDatos\Mapper\PedidoMapper.cs:line 71
   at AccesoDatos.CRUD.PedidoCrudFactory.Delete(BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\AccesoDatos\CRUD\PedidoCrudFactory.cs:line 50
   at CoreAPI.PedidoManager.Delete(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs', CAST(N'2018-03-03T00:51:33.400' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (29, 15, N'In catch block of Main method.
Caught: El estado de pedido ingresado no es valido. Disponible: 1: En Proceso, 2: En Transito, 3: Entregado', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 58', CAST(N'2018-03-03T01:25:19.830' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (30, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Procedure or function ''update_pedido'' expects parameter ''@P_EMAIL'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-03T01:40:07.063' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (31, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Object reference not set to an instance of an object.', N'   at CoreAPI.EmailManager.SendMail(String recipient, String subject, String body) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\EmailManager.cs:line 53
   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 149', CAST(N'2018-03-03T01:42:00.840' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (32, 19, N'In catch block of Main method.
Caught: Todos los campos son requeridos', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 57', CAST(N'2018-03-03T02:30:39.290' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (33, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Todos los campos son requeridos: Email', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 58', CAST(N'2018-03-03T02:36:16.767' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (34, 19, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Email', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 58', CAST(N'2018-03-03T02:43:29.470' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (35, 16, N'In catch block of Main method.
Caught: El estado inicial del pedido debe ser 1: En Proceso', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 63', CAST(N'2018-03-03T02:44:25.223' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (36, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Parameter count mismatch.', N'   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.RuntimePropertyInfo.GetValue(Object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture)
   at System.Reflection.RuntimePropertyInfo.GetValue(Ob', CAST(N'2018-03-03T02:55:00.900' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (37, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: SqlDateTime overflow. Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM.', N'   at System.Data.SqlClient.TdsParser.TdsExecuteRPC(SqlCommand cmd, _SqlRPC[] rpcArray, Int32 timeout, Boolean inSchema, SqlNotificationRequest notificationRequest, TdsParserStateObject stateObj, Boolean isCommandProc, Boolean sync, TaskCompletionSource`1 completion, Int32 startRpc, Int32 startParam)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, ', CAST(N'2018-03-03T03:00:11.350' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (38, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: SqlDateTime overflow. Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM.', N'   at System.Data.SqlClient.TdsParser.TdsExecuteRPC(SqlCommand cmd, _SqlRPC[] rpcArray, Int32 timeout, Boolean inSchema, SqlNotificationRequest notificationRequest, TdsParserStateObject stateObj, Boolean isCommandProc, Boolean sync, TaskCompletionSource`1 completion, Int32 startRpc, Int32 startParam)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, ', CAST(N'2018-03-03T03:00:45.547' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (39, 0, N'In catch block of Main method.
Caught: Error Interno Del Servidor, Contacte a soporte tecnico para mas ayuda
	Inner Exception: Object reference not set to an instance of an object.', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 165', CAST(N'2018-03-03T03:13:59.107' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (40, 18, N'In catch block of Main method.
Caught: No es posible actualizar un pedido ya entregado', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 117', CAST(N'2018-03-03T03:18:53.710' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (41, 18, N'In catch block of Main method.
Caught: No es posible actualizar un pedido ya entregado', N'   at CoreAPI.PedidoManager.Update(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 117', CAST(N'2018-03-03T03:24:53.747' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (42, 19, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Email', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 62', CAST(N'2018-03-04T02:20:02.657' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (43, 22, N'In catch block of Main method.
Caught: No es posible ingresar multiples lines de detalle con el mismo tipo de producto', N'   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 74', CAST(N'2018-03-04T02:20:50.263' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (44, 19, N'In catch block of Main method.
Caught: Todos los campos son requeridos: IdTipo', N'   at CoreAPI.PedidoManager.<>c__DisplayClass6_2.<Create>b__0(LineaDetalle linea) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 83
   at System.Collections.Generic.List`1.ForEach(Action`1 action)
   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 78', CAST(N'2018-03-04T02:52:31.560' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (45, 14, N'In catch block of Main method.
Caught: No es posible eliminar algo que no existe', N'   at CoreAPI.PedidoManager.Delete(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 284', CAST(N'2018-03-04T02:59:34.500' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (46, 21, N'In catch block of Main method.
Caught: Es imposible solicitar mas productos de los disponibles: Huevos', N'   at CoreAPI.PedidoManager.<>c__DisplayClass6_2.<Create>b__0(LineaDetalle linea) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 97
   at System.Collections.Generic.List`1.ForEach(Action`1 action)
   at CoreAPI.PedidoManager.Create(Pedido pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 78', CAST(N'2018-03-04T03:01:27.533' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (47, 14, N'In catch block of Main method.
Caught: No es posible eliminar algo que no existe', N'   at CoreAPI.PedidoManager.Delete(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 284', CAST(N'2018-03-04T03:01:32.370' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (48, 17, N'In catch block of Main method.
Caught: No es posible cancelar un pedido ya entregado', N'   at CoreAPI.PedidoManager.Delete(Pedido Pedido) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_5\CoreAPI\PedidoManager.cs:line 289', CAST(N'2018-03-04T03:01:37.687' AS DateTime))
SET IDENTITY_INSERT [dbo].[EXCEPTIONS] OFF
SET IDENTITY_INSERT [dbo].[LINEA_DETALLE] ON 

INSERT [dbo].[LINEA_DETALLE] ([ID], [ID_TIPO], [ID_PEDIDO], [NOMBRE], [CANTIDAD], [TOTAL]) VALUES (24, 2, 9, N'Carne', 10, 5000)
INSERT [dbo].[LINEA_DETALLE] ([ID], [ID_TIPO], [ID_PEDIDO], [NOMBRE], [CANTIDAD], [TOTAL]) VALUES (25, 1, 9, N'Huevos', 30, 5000)
SET IDENTITY_INSERT [dbo].[LINEA_DETALLE] OFF
SET IDENTITY_INSERT [dbo].[PEDIDO] ON 

INSERT [dbo].[PEDIDO] ([ID], [EMAIL], [FECHA], [COMERCIO], [DIRECCION], [TOTAL], [ESTADO]) VALUES (9, N'garyhampton.12@gmail.com', CAST(N'2018-02-02T00:00:00.000' AS DateTime), N'Pipasa', N'San Francisto de Heredia', 10000, 1)
SET IDENTITY_INSERT [dbo].[PEDIDO] OFF
SET IDENTITY_INSERT [dbo].[PRODUCCION] ON 

INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (22, 4, 1, 10, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 8000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (23, 4, 2, 25, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 4000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (24, 5, 2, 23, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 24000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (25, 5, 2, 14, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 8000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (26, 6, 1, 23, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 8000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (27, 6, 2, 17, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 16000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (28, 4, 1, 8, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 12000)
INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [ID_TIPO_PRODUCCION], [CANTIDAD], [FECHA_REGISTRO], [TOTAL]) VALUES (29, 5, 2, 3, CAST(N'2018-10-02T00:00:00.000' AS DateTime), 12000)
SET IDENTITY_INSERT [dbo].[PRODUCCION] OFF
SET IDENTITY_INSERT [dbo].[TIPO_ANIMAL] ON 

INSERT [dbo].[TIPO_ANIMAL] ([ID], [NOMBRE], [GENERO]) VALUES (1, N'Gallina', N'Hembra')
INSERT [dbo].[TIPO_ANIMAL] ([ID], [NOMBRE], [GENERO]) VALUES (2, N'Gallo', N'Macho')
INSERT [dbo].[TIPO_ANIMAL] ([ID], [NOMBRE], [GENERO]) VALUES (3, N'Vaca', N'Hembra')
INSERT [dbo].[TIPO_ANIMAL] ([ID], [NOMBRE], [GENERO]) VALUES (4, N'Toro', N'Macho')
INSERT [dbo].[TIPO_ANIMAL] ([ID], [NOMBRE], [GENERO]) VALUES (5, N'Cerdo', N'Macho')
INSERT [dbo].[TIPO_ANIMAL] ([ID], [NOMBRE], [GENERO]) VALUES (6, N'Cerdo', N'Hembra')
SET IDENTITY_INSERT [dbo].[TIPO_ANIMAL] OFF
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (1, 1)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (1, 2)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (2, 2)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (3, 2)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (3, 3)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (4, 2)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (5, 2)
INSERT [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION]) VALUES (6, 2)
SET IDENTITY_INSERT [dbo].[TIPO_PRODUCCION] ON 

INSERT [dbo].[TIPO_PRODUCCION] ([ID], [NOMBRE], [VALOR]) VALUES (1, N'Huevos', 2000)
INSERT [dbo].[TIPO_PRODUCCION] ([ID], [NOMBRE], [VALOR]) VALUES (2, N'Carne', 4000)
INSERT [dbo].[TIPO_PRODUCCION] ([ID], [NOMBRE], [VALOR]) VALUES (3, N'Leche', 1500)
SET IDENTITY_INSERT [dbo].[TIPO_PRODUCCION] OFF
ALTER TABLE [dbo].[ANIMAL]  WITH CHECK ADD  CONSTRAINT [FK_ANIMAL_TIPO_ANIMAL] FOREIGN KEY([ID_TIPO_ANIMAL])
REFERENCES [dbo].[TIPO_ANIMAL] ([ID])
GO
ALTER TABLE [dbo].[ANIMAL] CHECK CONSTRAINT [FK_ANIMAL_TIPO_ANIMAL]
GO
ALTER TABLE [dbo].[PRODUCCION]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCCION_ANIMAL] FOREIGN KEY([ID_ANIMAL])
REFERENCES [dbo].[ANIMAL] ([ID])
GO
ALTER TABLE [dbo].[PRODUCCION] CHECK CONSTRAINT [FK_PRODUCCION_ANIMAL]
GO
ALTER TABLE [dbo].[PRODUCCION]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCCION_TIPO_PRODUCCION] FOREIGN KEY([ID_TIPO_PRODUCCION])
REFERENCES [dbo].[TIPO_PRODUCCION] ([ID])
GO
ALTER TABLE [dbo].[PRODUCCION] CHECK CONSTRAINT [FK_PRODUCCION_TIPO_PRODUCCION]
GO
ALTER TABLE [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION]  WITH CHECK ADD  CONSTRAINT [FK_TIPO_ANIMAL_n_TIPO_PRODUCCION_TIPO_ANIMAL] FOREIGN KEY([ID_TIPO_ANIMAL])
REFERENCES [dbo].[TIPO_ANIMAL] ([ID])
GO
ALTER TABLE [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] CHECK CONSTRAINT [FK_TIPO_ANIMAL_n_TIPO_PRODUCCION_TIPO_ANIMAL]
GO
ALTER TABLE [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION]  WITH CHECK ADD  CONSTRAINT [FK_TIPO_ANIMAL_n_TIPO_PRODUCCION_TIPO_ANIMAL_n_TIPO_PRODUCCION] FOREIGN KEY([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION])
REFERENCES [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] ([ID_TIPO_ANIMAL], [ID_TIPO_PRODUCCION])
GO
ALTER TABLE [dbo].[TIPO_ANIMAL_n_TIPO_PRODUCCION] CHECK CONSTRAINT [FK_TIPO_ANIMAL_n_TIPO_PRODUCCION_TIPO_ANIMAL_n_TIPO_PRODUCCION]
GO
/****** Object:  StoredProcedure [dbo].[delete_animal]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_animal]
	(@P_ID	int)
AS
BEGIN
	DELETE FROM PRODUCCION WHERE ID_ANIMAL = @P_ID
	DELETE FROM ANIMAL WHERE ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[delete_linea_detalle]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_linea_detalle]
	(@P_ID int)
AS
BEGIN
	delete LINEA_DETALLE where ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[delete_pedido]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_pedido]
	(@P_ID int)
AS
BEGIN
	delete PEDIDO where ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[delete_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_produccion]
	(@P_ID	int)
AS
BEGIN
	DELETE FROM PRODUCCION WHERE ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[find_animal]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[find_animal]
	(@P_ID	int)
AS
BEGIN
	SELECT * FROM ANIMAL WHERE ID = @P_ID	
END
GO
/****** Object:  StoredProcedure [dbo].[find_animal_by_nombre]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[find_animal_by_nombre]
	(@P_NOMBRE		VARCHAR (50))
AS
BEGIN
	SELECT * FROM ANIMAL WHERE NOMBRE = @P_NOMBRE
END
GO
/****** Object:  StoredProcedure [dbo].[find_linea_detalle]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[find_linea_detalle]
	(@P_ID	        int)
AS
BEGIN
	SELECT * FROM LINEA_DETALLE WHERE ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[find_pedido]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[find_pedido]
	(@P_ID	        int)
AS
BEGIN
	SELECT * FROM PEDIDO WHERE ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[find_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[find_produccion]
	(@P_ID	int)
AS
BEGIN
	SELECT * FROM PRODUCCION WHERE ID = @P_ID	
END
GO
/****** Object:  StoredProcedure [dbo].[find_tipo_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[find_tipo_produccion]
	(@P_ID int)
AS
BEGIN
	SELECT * FROM TIPO_PRODUCCION WHERE ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[insert_animal]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_animal]
	(@P_NOMBRE	        varchar(50),
	 @P_CATEGORIA	        varchar(50),
	 @P_EDAD	            float,
	 @P_FECHA_NACIMIENTO	datetime,
	 @P_ALIMENTO	        varchar(50),
	 @P_GENERO		        varchar(50))
AS
BEGIN
	INSERT INTO ANIMAL (NOMBRE, CATEGORIA, EDAD, FECHA_NACIMIENTO, ALIMENTO, GENERO)
		VALUES (@P_NOMBRE, @P_CATEGORIA, @P_EDAD, @P_FECHA_NACIMIENTO, @P_ALIMENTO, @P_GENERO)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_exception]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_exception]
	(@P_CODE			int,
     @P_MESSAGE	        varchar(250),
	 @P_STACKTRACE	    varchar(500),
	 @P_DATE            datetime)
AS
BEGIN
	INSERT INTO EXCEPTIONS (CODE,MESSAGE,STACKTRACE,DATE) VALUES (@P_CODE,@P_MESSAGE, @P_STACKTRACE, @P_DATE)
	SELECT * FROM EXCEPTIONS WHERE ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insert_linea_detalle]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_linea_detalle]
	(@P_ID_TIPO		int,
	 @P_ID_PEDIDO	int,
	 @P_NOMBRE	    varchar(150),
	 @P_CANTIDAD	float,
	 @P_TOTAL	    float)

AS
BEGIN
	INSERT INTO LINEA_DETALLE (ID_TIPO,ID_PEDIDO,NOMBRE,CANTIDAD,TOTAL) VALUES (@P_ID_TIPO,@P_ID_PEDIDO,@P_NOMBRE,@P_CANTIDAD,@P_TOTAL)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_pedido]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_pedido]
	(@P_EMAIL		varchar(255),
	 @P_FECHA	    datetime,
	 @P_COMERCIO	varchar(50),
	 @P_DIRECCION	varchar(250),
	 @P_TOTAL	    float,
	 @P_ESTADO	    int)AS
BEGIN
	INSERT INTO PEDIDO (EMAIL,FECHA,COMERCIO,DIRECCION,TOTAL,ESTADO) VALUES (@P_EMAIL,@P_FECHA,@P_COMERCIO,@P_DIRECCION,@P_TOTAL,@P_ESTADO)
	SELECT * FROM PEDIDO WHERE ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insert_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_produccion]
	(@P_ID_ANIMAL	        int,
	 @P_TIPO	            varchar(50),
	 @P_CANTIDAD	        float,
	 @P_VALOR	            float,
	 @P_FECHA_REGISTRO	datetime)
AS
BEGIN
	INSERT INTO PRODUCCION (ID_ANIMAL, TIPO, CANTIDAD, VALOR, FECHA_REGISTRO)
		VALUES (@P_ID_ANIMAL, @P_TIPO, @P_CANTIDAD, @P_VALOR, @P_FECHA_REGISTRO)
END
GO
/****** Object:  StoredProcedure [dbo].[list_animal]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_animal]

AS
BEGIN
	SELECT * FROM ANIMAL	
END
GO
/****** Object:  StoredProcedure [dbo].[list_animal_by_categoria]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_animal_by_categoria]
	(@P_CATEGORIA		VARCHAR(50))
AS
BEGIN
	SELECT * FROM ANIMAL WHERE CATEGORIA = @P_CATEGORIA
END
GO
/****** Object:  StoredProcedure [dbo].[list_animal_by_nombre]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_animal_by_nombre]
	(@P_NOMBRE		VARCHAR(50))
AS
BEGIN
	SELECT * FROM ANIMAL WHERE NOMBRE like '%' + @P_NOMBRE + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[list_appmessages]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_appmessages]
AS
BEGIN
	SELECT * FROM APPMESSAGES
END
GO
/****** Object:  StoredProcedure [dbo].[list_linea_detalle]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_linea_detalle]
AS
BEGIN
	SELECT * FROM LINEA_DETALLE
END
GO
/****** Object:  StoredProcedure [dbo].[list_linea_detalle_by_pedido]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_linea_detalle_by_pedido] 
	(@P_ID_PEDIDO	INT)
AS
BEGIN
	SELECT * FROM LINEA_DETALLE WHERE ID_PEDIDO = @P_ID_PEDIDO
END
GO
/****** Object:  StoredProcedure [dbo].[list_pedido]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_pedido]
AS
BEGIN
	SELECT * FROM PEDIDO
END
GO
/****** Object:  StoredProcedure [dbo].[list_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_produccion]

AS
BEGIN
	SELECT * FROM PRODUCCION	
END
GO
/****** Object:  StoredProcedure [dbo].[list_produccion_by_animal]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_produccion_by_animal]
	(@P_ID_ANIMAL		INT)
AS
BEGIN
	SELECT * FROM PRODUCCION WHERE ID_ANIMAL = @P_ID_ANIMAL
END
GO
/****** Object:  StoredProcedure [dbo].[list_produccion_by_rango]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_produccion_by_rango]
	(@P_FECHA_INICIO		DATETIME,
	 @P_FECHA_FIN			DATETIME)
AS
BEGIN
	SELECT * FROM PRODUCCION WHERE 
		FECHA_REGISTRO >= @P_FECHA_INICIO AND 
		FECHA_REGISTRO <= @P_FECHA_FIN
END
GO
/****** Object:  StoredProcedure [dbo].[list_produccion_by_rango_categoria]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_produccion_by_rango_categoria]
	(@P_FECHA_INICIO		DATETIME,
	 @P_FECHA_FIN			DATETIME,
	 @P_CATEGORIA			VARCHAR (50))
AS
BEGIN
	SELECT * FROM PRODUCCION WHERE 
		FECHA_REGISTRO >= @P_FECHA_INICIO AND 
		FECHA_REGISTRO <= @P_FECHA_FIN	AND 
		ID_ANIMAL IN (SELECT ID FROM ANIMAL WHERE CATEGORIA = @P_CATEGORIA)
END
GO
/****** Object:  StoredProcedure [dbo].[list_productos]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_productos]
AS
BEGIN
	SELECT 
		P.ID_TIPO_PRODUCCION AS ID,
		T.NOMBRE AS NOMBRE,
		SUM (P.CANTIDAD) - COALESCE (SUM (L.CANTIDAD),0) AS CANTIDAD
		FROM PRODUCCION AS P
	INNER JOIN
		TIPO_PRODUCCION	AS T ON T.ID = P.ID_TIPO_PRODUCCION
	LEFT JOIN
		LINEA_DETALLE AS L ON	P.ID_TIPO_PRODUCCION = L.ID_TIPO
		GROUP BY P.ID_TIPO_PRODUCCION, T.NOMBRE
END
GO
/****** Object:  StoredProcedure [dbo].[list_tipo_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_tipo_produccion]
AS
BEGIN
	SELECT * FROM TIPO_PRODUCCION
END
GO
/****** Object:  StoredProcedure [dbo].[update_animal]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_animal]
	(@P_ID	            int,
	 @P_NOMBRE	        varchar(50),
	 @P_CATEGORIA	        varchar(50),
	 @P_EDAD	            float,
	 @P_FECHA_NACIMIENTO	datetime,
	 @P_ALIMENTO	        varchar(50),
	 @P_GENERO		        varchar(50))
AS
BEGIN
	UPDATE ANIMAL
    SET 
        NOMBRE              = @P_NOMBRE,
        CATEGORIA           = @P_CATEGORIA,
        EDAD                = @P_EDAD,
        FECHA_NACIMIENTO    = @P_FECHA_NACIMIENTO,
        ALIMENTO            = @P_ALIMENTO,
		GENERO				= @P_GENERO
        WHERE 
            ID = @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[update_linea_detalle]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_linea_detalle]
	(@P_ID	        int,
	 @P_ID_TIPO		int,
	 @P_ID_PEDIDO	int,
	 @P_NOMBRE	    varchar(150),
	 @P_CANTIDAD	float,
	 @P_TOTAL	    float)

AS
BEGIN
	UPDATE LINEA_DETALLE SET
		ID_TIPO     =   @P_ID_TIPO,
		ID_PEDIDO   =   @P_ID_PEDIDO,
		NOMBRE      =   @P_NOMBRE,
		CANTIDAD    =   @P_CANTIDAD,
		TOTAL       =   @P_TOTAL
		WHERE ID    =   @P_ID
END
GO
/****** Object:  StoredProcedure [dbo].[update_pedido]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_pedido]
	(@P_EMAIL		varchar(255),
	 @P_ID	        int,
	 @P_FECHA	    datetime,
	 @P_COMERCIO	varchar(50),
	 @P_DIRECCION	varchar(250),
	 @P_TOTAL	    float,
 @P_ESTADO	    int)
AS
BEGIN
	UPDATE PEDIDO SET
		EMAIL		=	@P_EMAIL,
		FECHA       =   @P_FECHA,
		COMERCIO    =   @P_COMERCIO,
		DIRECCION   =   @P_DIRECCION,
		TOTAL       =   @P_TOTAL,
		ESTADO      =   @P_ESTADO
		WHERE   ID  =   @P_ID

	SELECT * FROM PEDIDO WHERE ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[update_produccion]    Script Date: 3/4/2018 10:26:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_produccion]
	(@P_ID	            int,
	 @P_ID_ANIMAL	        int,
	 @P_TIPO	            varchar(50),
	 @P_CANTIDAD	        float,
	 @P_VALOR	            float,
	 @P_FECHA_REGISTRO	datetime)
AS
BEGIN
	UPDATE PRODUCCION 
    SET
        ID_ANIMAL       = @P_ID_ANIMAL,
        TIPO            = @P_TIPO,
        CANTIDAD        = @P_CANTIDAD,
        VALOR           = @P_VALOR,
        FECHA_REGISTRO  = @P_FECHA_REGISTRO
        WHERE
            ID = @P_ID
END
GO
USE [master]
GO
ALTER DATABASE [GranjaCenfotec] SET  READ_WRITE 
GO
