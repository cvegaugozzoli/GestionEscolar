using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ComprobantesPtosVta
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cpvId;
            public Int32 cpvId { get { return _cpvId; } set { _cpvId = value; } }

            private String _cpvPtoVta;
            public String cpvPtoVta { get { return _cpvPtoVta; } set { _cpvPtoVta = value; } }

            private Int32 _cpvUltimoNro;
            public Int32 cpvUltimoNro { get { return _cpvUltimoNro; } set { _cpvUltimoNro = value; } }

            private Boolean _cpvActivo;
            public Boolean cpvActivo { get { return _cpvActivo; } set { _cpvActivo = value; } }

            private DateTime _cpvFechaHoraCreacion;
            public DateTime cpvFechaHoraCreacion { get { return _cpvFechaHoraCreacion; } set { _cpvFechaHoraCreacion = value; } }

            private DateTime _cpvFechaHoraUltimaModificacion;
            public DateTime cpvFechaHoraUltimaModificacion { get { return _cpvFechaHoraUltimaModificacion; } set { _cpvFechaHoraUltimaModificacion = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private Int32 _ctiId;
            public Int32 ctiId { get { return _ctiId; } set { _ctiId = value; } }

            private Int32 _cdoId;
            public Int32 cdoId { get { return _cdoId; } set { _cdoId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ComprobantesPtosVta() { try { this.cpvId = 0; } catch (Exception oError) { throw oError; } }

            public ComprobantesPtosVta(Int32 cpvId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ComprobantesPtosVta.ObtenerUno]", new object[,] { { "@cpvId", cpvId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["cpvId"].ToString().Trim().Length > 0)
                        {
                            this.cpvId = Convert.ToInt32(Fila.Rows[0]["cpvId"]);
                        }
                        else
                        {
                            this.cpvId = 0;
                        }

                        if (Fila.Rows[0]["cpvPtoVta"].ToString().Trim().Length > 0)
                        {
                            this.cpvPtoVta = Convert.ToString(Fila.Rows[0]["cpvPtoVta"]);
                        }
                        else
                        {
                            this.cpvPtoVta = "";
                        }

                        if (Fila.Rows[0]["cpvUltimoNro"].ToString().Trim().Length > 0)
                        {
                            this.cpvUltimoNro = Convert.ToInt32(Fila.Rows[0]["cpvUltimoNro"]);
                        }
                        else
                        {
                            this.cpvUltimoNro = 0;
                        }

                        if (Fila.Rows[0]["cpvFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cpvFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cpvFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cpvFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cpvFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cpvFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cpvFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cpvFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cpvActivo"].ToString().Trim().Length > 0)
                        {
                            this.cpvActivo = (Convert.ToInt32(Fila.Rows[0]["cpvActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.cpvActivo = false;
                        }

                        if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

                        if (Fila.Rows[0]["ctiId"].ToString().Trim().Length > 0)
                        {
                            this.ctiId = Convert.ToInt32(Fila.Rows[0]["ctiId"]);
                        }
                        else
                        {
                            this.ctiId = 0;
                        }

                        if (Fila.Rows[0]["cdoId"].ToString().Trim().Length > 0)
                        {
                            this.cdoId = Convert.ToInt32(Fila.Rows[0]["cdoId"]);
                        }
                        else
                        {
                            this.cdoId = 0;
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

            public ComprobantesPtosVta(Int32 cpvId, String cpvPtoVta, Int32 cpvUltimoNro, Boolean cpvActivo, DateTime cpvFechaHoraCreacion, DateTime cpvFechaHoraUltimaModificacion, Int32 IinsId, Int32 IctiId, Int32 IcdoId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.cpvId = cpvId;
                    this.cpvPtoVta = cpvPtoVta;
                    this.cpvUltimoNro = cpvUltimoNro;
                    this.cpvActivo = cpvActivo;
                    this.cpvFechaHoraCreacion = cpvFechaHoraCreacion;
                    this.cpvFechaHoraUltimaModificacion = cpvFechaHoraUltimaModificacion;
                    this.insId = insId;
                    this.ctiId = ctiId;
                    this.cdoId = cdoId;
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesPtosVta.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 cpvId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesPtosVta.ObtenerUno]", new object[,] { { "@cpvId", cpvId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxInstxTipoCompxDest(Int32 instId, int compTipoId, int destId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesPtosVta.ObtenerUnoxInstxTipoCompxDest]", new object[,] { { "@instId", instId }, { "@compTipoId", compTipoId }, { "@destId", destId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                
                return Tabla;
            }

            public void ActualizarUltimoNro(Int32 cpvId, Int32 cpvUltimoNro, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cpvFechaHoraCreacion, DateTime cpvFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesPtosVta.ActualizarUltimoNro]", new object[,] { { "@cpvId", cpvId }, { "@cpvUltimoNro", cpvUltimoNro }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cpvFechaHoraCreacion", cpvFechaHoraCreacion }, { "@cpvFechaHoraUltimaModificacion", cpvFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 cpvId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesPtosVta.Eliminar]", new object[,] { { "@cpvId", cpvId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 insId, Int32 ctiId, String cpvPtoVta, Int32 cpvUltimoNro, Int32 cdoId, Boolean cpvActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cpvFechaHoraCreacion, DateTime cpvFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesPtosVta.Insertar]", new object[,] { { "@insId", insId }, { "@ctiId", ctiId }, { "@cpvPtoVta", cpvPtoVta }, { "@cpvUltimoNro", cpvUltimoNro }, { "@cdoId", cdoId }, { "@cpvActivo", cpvActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cpvFechaHoraCreacion", cpvFechaHoraCreacion }, { "@cpvFechaHoraUltimaModificacion", cpvFechaHoraUltimaModificacion } });
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
                    if (this.cpvId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesPtosVta.Actualizar]", new object[,] { { "@cpvId", cpvId }, { "@insId", insId }, { "@ctiId", ctiId }, { "@cpvPtoVta", cpvPtoVta }, { "@cpvUltimoNro", cpvUltimoNro }, { "@cdoId", cdoId }, { "@cpvActivo", cpvActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cpvFechaHoraCreacion", cpvFechaHoraCreacion }, { "@cpvFechaHoraUltimaModificacion", cpvFechaHoraUltimaModificacion } });
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
                    if (this.cpvId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesPtosVta.Eliminar]", new object[,] { { "@cpvId", cpvId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesPtosVta.Insertar]", new object[,] { { "@insId", insId }, { "@ctiId", ctiId }, { "@cpvPtoVta", cpvPtoVta }, { "@cpvUltimoNro", cpvUltimoNro }, { "@cdoId", cdoId }, { "@cpvActivo", cpvActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cpvFechaHoraCreacion", cpvFechaHoraCreacion }, { "@cpvFechaHoraUltimaModificacion", cpvFechaHoraUltimaModificacion } });
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