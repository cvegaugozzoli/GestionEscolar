USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[InscripcionCursado.ObtenerUnoControlExisteNoTerciario]    Script Date: 28/2/2025 09:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InscripcionCursado.ObtenerUnoControlExisteMismoAño]
(
@insId int,
@aluId int,
--@curId int,
@icuAnioCursado int
)

 --exec [InscripcionCursado.ObtenerUnoControlExisteMismoAño] 1,25013,2025

as

select 
InscripcionCursado.icuId as [Id], 
Alumno_aluId.aluNombre as [Alumno], 
Carrera_carId.carNombre as [Carrera], 
PlanEstudio_plaId.plaNombre as [PlanEstudio], 
Curso_curId.curNombre as [Curso], 
Campo_camId.camNombre as [Campo], 
EspacioCurricular_escId.escNombre as [EspacioCurricular], 
InscripcionCursado.icuAnoCursado as [AnoCursado], 
convert(varchar(10),InscripcionCursado.icuFechaInscripcion,103) as [FechaInscripcion], 
case when InscripcionCursado.icuActivo = 0 then 'No' else 'Si' end as [Activo], 
Usuario_usuIdCreacion.usuNombre as [Usuario Creacion], 
Usuario_usuIdUltimaModificacion.usuNombre as [Usuario UltimaModificacion], 
convert(varchar(10),InscripcionCursado.icuFechaHoraCreacion,103) as [FechaHoraCreacion], 
convert(varchar(10),InscripcionCursado.icuFechaHoraUltimaModificacion,103) as [FechaHoraUltimaModificacion], 
InscripcionCursado.icuId,
InscripcionCursado.aluId,
InscripcionCursado.carId,
InscripcionCursado.plaId,
InscripcionCursado.curId,
InscripcionCursado.camId,
InscripcionCursado.escId,
InscripcionCursado.icuAnoCursado,
InscripcionCursado.icuFechaInscripcion,
InscripcionCursado.icuActivo,
InscripcionCursado.usuIdCreacion,
InscripcionCursado.usuIdUltimaModificacion,
InscripcionCursado.icuFechaHoraCreacion,
InscripcionCursado.icuFechaHoraUltimaModificacion

from InscripcionCursado
left outer join Alumno as Alumno_aluId on InscripcionCursado.aluId = Alumno_aluId.aluId
left outer join Carrera as Carrera_carId on InscripcionCursado.carId = Carrera_carId.carId
left outer join PlanEstudio as PlanEstudio_plaId on InscripcionCursado.plaId = PlanEstudio_plaId.plaId
left outer join Curso as Curso_curId on InscripcionCursado.curId = Curso_curId.curId
left outer join Campo as Campo_camId on InscripcionCursado.camId = Campo_camId.camId
left outer join EspacioCurricular as EspacioCurricular_escId on InscripcionCursado.escId = EspacioCurricular_escId.escId
left outer join Usuario as Usuario_usuIdCreacion on InscripcionCursado.usuIdCreacion = Usuario_usuIdCreacion.usuId
left outer join Usuario as Usuario_usuIdUltimaModificacion on InscripcionCursado.usuIdUltimaModificacion = Usuario_usuIdUltimaModificacion.usuId

where 1 = 1 and InscripcionCursado.insId = @insId
and InscripcionCursado.aluId = @aluId
--and InscripcionCursado.curId = @curId
and InscripcionCursado.icuAnoCursado = @icuAnioCursado

