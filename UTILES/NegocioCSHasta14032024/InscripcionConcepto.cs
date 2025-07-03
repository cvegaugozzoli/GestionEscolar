using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class InscripcionConcepto
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _icoId;
            public Int32 icoId { get { return _icoId; } set { _icoId = value; } }

            private Decimal _icoImporte;
            public Decimal icoImporte { get { return _icoImporte; } set { _icoImporte = value; } }

            private DateTime _icoFechaInscripcion;
            public DateTime icoFechaInscripcion { get { return _icoFechaInscripcion; } set { _icoFechaInscripcion = value; } }

            private Int32 _icoNroCuota;
            public Int32 icoNroCuota { get { return _icoNroCuota; } set { _icoNroCuota = value; } }

            private Boolean _icoActivo;
            public Boolean icoActivo { get { return _icoActivo; } set { _icoActivo = value; } }

            private DateTime _icoFechaHoraCreacion;
            public DateTime icoFechaHoraCreacion { get { return _icoFechaHoraCreacion; } set { _icoFechaHoraCreacion = value; } }

            private DateTime _icoFechaHoraUltimaModificacion;
            public DateTime icoFechaHoraUltimaModificacion { get { return _icoFechaHoraUltimaModificacion; } set { _icoFechaHoraUltimaModificacion = value; } }

            private Int32 _icuId;
            public Int32 icuId { get { return _icuId; } set { _icuId = value; } }

            private Int32 _conId;
            public Int32 conId { get { return _conId; } set { _conId = value; } }

            private Int32 _becId;
            public Int32 becId { get { return _becId; } set { _becId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public InscripcionConcepto() { try { this.icoId = 0; } catch (Exception oError) { throw oError; } }

            public InscripcionConcepto(Int32 icoId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUno]", new object[,] { { "@icoId", icoId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["icoId"].ToString().Trim().Length > 0)
                        {
                            this.icoId = Convert.ToInt32(Fila.Rows[0]["icoId"]);
                        }
                        else
                        {
                            this.icoId = 0;
                        }

                        if (Fila.Rows[0]["icoImporte"].ToString().Trim().Length > 0)
                        {
                            this.icoImporte = Convert.ToDecimal(Fila.Rows[0]["icoImporte"]);
                        }
                        else
                        {
                            this.icoImporte = 0;
                        }

                        if (Fila.Rows[0]["icoFechaInscripcion"].ToString().Trim().Length > 0)
                        {
                            this.icoFechaInscripcion = Convert.ToDateTime(Fila.Rows[0]["icoFechaInscripcion"]);
                        }
                        else
                        {
                            this.icoFechaInscripcion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["icoNroCuota"].ToString().Trim().Length > 0)
                        {
                            this.icoNroCuota = Convert.ToInt32(Fila.Rows[0]["icoNroCuota"]);
                        }
                        else
                        {
                            this.icoNroCuota = 0;
                        }

                        if (Fila.Rows[0]["icoFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.icoFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["icoFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.icoFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["icoFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.icoFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["icoFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.icoFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["icoActivo"].ToString().Trim().Length > 0)
                        {
                            this.icoActivo = (Convert.ToInt32(Fila.Rows[0]["icoActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.icoActivo = false;
                        }

                        if (Fila.Rows[0]["icuId"].ToString().Trim().Length > 0)
                        {
                            this.icuId = Convert.ToInt32(Fila.Rows[0]["icuId"]);
                        }
                        else
                        {
                            this.icuId = 0;
                        }

                        if (Fila.Rows[0]["conId"].ToString().Trim().Length > 0)
                        {
                            this.conId = Convert.ToInt32(Fila.Rows[0]["conId"]);
                        }
                        else
                        {
                            this.conId = 0;
                        }

                        if (Fila.Rows[0]["becId"].ToString().Trim().Length > 0)
                        {
                            this.becId = Convert.ToInt32(Fila.Rows[0]["becId"]);
                        }
                        else
                        {
                            this.becId = 0;
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

            public InscripcionConcepto(Int32 icoId, Decimal icoImporte, DateTime icoFechaInscripcion, Int32 icoNroCuota, Boolean icoActivo, DateTime icoFechaHoraCreacion, DateTime icoFechaHoraUltimaModificacion, Int32 IicuId, Int32 IconId, Int32 IbecId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.icoId = icoId;
                    this.icoImporte = icoImporte;
                    this.icoFechaInscripcion = icoFechaInscripcion;
                    this.icoNroCuota = icoNroCuota;
                    this.icoActivo = icoActivo;
                    this.icoFechaHoraCreacion = icoFechaHoraCreacion;
                    this.icoFechaHoraUltimaModificacion = icoFechaHoraUltimaModificacion;
                    this.icuId = icuId;
                    this.conId = conId;
                    this.becId = becId;
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
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTodoxVencido(Int32 insId, Int32 curId, Int32 Anio, Int32 Cuota1, Int32 Cuota2, Int32 ConId, Int32 CarId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto_ObtenerTodoxVencido]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@Anio", Anio }, { "@Cuota1", Cuota1 }, { "@Cuota2", Cuota2 }, { "@ConId", ConId }, { "@carId", CarId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }


            public DataTable ObtenerUno(Int32 icoId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUno]", new object[,] { { "@icoId", icoId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable TraerxIcuId(Int32 icuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.TraerxIcuId]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 icoId, Int32 icuId, Int32 conId, Decimal icoImporte, DateTime icoFechaInscripcion, Int32 icoNroCuota, Int32 becId, Boolean icoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime icoFechaHoraCreacion, DateTime icoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionConcepto.Actualizar]", new object[,] { { "@icoId", icoId }, { "@icuId", icuId }, { "@conId", conId }, { "@icoImporte", icoImporte }, { "@icoFechaInscripcion", icoFechaInscripcion }, { "@icoNroCuota", icoNroCuota }, { "@becId", becId }, { "@icoActivo", icoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@icoFechaHoraCreacion", icoFechaHoraCreacion }, { "@icoFechaHoraUltimaModificacion", icoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void ActualizarBeca(Int32 icoId, Int32 becId, Boolean icoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime icoFechaHoraCreacion, DateTime icoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionConcepto.ActualizarBeca]", new object[,] { { "@icoId", icoId }, { "@becId", becId }, { "@icoActivo", icoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@icoFechaHoraCreacion", icoFechaHoraCreacion }, { "@icoFechaHoraUltimaModificacion", icoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void Eliminar(Int32 icoId, int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionConcepto.Eliminar]", new object[,] { { "@icoId", icoId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarporIcoIdporAnio(Int32 icoId, int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionConcepto.EliminarporIcoIdporAnio]", new object[,] { { "@icoId", icoId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void Insertar(Int32 icuId, Int32 conId, Decimal icoImporte, DateTime icoFechaInscripcion, Int32 icoNroCuota, Int32 becId, Boolean icoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime icoFechaHoraCreacion, DateTime icoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionConcepto.Insertar]", new object[,] { { "@icuId", icuId }, { "@conId", conId }, { "@icoImporte", icoImporte }, { "@icoFechaInscripcion", icoFechaInscripcion }, { "@icoNroCuota", icoNroCuota }, { "@becId", becId }, { "@icoActivo", icoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@icoFechaHoraCreacion", icoFechaHoraCreacion }, { "@icoFechaHoraUltimaModificacion", icoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 InsertarTraerIco(Int32 icuId, Int32 conId, Decimal icoImporte, DateTime icoFechaInscripcion, Int32 icoNroCuota, Int32 becId, Boolean icoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime icoFechaHoraCreacion, DateTime icoFechaHoraUltimaModificacion)

            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionConcepto.Insertar]", new object[,] { { "@icuId", icuId }, { "@conId", conId }, { "@icoImporte", icoImporte }, { "@icoFechaInscripcion", icoFechaInscripcion }, { "@icoNroCuota", icoNroCuota }, { "@becId", becId }, { "@icoActivo", icoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@icoFechaHoraCreacion", icoFechaHoraCreacion }, { "@icoFechaHoraUltimaModificacion", icoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public DataTable ObtenerUnoxInsxaluxcuota(Int32 insId, Int32 aluId, Int32 icoNroCuota)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxInsxaluxcuota]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@icoNroCuota", icoNroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerUnoxInsxaluxcuotaximporte(Int32 insId, Int32 aluId, Int32 icoNroCuota, decimal Importe)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxInsxaluxcuotaximporte]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@icoNroCuota", icoNroCuota }, { "@Importe", Importe } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }

            public DataTable ObtenerUnoxaluxcuotaximportePat(Int32 aluId, Int32 icoNroCuota, decimal Importe, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxaluxcuotaximportePat]", new object[,] { { "@aluId", aluId }, { "@icoNroCuota", icoNroCuota }, { "@Importe", Importe }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerImporteRealPat(Int32 aluId, Int32 icoNroCuota, int tcon, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerImporteRealPat]", new object[,] { { "@aluId", aluId }, { "@icoNroCuota", icoNroCuota }, { "@tcon", tcon }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerTodoxCobrado(Int32 insId, Int32 curId, Int32 Anio, Int32 Cuota1, Int32 Cuota2, Int32 ConId, Int32 CarId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerTodoxCobrado]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@Anio", Anio }, { "@Cuota1", Cuota1 }, { "@Cuota2", Cuota2 }, { "@ConId", ConId }, { "@carId", CarId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }
            public DataTable ObtenerTodoxCobradoxBecados(Int32 insId, Int32 curId, Int32 Anio, Int32 Cuota1, Int32 Cuota2, Int32 ConId, Int32 CarId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerTodoxCobradoxBecados]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@Anio", Anio }, { "@Cuota1", Cuota1 }, { "@Cuota2", Cuota2 }, { "@ConId", ConId }, { "@carId", CarId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }
            public DataTable ObtenerTodoxCobradoxBecadosFra(Int32 insId, Int32 curId, Int32 Anio, Int32 Cuota1, Int32 Cuota2, Int32 ConId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerTodoxCobradoxBecadosFra]", new object[,] { { "@insId", insId }, { "@curId", curId }, { "@Anio", Anio }, { "@Cuota1", Cuota1 }, { "@Cuota2", Cuota2 }, { "@ConId", ConId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }
            public DataTable ObtenerUnoxInsxaluxcuotaximporteDetalle(Int32 insId, Int32 aluId, Int32 icoNroCuota, Decimal Importe)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxInsxaluxcuotaximporteDetalle]", new object[,] { { "@insId", insId }, { "@aluId", aluId }, { "@icoNroCuota", icoNroCuota }, { "@Importe", Importe } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }

            public DataTable ObtenerUnoxaluxcuotaximporteDetallePat(Int32 aluId, Int32 icoNroCuota, Decimal Importe, Int32 Anio)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxaluxcuotaximporteDetallePat]", new object[,] { { "@aluId", aluId }, { "@icoNroCuota", icoNroCuota }, { "@Importe", Importe } , { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerUnoxIcuIdxConIdxNroCuota(Int32 icuId, Int32 conId, Int32 icoNroCuota)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxIcuIdxConIdxNroCuota]", new object[,] { { "@icuId", icuId }, { "@conId", conId }, { "@icoNroCuota", icoNroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerUnoxicuIdxMat(Int32 icuId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxicuIdxMat]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerUnoxicuIdxconId(Int32 icuId, Int32 conId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxicuIdxconId]", new object[,] { { "@icuId", icuId }, { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public DataTable ObtenerUnoxicuId(Int32 icuId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxicuId]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }

            public DataTable ObtenerUnoxicuId_SinBeca100(Int32 icuId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxicuId_SinBeca100]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }


            public DataTable ObtenerUnoxicuIdsinPre(Int32 icuId)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InscripcionConcepto.ObtenerUnoxicuIdsinPre]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;

            }
            public void Actualizar()
            {
                try
                {
                    if (this.icoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionConcepto.Actualizar]", new object[,] { { "@icoId", icoId }, { "@icuId", icuId }, { "@conId", conId }, { "@icoImporte", icoImporte }, { "@icoFechaInscripcion", icoFechaInscripcion }, { "@icoNroCuota", icoNroCuota }, { "@becId", becId }, { "@icoActivo", icoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@icoFechaHoraCreacion", icoFechaHoraCreacion }, { "@icoFechaHoraUltimaModificacion", icoFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarTodoxIcuId(int icuId, int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[InscripcionConcepto.EliminarTodoxIcuId]", new object[,] { { "@icuId", icuId }, { "@usuId", usuId } });

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
                    if (this.icoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[InscripcionConcepto.Eliminar]", new object[,] { { "@icoId", icoId } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[InscripcionConcepto.Insertar]", new object[,] { { "@icuId", icuId }, { "@conId", conId }, { "@icoImporte", icoImporte }, { "@icoFechaInscripcion", icoFechaInscripcion }, { "@icoNroCuota", icoNroCuota }, { "@becId", becId }, { "@icoActivo", icoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@icoFechaHoraCreacion", icoFechaHoraCreacion }, { "@icoFechaHoraUltimaModificacion", icoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            public DataTable ArchivoBancoObtenerporVarios(Int32 insId, Int32 conId, Int32 conAnioLectivo)

            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ArchivoBanco.ObtenerporVarios]", new object[,] { { "@insId", insId }, { "@conId", conId }, { "@conAnioLectivo", conAnioLectivo } });
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