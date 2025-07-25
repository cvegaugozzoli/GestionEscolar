USE [GESTIONESCOLAR]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioEspacioCurricular.Actualizar]    Script Date: 29/10/2019 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioEspacioCurricular.Actualizar]
(
@uscId int,
@usuId int,
@uscAnoCursado int,
@carId int,
@plaId int,
@curId int,
@camId int,
@escId int,
@uscActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@uscFechaHoraCreacion datetime,
@uscFechaHoraUltimaModificacion datetime
)

as

update UsuarioEspacioCurricular set
usuId = @usuId,
uscAnoCursado = @uscAnoCursado,
carId = @carId,
plaId = @plaId,
curId = @curId,
camId = @camId,
escId = @escId,
uscActivo = @uscActivo,
usuIdCreacion = @usuIdCreacion,
usuIdUltimaModificacion = @usuIdUltimaModificacion,
uscFechaHoraCreacion = @uscFechaHoraCreacion,
uscFechaHoraUltimaModificacion = @uscFechaHoraUltimaModificacion

where 1 = 1
and uscId = @uscId
GO
/****** Object:  StoredProcedure [dbo].[UsuarioEspacioCurricular.Eliminar]    Script Date: 29/10/2019 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioEspacioCurricular.Eliminar]
(
@uscId int
)

as
delete from UsuarioEspacioCurricular
where 1 = 1 
and UsuarioEspacioCurricular.uscId = @uscId
GO
/****** Object:  StoredProcedure [dbo].[UsuarioEspacioCurricular.Insertar]    Script Date: 29/10/2019 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioEspacioCurricular.Insertar]
(
@usuId int,
@uscAnoCursado int,
@carId int,
@plaId int,
@curId int,
@camId int,
@escId int,
@uscActivo tinyint,
@usuIdCreacion int,
@usuIdUltimaModificacion int,
@uscFechaHoraCreacion datetime,
@uscFechaHoraUltimaModificacion datetime
)

as

insert into UsuarioEspacioCurricular
(
usuId,
uscAnoCursado,
carId,
plaId,
curId,
camId,
escId,
uscActivo,
usuIdCreacion,
usuIdUltimaModificacion,
uscFechaHoraCreacion,
uscFechaHoraUltimaModificacion
)

values
(
@usuId,
@uscAnoCursado,
@carId,
@plaId,
@curId,
@camId,
@escId,
@uscActivo,
@usuIdCreacion,
@usuIdUltimaModificacion,
@uscFechaHoraCreacion,
@uscFechaHoraUltimaModificacion
)

select @@identity as IdMax
GO
/****** Object:  StoredProcedure [dbo].[UsuarioEspacioCurricular.ObtenerTodo]    Script Date: 29/10/2019 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioEspacioCurricular.ObtenerTodo]

as

select UsuarioEspacioCurricular.uscId as [Id], 
Usuario_usuId.usuNombre as [Usuario], 
UsuarioEspacioCurricular.uscAnoCursado as [AnoCursado], 
Carrera_carId.carNombre as [Carrera], 
PlanEstudio_plaId.plaNombre as [PlanEstudio], 
Curso_curId.curNombre as [Curso], 
Campo_camId.camNombre as [Campo], 
EspacioCurricular_escId.escNombre as [EspacioCurricular], 
case when UsuarioEspacioCurricular.uscActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),UsuarioEspacioCurricular.uscFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),UsuarioEspacioCurricular.uscFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion],
UsuarioEspacioCurricular.uscId, 
UsuarioEspacioCurricular.usuId, 
UsuarioEspacioCurricular.uscAnoCursado, 
UsuarioEspacioCurricular.carId, 
UsuarioEspacioCurricular.plaId, 
UsuarioEspacioCurricular.curId, 
UsuarioEspacioCurricular.camId, 
UsuarioEspacioCurricular.escId, 
UsuarioEspacioCurricular.uscActivo, 
UsuarioEspacioCurricular.usuIdCreacion, 
UsuarioEspacioCurricular.usuIdUltimaModificacion, 
UsuarioEspacioCurricular.uscFechaHoraCreacion, 
UsuarioEspacioCurricular.uscFechaHoraUltimaModificacion

from UsuarioEspacioCurricular
left outer join Usuario as Usuario_usuId on UsuarioEspacioCurricular.usuId = Usuario_usuId.usuId
left outer join Carrera as Carrera_carId on UsuarioEspacioCurricular.carId = Carrera_carId.carId
left outer join PlanEstudio as PlanEstudio_plaId on UsuarioEspacioCurricular.plaId = PlanEstudio_plaId.plaId
left outer join Curso as Curso_curId on UsuarioEspacioCurricular.curId = Curso_curId.curId
left outer join Campo as Campo_camId on UsuarioEspacioCurricular.camId = Campo_camId.camId
left outer join EspacioCurricular as EspacioCurricular_escId on UsuarioEspacioCurricular.escId = EspacioCurricular_escId.escId
left outer join Usuario as Usuario_usuIdCreacion on UsuarioEspacioCurricular.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on UsuarioEspacioCurricular.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

order by 1
GO
/****** Object:  StoredProcedure [dbo].[UsuarioEspacioCurricular.ObtenerUno]    Script Date: 29/10/2019 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioEspacioCurricular.ObtenerUno]
(
@uscId int
)

as

select 
UsuarioEspacioCurricular.uscId as [Id], 
Usuario_usuId.usuNombre as [Usuario], 
UsuarioEspacioCurricular.uscAnoCursado as [AnoCursado], 
Carrera_carId.carNombre as [Carrera], 
PlanEstudio_plaId.plaNombre as [PlanEstudio], 
Curso_curId.curNombre as [Curso], 
Campo_camId.camNombre as [Campo], 
EspacioCurricular_escId.escNombre as [EspacioCurricular], 
case when UsuarioEspacioCurricular.uscActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),UsuarioEspacioCurricular.uscFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),UsuarioEspacioCurricular.uscFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], UsuarioEspacioCurricular.uscId,
UsuarioEspacioCurricular.usuId,
UsuarioEspacioCurricular.uscAnoCursado,
UsuarioEspacioCurricular.carId,
UsuarioEspacioCurricular.plaId,
UsuarioEspacioCurricular.curId,
UsuarioEspacioCurricular.camId,
UsuarioEspacioCurricular.escId,
UsuarioEspacioCurricular.uscActivo,
UsuarioEspacioCurricular.usuIdCreacion,
UsuarioEspacioCurricular.usuIdUltimaModificacion,
UsuarioEspacioCurricular.uscFechaHoraCreacion,
UsuarioEspacioCurricular.uscFechaHoraUltimaModificacion

from UsuarioEspacioCurricular
left outer join Usuario as Usuario_usuId on UsuarioEspacioCurricular.usuId = Usuario_usuId.usuId
left outer join Carrera as Carrera_carId on UsuarioEspacioCurricular.carId = Carrera_carId.carId
left outer join PlanEstudio as PlanEstudio_plaId on UsuarioEspacioCurricular.plaId = PlanEstudio_plaId.plaId
left outer join Curso as Curso_curId on UsuarioEspacioCurricular.curId = Curso_curId.curId
left outer join Campo as Campo_camId on UsuarioEspacioCurricular.camId = Campo_camId.camId
left outer join EspacioCurricular as EspacioCurricular_escId on UsuarioEspacioCurricular.escId = EspacioCurricular_escId.escId
left outer join Usuario as Usuario_usuIdCreacion on UsuarioEspacioCurricular.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on UsuarioEspacioCurricular.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

where 1 = 1 
and UsuarioEspacioCurricular.uscId = @uscId
GO
