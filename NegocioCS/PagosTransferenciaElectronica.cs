using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class PagosTransferenciaElectronica
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _pteId;
            public Int32 pteId { get { return _pteId; } set { _pteId = value; } }

            private Decimal _pteImporte;
            public Decimal pteImporte { get { return _pteImporte; } set { _pteImporte = value; } }

            private String _pteNroCuenta;
            public String pteNroCuenta { get { return _pteNroCuenta; } set { _pteNroCuenta = value; } }

            private Boolean _pteActivo;
            public Boolean pteActivo { get { return _pteActivo; } set { _pteActivo = value; } }

            private DateTime _pteFechaHoraCreacion;
            public DateTime pteFechaHoraCreacion { get { return _pteFechaHoraCreacion; } set { _pteFechaHoraCreacion = value; } }

            private DateTime _pteFechaHoraUltimaModificacion;
            public DateTime pteFechaHoraUltimaModificacion { get { return _pteFechaHoraUltimaModificacion; } set { _pteFechaHoraUltimaModificacion = value; } }

            private Int32 _cfpId;
            public Int32 cfpId { get { return _cfpId; } set { _cfpId = value; } }

            private Int32 _banId;
            public Int32 banId { get { return _banId; } set { _banId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public PagosTransferenciaElectronica() { try { this.pteId = 0; } catch (Exception oError) { throw oError; } }

            public PagosTransferenciaElectronica(Int32 pteId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosTransferenciaElectronica.ObtenerUno]", new object[,] { { "@pteId", pteId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["pteId"].ToString().Trim().Length > 0)
                        {
                            this.pteId = Convert.ToInt32(Fila.Rows[0]["pteId"]);
                        }
                        else
                        {
                            this.pteId = 0;
                        }

                        if (Fila.Rows[0]["pteImporte"].ToString().Trim().Length > 0)
                        {
                            this.pteImporte = Convert.ToDecimal(Fila.Rows[0]["pteImporte"]);
                        }
                        else
                        {
                            this.pteImporte = 0;
                        }

                        if (Fila.Rows[0]["pteNroCuenta"].ToString().Trim().Length > 0)
                        {
                            this.pteNroCuenta = Convert.ToString(Fila.Rows[0]["pteNroCuenta"]);
                        }
                        else
                        {
                            this.pteNroCuenta = "";
                        }

                        if (Fila.Rows[0]["pteFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.pteFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["pteFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.pteFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["pteFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.pteFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["pteFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.pteFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["pteActivo"].ToString().Trim().Length > 0)
                        {
                            this.pteActivo = (Convert.ToInt32(Fila.Rows[0]["pteActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.pteActivo = false;
                        }

                        if (Fila.Rows[0]["cfpId"].ToString().Trim().Length > 0)
                        {
                            this.cfpId = Convert.ToInt32(Fila.Rows[0]["cfpId"]);
                        }
                        else
                        {
                            this.cfpId = 0;
                        }

                        if (Fila.Rows[0]["banId"].ToString().Trim().Length > 0)
                        {
                            this.banId = Convert.ToInt32(Fila.Rows[0]["banId"]);
                        }
                        else
                        {
                            this.banId = 0;
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

            public PagosTransferenciaElectronica(Int32 pteId, Decimal pteImporte, String pteNroCuenta, Boolean pteActivo, DateTime pteFechaHoraCreacion, DateTime pteFechaHoraUltimaModificacion, Int32 IcfpId, Int32 IbanId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.pteId = pteId;
                    this.pteImporte = pteImporte;
                    this.pteNroCuenta = pteNroCuenta;
                    this.pteActivo = pteActivo;
                    this.pteFechaHoraCreacion = pteFechaHoraCreacion;
                    this.pteFechaHoraUltimaModificacion = pteFechaHoraUltimaModificacion;
                    this.cfpId = cfpId;
                    this.banId = banId;
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
                    Tabla = ocdGestor.EjecutarReader("[PagosTransferenciaElectronica.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 pteId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PagosTransferenciaElectronica.ObtenerUno]", new object[,] { { "@pteId", pteId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 pteId, Int32 cfpId, Decimal pteImporte, String pteNroCuenta, Int32 banId, Boolean pteActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime pteFechaHoraCreacion, DateTime pteFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.Actualizar]", new object[,] { { "@pteId", pteId }, { "@cfpId", cfpId }, { "@pteImporte", pteImporte }, { "@pteNroCuenta", pteNroCuenta }, { "@banId", banId }, { "@pteActivo", pteActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pteFechaHoraCreacion", pteFechaHoraCreacion }, { "@pteFechaHoraUltimaModificacion", pteFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarActivoxcfp(Int32 cfpId, Boolean pteActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime pteFechaHoraCreacion, DateTime pteFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.ActualizarActivoxcfp]", new object[,] { { "@cfpId", cfpId }, { "@pteActivo", pteActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pteFechaHoraCreacion", pteFechaHoraCreacion }, { "@pteFechaHoraUltimaModificacion", pteFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void Eliminar(Int32 pteId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.Eliminar]", new object[,] { { "@pteId", pteId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void EliminarxcfpId(Int32 cfpId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.EliminarxcfpId]", new object[,] { { "@cfpId", cfpId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void Insertar(Int32 cfpId, Decimal pteImporte, String pteNroCuenta, Int32 banId, Boolean pteActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime pteFechaHoraCreacion, DateTime pteFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.Insertar]", new object[,] { { "@cfpId", cfpId }, { "@pteImporte", pteImporte }, { "@pteNroCuenta", pteNroCuenta }, { "@banId", banId }, { "@pteActivo", pteActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pteFechaHoraCreacion", pteFechaHoraCreacion }, { "@pteFechaHoraUltimaModificacion", pteFechaHoraUltimaModificacion } });
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
                    if (this.pteId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.Actualizar]", new object[,] { { "@pteId", pteId }, { "@cfpId", cfpId }, { "@pteImporte", pteImporte }, { "@pteNroCuenta", pteNroCuenta }, { "@banId", banId }, { "@pteActivo", pteActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pteFechaHoraCreacion", pteFechaHoraCreacion }, { "@pteFechaHoraUltimaModificacion", pteFechaHoraUltimaModificacion } });
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
                    if (this.pteId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PagosTransferenciaElectronica.Eliminar]", new object[,] { { "@pteId", pteId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PagosTransferenciaElectronica.Insertar]", new object[,] { { "@cfpId", cfpId }, { "@pteImporte", pteImporte }, { "@pteNroCuenta", pteNroCuenta }, { "@banId", banId }, { "@pteActivo", pteActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pteFechaHoraCreacion", pteFechaHoraCreacion }, { "@pteFechaHoraUltimaModificacion", pteFechaHoraUltimaModificacion } });
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