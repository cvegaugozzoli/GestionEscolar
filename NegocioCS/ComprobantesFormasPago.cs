using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ComprobantesFormasPago
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cfpId;
            public Int32 cfpId { get { return _cfpId; } set { _cfpId = value; } }

            private Decimal _cfpImporteParcial;
            public Decimal cfpImporteParcial { get { return _cfpImporteParcial; } set { _cfpImporteParcial = value; } }

            private Boolean _cfpActivo;
            public Boolean cfpActivo { get { return _cfpActivo; } set { _cfpActivo = value; } }

            private DateTime _cfpFechaHoraCreacion;
            public DateTime cfpFechaHoraCreacion { get { return _cfpFechaHoraCreacion; } set { _cfpFechaHoraCreacion = value; } }

            private DateTime _cfpFechaHoraUltimaModificacion;
            public DateTime cfpFechaHoraUltimaModificacion { get { return _cfpFechaHoraUltimaModificacion; } set { _cfpFechaHoraUltimaModificacion = value; } }

            private Int32 _cdeId;
            public Int32 cdeId { get { return _cdeId; } set { _cdeId = value; } }

            private Int32 _fopId;
            public Int32 fopId { get { return _fopId; } set { _fopId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ComprobantesFormasPago() { try { this.cfpId = 0; } catch (Exception oError) { throw oError; } }

            public ComprobantesFormasPago(Int32 cfpId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ComprobantesFormasPago.ObtenerUno]", new object[,] { { "@cfpId", cfpId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["cfpId"].ToString().Trim().Length > 0)
                        {
                            this.cfpId = Convert.ToInt32(Fila.Rows[0]["cfpId"]);
                        }
                        else
                        {
                            this.cfpId = 0;
                        }

                        if (Fila.Rows[0]["cfpImporteParcial"].ToString().Trim().Length > 0)
                        {
                            this.cfpImporteParcial = Convert.ToDecimal(Fila.Rows[0]["cfpImporteParcial"]);
                        }
                        else
                        {
                            this.cfpImporteParcial = 0;
                        }

                        if (Fila.Rows[0]["cfpFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cfpFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cfpFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cfpFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cfpFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cfpFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cfpFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cfpFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cfpActivo"].ToString().Trim().Length > 0)
                        {
                            this.cfpActivo = (Convert.ToInt32(Fila.Rows[0]["cfpActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.cfpActivo = false;
                        }

                        if (Fila.Rows[0]["cdeId"].ToString().Trim().Length > 0)
                        {
                            this.cdeId = Convert.ToInt32(Fila.Rows[0]["cdeId"]);
                        }
                        else
                        {
                            this.cdeId = 0;
                        }

                        if (Fila.Rows[0]["fopId"].ToString().Trim().Length > 0)
                        {
                            this.fopId = Convert.ToInt32(Fila.Rows[0]["fopId"]);
                        }
                        else
                        {
                            this.fopId = 0;
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

            public ComprobantesFormasPago(Int32 cfpId, Decimal cfpImporteParcial, Boolean cfpActivo, DateTime cfpFechaHoraCreacion, DateTime cfpFechaHoraUltimaModificacion, Int32 IcocId, Int32 IfopId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.cfpId = cfpId;
                    this.cfpImporteParcial = cfpImporteParcial;
                    this.cfpActivo = cfpActivo;
                    this.cfpFechaHoraCreacion = cfpFechaHoraCreacion;
                    this.cfpFechaHoraUltimaModificacion = cfpFechaHoraUltimaModificacion;
                    this.cdeId = cdeId;
                    this.fopId = fopId;
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesFormasPago.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

   public DataTable ObtenerTodoxcdeId(int cdeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesFormasPago.ObtenerTodoxcdeId]", new object[,] { { "@cdeId", cdeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 cfpId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesFormasPago.ObtenerUno]", new object[,] { { "@cfpId", cfpId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 cfpId, Int32 cdeId, Int32 fopId, Decimal cfpImporteParcial, Boolean cfpActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cfpFechaHoraCreacion, DateTime cfpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.Actualizar]", new object[,] { { "@cfpId", cfpId }, { "@cdeId", cdeId }, { "@fopId", fopId }, { "@cfpImporteParcial", cfpImporteParcial }, { "@cfpActivo", cfpActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraCreacion", cfpFechaHoraCreacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarActivoxcdeId( Int32 cdeId,  Boolean cfpActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cfpFechaHoraCreacion, DateTime cfpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.ActualizarActivoxcdeId]", new object[,] {  { "@cdeId", cdeId }, { "@cfpActivo", cfpActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraCreacion", cfpFechaHoraCreacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 cfpId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.Eliminar]", new object[,] { { "@cfpId", cfpId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void EliminarxEliminarxcdeId(Int32 cdeId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.EliminarxEliminarxcdeId]", new object[,] { { "@cdeId", cdeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 cdeId, Int32 fopId, Decimal cfpImporteParcial, Boolean cfpActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cfpFechaHoraCreacion, DateTime cfpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.Insertar]", new object[,] { { "@cdeId", cdeId }, { "@fopId", fopId }, { "@cfpImporteParcial", cfpImporteParcial }, { "@cfpActivo", cfpActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraCreacion", cfpFechaHoraCreacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public Int32 InsertarTraerId(Int32 cdeId, Int32 fopId, Decimal cfpImporteParcial, Boolean cfpActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cfpFechaHoraCreacion, DateTime cfpFechaHoraUltimaModificacion)

            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesFormasPago.Insertar]", new object[,] { { "@cdeId", cdeId }, { "@fopId", fopId }, { "@cfpImporteParcial", cfpImporteParcial }, { "@cfpActivo", cfpActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraCreacion", cfpFechaHoraCreacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }
            
            public void Actualizar()
            {
                try
                {
                    if (this.cfpId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.Actualizar]", new object[,] { { "@cfpId", cfpId }, { "@cdeId", cdeId }, { "@fopId", fopId }, { "@cfpImporteParcial", cfpImporteParcial }, { "@cfpActivo", cfpActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraCreacion", cfpFechaHoraCreacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
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
                    if (this.cfpId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.Eliminar]", new object[,] { { "@cfpId", cfpId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesFormasPago.Insertar]", new object[,] { { "@cdeId", cdeId }, { "@fopId", fopId }, { "@cfpImporteParcial", cfpImporteParcial }, { "@cfpActivo", cfpActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraCreacion", cfpFechaHoraCreacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }



            public void ActualizarFormadePago(Int32 cfpId, Int32 fopId, Int32 usuidUltimaModificacion, DateTime cfpFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesFormasPago.ActualizarFormadePago]", new object[,] { { "@cfpId", cfpId }, { "@fopId", fopId }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cfpFechaHoraUltimaModificacion", cfpFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }



            #endregion
        }
    }
}