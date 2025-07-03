select * from Alumno where aluNombre like '%Vega miranda mi%'
select * from InscripcionCursado where aluid =8491 and icuAnoCursado = 2023

select * from Alumno where aluNombre like '%lococo su%'
select * from InscripcionCursado where aluid = 18907
select * from InscripcionConcepto where icuid = 77580 or icuid = 80724
select * from ComprobantesDetalle where icoid = 680744
delete from InscripcionConcepto where icuid = 77580
delete from inscripcioncursado where  icuid = 77580

select * from Becas

exec [InscripcionCursado.ObtenerTodoxaluIdxAnio] 18907, 2023
exec [InscripcionConcepto.ObtenerUnoxicuId] 80724 
exec [ComprobantesDetalle.ObtenerUnoxicoId] 680744