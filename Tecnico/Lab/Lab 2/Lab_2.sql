USE [master]
GO
/****** Object:  Database [Laboratorio2]    Script Date: 2/2/2018 4:11:03 AM ******/
CREATE DATABASE [Laboratorio2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Laboratorio2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Laboratorio2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Laboratorio2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Laboratorio2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Laboratorio2] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Laboratorio2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Laboratorio2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Laboratorio2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Laboratorio2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Laboratorio2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Laboratorio2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Laboratorio2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Laboratorio2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Laboratorio2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Laboratorio2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Laboratorio2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Laboratorio2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Laboratorio2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Laboratorio2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Laboratorio2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Laboratorio2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Laboratorio2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Laboratorio2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Laboratorio2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Laboratorio2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Laboratorio2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Laboratorio2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Laboratorio2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Laboratorio2] SET RECOVERY FULL 
GO
ALTER DATABASE [Laboratorio2] SET  MULTI_USER 
GO
ALTER DATABASE [Laboratorio2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Laboratorio2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Laboratorio2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Laboratorio2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Laboratorio2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Laboratorio2', N'ON'
GO
ALTER DATABASE [Laboratorio2] SET QUERY_STORE = OFF
GO
USE [Laboratorio2]
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
USE [Laboratorio2]
GO
/****** Object:  Table [dbo].[PLANETA]    Script Date: 2/2/2018 4:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLANETA](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ID_SISTEMA] [numeric](18, 0) NULL,
	[NOMBRE] [varchar](50) NULL,
	[SUNDISTANCE] [numeric](18, 0) NULL,
	[FECHA] [datetime] NULL,
 CONSTRAINT [PK__tmp_ms_x__3214EC0751E29275] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SISTEMA]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SISTEMA](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[FECHA] [datetime] NULL,
 CONSTRAINT [PK__TSistema__3214EC07C87A3C52] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PLANETA] ADD  CONSTRAINT [DF__tmp_ms_xx__fecha__38996AB5]  DEFAULT (getdate()) FOR [FECHA]
GO
ALTER TABLE [dbo].[SISTEMA] ADD  CONSTRAINT [DF__TSistemaS__fecha__398D8EEE]  DEFAULT (getdate()) FOR [FECHA]
GO
ALTER TABLE [dbo].[PLANETA]  WITH CHECK ADD  CONSTRAINT [FK_PLANETA_PLANETA] FOREIGN KEY([ID_SISTEMA])
REFERENCES [dbo].[SISTEMA] ([ID])
GO
ALTER TABLE [dbo].[PLANETA] CHECK CONSTRAINT [FK_PLANETA_PLANETA]
GO
/****** Object:  StoredProcedure [dbo].[delete_planeta]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_planeta]
	(@ID		NUMERIC(18,0))
AS
BEGIN
	DELETE FROM PLANETA WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[delete_sistema]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_sistema]
	(@ID		NUMERIC(18,0))
AS
BEGIN
	DELETE FROM SISTEMA WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[insertar_planeta]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insertar_planeta]
	(@ID_SISTEMA	NUMERIC (18,0),
	 @NOMBRE		VARCHAR(50),
	 @SUNDISTANCE	NUMERIC (18,0),
	 @FECHA			DATETIME)
AS
BEGIN
	INSERT INTO PLANETA (ID_SISTEMA, NOMBRE, SUNDISTANCE, FECHA) VALUES (@ID_SISTEMA, @NOMBRE,@SUNDISTANCE, @FECHA)
END
GO
/****** Object:  StoredProcedure [dbo].[insertar_sistema]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insertar_sistema]
	(@NOMBRE		VARCHAR(50),
	 @FECHA			DATETIME)
AS
BEGIN
	INSERT INTO SISTEMA(NOMBRE, FECHA) VALUES (@NOMBRE, @FECHA)
END
GO
/****** Object:  StoredProcedure [dbo].[list_planetas]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_planetas]
AS
BEGIN
	SELECT * FROM PLANETA
END
GO
/****** Object:  StoredProcedure [dbo].[list_sistemas]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_sistemas]
AS
BEGIN
	SELECT * FROM SISTEMA
END
GO
/****** Object:  StoredProcedure [dbo].[select_planeta]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_planeta]
	(@ID	NUMERIC (18,0))
AS
BEGIN
	SELECT * FROM PLANETA WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[select_planetas_por_sistema]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[select_planetas_por_sistema]
	(@ID_SISTEMA	NUMERIC (18,0))
AS
BEGIN
	SELECT * FROM PLANETA WHERE ID_SISTEMA = @ID_SISTEMA
END
GO
/****** Object:  StoredProcedure [dbo].[select_sistema]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[select_sistema]
	(@ID	NUMERIC (18,0))
AS
BEGIN
	SELECT * FROM SISTEMA WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[update_planeta]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_planeta]
	(@ID			NUMERIC (18,0),
	 @ID_SISTEMA	NUMERIC (18,0),
	 @NOMBRE		VARCHAR(50),
	 @SUNDISTANCE	NUMERIC (18,0),
	 @FECHA			DATETIME)
AS
BEGIN
	UPDATE PLANETA 
		SET
			ID_SISTEMA = @ID_SISTEMA, 
			NOMBRE = @NOMBRE, 
			SUNDISTANCE = @SUNDISTANCE,
			FECHA = @FECHA
			WHERE
				ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[update_sistema]    Script Date: 2/2/2018 4:11:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_sistema]
	(@ID			NUMERIC (18,0),
	 @NOMBRE		VARCHAR(50),
	 @FECHA			DATETIME)
AS
BEGIN
	UPDATE SISTEMA 
		SET
			NOMBRE = @NOMBRE, 
			FECHA = @FECHA
			WHERE
				ID = @ID
END
GO
USE [master]
GO
ALTER DATABASE [Laboratorio2] SET  READ_WRITE 
GO
