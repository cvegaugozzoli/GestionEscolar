USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[Bancos.ObtenerUno]    Script Date: 02/07/2025 8:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter procedure [dbo].[IntencionPagos.Actualizar]
(
@aluId int,
@inp_bearerToken varchar(1000),
@inp_hash varchar(200)
)

as
Update IntencionPagos
set inp_hash = @inp_hash
where 1 = 1 
and inp_bearerToken = @inp_bearerToken
and aluId = @aluId
