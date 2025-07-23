select top 500 * from ComprobantesCabecera CC
join ComprobantesDetalle CD on CD.cocid = CC.cocid  
order by CC.cocid desc

exec [InformeFacturaNueva] '00001', 59218

select * from [ComprobantesPtosVta]

insert into ComprobantesTipos(ctiNombre, ctiActivo)
select 'Recibo X', 1
insert into [ComprobantesPtosVta](insid, ctiid, cpvPtoVta, cpvUltimoNro, cdoId, cpvActivo)
select 1, 3, '00002', 1, 1, 1

select * from ComprobantesTipos
select * from ComprobantesDestinos



exec [ComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest] 1, 1, 1, 2

delete from [ComprobantesPtosVta] where cpvid = 9