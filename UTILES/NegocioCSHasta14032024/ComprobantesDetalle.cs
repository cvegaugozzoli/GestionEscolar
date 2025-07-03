using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ComprobantesDetalle
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cdeId;
            public Int32 cdeId { get { return _cdeId; } set { _cdeId = value; } }

            private Decimal _cdeImporte;
            public Decimal cdeImporte { get { return _cdeImporte; } set { _cdeImporte = value; } }

            private Boolean _cdeActivo;
            public Boolean cdeActivo { get { return _cdeActivo; } set { _cdeActivo = value; } }

            private DateTime _cdeFechaHoraCreacion;
            public DateTime cdeFechaHoraCreacion { get { return _cdeFechaHoraCreacion; } set { _cdeFechaHoraCreacion = value; } }

            private DateTime _cdeFechaHoraUltimaModificacion;
            public DateTime cdeFechaHoraUltimaModificacion { get { return _cdeFechaHoraUltimaModificacion; } set { _cdeFechaHoraUltimaModificacion = value; } }

            private Int32 _cocId;
            public Int32 cocId { get { return _cocId; } set { _cocId = value; } }

            private Int32 _icoId;
            public Int32 icoId { get { return _icoId; } set { _icoId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ComprobantesDetalle() { try { this.cdeId = 0; } catch (Exception oError) { throw oError; } }

            public ComprobantesDetalle(Int32 cdeId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ComprobantesDetalle.ObtenerUno]", new object[,] { { "@cdeId", cdeId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["cdeId"].ToString().Trim().Length > 0)
                        {
                            this.cdeId = Convert.ToInt32(Fila.Rows[0]["cdeId"]);
                        }
                        else
                        {
                            this.cdeId = 0;
                        }

                        if (Fila.Rows[0]["cdeImporte"].ToString().Trim().Length > 0)
                        {
                            this.cdeImporte = Convert.ToDecimal(Fila.Rows[0]["cdeImporte"]);
                        }
                        else
                        {
                            this.cdeImporte = 0;
                        }

                        if (Fila.Rows[0]["cdeFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cdeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cdeFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cdeFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cdeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cdeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cdeFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cdeFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cdeActivo"].ToString().Trim().Length > 0)
                        {
                            this.cdeActivo = (Convert.ToInt32(Fila.Rows[0]["cdeActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.cdeActivo = false;
                        }

                        if (Fila.Rows[0]["cocId"].ToString().Trim().Length > 0)
                        {
                            this.cocId = Convert.ToInt32(Fila.Rows[0]["cocId"]);
                        }
                        else
                        {
                            this.cocId = 0;
                        }

                        if (Fila.Rows[0]["icoId"].ToString().Trim().Length > 0)
                        {
                            this.icoId = Convert.ToInt32(Fila.Rows[0]["icoId"]);
                        }
                        else
                        {
                            this.icoId = 0;
                        }

                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuidUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuidUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuidUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuidUltimaModificacion = 0;
                        }

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public ComprobantesDetalle(Int32 cdeId, Decimal cdeImporte, Boolean cdeActivo, DateTime cdeFechaHoraCreacion, DateTime cdeFechaHoraUltimaModificacion, Int32 IcocId, Int32 IicoId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.cdeId = cdeId;
                    this.cdeImporte = cdeImporte;
                    this.cdeActivo = cdeActivo;
                    this.cdeFechaHoraCreacion = cdeFechaHoraCreacion;
                    this.cdeFechaHoraUltimaModificacion = cdeFechaHoraUltimaModificacion;
                    this.cocId = cocId;
                    this.icoId = icoId;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuidUltimaModificacion = usuidUltimaModificacion;
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos


            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 cdeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.ObtenerUno]", new object[,] { { "@cdeId", cdeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable RecaudacionxInsxfecha(Int32 inst, DateTime desde, DateTime hasta)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.RecaudacionxInsxfecha]", new object[,] { { "@inst", inst }, { "@desde", desde }, { "@hasta", hasta } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxicoId(Int32 icoId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.ObtenerUnoxicoId]", new object[,] { { "@icoId", icoId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxcocId(Int32 cocId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.ObtenerUnoxcocId]", new object[,] { { "@cocId", cocId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void Actualizar(Int32 cdeId, Int32 cocId, Int32 icoId, Decimal cdeImporte, Boolean cdeActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdeFechaHoraCreacion, DateTime cdeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.Actualizar]", new object[,] { { "@cdeId", cdeId }, { "@cocId", cocId }, { "@icoId", icoId }, { "@cdeImporte", cdeImporte }, { "@cdeActivo", cdeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdeFechaHoraCreacion", cdeFechaHoraCreacion }, { "@cdeFechaHoraUltimaModificacion", cdeFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarActivo(Int32 cocId, Boolean cdeActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdeFechaHoraCreacion, DateTime cdeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.ActualizarActivo]", new object[,] { { "@cocId", cocId }, { "@cdeActivo", cdeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdeFechaHoraCreacion", cdeFechaHoraCreacion }, { "@cdeFechaHoraUltimaModificacion", cdeFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void Eliminar(Int32 cdeId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.Eliminar]", new object[,] { { "@cdeId", cdeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarxcocId(Int32 cocId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.EliminarxcocId]", new object[,] { { "@cocId", cocId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 cocId, Int32 icoId, Decimal cdeImporte, Boolean cdeActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdeFechaHoraCreacion, DateTime cdeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.Insertar]", new object[,] { { "@cocId", cocId }, { "@icoId", icoId }, { "@cdeImporte", cdeImporte }, { "@cdeActivo", cdeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdeFechaHoraCreacion", cdeFechaHoraCreacion }, { "@cdeFechaHoraUltimaModificacion", cdeFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Actualizar()
            {
                try
                {
                    if (this.cdeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.Actualizar]", new object[,] { { "@cdeId", cdeId }, { "@cocId", cocId }, { "@icoId", icoId }, { "@cdeImporte", cdeImporte }, { "@cdeActivo", cdeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdeFechaHoraCreacion", cdeFechaHoraCreacion }, { "@cdeFechaHoraUltimaModificacion", cdeFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar()
            {
                try
                {
                    if (this.cdeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesDetalle.Eliminar]", new object[,] { { "@cdeId", cdeId } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 InsertarTraeId(Int32 cocId, Int32 icoId, Decimal cdeImporte, Boolean cdeActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdeFechaHoraCreacion, DateTime cdeFechaHoraUltimaModificacion)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesDetalle.Insertar]", new object[,] { { "@cocId", cocId }, { "@icoId", icoId }, { "@cdeImporte", cdeImporte }, { "@cdeActivo", cdeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdeFechaHoraCreacion", cdeFechaHoraCreacion }, { "@cdeFechaHoraUltimaModificacion", cdeFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }
          
       public Int32 HabilitarInscripcion(Int32 inst, Int32 aluId,  Int32 Anio, Int32 cuotasAnioAnt,Int32 cuotasAnioAnteriores)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesDetalle.HabilitarInscripcion]", new object[,] { { "@inst", inst }, { "@aluId", aluId }, { "@Anio", Anio }, { "@cuotasAnioAnt", cuotasAnioAnt } ,{ "@cuotasAnioAnteriores", cuotasAnioAnteriores } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public Int32 HabilitarxPromocion(Int32 inst, Int32 aluId,  Int32 Anio, Int32 cuotasAnioAnt,Int32 cuotasAnioAnteriores)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesDetalle.HabilitarxPromocion]", new object[,] { { "@inst", inst }, { "@aluId", aluId }, { "@Anio", Anio }, { "@cuotasAnioAnt", cuotasAnioAnt } ,{ "@cuotasAnioAnteriores", cuotasAnioAnteriores } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }public Int32 HabilitarInscripcion2(Int32 inst, Int32 aluId,  Int32 Anio, Int32 cuotasAnioAnt)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesDetalle.HabilitarInscripcion]", new object[,] { { "@inst", inst }, { "@aluId", aluId }, { "@Anio", Anio }, { "@cuotasAnioAnt", cuotasAnioAnt } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }
            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesDetalle.Insertar]", new object[,] { { "@cocId", cocId }, { "@icoId", icoId }, { "@cdeImporte", cdeImporte }, { "@cdeActivo", cdeActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdeFechaHoraCreacion", cdeFechaHoraCreacion }, { "@cdeFechaHoraUltimaModificacion", cdeFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public DataTable RecaudacionxInsxCuota(int tipoConcepto, int desde, int hasta, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.RecaudacionxInsxCuota]", new object[,] { { "@tipoConcepto", tipoConcepto }, { "@desde", desde }, { "@hasta", hasta }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable RecaudacionxInsxCuotaTotal(int tipoConcepto, int desde, int hasta, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDetalle.RecaudacionxInsxCuotaTotal]", new object[,] { { "@tipoConcepto", tipoConcepto }, { "@desde", desde }, { "@hasta", hasta }, { "@Anio", Anio } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            #endregion
        }
    }
}