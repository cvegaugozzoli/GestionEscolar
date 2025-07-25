USE [GESTIONESCOLAR]
GO
/****** Object:  StoredProcedure [dbo].[Docentes.Actualizar]    Script Date: 11/11/2019 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Docentes.Actualizar]
(
@doc_id int,
@doc_doc varchar(20),
@doc_nombre varchar(50),
@doc_apellido varchar(50),
@doc_domicilio varchar(50),
@doc_telef varchar(50),
@doc_mail varchar(50),
@usu_id int,
@usuidCreacion int,
@usuidUltimaModificacion int,
@docFechaHoraCreacion datetime,
@docFechaHoraUltimaModificacion datetime
)

as

update Docentes set
doc_doc = @doc_doc,
doc_nombre = @doc_nombre,
doc_apellido = @doc_apellido,
doc_domicilio = @doc_domicilio,
doc_telef = @doc_telef,
doc_mail = @doc_mail,
usu_id = @usu_id,
usuidCreacion = @usuidCreacion,
usuidUltimaModificacion = @usuidUltimaModificacion,
docFechaHoraCreacion = @docFechaHoraCreacion,
docFechaHoraUltimaModificacion = @docFechaHoraUltimaModificacion

where 1 = 1
and doc_id = @doc_id
GO
/****** Object:  StoredProcedure [dbo].[Docentes.Eliminar]    Script Date: 11/11/2019 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Docentes.Eliminar]
(
@doc_id int
)

as
delete from Docentes
where 1 = 1 
and Docentes.doc_id = @doc_id
GO
/****** Object:  StoredProcedure [dbo].[Docentes.Insertar]    Script Date: 11/11/2019 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Docentes.Insertar]
(
@doc_doc varchar(20),
@doc_nombre varchar(50),
@doc_apellido varchar(50),
@doc_domicilio varchar(50),
@doc_telef varchar(50),
@doc_mail varchar(50),
@usu_id int,
@usuidCreacion int,
@usuidUltimaModificacion int,
@docFechaHoraCreacion datetime,
@docFechaHoraUltimaModificacion datetime
)

as

insert into Docentes
(
doc_doc,
doc_nombre,
doc_apellido,
doc_domicilio,
doc_telef,
doc_mail,
usu_id,
usuidCreacion,
usuidUltimaModificacion,
docFechaHoraCreacion,
docFechaHoraUltimaModificacion
)

values
(
@doc_doc,
@doc_nombre,
@doc_apellido,
@doc_domicilio,
@doc_telef,
@doc_mail,
@usu_id,
@usuidCreacion,
@usuidUltimaModificacion,
@docFechaHoraCreacion,
@docFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
/****** Object:  StoredProcedure [dbo].[Docentes.ObtenerTodo]    Script Date: 11/11/2019 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Docentes.ObtenerTodo]

as

select Docentes.doc_id as [_id], 
isnull(Docentes.doc_doc,' ') as [_doc], 
isnull(Docentes.doc_nombre,' ') as [_nombre], 
isnull(Docentes.doc_apellido,' ') as [_apellido], 
isnull(Docentes.doc_domicilio,' ') as [_domicilio], 
isnull(Docentes.doc_telef,' ') as [_telef], 
isnull(Docentes.doc_mail,' ') as [_mail], 
Docentes.usu_id as [_id], 
Usuario_usuidCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuidUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Docentes.docFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Docentes.docFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
Docentes.doc_id, 
Docentes.doc_doc, 
Docentes.doc_nombre, 
Docentes.doc_apellido, 
Docentes.doc_domicilio, 
Docentes.doc_telef, 
Docentes.doc_mail, 
Docentes.usu_id, 
Docentes.usuidCreacion, 
Docentes.usuidUltimaModificacion, 
Docentes.docFechaHoraCreacion, 
Docentes.docFechaHoraUltimaModificacion

from Docentes
left outer join Usuario as Usuario_usuidCreacion on Docentes.usuidCreacion = Usuario_usuidCreacion.usuid
left outer join Usuario as Usuario_usuidUltimaModificacion on Docentes.usuidUltimaModificacion = Usuario_usuidUltimaModificacion.usuid

order by 1
GO
/****** Object:  StoredProcedure [dbo].[Docentes.ObtenerUno]    Script Date: 11/11/2019 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Docentes.ObtenerUno]
(
@doc_id int
)

as

select 
Docentes.doc_id as [_id], 
isnull(Docentes.doc_doc,' ') as [_doc], 
isnull(Docentes.doc_nombre,' ') as [_nombre], 
isnull(Docentes.doc_apellido,' ') as [_apellido], 
isnull(Docentes.doc_domicilio,' ') as [_domicilio], 
isnull(Docentes.doc_telef,' ') as [_telef], 
isnull(Docentes.doc_mail,' ') as [_mail], 
Docentes.usu_id as [_id], 
Usuario_usuidCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuidUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),Docentes.docFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),Docentes.docFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], Docentes.doc_id,
Docentes.doc_doc,
Docentes.doc_nombre,
Docentes.doc_apellido,
Docentes.doc_domicilio,
Docentes.doc_telef,
Docentes.doc_mail,
Docentes.usu_id,
Docentes.usuidCreacion,
Docentes.usuidUltimaModificacion,
Docentes.docFechaHoraCreacion,
Docentes.docFechaHoraUltimaModificacion

from Docentes
left outer join Usuario as Usuario_usuidCreacion on Docentes.usuidCreacion = Usuario_usuidCreacion.usuid
left outer join Usuario as Usuario_usuidUltimaModificacion on Docentes.usuidUltimaModificacion = Usuario_usuidUltimaModificacion.usuid

where 1 = 1 
and Docentes.doc_id = @doc_id
GO
/****** Object:  Table [dbo].[Docentes]    Script Date: 11/11/2019 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Docentes](
	[doc_id] [int] IDENTITY(1,1) NOT NULL,
	[doc_doc] [varchar](20) NULL,
	[doc_nombre] [varchar](50) NULL,
	[doc_apellido] [varchar](50) NULL,
	[doc_domicilio] [varchar](50) NULL,
	[doc_telef] [varchar](50) NULL,
	[doc_mail] [varchar](50) NULL,
	[usu_id] [int] NULL,
	[usuidCreacion] [int] NULL,
	[usuidUltimaModificacion] [int] NULL,
	[docFechaHoraCreacion] [datetime] NULL,
	[docFechaHoraUltimaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Docentes] PRIMARY KEY CLUSTERED 
(
	[doc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
