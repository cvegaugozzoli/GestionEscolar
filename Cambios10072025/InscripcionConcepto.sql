Use GestionEscolar
/*
   viernes, 11 de julio de 20259:35:29
   Usuario: sa
   Servidor: PC\SQL2012
   Base de datos: GestionEscolar
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InscripcionConcepto ADD
	inp_IdReferenciaOperacion varchar(100) NULL
GO
ALTER TABLE dbo.InscripcionConcepto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.InscripcionConcepto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.InscripcionConcepto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.InscripcionConcepto', 'Object', 'CONTROL') as Contr_Per 