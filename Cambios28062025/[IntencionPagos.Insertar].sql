USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[IntencionPagos.Insertar]    Script Date: 02/07/2025 8:11:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter procedure [dbo].[IntencionPagos.Insertar]
(
@inp_IdReferenciaOperacion varchar(100),
@inp_Hash varchar(200),
@inp_FechaCreacion datetime,
@inp_Estado varchar(50),
@inp_Monto numeric(18, 2),
@inp_UsuId int,
@inp_comprobantenro varchar(50),
@aluid int,
@inp_FechaExpiracion datetime,
@inp_bearerToken varchar(1000)

)

as

insert into IntencionPagos
(
inp_IdReferenciaOperacion,
inp_Hash,
inp_FechaCreacion,
inp_Estado,
inp_Monto,
inp_UsuId,
inp_comprobantenro,
aluid,
inp_FechaExpiracion,
inp_bearerToken
)

values
(
@inp_IdReferenciaOperacion,
@inp_Hash,
@inp_FechaCreacion,
@inp_Estado,
@inp_Monto,
@inp_UsuId,
@inp_comprobantenro,
@aluid,
@inp_FechaExpiracion,
@inp_bearerToken
)

select @@identity as IdMax
