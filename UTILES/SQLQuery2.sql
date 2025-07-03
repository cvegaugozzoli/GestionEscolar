--Las hermanas Orazi Martina, Elena y Bianca solicitan Beca por hermanos
--Pero el sistema no los muestra como hermanos aún cuando tienen cargado el DNI de la madre en los tres alumnos
--Lo mismo pasó con los hermanos Toledo Di Chiara que tuve que asignarles a cada uno de forma manual

use GestionEscolar

[AlumnoFamiliar.ObtenerUnoafaId]

SELECT COUNT(AlumnoFamiliar.famId) as [Hijos],AlumnoFamiliar.famId as [famId]
FROM AlumnoFamiliar
left join Alumno on Alumno.aluId=AlumnoFamiliar.aluId
left join Familiar on Familiar.famId=AlumnoFamiliar.famId
WHERE AlumnoFamiliar.afaEsTutor=1
GROUP BY AlumnoFamiliar.famId

select * from Alumno where aluNombre like '%Orazi%'
select * from AlumnoFamiliar where aluId = 7642 or aluid = 9009 or aluid = 13159
select * from Familiar where famDNI = '25644534' -- famId = 1810 or famid = 3129