USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[Bancos.ObtenerUno]    Script Date: 02/07/2025 8:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter procedure [dbo].[IntencionPagos.ObtenerTodoBuscarxVarios]
(
@inp_hash varchar(200),
@aluId int
)

as

select * 
from IntencionPagos

where 1 = 1 
and inp_hash = @inp_hash
and inp_UsuId = @aluId
