USE [master]
GO
/****** Object:  Database [PolyBot]    Script Date: 3/5/2018 5:44:09 AM ******/
CREATE DATABASE [PolyBot]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PolyBot', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\PolyBot.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PolyBot_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\PolyBot_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PolyBot] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PolyBot].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PolyBot] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PolyBot] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PolyBot] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PolyBot] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PolyBot] SET ARITHABORT OFF 
GO
ALTER DATABASE [PolyBot] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PolyBot] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PolyBot] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PolyBot] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PolyBot] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PolyBot] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PolyBot] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PolyBot] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PolyBot] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PolyBot] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PolyBot] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PolyBot] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PolyBot] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PolyBot] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PolyBot] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PolyBot] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PolyBot] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PolyBot] SET RECOVERY FULL 
GO
ALTER DATABASE [PolyBot] SET  MULTI_USER 
GO
ALTER DATABASE [PolyBot] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PolyBot] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PolyBot] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PolyBot] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PolyBot] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PolyBot', N'ON'
GO
ALTER DATABASE [PolyBot] SET QUERY_STORE = OFF
GO
USE [PolyBot]
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
USE [PolyBot]
GO
/****** Object:  Table [dbo].[APPMESSAGES]    Script Date: 3/5/2018 5:44:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPMESSAGES](
	[ID] [int] NOT NULL,
	[TEXT] [text] NULL,
 CONSTRAINT [PK_APPMESSAGES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXCEPTIONS]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXCEPTIONS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODE] [int] NULL,
	[MESSAGE] [text] NULL,
	[STACKTRACE] [text] NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [PK_EXCEPTIONS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDIOMA]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDIOMA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO] [varchar](2) NULL,
	[NOMBRE] [varchar](50) NULL,
 CONSTRAINT [PK_IDIOMA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PALABRA]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PALABRA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_IDIOMA] [int] NULL,
	[ID_TRADUCTOR] [int] NULL,
	[FAMILIA] [varchar](100) NULL,
	[PALABRA] [varchar](100) NULL,
	[FECHA] [datetime] NULL,
 CONSTRAINT [PK_PALABRA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRADUCCION]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRADUCCION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_USUARIO] [int] NULL,
	[IDIOMA_ORIGINAL] [int] NULL,
	[IDIOMA_DESTINO] [int] NULL,
	[FRASE_ORIGINAL] [varchar](500) NULL,
	[FRASE_TRADUCIDA] [varchar](500) NULL,
	[POPULARIDAD_TOTAL] [int] NULL,
	[FECHA] [datetime] NULL,
 CONSTRAINT [PK_TRADUCCION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRADUCCIONES_PALABRAS]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRADUCCIONES_PALABRAS](
	[ID_TRADUCCION] [int] NOT NULL,
	[ID_PALABRA] [int] NOT NULL,
	[ORDEN] [int] NULL,
 CONSTRAINT [PK_TRADUCCIONES_PALABRAS] PRIMARY KEY CLUSTERED 
(
	[ID_TRADUCCION] ASC,
	[ID_PALABRA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[APELLIDO] [varchar](50) NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (0, N'Error de sistema, contacte a soporte tecnico')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (1, N'El objeto ya existe en el sistema')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (2, N'Todos los campos son requeridos')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (3, N'No se puede actualizar un objeto que no existe')
SET IDENTITY_INSERT [dbo].[EXCEPTIONS] ON 

INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (1, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Fecha', N'   at CoreAPI.Managers.UsuarioManager.Create(Usuario usuario) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\UsuarioManager.cs:line 39', CAST(N'2018-03-04T00:00:49.790' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (2, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Parameter count mismatch.', N'   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.RuntimePropertyInfo.GetValue(Object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture)
   at System.Reflection.RuntimePropertyInfo.GetValue(Ob', CAST(N'2018-03-04T00:05:01.090' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (3, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Parameter count mismatch.', N'   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.RuntimePropertyInfo.GetValue(Object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture)
   at System.Reflection.RuntimePropertyInfo.GetValue(Ob', CAST(N'2018-03-04T00:08:40.383' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (4, 3, N'In catch block of Main method.
Caught: No se puede actualizar un objeto que no existe', N'   at CoreAPI.Managers.UsuarioManager.Update(Usuario usuario) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\UsuarioManager.cs:line 89', CAST(N'2018-03-04T00:12:14.070' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (5, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Codigo', N'   at CoreAPI.Managers.IdiomaManager.Create(Idioma idioma) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\IdiomaManager.cs:line 39', CAST(N'2018-03-04T00:25:30.450' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (6, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Codigo: Id_Usuario,Idioma_Original,Idioma_Destino,Frase_Original,Frase_Traducida,Popularidad_Total,Fecha', N'   at CoreAPI.Managers.TraduccionManager.Create(Traduccion traduccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionManager.cs:line 39', CAST(N'2018-03-04T00:28:38.750' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (7, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Id_Idioma,Id_Traductor', N'   at CoreAPI.Managers.PalabraManager.Create(Palabra palabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\PalabraManager.cs:line 40', CAST(N'2018-03-04T22:43:45.313' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (8, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:15:32.577' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (9, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:15:32.997' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (10, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:16:00.933' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (11, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:19:11.267' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (12, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:33:29.383' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (13, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:33:29.700' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (14, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:38:25.177' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (15, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:38:25.517' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (16, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Procedure or function ''select_palabra_by_palabra'' expects parameter ''@P_PALABRA'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:38:25.613' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (17, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:40:43.497' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (18, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:40:58.590' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (19, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Procedure or function ''select_palabra_by_palabra'' expects parameter ''@P_PALABRA'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:41:16.927' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (20, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:43:00.963' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (21, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:43:01.283' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (22, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Procedure or function ''select_palabra_by_palabra'' expects parameter ''@P_PALABRA'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:43:41.397' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (23, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:44:52.990' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (24, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Error converting data type varchar to int.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:48:09.143' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (25, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Procedure or function ''select_palabra_by_familia_and_idioma'' expects parameter ''@P_FAMILIA'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:49:34.683' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (26, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Familia', N'   at CoreAPI.Managers.PalabraManager.Create(Palabra palabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\PalabraManager.cs:line 40', CAST(N'2018-03-05T01:51:35.547' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (27, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Procedure or function ''select_palabra_by_familia_and_idioma'' expects parameter ''@P_FAMILIA'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:52:42.970' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (28, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Familia: Familia', N'   at CoreAPI.Managers.PalabraManager.Create(Palabra palabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\PalabraManager.cs:line 40', CAST(N'2018-03-05T01:53:05.393' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (29, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Procedure or function ''select_palabra_by_familia_and_idioma'' expects parameter ''@P_FAMILIA'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T01:53:58.137' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (30, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Familia: Familia: Familia', N'   at CoreAPI.Managers.PalabraManager.Create(Palabra palabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\PalabraManager.cs:line 40', CAST(N'2018-03-05T01:54:02.950' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (31, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Popularidad_Total', N'   at CoreAPI.Managers.TraduccionManager.Create(Traduccion traduccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionManager.cs:line 39', CAST(N'2018-03-05T03:09:22.027' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (32, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Popularidad_Total', N'   at CoreAPI.Managers.TraduccionManager.Create(Traduccion traduccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionManager.cs:line 39', CAST(N'2018-03-05T03:12:26.290' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (33, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: The method or operation is not implemented.', N'   at AccesoDatos.CRUD.TraduccionPalabraCrudFactory.Retrieve[T](BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\AccesoDatos\CRUD\TraduccionPalabraCrudFactory.cs:line 41
   at CoreAPI.Managers.TraduccionPalabraManager.Create(TraduccionPalabra traduccionPalabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionPalabraManager.cs:line 29', CAST(N'2018-03-05T03:17:41.580' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (34, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: The method or operation is not implemented.', N'   at AccesoDatos.CRUD.TraduccionPalabraCrudFactory.Retrieve[T](BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\AccesoDatos\CRUD\TraduccionPalabraCrudFactory.cs:line 41
   at CoreAPI.Managers.TraduccionPalabraManager.Create(TraduccionPalabra traduccionPalabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionPalabraManager.cs:line 29', CAST(N'2018-03-05T03:17:41.650' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (35, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: The method or operation is not implemented.', N'   at AccesoDatos.CRUD.TraduccionPalabraCrudFactory.Retrieve[T](BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\AccesoDatos\CRUD\TraduccionPalabraCrudFactory.cs:line 41
   at CoreAPI.Managers.TraduccionPalabraManager.Create(TraduccionPalabra traduccionPalabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionPalabraManager.cs:line 29', CAST(N'2018-03-05T03:17:41.687' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (36, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: The method or operation is not implemented.', N'   at AccesoDatos.CRUD.TraduccionPalabraCrudFactory.Retrieve[T](BaseEntity entity) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\AccesoDatos\CRUD\TraduccionPalabraCrudFactory.cs:line 41
   at CoreAPI.Managers.TraduccionPalabraManager.Create(TraduccionPalabra traduccionPalabra) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionPalabraManager.cs:line 29', CAST(N'2018-03-05T03:17:41.793' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (37, 2, N'In catch block of Main method.
Caught: Todos los campos son requeridos: Id_Idioma,Id_Traduccion', N'   at CoreAPI.Managers.TraduccionManager.Create(Traduccion traduccion) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\CoreAPI\Managers\TraduccionManager.cs:line 39', CAST(N'2018-03-05T03:48:38.877' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (38, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: The given key was not present in the dictionary.', N'   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
   at AccesoDatos.Mapper.EntityMapper.GetIntValue(Dictionary`2 dic, String attName) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\AccesoDatos\Mapper\EntityMapper.cs:line 22
   at AccesoDatos.Mapper.TraduccionMapper.BuildObject(Dictionary`2 row) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Ex_1\AccesoDatos\Mapper\TraduccionMapper.cs:line 122
   at AccesoDatos.CRUD.TraduccionCrudFactory.CalcularPopula', CAST(N'2018-03-05T03:52:13.210' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (39, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Violation of PRIMARY KEY constraint ''PK_TRADUCCIONES_PALABRAS''. Cannot insert duplicate key in object ''dbo.TRADUCCIONES_PALABRAS''. The duplicate key', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T03:56:35.250' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [CODE], [MESSAGE], [STACKTRACE], [DATE]) VALUES (40, 0, N'In catch block of Main method.
Caught: Error de sistema, contacte a soporte tecnico
	Inner Exception: Violation of PRIMARY KEY constraint ''PK_TRADUCCIONES_PALABRAS''. Cannot insert duplicate key in object ''dbo.TRADUCCIONES_PALABRAS''. The duplicate key', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHand', CAST(N'2018-03-05T03:56:35.327' AS DateTime))
SET IDENTITY_INSERT [dbo].[EXCEPTIONS] OFF
SET IDENTITY_INSERT [dbo].[IDIOMA] ON 

INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (1, N'EN', N'Ingles')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (2, N'RU', N'Ruso')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (3, N'ES', N'Español')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (4, N'FR', N'Frances')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (5, N'PT', N'Portugues')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (6, N'DE', N'Aleman')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (7, N'JA', N'Japones')
INSERT [dbo].[IDIOMA] ([ID], [CODIGO], [NOMBRE]) VALUES (8, N'IT', N'Italiano')
SET IDENTITY_INSERT [dbo].[IDIOMA] OFF
SET IDENTITY_INSERT [dbo].[PALABRA] ON 

INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (20, 3, 2, N'5d3f867d-d56a-46e3-8e45-4f8705a4c19e', N'buenos', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (21, 3, 2, N'53ba660d-73bc-4fee-8838-d6489a8be673', N'dias', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (22, 1, 2, N'5d3f867d-d56a-46e3-8e45-4f8705a4c19e', N'good', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (23, 1, 2, N'53ba660d-73bc-4fee-8838-d6489a8be673', N'morning', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (24, 7, 2, N'5d3f867d-d56a-46e3-8e45-4f8705a4c19e', N'yoi', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (25, 7, 2, N'53ba660d-73bc-4fee-8838-d6489a8be673', N'hi', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (26, 3, 2, N'198d6df3-9a28-4cf0-bbdb-6ea1dc7d75ea', N'profesor', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (27, 3, 2, N'1a6442ab-834f-4cb4-8afd-23722c52408a', N'hola', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PALABRA] ([ID], [ID_IDIOMA], [ID_TRADUCTOR], [FAMILIA], [PALABRA], [FECHA]) VALUES (28, 3, 2, N'85abd06f-bdf6-4d9e-8eea-eb76219ac706', N'amigo', CAST(N'2018-03-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PALABRA] OFF
SET IDENTITY_INSERT [dbo].[TRADUCCION] ON 

INSERT [dbo].[TRADUCCION] ([ID], [ID_USUARIO], [IDIOMA_ORIGINAL], [IDIOMA_DESTINO], [FRASE_ORIGINAL], [FRASE_TRADUCIDA], [POPULARIDAD_TOTAL], [FECHA]) VALUES (7, 2, 3, 1, N'buenos dias', N'good morning ', 2, CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TRADUCCION] ([ID], [ID_USUARIO], [IDIOMA_ORIGINAL], [IDIOMA_DESTINO], [FRASE_ORIGINAL], [FRASE_TRADUCIDA], [POPULARIDAD_TOTAL], [FECHA]) VALUES (8, 2, 3, 7, N'buenos dias', N'yoi hi ', 2, CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TRADUCCION] ([ID], [ID_USUARIO], [IDIOMA_ORIGINAL], [IDIOMA_DESTINO], [FRASE_ORIGINAL], [FRASE_TRADUCIDA], [POPULARIDAD_TOTAL], [FECHA]) VALUES (9, 2, 3, 3, N'buenos dias', N'buenos dias ', 2, CAST(N'2018-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TRADUCCION] ([ID], [ID_USUARIO], [IDIOMA_ORIGINAL], [IDIOMA_DESTINO], [FRASE_ORIGINAL], [FRASE_TRADUCIDA], [POPULARIDAD_TOTAL], [FECHA]) VALUES (10, 2, 3, 1, N'buenos dias', N'good morning ', 2, CAST(N'2018-03-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[TRADUCCION] OFF
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (7, 20, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (7, 21, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (7, 22, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (7, 23, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (8, 20, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (8, 21, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (8, 24, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (8, 25, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (9, 20, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (9, 21, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (10, 20, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (10, 21, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (10, 22, 1)
INSERT [dbo].[TRADUCCIONES_PALABRAS] ([ID_TRADUCCION], [ID_PALABRA], [ORDEN]) VALUES (10, 23, 1)
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [APELLIDO]) VALUES (2, N'Gary', N'Valverde Hampton')
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [APELLIDO]) VALUES (3, N'Gary', N'Hampton')
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [APELLIDO]) VALUES (4, N'Denisse', N'Valverde Hampton')
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
ALTER TABLE [dbo].[PALABRA]  WITH CHECK ADD  CONSTRAINT [FK_PALABRAS_IDIOMAS] FOREIGN KEY([ID_IDIOMA])
REFERENCES [dbo].[IDIOMA] ([ID])
GO
ALTER TABLE [dbo].[PALABRA] CHECK CONSTRAINT [FK_PALABRAS_IDIOMAS]
GO
ALTER TABLE [dbo].[PALABRA]  WITH CHECK ADD  CONSTRAINT [FK_PALABRAS_USUARIOS] FOREIGN KEY([ID_TRADUCTOR])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[PALABRA] CHECK CONSTRAINT [FK_PALABRAS_USUARIOS]
GO
ALTER TABLE [dbo].[TRADUCCION]  WITH CHECK ADD  CONSTRAINT [FK_TRADUCCIONES_USUARIOS] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[TRADUCCION] CHECK CONSTRAINT [FK_TRADUCCIONES_USUARIOS]
GO
ALTER TABLE [dbo].[TRADUCCIONES_PALABRAS]  WITH CHECK ADD  CONSTRAINT [FK_PALABRAS_TRADUCCIONES] FOREIGN KEY([ID_PALABRA])
REFERENCES [dbo].[PALABRA] ([ID])
GO
ALTER TABLE [dbo].[TRADUCCIONES_PALABRAS] CHECK CONSTRAINT [FK_PALABRAS_TRADUCCIONES]
GO
ALTER TABLE [dbo].[TRADUCCIONES_PALABRAS]  WITH CHECK ADD  CONSTRAINT [FK_TRADUCCIONES_PALABRAS] FOREIGN KEY([ID_TRADUCCION])
REFERENCES [dbo].[TRADUCCION] ([ID])
GO
ALTER TABLE [dbo].[TRADUCCIONES_PALABRAS] CHECK CONSTRAINT [FK_TRADUCCIONES_PALABRAS]
GO
/****** Object:  StoredProcedure [dbo].[calcular_popularidad_traduccion_por_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[calcular_popularidad_traduccion_por_idioma]
	(@P_ID_IDIOMA		INT,
	 @P_ID_TRADUCCION	INT)
AS
BEGIN
	DECLARE @POPULARIDAD_TOTAL INT = 0;
	SELECT @POPULARIDAD_TOTAL = COUNT (1)
	FROM TRADUCCIONES_PALABRAS AS TP
	WHERE TP.ID_TRADUCCION = @P_ID_TRADUCCION AND TP.ID_PALABRA IN
		(SELECT ID FROM PALABRA AS P WHERE ID_IDIOMA = @P_ID_IDIOMA)

		

	SELECT ID, ID_USUARIO, IDIOMA_ORIGINAL, IDIOMA_DESTINO, FRASE_ORIGINAL, FRASE_TRADUCIDA, FECHA, @POPULARIDAD_TOTAL as POPULARIDAD_TOTAL FROM TRADUCCION WHERE ID = @P_ID_TRADUCCION
END
GO
/****** Object:  StoredProcedure [dbo].[delete_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_idioma]
(@P_ID int)
AS
BEGIN
DELETE FROM IDIOMA WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[delete_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_palabra]
(@P_ID int)
AS
BEGIN
DELETE FROM PALABRA WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[delete_traduccion]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_traduccion]
(@P_ID int)
AS
BEGIN
DELETE FROM TRADUCCION WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[delete_usuario]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_usuario]
(@P_ID int)
AS
BEGIN
DELETE FROM USUARIO WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[insert_exception]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[insert_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_idioma]
(@P_CODIGO	varchar(2),
@P_NOMBRE	varchar(50))
AS
BEGIN
INSERT INTO IDIOMA (CODIGO,NOMBRE) VALUES (@P_CODIGO,@P_NOMBRE)
SELECT * FROM IDIOMA WHERE ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insert_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_palabra]
(@P_ID_IDIOMA	int,
@P_ID_TRADUCTOR	int,
@P_FAMILIA	varchar(100),
@P_PALABRA	varchar(100),
@P_FECHA	datetime)
AS
BEGIN
INSERT INTO PALABRA (ID_IDIOMA,ID_TRADUCTOR,FAMILIA,PALABRA,FECHA) VALUES (@P_ID_IDIOMA,@P_ID_TRADUCTOR,@P_FAMILIA,@P_PALABRA,@P_FECHA)
SELECT * FROM PALABRA WHERE ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insert_traduccion]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_traduccion]
(@P_ID_USUARIO	int,
@P_IDIOMA_ORIGINAL	int,
@P_IDIOMA_DESTINO	int,
@P_FRASE_ORIGINAL	varchar(500),
@P_FRASE_TRADUCIDA	varchar(500),
@P_POPULARIDAD_TOTAL	int,
@P_FECHA	datetime)
AS
BEGIN
INSERT INTO TRADUCCION (ID_USUARIO,IDIOMA_ORIGINAL,IDIOMA_DESTINO,FRASE_ORIGINAL,FRASE_TRADUCIDA,POPULARIDAD_TOTAL,FECHA) VALUES (@P_ID_USUARIO,@P_IDIOMA_ORIGINAL,@P_IDIOMA_DESTINO,@P_FRASE_ORIGINAL,@P_FRASE_TRADUCIDA,@P_POPULARIDAD_TOTAL,@P_FECHA)
SELECT * FROM TRADUCCION WHERE ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insert_traducciones_palabras]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_traducciones_palabras]
(@P_ID_TRADUCCION	int,
@P_ID_PALABRA	int,
@P_ORDEN	int)
AS
BEGIN
INSERT INTO TRADUCCIONES_PALABRAS (ID_TRADUCCION,ID_PALABRA,ORDEN) VALUES (@P_ID_TRADUCCION,@P_ID_PALABRA,@P_ORDEN)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_usuario]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_usuario]
(@P_NOMBRE	varchar(50),
@P_APELLIDO	varchar(50))
AS
BEGIN
INSERT INTO USUARIO (NOMBRE,APELLIDO) VALUES (@P_NOMBRE,@P_APELLIDO)
SELECT * FROM USUARIO WHERE ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[list_appmessages]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_appmessages]
AS
BEGIN
	SELECT * FROM APPMESSAGES
END
GO
/****** Object:  StoredProcedure [dbo].[list_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_idioma]
AS
BEGIN
SELECT * FROM IDIOMA
END

GO
/****** Object:  StoredProcedure [dbo].[list_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_palabra]
AS
BEGIN
SELECT * FROM PALABRA
END
GO
/****** Object:  StoredProcedure [dbo].[list_palabra_by_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_palabra_by_idioma]
	(@P_ID_IDIOMA INT)
AS
BEGIN
	SELECT * FROM PALABRA WHERE ID_IDIOMA = @P_ID_IDIOMA
END
GO
/****** Object:  StoredProcedure [dbo].[list_traduccion]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_traduccion]
AS
BEGIN
SELECT * FROM TRADUCCION
END

GO
/****** Object:  StoredProcedure [dbo].[list_traducciones_palabras]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_traducciones_palabras]
AS
BEGIN
SELECT * FROM TRADUCCIONES_PALABRAS
END

GO
/****** Object:  StoredProcedure [dbo].[list_usuario]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[list_usuario]
AS
BEGIN
SELECT * FROM USUARIO
END

GO
/****** Object:  StoredProcedure [dbo].[select_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[select_idioma]
(@P_ID int)
AS
BEGIN
SELECT * FROM IDIOMA WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[select_idioma_mas_popular]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_idioma_mas_popular]
AS
BEGIN
	SELECT I.ID, I.CODIGO, I.NOMBRE, J.POPULARIDAD FROM IDIOMA AS I
	INNER JOIN (SELECT * FROM 
					(SELECT 
						ROW_NUMBER() OVER (ORDER BY P.POPULARIDAD DESC) AS ROW,
						P.IDIOMA,
						P.POPULARIDAD
						FROM (SELECT 
								T.IDIOMA_DESTINO AS IDIOMA, 
								COUNT(T.IDIOMA_DESTINO) AS POPULARIDAD
									FROM TRADUCCION AS T
									GROUP BY T.IDIOMA_DESTINO) AS P) AS A
					WHERE A.ROW = 1) AS J ON J.IDIOMA = IDIOMA
	WHERE ID IN (SELECT IDIOMA FROM 
					(SELECT 
						ROW_NUMBER() OVER (ORDER BY P.POPULARIDAD DESC) AS ROW,
						P.IDIOMA,
						P.POPULARIDAD
						FROM (SELECT 
								T.IDIOMA_DESTINO AS IDIOMA, 
								COUNT(T.IDIOMA_DESTINO) AS POPULARIDAD
									FROM TRADUCCION AS T
									GROUP BY T.IDIOMA_DESTINO) AS P) AS A
					WHERE A.ROW = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[select_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[select_palabra]
(@P_ID int)
AS
BEGIN
SELECT * FROM PALABRA WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[select_palabra_by_familia_and_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[select_palabra_by_familia_and_idioma]
(@P_ID_IDIOMA INT,
 @P_FAMILIA VARCHAR(100))
AS
BEGIN
SELECT * FROM PALABRA WHERE FAMILIA = @P_FAMILIA AND ID_IDIOMA = @P_ID_IDIOMA
END
GO
/****** Object:  StoredProcedure [dbo].[select_palabra_by_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[select_palabra_by_palabra]
(@P_PALABRA VARCHAR(100))
AS
BEGIN
SELECT * FROM PALABRA WHERE PALABRA = @P_PALABRA
END
GO
/****** Object:  StoredProcedure [dbo].[select_top_palabras]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_top_palabras]
AS
BEGIN
	SELECT TOP 100
		P.ID,
		P.ID_IDIOMA,
		P.ID_TRADUCTOR,
		P.FAMILIA,
		P.PALABRA,
		P.FECHA,
		COUNT (TP.ID_PALABRA) AS POPULARIDAD 
			FROM TRADUCCIONES_PALABRAS AS TP
	INNER JOIN
		PALABRA AS P ON P.ID = TP.ID_PALABRA
		GROUP BY P.ID,
		P.ID_IDIOMA,
		P.ID_TRADUCTOR,
		P.FAMILIA,
		P.PALABRA,
		P.FECHA,
		TP.ID_PALABRA
		
END
GO
/****** Object:  StoredProcedure [dbo].[select_top_palabras_by_dia]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_top_palabras_by_dia]
	(@P_DIA INT)
AS
BEGIN
	SELECT TOP 10
		P.ID,
		P.ID_IDIOMA,
		P.ID_TRADUCTOR,
		P.FAMILIA,
		P.PALABRA,
		P.FECHA,
		COUNT (TP.ID_PALABRA) AS POPULARIDAD 
			FROM TRADUCCIONES_PALABRAS AS TP
	INNER JOIN
		PALABRA AS P ON P.ID = TP.ID_PALABRA
	WHERE DATEPART(DW,P.FECHA) = @P_DIA
	GROUP BY P.ID,
		P.ID_IDIOMA,
		P.ID_TRADUCTOR,
		P.FAMILIA,
		P.PALABRA,
		P.FECHA,
		TP.ID_PALABRA
END
GO
/****** Object:  StoredProcedure [dbo].[select_traduccion]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[select_traduccion]
(@P_ID int)
AS
BEGIN
SELECT * FROM TRADUCCION WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[select_traducciones_por_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_traducciones_por_palabra]
	(@P_ID_PALABRA INT)
AS
BEGIN
	SELECT * FROM TRADUCCION
		WHERE ID IN (SELECT ID_TRADUCCION FROM TRADUCCIONES_PALABRAS WHERE ID_PALABRA = @P_ID_PALABRA)
END
GO
/****** Object:  StoredProcedure [dbo].[select_usuario]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[select_usuario]
(@P_ID int)
AS
BEGIN
SELECT * FROM USUARIO WHERE ID = @P_ID
END

GO
/****** Object:  StoredProcedure [dbo].[select_usuario_mas_traducciones]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_usuario_mas_traducciones]
AS
BEGIN
	SELECT I.ID, I.NOMBRE, I.APELLIDO, J.POPULARIDAD FROM USUARIO AS I
INNER JOIN (SELECT * FROM 
				(SELECT 
					ROW_NUMBER() OVER (ORDER BY P.POPULARIDAD DESC) AS ROW,
					P.USUARIO,
					P.POPULARIDAD
					FROM (SELECT 
							T.ID_USUARIO AS USUARIO, 
							COUNT(T.ID_USUARIO) AS POPULARIDAD
								FROM TRADUCCION AS T
								GROUP BY T.ID_USUARIO) AS P) AS A
				WHERE A.ROW = 1) AS J ON J.USUARIO = USUARIO
WHERE ID IN (SELECT USUARIO FROM 
				(SELECT 
					ROW_NUMBER() OVER (ORDER BY P.POPULARIDAD DESC) AS ROW,
					P.USUARIO,
					P.POPULARIDAD
					FROM (SELECT 
							T.ID_USUARIO AS USUARIO, 
							COUNT(T.ID_USUARIO) AS POPULARIDAD
								FROM TRADUCCION AS T
								GROUP BY T.ID_USUARIO) AS P) AS A
				WHERE A.ROW = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[update_idioma]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_idioma]
(@P_ID	int,
@P_CODIGO	varchar(2),
@P_NOMBRE	varchar(50))
AS
BEGIN
UPDATE IDIOMA SET CODIGO = @P_CODIGO,NOMBRE = @P_NOMBRE WHERE ID = @P_ID
SELECT * FROM IDIOMA WHERE ID = @P_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[update_palabra]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_palabra]
(@P_ID	int,
@P_ID_IDIOMA	int,
@P_ID_TRADUCTOR	int,
@P_FAMILIA	varchar(100),
@P_PALABRA	varchar(100),
@P_FECHA	datetime)
AS
BEGIN
UPDATE PALABRA SET ID_IDIOMA = @P_ID_IDIOMA,ID_TRADUCTOR = @P_ID_TRADUCTOR,FAMILIA = @P_FAMILIA,PALABRA = @P_PALABRA,FECHA = @P_FECHA WHERE ID = @P_ID

SELECT * FROM IDIOMA WHERE ID = @P_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[update_traduccion]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_traduccion]
(@P_ID	int,
@P_ID_USUARIO	int,
@P_IDIOMA_ORIGINAL	int,
@P_IDIOMA_DESTINO	int,
@P_FRASE_ORIGINAL	varchar(500),
@P_FRASE_TRADUCIDA	varchar(500),
@P_POPULARIDAD_TOTAL	int,
@P_FECHA	datetime)
AS
BEGIN
UPDATE TRADUCCION SET ID_USUARIO = @P_ID_USUARIO,IDIOMA_ORIGINAL = @P_IDIOMA_ORIGINAL,IDIOMA_DESTINO = @P_IDIOMA_DESTINO,FRASE_ORIGINAL = @P_FRASE_ORIGINAL,FRASE_TRADUCIDA = @P_FRASE_TRADUCIDA,POPULARIDAD_TOTAL = @P_POPULARIDAD_TOTAL,FECHA = @P_FECHA WHERE ID = @P_ID

SELECT * FROM TRADUCCION WHERE ID = @P_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[update_usuario]    Script Date: 3/5/2018 5:44:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_usuario]
(@P_ID	int,
@P_NOMBRE	varchar(50),
@P_APELLIDO	varchar(50))
AS
BEGIN
UPDATE USUARIO SET NOMBRE = @P_NOMBRE,APELLIDO = @P_APELLIDO WHERE ID = @P_ID

SELECT * FROM USUARIO WHERE ID = @P_ID;
END
GO
USE [master]
GO
ALTER DATABASE [PolyBot] SET  READ_WRITE 
GO
