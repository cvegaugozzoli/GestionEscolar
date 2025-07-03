using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class PagosCheques
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _pchId;
            public Int32 pchId { get { return _pchId; } set { _pchId = value; } }

            private Decimal _pchImporte;
            public Decimal pchImporte { get { return _pchImporte; } set { _pchImporte = value; } }

            private String _pchChequeNro;
            public String pchChequeNro { get { return _pchChequeNro; } set { _pchChequeNro = value; } }

            private Boolean _pchActivo;
            public Boolean pchActivo { get { return _pchActivo; } set { _pchActivo = value; } }

            private DateTime _pchFechaHoraCreacion;
            public DateTime pchFechaHoraCreacion { get { return _pchFechaHoraCreacion; } set { _pchFechaHoraCreacion = value; } }

            private DateTime _pchFechaHoraUltimaModificacion;
            public DateTime pchFechaHoraUltimaModificacion { get { return _pchFechaHoraUltimaModificacion; } set { _pchFechaHoraUltimaModificacion = value; } }

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

            public PagosCheques() { try { this.pchId = 0; } catch (Exception oError) { throw oError; } }

            public PagosCheques(Int32 pchId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosCheques.ObtenerUno]", new object[,] { { "@pchId", pchId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["pchId"].ToString().Trim().Length > 0)
                        {
                            this.pchId = Convert.ToInt32(Fila.Rows[0]["pchId"]);
                        }
                        else
                        {
                            this.pchId = 0;
                        }

                        if (Fila.Rows[0]["pchImporte"].ToString().Trim().Length > 0)
                        {
                            this.pchImporte = Convert.ToDecimal(Fila.Rows[0]["pchImporte"]);
                        }
                        else
                        {
                            this.pchImporte = 0;
                        }

                        if (Fila.Rows[0]["pchChequeNro"].ToString().Trim().Length > 0)
                        {
                            this.pchChequeNro = Convert.ToString(Fila.Rows[0]["pchChequeNro"]);
                        }
                        else
                        {
                            this.pchChequeNro = "";
                        }

                        if (Fila.Rows[0]["pchFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.pchFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["pchFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.pchFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["pchFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.pchFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["pchFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.pchFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["pchActivo"].ToString().Trim().Length > 0)
                        {
                            this.pchActivo = (Convert.ToInt32(Fila.Rows[0]["pchActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.pchActivo = false;
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

            public PagosCheques(Int32 pchId, Decimal pchImporte, String pchChequeNro, Boolean pchActivo, DateTime pchFechaHoraCreacion, DateTime pchFechaHoraUltimaModificacion, Int32 IcfpId, Int32 IbanId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.pchId = pchId;
                    this.pchImporte = pchImporte;
                    this.pchChequeNro = pchChequeNro;
                    this.pchActivo = pchActivo;
                    this.pchFechaHoraCreacion = pchFechaHoraCreacion;
                    this.pchFechaHoraUltimaModificacion = pchFechaHoraUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[PagosCheques.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 pchId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PagosCheques.ObtenerUno]", new object[,] { { "@pchId", pchId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 pchId, Int32 cfpId, Decimal pchImporte, String pchChequeNro, Int32 banId, Boolean pchActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime pchFechaHoraCreacion, DateTime pchFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosCheques.Actualizar]", new object[,] { { "@pchId", pchId }, { "@cfpId", cfpId }, { "@pchImporte", pchImporte }, { "@pchChequeNro", pchChequeNro }, { "@banId", banId }, { "@pchActivo", pchActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pchFechaHoraCreacion", pchFechaHoraCreacion }, { "@pchFechaHoraUltimaModificacion", pchFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarActivoxcfp( Int32 cfpId, Boolean pchActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime pchFechaHoraCreacion, DateTime pchFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosCheques.Actualizar]", new object[,] { { "@cfpId", cfpId }, { "@pchActivo", pchActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pchFechaHoraCreacion", pchFechaHoraCreacion }, { "@pchFechaHoraUltimaModificacion", pchFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 pchId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosCheques.Eliminar]", new object[,] { { "@pchId", pchId } });
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
                    ocdGestor.EjecutarNonQuery("[PagosCheques.EliminarxcfpId]", new object[,] { { "@cfpId", cfpId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 cfpId, Decimal pchImporte, String pchChequeNro, Int32 banId, Boolean pchActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime pchFechaHoraCreacion, DateTime pchFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosCheques.Insertar]", new object[,] { { "@cfpId", cfpId }, { "@pchImporte", pchImporte }, { "@pchChequeNro", pchChequeNro }, { "@banId", banId }, { "@pchActivo", pchActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pchFechaHoraCreacion", pchFechaHoraCreacion }, { "@pchFechaHoraUltimaModificacion", pchFechaHoraUltimaModificacion } });
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
                    if (this.pchId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PagosCheques.Actualizar]", new object[,] { { "@pchId", pchId }, { "@cfpId", cfpId }, { "@pchImporte", pchImporte }, { "@pchChequeNro", pchChequeNro }, { "@banId", banId }, { "@pchActivo", pchActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pchFechaHoraCreacion", pchFechaHoraCreacion }, { "@pchFechaHoraUltimaModificacion", pchFechaHoraUltimaModificacion } });
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
                    if (this.pchId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PagosCheques.Eliminar]", new object[,] { { "@pchId", pchId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PagosCheques.Insertar]", new object[,] { { "@cfpId", cfpId }, { "@pchImporte", pchImporte }, { "@pchChequeNro", pchChequeNro }, { "@banId", banId }, { "@pchActivo", pchActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@pchFechaHoraCreacion", pchFechaHoraCreacion }, { "@pchFechaHoraUltimaModificacion", pchFechaHoraUltimaModificacion } });
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