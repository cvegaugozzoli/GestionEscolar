USE [GestionEscolar]
GO
/****** Object:  StoredProcedure [dbo].[InformeFactura]    Script Date: 18/07/2025 8:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter procedure [dbo].[InformeFacturaNueva]
(
@inp_IdReferenciaOperacion varchar(100)

--exec [InformeFactura]61115,560401
)
as
select ComprobantesCabecera.cocId, InscripcionConcepto.*,InscripcionCursado.icuId, Alumno.aluDoc, Alumno.aluNombre,
 Curso.curNombre, InscripcionCursado.icuAnoCursado,InscripcionConcepto.icoImporte
, Conceptos.conNombre,Conceptos.conImporte, ComprobantesDetalle.icoId,  ComprobantesDetalle.cdeId, ComprobantesDetalle.cdeImporte,
ComprobantesCabecera.cocNroPtoVta,ComprobantesCabecera.cocNroCompbte,
ComprobantesCabecera.cocFechaPago,Instituciones.insDireccion,Instituciones.insCUIT,Instituciones.insNombre, 
ComprobantesCabecera.cocImporteRendido

from InscripcionConcepto

join InscripcionCursado on InscripcionCursado.icuId = InscripcionConcepto.icuId
join Curso on Curso.curId = InscripcionCursado.curId
join Alumno on Alumno.aluId = InscripcionCursado.aluId
join Conceptos on Conceptos.conId = InscripcionConcepto.conId
join Instituciones on Instituciones.insId = Conceptos.insId
join ComprobantesDetalle on ComprobantesDetalle.icoId = InscripcionConcepto.icoId
join ComprobantesCabecera on ComprobantesCabecera.cocId = ComprobantesDetalle.cocId

where 1 = 1 
and  ComprobantesCabecera.inp_IdReferenciaOperacion = @inp_IdReferenciaOperacion





