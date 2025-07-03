using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class PagosTarjetas
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _patId;
            public Int32 patId { get { return _patId; } set { _patId = value; } }

            private Decimal _patInteresPorcMensual;
            public Decimal patInteresPorcMensual { get { return _patInteresPorcMensual; } set { _patInteresPorcMensual = value; } }

            private Decimal _patImporteCuota;
            public Decimal patImporteCuota { get { return _patImporteCuota; } set { _patImporteCuota = value; } }

            private Int32 _patCantCuotas;
            public Int32 patCantCuotas { get { return _patCantCuotas; } set { _patCantCuotas = value; } }

            private String _patNroCupon;
            public String patNroCupon { get { return _patNroCupon; } set { _patNroCupon = value; } }

            private Boolean _patActivo;
            public Boolean patActivo { get { return _patActivo; } set { _patActivo = value; } }

            private DateTime _patFechaHoraCreacion;
            public DateTime patFechaHoraCreacion { get { return _patFechaHoraCreacion; } set { _patFechaHoraCreacion = value; } }

            private DateTime _patFechaHoraUltimaModificacion;
            public DateTime patFechaHoraUltimaModificacion { get { return _patFechaHoraUltimaModificacion; } set { _patFechaHoraUltimaModificacion = value; } }

            private Int32 _cfpId;
            public Int32 cfpId { get { return _cfpId; } set { _cfpId = value; } }

            private Int32 _tarId;
            public Int32 tarId { get { return _tarId; } set { _tarId = value; } }

            private Int32 _tapId;
            public Int32 tapId { get { return _tapId; } set { _tapId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public PagosTarjetas() { try { this.patId = 0; } catch (Exception oError) { throw oError; } }

            public PagosTarjetas(Int32 patId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosTarjetas.ObtenerUno]", new object[,] { { "@patId", patId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["patId"].ToString().Trim().Length > 0)
                        {
                            this.patId = Convert.ToInt32(Fila.Rows[0]["patId"]);
                        }
                        else
                        {
                            this.patId = 0;
                        }

                        if (Fila.Rows[0]["patInteresPorcMensual"].ToString().Trim().Length > 0)
                        {
                            this.patInteresPorcMensual = Convert.ToDecimal(Fila.Rows[0]["patInteresPorcMensual"]);
                        }
                        else
                        {
                            this.patInteresPorcMensual = 0;
                        }

                        if (Fila.Rows[0]["patImporteCuota"].ToString().Trim().Length > 0)
                        {
                            this.patImporteCuota = Convert.ToDecimal(Fila.Rows[0]["patImporteCuota"]);
                        }
                        else
                        {
                            this.patImporteCuota = 0;
                        }


                        if (Fila.Rows[0]["patCantCuotas"].ToString().Trim().Length > 0)
                        {
                            this.patCantCuotas = Convert.ToInt32(Fila.Rows[0]["patCantCuotas"]);
                        }
                        else
                        {
                            this.patCantCuotas = 0;
                        }

                     
                        if (Fila.Rows[0]["patNroCupon"].ToString().Trim().Length > 0)
                        {
                            this.patNroCupon = Convert.ToString(Fila.Rows[0]["patNroCupon"]);
                        }
                        else
                        {
                            this.patNroCupon = "";
                        }

                        if (Fila.Rows[0]["patFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.patFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["patFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.patFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["patFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.patFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["patFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.patFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["patActivo"].ToString().Trim().Length > 0)
                        {
                            this.patActivo = (Convert.ToInt32(Fila.Rows[0]["patActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.patActivo = false;
                        }

                        if (Fila.Rows[0]["cfpId"].ToString().Trim().Length > 0)
                        {
                            this.cfpId = Convert.ToInt32(Fila.Rows[0]["cfpId"]);
                        }
                        else
                        {
                            this.cfpId = 0;
                        }

                        if (Fila.Rows[0]["tarId"].ToString().Trim().Length > 0)
                        {
                            this.tarId = Convert.ToInt32(Fila.Rows[0]["tarId"]);
                        }
                        else
                        {
                            this.tarId = 0;
                        }

                        if (Fila.Rows[0]["tapId"].ToString().Trim().Length > 0)
                        {
                            this.tapId = Convert.ToInt32(Fila.Rows[0]["tapId"]);
                        }
                        else
                        {
                            this.tapId = 0;
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

            public PagosTarjetas(Int32 patId, Decimal patInteresPorcMensual, Decimal patImporteCuota, Int32 patCantCuotas, String patNroCupon, Boolean patActivo, DateTime patFechaHoraCreacion, DateTime patFechaHoraUltimaModificacion, Int32 IcfpId, Int32 ItarId, Int32 ItapId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.patId = patId;
                    this.patInteresPorcMensual = patInteresPorcMensual;
                    this.patImporteCuota = patImporteCuota;
                    this.patCantCuotas = patCantCuotas;
                  
                    this.patNroCupon = patNroCupon;
                    this.patActivo = patActivo;
                    this.patFechaHoraCreacion = patFechaHoraCreacion;
                    this.patFechaHoraUltimaModificacion = patFechaHoraUltimaModificacion;
                    this.cfpId = cfpId;
                    this.tarId = tarId;
                    this.tapId = tapId;
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
                    Tabla = ocdGestor.EjecutarReader("[PagosTarjetas.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 patId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PagosTarjetas.ObtenerUno]", new object[,] { { "@patId", patId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 patId, Int32 cfpId, Int32 tarId, Int32 tapId, Decimal patInteresPorcMensual, Decimal patImporteCuota, Int32 patCantCuotas, String patNroCupon, Boolean patActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime patFechaHoraCreacion, DateTime patFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTarjetas.Actualizar]", new object[,] { { "@patId", patId }, { "@cfpId", cfpId }, { "@tarId", tarId }, { "@tapId", tapId }, { "@patInteresPorcMensual", patInteresPorcMensual }, { "@patImporteCuota", patImporteCuota }, { "@patCantCuotas", patCantCuotas }, { "@patNroCupon", patNroCupon }, { "@patActivo", patActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@patFechaHoraCreacion", patFechaHoraCreacion }, { "@patFechaHoraUltimaModificacion", patFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }    public void ActualizarActivoxcfp(Int32 cfpId, Boolean patActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime patFechaHoraCreacion, DateTime patFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTarjetas.ActualizarActivoxcfp]", new object[,] { { "@cfpId", cfpId }, { "@patActivo", patActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@patFechaHoraCreacion", patFechaHoraCreacion }, { "@patFechaHoraUltimaModificacion", patFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 patId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTarjetas.Eliminar]", new object[,] { { "@patId", patId } });
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
                    ocdGestor.EjecutarNonQuery("[PagosTarjetas.EliminarxcfpId]", new object[,] { { "@cfpId", cfpId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 cfpId, Int32 tarId, Int32 tapId, Decimal patInteresPorcMensual, Decimal patImporteCuota, Int32 patCantCuotas, String patNroCupon, Boolean patActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime patFechaHoraCreacion, DateTime patFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PagosTarjetas.Insertar]", new object[,] { { "@cfpId", cfpId }, { "@tarId", tarId }, { "@tapId", tapId }, { "@patInteresPorcMensual", patInteresPorcMensual }, { "@patImporteCuota", patImporteCuota }, { "@patCantCuotas", patCantCuotas },  { "@patNroCupon", patNroCupon }, { "@patActivo", patActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@patFechaHoraCreacion", patFechaHoraCreacion }, { "@patFechaHoraUltimaModificacion", patFechaHoraUltimaModificacion } });
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
                    if (this.patId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PagosTarjetas.Actualizar]", new object[,] { { "@patId", patId }, { "@cfpId", cfpId }, { "@tarId", tarId }, { "@tapId", tapId }, { "@patInteresPorcMensual", patInteresPorcMensual }, { "@patImporteCuota", patImporteCuota }, { "@patCantCuotas", patCantCuotas }, { "@patNroCupon", patNroCupon }, { "@patActivo", patActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@patFechaHoraCreacion", patFechaHoraCreacion }, { "@patFechaHoraUltimaModificacion", patFechaHoraUltimaModificacion } });
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
                    if (this.patId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PagosTarjetas.Eliminar]", new object[,] { { "@patId", patId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PagosTarjetas.Insertar]", new object[,] { { "@cfpId", cfpId }, { "@tarId", tarId }, { "@tapId", tapId }, { "@patInteresPorcMensual", patInteresPorcMensual }, { "@patImporteCuota", patImporteCuota }, { "@patCantCuotas", patCantCuotas }, { "@patNroCupon", patNroCupon }, { "@patActivo", patActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@patFechaHoraCreacion", patFechaHoraCreacion }, { "@patFechaHoraUltimaModificacion", patFechaHoraUltimaModificacion } });
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