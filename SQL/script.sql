USE [master]
GO

CREATE DATABASE [SistemasDeInformacion]

USE [SistemasDeInformacion]
GO


CREATE TABLE [dbo].[trnRol](
	[IdRol] [int] NULL,
	[NombreRol] [nvarchar](50) NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [bit] NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[visRol]
AS
SELECT     dbo.trnRol.*
FROM         dbo.trnRol
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trnUsuario](
	[IdUsuario] [int] NULL,
	[NombreUsuario] [nvarchar](50) NULL,
	[Clave] [nvarchar](100) NULL,
	[Salt] [nvarchar](10) NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [bit] NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[visUsuario]
AS
SELECT     dbo.trnUsuario.*
FROM         dbo.trnUsuario
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
