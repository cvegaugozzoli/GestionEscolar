USE [GestionEscolar]
GO

/****** Object:  Table [dbo].[IntencionPagos]    Script Date: 03/07/2025 20:59:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[IntencionPagos](
	[inpId] [int] IDENTITY(1,1) NOT NULL,
	[inp_IdReferenciaOperacion] [varchar](100) NULL,
	[inp_Hash] [varchar](200) NULL,
	[inp_FechaCreacion] [datetime] NULL,
	[inp_Estado] [nvarchar](50) NULL,
	[inp_Monto] [decimal](18, 2) NULL,
	[inp_UsuId] [int] NULL,
	[inp_comprobantenro] [varchar](50) NULL,
	[aluid] [int] NULL,
	[inp_FechaExpiracion] [datetime] NULL,
	[inp_bearerToken] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[inpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

