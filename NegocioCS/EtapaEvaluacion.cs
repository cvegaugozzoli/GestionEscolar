using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class EtapaEvaluacion
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _etaId;
            public Int32 etaId { get { return _etaId; } set { _etaId = value; } }

            private Int32 _tcaId;
            public Int32 tcaId { get { return _tcaId; } set { _tcaId = value; } }

            private String _etaDescripcion;
            public String etaDescripcion { get { return _etaDescripcion; } set { _etaDescripcion = value; } }

            private String _etaAbrev;
            public String etaAbrev { get { return _etaAbrev; } set { _etaAbrev = value; } }

            private DateTime _etaFechaHoraCreacion;
            public DateTime etaFechaHoraCreacion { get { return _etaFechaHoraCreacion; } set { _etaFechaHoraCreacion = value; } }

            private DateTime _etaFechaHoraUltimaModificacion;
            public DateTime etaFechaHoraUltimaModificacion { get { return _etaFechaHoraUltimaModificacion; } set { _etaFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public EtapaEvaluacion() { try { this.etaId = 0; } catch (Exception oError) { throw oError; } }

            public EtapaEvaluacion(Int32 etaId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[EtapaEvaluacion.ObtenerUno]", new object[,] { { "@etaId", etaId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["etaId"].ToString().Trim().Length > 0)
                        {
                            this.etaId = Convert.ToInt32(Fila.Rows[0]["etaId"]);
                        }
                        else
                        {
                            this.etaId = 0;
                        }

                        if (Fila.Rows[0]["tcaId"].ToString().Trim().Length > 0)
                        {
                            this.tcaId = Convert.ToInt32(Fila.Rows[0]["tcaId"]);
                        }
                        else
                        {
                            this.tcaId = 0;
                        }
                        if (Fila.Rows[0]["etaDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.etaDescripcion = Convert.ToString(Fila.Rows[0]["etaDescripcion"]);
                        }
                        else
                        {
                            this.etaDescripcion = "";
                        }
                        if (Fila.Rows[0]["etaAbrev"].ToString().Trim().Length > 0)
                        {
                            this.etaAbrev = Convert.ToString(Fila.Rows[0]["etaAbrev"]);
                        }
                        else
                        {
                            this.etaAbrev = "";
                        }


                        if (Fila.Rows[0]["etaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.etaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["etaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.etaFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["etaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.etaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["etaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.etaFechaHoraUltimaModificacion = DateTime.Now;
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

            public EtapaEvaluacion(Int32 etaId, Int32 tcaId, String etaDescripcion, String etaAbrev, DateTime etaFechaHoraCreacion, DateTime etaFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.etaId = etaId;
                    this.tcaId = tcaId;
                    this.etaDescripcion = etaDescripcion;
                    this.etaAbrev = etaAbrev;
                    this.etaFechaHoraCreacion = etaFechaHoraCreacion;
                    this.etaFechaHoraUltimaModificacion = etaFechaHoraUltimaModificacion;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos


         
            public DataTable ObtenerListaxtcaId(String PrimerItem, Int32 tcaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EtapaEvaluacion.ObtenerListaxtcaId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@tcaId", tcaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
  public DataTable ObtenerTodoxtcaId( Int32 tcaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EtapaEvaluacion.ObtenerTodoxtcaId]", new object[,] { { "@tcaId", tcaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerUno(Int32 extId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerUno]", new object[,] { { "@extId", extId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerValidarRepetido(Int32 extId, String extNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[ExamenTipo.ObtenerValidarRepetido]", new object[,] { { "@extId", extId }, { "@extNombre", extNombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 extId, String extNombre, Boolean extActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[ExamenTipo.Actualizar]", new object[,] { { "@extId", extId }, { "@extNombre", extNombre }, { "@extActivo", extActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@extFechaHoraCreacion", extFechaHoraCreacion }, { "@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar(String extNombre, Boolean extActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[ExamenTipo.Copiar]", new object[,] { { "@extNombre", extNombre }, { "@extActivo", extActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@extFechaHoraCreacion", extFechaHoraCreacion }, { "@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Eliminar(Int32 extId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[ExamenTipo.Eliminar]", new object[,] { { "@extId", extId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Insertar(String extNombre, Boolean extActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime extFechaHoraCreacion, DateTime extFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[ExamenTipo.Insertar]", new object[,] { { "@extNombre", extNombre }, { "@extActivo", extActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@extFechaHoraCreacion", extFechaHoraCreacion }, { "@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Actualizar()
            //{
            //    try
            //    {
            //        if (this.extId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[ExamenTipo.Actualizar]", new object[,] { { "@extId", extId }, { "@extNombre", extNombre }, { "@extActivo", extActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@extFechaHoraCreacion", extFechaHoraCreacion }, { "@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar()
            //{
            //    try
            //    {
            //        if (this.extId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[ExamenTipo.Copiar]", new object[,] { { "@extNombre", extNombre }, { "@extActivo", extActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@extFechaHoraCreacion", extFechaHoraCreacion }, { "@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Eliminar()
            //{
            //    try
            //    {
            //        if (this.extId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[ExamenTipo.Eliminar]", new object[,] { { "@extId", extId } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public Int32 Insertar()
            //{
            //    Int32 IdMax;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ExamenTipo.Insertar]", new object[,] { { "@extNombre", extNombre }, { "@extActivo", extActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@extFechaHoraCreacion", extFechaHoraCreacion }, { "@extFechaHoraUltimaModificacion", extFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //    return IdMax;
            //}


            #endregion
        }
    }
}