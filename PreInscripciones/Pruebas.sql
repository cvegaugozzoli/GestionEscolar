use GestionEscolar
select * from Alumno order by aluId
select * from Alumno where aluNombre like 'Vega Miranda%'
select * from TemporalPreinscripcion order by tpiId desc
-- 48481957 VEGA MIRANDA MILAGROS
-- 46160375 PARISINI GUIDO FRANCO
delete from TemporalPreinscripcion where tpiId > 3771

exec InformeConstanciaPreinscripcion 17661, 171, 2023
select * from Instituciones
select * from Curso 
select * from InscripcionCursado order by icuid desc 

select Alumno.aluDoc, Alumno.aluId,Alumno.aluNombre, Alumno.aluDomicilio,Curso.curNombre,
Familiar.famApellido, Familiar.famNombre, Instituciones.insNombre,-- TemporalPreinscripcion.tpiNombreAfiliacion,TemporalPreinscripcion.tpiAfiliacion,
InscripcionCursado.curId,InscripcionCursado.icuAnoCursado,AlumnoFamiliar.afaEsTutor
--'Familiar' =
--			Case  
			
--				when Familiar.famApellido = 2 then dbo.Proveedores.proCBU
--			End, 

--isnull(RegistracionCalificaciones.recObservaciones,' ') as [Observaciones], 
--case when RegistracionCalificaciones.recActivo = 0 then 'No' else 'Si' end as [Activo], 
from InscripcionCursado as InscripcionCursado 
join Curso on Curso.curId = InscripcionCursado.curId
join Alumno on Alumno.aluId = InscripcionCursado.aluId
left  join AlumnoFamiliar on AlumnoFamiliar.aluId=Alumno.aluId 
left join Familiar on Familiar.famId =AlumnoFamiliar.famId
join Instituciones on Instituciones.insId =InscripcionCursado.insId
-- join TemporalPreinscripcion on TemporalPreinscripcion.aluId =InscripcionCursado.aluId

where 1 = 1 

and InscripcionCursado.icuAnoCursado=2023  AND InscripcionCursado.curId = 171
-- and Alumno.aluActivo = 1
and Alumno.aluId = 17661