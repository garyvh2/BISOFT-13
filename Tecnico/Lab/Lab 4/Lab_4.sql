USE [master]
GO
/****** Object:  Database [GranjaCenfotec]    Script Date: 2/15/2018 3:51:39 PM ******/
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
/****** Object:  Table [dbo].[ANIMAL]    Script Date: 2/15/2018 3:51:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANIMAL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[CATEGORIA] [varchar](50) NULL,
	[EDAD] [float] NULL,
	[FECHA_NACIMIENTO] [datetime] NULL,
	[ALIMENTO] [varchar](50) NULL,
	[GENERO] [varchar](50) NULL,
 CONSTRAINT [PK_ANIMAL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[APPMESSAGES]    Script Date: 2/15/2018 3:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPMESSAGES](
	[ID] [int] NULL,
	[TEXT] [varchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXCEPTIONS]    Script Date: 2/15/2018 3:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXCEPTIONS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MESSAGE] [varchar](250) NULL,
	[STACKTRACE] [varchar](500) NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [PK_EXCEPTIONS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MENSAJES]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  Table [dbo].[PRODUCCION]    Script Date: 2/15/2018 3:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCCION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_ANIMAL] [int] NULL,
	[TIPO] [varchar](50) NULL,
	[CANTIDAD] [float] NULL,
	[VALOR] [float] NULL,
	[FECHA_REGISTRO] [datetime] NULL,
 CONSTRAINT [PK_PRODUCCION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ANIMAL] ON 

INSERT [dbo].[ANIMAL] ([ID], [NOMBRE], [CATEGORIA], [EDAD], [FECHA_NACIMIENTO], [ALIMENTO], [GENERO]) VALUES (4, N'Juan', N'Gallina', 3, CAST(N'2015-03-04T00:00:00.000' AS DateTime), N'Trigo', N'Hembra')
INSERT [dbo].[ANIMAL] ([ID], [NOMBRE], [CATEGORIA], [EDAD], [FECHA_NACIMIENTO], [ALIMENTO], [GENERO]) VALUES (5, N'Carlos', N'Vaca', 2, CAST(N'2016-04-02T00:00:00.000' AS DateTime), N'Pasto', N'Macho')
SET IDENTITY_INSERT [dbo].[ANIMAL] OFF
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (2, N'La edad de los animales debe ser de minimo 6 meses')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (3, N'Un Animal Con el mismo codigo ya fue ingresado al sistema anteriormente')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (4, N'Un Animal con el mismo nombre ya fue ingresado al sistema anteriormente')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (5, N'Al registrar a un animal la fecha de nacimiento debe ser menor al día en curso')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (6, N'Ni valor ni cantidad de la produccion pueden ser 0')
INSERT [dbo].[APPMESSAGES] ([ID], [TEXT]) VALUES (7, N'No se pueden registrar producciones si estas no pertenecen a animales existentes')
SET IDENTITY_INSERT [dbo].[EXCEPTIONS] ON 

INSERT [dbo].[EXCEPTIONS] ([ID], [MESSAGE], [STACKTRACE], [DATE]) VALUES (1, N'Exception of type ''Excepciones.BussinessException'' was thrown.', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 36', CAST(N'2018-02-15T14:49:47.110' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [MESSAGE], [STACKTRACE], [DATE]) VALUES (2, N'Exception of type ''Excepciones.BussinessException'' was thrown.
Un Animal con el mismo nombre ya fue ingresado al sistema anteriormente', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 38', CAST(N'2018-02-15T14:58:08.447' AS DateTime))
INSERT [dbo].[EXCEPTIONS] ([ID], [MESSAGE], [STACKTRACE], [DATE]) VALUES (3, N'Exception of type ''Excepciones.BussinessException'' was thrown.
La edad de los animales debe ser de minimo 6 meses', N'   at Cliente.AnimalManagement.Create(Animal animal) in C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_4\Cliente\AnimalManagement.cs:line 54', CAST(N'2018-02-15T15:36:26.150' AS DateTime))
SET IDENTITY_INSERT [dbo].[EXCEPTIONS] OFF
SET IDENTITY_INSERT [dbo].[PRODUCCION] ON 

INSERT [dbo].[PRODUCCION] ([ID], [ID_ANIMAL], [TIPO], [CANTIDAD], [VALOR], [FECHA_REGISTRO]) VALUES (8, 4, N'Huevos', 30, 3500, CAST(N'2018-02-09T23:54:23.960' AS DateTime))
SET IDENTITY_INSERT [dbo].[PRODUCCION] OFF
ALTER TABLE [dbo].[PRODUCCION]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCCION_ANIMAL] FOREIGN KEY([ID_ANIMAL])
REFERENCES [dbo].[ANIMAL] ([ID])
GO
ALTER TABLE [dbo].[PRODUCCION] CHECK CONSTRAINT [FK_PRODUCCION_ANIMAL]
GO
/****** Object:  StoredProcedure [dbo].[delete_animal]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_produccion]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[find_animal]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[find_animal_by_nombre]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[find_produccion]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[insert_animal]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[insert_exception]    Script Date: 2/15/2018 3:51:40 PM ******/
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
	(@P_MESSAGE	        varchar(250),
	 @P_STACKTRACE	    varchar(500),
	 @P_DATE            datetime)
AS
BEGIN
	INSERT INTO EXCEPTIONS (MESSAGE,STACKTRACE,DATE) VALUES (@P_MESSAGE, @P_STACKTRACE, @P_DATE)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_produccion]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_animal]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_animal_by_categoria]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_animal_by_nombre]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_appmessages]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_produccion]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_produccion_by_animal]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_produccion_by_rango]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[list_produccion_by_rango_categoria]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_animal]    Script Date: 2/15/2018 3:51:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_produccion]    Script Date: 2/15/2018 3:51:40 PM ******/
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
