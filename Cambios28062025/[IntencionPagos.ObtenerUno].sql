USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[Bancos.ObtenerUno]    Script Date: 02/07/2025 8:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[IntencionPagos.ObtenerUno]
(
@inpId int
)

as

select * 
from IntencionPagos

where 1 = 1 
and inpId = @inpId
