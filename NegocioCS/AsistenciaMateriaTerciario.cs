using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class AsistenciaMateriaTerciario
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _amtId;
            public Int32 amtId { get { return _amtId; } set { _amtId = value; } }

            private Int32 _ictId;
            public Int32 ictId { get { return _ictId; } set { _ictId = value; } }

            private DateTime _amtFecha;
            public DateTime amtFecha { get { return _amtFecha; } set { _amtFecha = value; } }

            private Boolean _amtPresente;
            public Boolean amtPresente { get { return _amtPresente; } set { _amtPresente = value; } }

            private String _amtObservaciones;
            public String amtObservaciones { get { return _amtObservaciones; } set { _amtObservaciones = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private DateTime _amtFechaHoraCreacion;
            public DateTime amtFechaHoraCreacion { get { return _amtFechaHoraCreacion; } set { _amtFechaHoraCreacion = value; } }

            private DateTime _amtFechaHoraUltimaModificacion;
            public DateTime amtFechaHoraUltimaModificacion { get { return _amtFechaHoraUltimaModificacion; } set { _amtFechaHoraUltimaModificacion = value; } }

            #endregion
            #region Constructores

            public AsistenciaMateriaTerciario() { try { this.amtId = 0; } catch (Exception oError) { throw oError; } }

            public AsistenciaMateriaTerciario(Int32 amtId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenerUno]", new object[,] { { "@amtId", amtId } });

                    if (Fila.Rows.Count > 0)
                    {

                        if (Fila.Rows[0]["amtFecha"].ToString().Trim().Length > 0)
                        {
                            this.amtFecha = Convert.ToDateTime(Fila.Rows[0]["amtFecha"]);
                        }
                        else
                        {
                            this.amtFecha = DateTime.Now;
                        }
                        if (Fila.Rows[0]["ictId"].ToString().Trim().Length > 0)
                        {
                            this.ictId = Convert.ToInt32(Fila.Rows[0]["ictId"]);
                        }
                        else
                        {
                            this.ictId = 0;
                        }
                        if (Fila.Rows[0]["amtPresente"].ToString().Trim().Length > 0)
                        {
                            this.amtPresente = (Convert.ToInt32(Fila.Rows[0]["amtPresente"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.amtPresente = false;
                        }

                        if (Fila.Rows[0]["amtObservaciones"].ToString().Trim().Length > 0)
                        {
                            this.amtObservaciones = Convert.ToString(Fila.Rows[0]["amtObservaciones"]);
                        }
                        else
                        {
                            this.amtObservaciones = "";
                        }

                        if (Fila.Rows[0]["amtFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.amtFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["amtFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.amtFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["amtFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.amtFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["amtFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.amtFechaHoraUltimaModificacion = DateTime.Now;
                        }


                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuIdUltimaModificacion = 0;
                        }

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            #endregion
            #region Métodos

            public DataTable ObtenerUno(Int32 amtId)
            {
                try
                {
                    return ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenerUno]", new object[,] { { "@amtId", amtId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public int ObtenerCantidadTotalClases(int ictId)
            {
                try
                {
                    object resultado = ocdGestor.EjecutarNonQueryRetornaId("[AsistenciaMateriaTerciario.ObtenerCantidadTotalClases]", new object[,] {
            { "@ictId", ictId }
        });
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public int ObtenerCantidadPresentes(int ictId)
            {
                try
                {
                    object resultado = ocdGestor.EjecutarNonQueryRetornaId("[AsistenciaMateriaTerciario.ObtenerCantidadPresentes]", new object[,] {
            { "@ictId", ictId }
        });
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable ObtenerPorEspCurrYFecha(Int32 escId, Int32 Anio, DateTime fecha)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenerPorEspCurrYFecha]", new object[,] { { "@escId", escId }, { "@Anio", Anio }, { "@fecha", fecha } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
 public DataTable ObtenerPorictIdyFecha(Int32 ictId,  DateTime fecha)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenerPorictIdyFecha]", new object[,] { { "@ictId", ictId }, { "@fecha", fecha } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerPorIctYFecha(Int32 ictId, DateTime desde, DateTime hasta)
            {
                try
                {
                    return ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenerPorIctYFecha]", new object[,] {
                    { "@ictId", ictId },
                    { "@desde", desde },
                    { "@hasta", hasta }
                });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public DataTable ObtenertodoxEspCurr(Int32 escId, Int32 Anio)
            {
                try
                {
                    return ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenertodoxEspCurr]", new object[,] {
                    { "@escId", escId },
                    { "@Anio", Anio }
                });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public Int32 Insertar()
            {
                try
                {
                    return ocdGestor.EjecutarNonQueryRetornaId("[AsistenciaMateriaTerciario.Insertar]", new object[,] {
                    { "@ictId", ictId },
                    { "@amtFecha", amtFecha },
                    { "@amtPresente", amtPresente },
                    { "@amtObservaciones", amtObservaciones },
                    { "@usuIdCreacion", usuIdCreacion },
                    { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                    { "@amtFechaHoraCreacion", amtFechaHoraCreacion },
                    { "@amtFechaHoraUltimaModificacion", amtFechaHoraUltimaModificacion }
                });
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
                    ocdGestor.EjecutarNonQuery("[AsistenciaMateriaTerciario.Actualizar]", new object[,] {
                    { "@amtId", amtId },
                    { "@amtPresente", amtPresente },
                    { "@amtObservaciones", amtObservaciones },
                    { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                    { "@amtFechaHoraUltimaModificacion", amtFechaHoraUltimaModificacion }
                });
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
                    ocdGestor.EjecutarNonQuery("[AsistenciaMateriaTerciario.Eliminar]", new object[,] {
                    { "@amtId", amtId }
                });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarxFecha(Int32 escId, Int32 Anio, DateTime fecha)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[AsistenciaMateriaTerciario.EliminarxFecha]", new object[,] {
                    { "@escId", escId }, { "@Anio", Anio },{ "@fecha", fecha }
                });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public DataTable ObtenerPorcentajeAsistencia(int ictId, DateTime desde, DateTime hasta)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AsistenciaMateriaTerciario.ObtenerPorcentajeAsistencia]", new object[,] { { "@ictId", ictId }, { "@desde", desde }, { "@hasta", hasta } });
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