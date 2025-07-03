using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ConceptosIntereses
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _coiId;
            public Int32 coiId { get { return _coiId; } set { _coiId = value; } }

            private Int32 _coiNroCuota;
            public Int32 coiNroCuota { get { return _coiNroCuota; } set { _coiNroCuota = value; } }

            private DateTime _coiFechaVto;
            public DateTime coiFechaVto { get { return _coiFechaVto; } set { _coiFechaVto = value; } }

            private Decimal _coiValorInteres;
            public Decimal coiValorInteres { get { return _coiValorInteres; } set { _coiValorInteres = value; } }

            private Boolean _coiAplicaBeca;
            public Boolean coiAplicaBeca { get { return _coiAplicaBeca; } set { _coiAplicaBeca = value; } }

            private Boolean _coiAplicaInteresAbierto;
            public Boolean coiAplicaInteresAbierto { get { return _coiAplicaInteresAbierto; } set { _coiAplicaInteresAbierto = value; } }

            private Boolean _coiActivo;
            public Boolean coiActivo { get { return _coiActivo; } set { _coiActivo = value; } }

            private DateTime _coiFechaHoraCreacion;
            public DateTime coiFechaHoraCreacion { get { return _coiFechaHoraCreacion; } set { _coiFechaHoraCreacion = value; } }

            private DateTime _coiFechaHoraUltimaModificacion;
            public DateTime coiFechaHoraUltimaModificacion { get { return _coiFechaHoraUltimaModificacion; } set { _coiFechaHoraUltimaModificacion = value; } }

            private Int32 _conId;
            public Int32 conId { get { return _conId; } set { _conId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ConceptosIntereses() { try { this.coiId = 0; } catch (Exception oError) { throw oError; } }

            public ConceptosIntereses(Int32 coiId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerUno]", new object[,] { { "@coiId", coiId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["coiId"].ToString().Trim().Length > 0)
                        {
                            this.coiId = Convert.ToInt32(Fila.Rows[0]["coiId"]);
                        }
                        else
                        {
                            this.coiId = 0;
                        }

                        if (Fila.Rows[0]["coiNroCuota"].ToString().Trim().Length > 0)
                        {
                            this.coiNroCuota = Convert.ToInt32(Fila.Rows[0]["coiNroCuota"]);
                        }
                        else
                        {
                            this.coiNroCuota = 0;
                        }

                        if (Fila.Rows[0]["coiFechaVto"].ToString().Trim().Length > 0)
                        {
                            this.coiFechaVto = Convert.ToDateTime(Fila.Rows[0]["coiFechaVto"]);
                        }
                        else
                        {
                            this.coiFechaVto = DateTime.Now;
                        }

                        if (Fila.Rows[0]["coiValorInteres"].ToString().Trim().Length > 0)
                        {
                            this.coiValorInteres = Convert.ToDecimal(Fila.Rows[0]["coiValorInteres"]);
                        }
                        else
                        {
                            this.coiValorInteres = 0;
                        }

                        if (Fila.Rows[0]["coiFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.coiFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["coiFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.coiFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["coiFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.coiFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["coiFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.coiFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["coiAplicaBeca"].ToString().Trim().Length > 0)
                        {
                            this.coiAplicaBeca = (Convert.ToInt32(Fila.Rows[0]["coiAplicaBeca"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.coiAplicaBeca = false;
                        }
                        if (Fila.Rows[0]["coiAplicaInteresAbierto"].ToString().Trim().Length > 0)
                        {
                            this.coiAplicaInteresAbierto = (Convert.ToInt32(Fila.Rows[0]["coiAplicaInteresAbierto"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.coiAplicaInteresAbierto = false;
                        }

                        if (Fila.Rows[0]["coiActivo"].ToString().Trim().Length > 0)
                        {
                            this.coiActivo = (Convert.ToInt32(Fila.Rows[0]["coiActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.coiActivo = false;
                        }

                        if (Fila.Rows[0]["conId"].ToString().Trim().Length > 0)
                        {
                            this.conId = Convert.ToInt32(Fila.Rows[0]["conId"]);
                        }
                        else
                        {
                            this.conId = 0;
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

            public ConceptosIntereses(Int32 coiId, Int32 coiNroCuota, DateTime coiFechaVto, Decimal coiValorInteres, Boolean coiAplicaBeca, Boolean coiActivo, DateTime coiFechaHoraCreacion, DateTime coiFechaHoraUltimaModificacion, Int32 IconId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.coiId = coiId;
                    this.coiNroCuota = coiNroCuota;
                    this.coiFechaVto = coiFechaVto;
                    this.coiValorInteres = coiValorInteres;
                    this.coiAplicaBeca = coiAplicaBeca;
                    this.coiActivo = coiActivo;
                    this.coiFechaHoraCreacion = coiFechaHoraCreacion;
                    this.coiFechaHoraUltimaModificacion = coiFechaHoraUltimaModificacion;
                    this.conId = conId;
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
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxinsId(int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerTodoxinsId]", new object[,] { { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxinsIdxAnio(int insId,String Nombre, String Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerTodoxinsIdxAnio]", new object[,] { { "@insId", insId } , { "@Nombre", Nombre } , { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 coiId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerUno]", new object[,] { { "@coiId", coiId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUltimoVencimiento(Int32 conId, Int32 NroCuota)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerUltimoVencimiento]", new object[,] { { "@conId", conId }, { "@NroCuota", NroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerPrimerVencimiento(Int32 conId, Int32 NroCuota)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerPrimerVencimiento]", new object[,] { { "@conId", conId }, { "@NroCuota", NroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaxconIdxNroCuota(Int32 conId, Int32 NroCuota)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerListaxconIdxNroCuota]", new object[,] { { "@conId", conId }, { "@NroCuota", NroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerInteresxconIdxNroCuota(Int32 conId, Int32 NroCuota)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerInteresxconIdxNroCuota]", new object[,] { { "@conId", conId }, { "@NroCuota", NroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerInteresxconIdxNroCuotaPatagonia(Int32 conId, Int32 NroCuota)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerInteresxconIdxNroCuotaPatagonia]", new object[,] { { "@conId", conId }, { "@NroCuota", NroCuota } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerInteresxconId(Int32 conId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ConceptosIntereses.ObtenerInteresxconId]", new object[,] { { "@conId", conId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void Actualizar(Int32 coiId, Int32 conId, Int32 coiNroCuota, DateTime coiFechaVto, Decimal coiValorInteres, Boolean coiAplicaBeca,Boolean coiAplicaInteresAbierto, Boolean coiActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime coiFechaHoraCreacion, DateTime coiFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosIntereses.Actualizar]", new object[,] { { "@coiId", coiId }, { "@conId", conId }, { "@coiNroCuota", coiNroCuota }, { "@coiFechaVto", coiFechaVto }, { "@coiValorInteres", coiValorInteres }, { "@coiAplicaBeca", coiAplicaBeca }, { "@coiAplicaInteresAbierto", coiAplicaInteresAbierto },{ "@coiActivo", coiActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@coiFechaHoraCreacion", coiFechaHoraCreacion }, { "@coiFechaHoraUltimaModificacion", coiFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 coiId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosIntereses.Eliminar]", new object[,] { { "@coiId", coiId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 conId, Int32 coiNroCuota, DateTime coiFechaVto, Decimal coiValorInteres, Boolean coiAplicaBeca,  Boolean coiAplicaInteresAbierto, Boolean coiActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime coiFechaHoraCreacion, DateTime coiFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ConceptosIntereses.Insertar]", new object[,] { { "@conId", conId }, { "@coiNroCuota", coiNroCuota }, { "@coiFechaVto", coiFechaVto }, { "@coiValorInteres", coiValorInteres }, { "@coiAplicaBeca", coiAplicaBeca }, { "@coiAplicaInteresAbierto", coiAplicaInteresAbierto },{ "@coiActivo", coiActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@coiFechaHoraCreacion", coiFechaHoraCreacion }, { "@coiFechaHoraUltimaModificacion", coiFechaHoraUltimaModificacion } });
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
                    if (this.coiId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosIntereses.Actualizar]", new object[,] { { "@coiId", coiId }, { "@conId", conId }, { "@coiNroCuota", coiNroCuota }, { "@coiFechaVto", coiFechaVto }, { "@coiValorInteres", coiValorInteres }, { "@coiAplicaBeca", coiAplicaBeca },{ "@coiAplicaInteresAbierto", coiAplicaInteresAbierto }, { "@coiActivo", coiActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@coiFechaHoraCreacion", coiFechaHoraCreacion }, { "@coiFechaHoraUltimaModificacion", coiFechaHoraUltimaModificacion } });
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
                    if (this.coiId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ConceptosIntereses.Eliminar]", new object[,] { { "@coiId", coiId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ConceptosIntereses.Insertar]", new object[,] { { "@conId", conId }, { "@coiNroCuota", coiNroCuota }, { "@coiFechaVto", coiFechaVto }, { "@coiValorInteres", coiValorInteres }, { "@coiAplicaBeca", coiAplicaBeca }, { "@coiAplicaInteresAbierto", coiAplicaInteresAbierto },{ "@coiActivo", coiActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@coiFechaHoraCreacion", coiFechaHoraCreacion }, { "@coiFechaHoraUltimaModificacion", coiFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            #endregion
        }
    }
}