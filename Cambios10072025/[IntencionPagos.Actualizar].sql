USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[IntencionPagos.Actualizar]    Script Date: 10/07/2025 17:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[IntencionPagos.Actualizar]
(
@aluId int,
@inp_bearerToken varchar(1000),
@inp_hash varchar(200),
@inp_ResultadoPago varchar(50)
)

as
Update IntencionPagos
set inp_hash = @inp_hash,
inp_ResultadoPago = @inp_ResultadoPago
where 1 = 1 
and inp_bearerToken = @inp_bearerToken
and aluId = @aluId
