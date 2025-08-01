/*
   jueves, 10 de julio de 202512:57:40
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
CREATE TABLE dbo.Tmp_IntencionPagos
	(
	inpId int NOT NULL IDENTITY (1, 1),
	inp_IdReferenciaOperacion varchar(100) NULL,
	inp_Hash varchar(200) NULL,
	inp_ResultadoPago varchar(50) NULL,
	inp_FechaCreacion datetime NULL,
	inp_Estado nvarchar(50) NULL,
	inp_Monto decimal(18, 2) NULL,
	inp_UsuId int NULL,
	inp_comprobantenro varchar(50) NULL,
	aluid int NULL,
	inp_FechaExpiracion datetime NULL,
	inp_bearerToken varchar(1000) NULL,
	inp_CanalCobro varchar(3) NULL,
	inp_CodRechazo varchar(3) NULL,
	inp_DescripcionRechazo varchar(20) NULL,
	inp_Cuotas int NULL,
	inp_Tarjetas varchar(15) NULL,
	inp_idPagosSiro int NULL,
	inp_ImportePagado decimal(18, 2) NULL,
	inp_fechaacreditacion datetime NULL,
	inp_fechapago datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_IntencionPagos SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_IntencionPagos ON
GO
IF EXISTS(SELECT * FROM dbo.IntencionPagos)
	 EXEC('INSERT INTO dbo.Tmp_IntencionPagos (inpId, inp_IdReferenciaOperacion, inp_Hash, inp_FechaCreacion, inp_Estado, inp_Monto, inp_UsuId, inp_comprobantenro, aluid, inp_FechaExpiracion, inp_bearerToken)
		SELECT inpId, inp_IdReferenciaOperacion, inp_Hash, inp_FechaCreacion, inp_Estado, inp_Monto, inp_UsuId, inp_comprobantenro, aluid, inp_FechaExpiracion, inp_bearerToken FROM dbo.IntencionPagos WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_IntencionPagos OFF
GO
DROP TABLE dbo.IntencionPagos
GO
EXECUTE sp_rename N'dbo.Tmp_IntencionPagos', N'IntencionPagos', 'OBJECT' 
GO
ALTER TABLE dbo.IntencionPagos ADD CONSTRAINT
	PK__Intencio__00F3629FB94EC714 PRIMARY KEY CLUSTERED 
	(
	inpId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.IntencionPagos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IntencionPagos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IntencionPagos', 'Object', 'CONTROL') as Contr_Per 