-- Crear usuarios alumnos nuevos en la tabla usuarios

insert into Usuario(usuApellido, usuNombreIngreso, usuClave, usuActivo)
select A.aluNombre, A.aluDoc, 'xDmWEs27e4XW1uB7ab4YNi9lfCAhAHWApRJJH93Wpd8y4qSbeH4ZJ2nFPmcRWt9Mx6h66cTaSwfQ07fNGiLs4Q==', 1 
 from InscripcionCursado I
join Alumno A on A.aluid = I.aluid 
join Curso C on C.curid = I.curid 
where icuAnoCursado = 2025 and 
not exists (select * from Usuario where usuNombreIngreso = A.aluDoc)


Insert into UsuarioPerfil(usuid, perid, upeActivo)
select distinct usuid, 16, 1 from Usuario where 
usuid >= 23267 and 
usuClave = 'xDmWEs27e4XW1uB7ab4YNi9lfCAhAHWApRJJH93Wpd8y4qSbeH4ZJ2nFPmcRWt9Mx6h66cTaSwfQ07fNGiLs4Q==' 

select * from Perfil
Insert into UsuarioPerfil(usuid, perid, upeActivo)
select distinct usuid, 25, 1 from Usuario where 
usuid = 140

Insert into UsuarioPerfil(usuid, perid, insid, upeActivo)
select distinct usuid, 5, 1, 1 from Usuario where 
usuid = 140

Insert into UsuarioPerfil(usuid, perid, insid, upeActivo)
select distinct usuid, 21, 1, 1 from Usuario where 
usuid = 140

select * from UsuarioPerfil where usuid = 140
update UsuarioPerfil set insid = 1 where upeId = 16375 or upeid = 16376

