using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TipoRegistro
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _treId;
            public Int32 treId { get { return _treId; } set { _treId = value; } }
         

            private String _treDescripcion;
            public String treDescripcion { get { return _treDescripcion; } set { _treDescripcion = value; } }

          
            #endregion

            #region Constructores

            public TipoRegistro() { try { this.treId = 0; } catch (Exception oError) { throw oError; } }

            public TipoRegistro(Int32 treId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[TipoRegistro.ObtenerUno]", new object[,] { { "@treId", treId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["treId"].ToString().Trim().Length > 0)
                        {
                            this.treId = Convert.ToInt32(Fila.Rows[0]["treId"]);
                        }
                        else
                        {
                            this.treId = 0;
                        }

                  
                        if (Fila.Rows[0]["treDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.treDescripcion = Convert.ToString(Fila.Rows[0]["treDescripcion"]);
                        }
                        else
                        {
                            this.treDescripcion = "";
                        }
                    
                        

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public EtapaEvaluacion(Int32 etaId, Int32 tcaId, String etaDescripcion, String etaAbrev, DateTime etaFechaHoraCreacion, DateTime etaFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.etaId = etaId;
            //        this.tcaId = tcaId;
            //        this.etaDescripcion = etaDescripcion;
            //        this.etaAbrev = etaAbrev;
            //        this.etaFechaHoraCreacion = etaFechaHoraCreacion;
            //        this.etaFechaHoraUltimaModificacion = etaFechaHoraUltimaModificacion;
            //        this.usuIdCreacion = usuIdCreacion;
            //        this.usuIdUltimaModificacion = usuIdUltimaModificacion;
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            #endregion

            #region Metodos


         
            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TipoRegistro.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
       public DataTable ObtenerListaxCarxPlaxEsc(String PrimerItem, int carId, int plaId, int escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TipoRegistro.ObtenerListaxCarxPlaxEsc]", new object[,] { { "@PrimerItem", PrimerItem }, { "@carId", carId }, 
                        { "@plaId", plaId },    { "@escId", escId }});
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