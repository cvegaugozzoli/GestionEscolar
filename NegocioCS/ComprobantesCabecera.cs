using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ComprobantesCabecera
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cocId;
            public Int32 cocId { get { return _cocId; } set { _cocId = value; } }

            private String _cocNroPtoVta;
            public String cocNroPtoVta { get { return _cocNroPtoVta; } set { _cocNroPtoVta = value; } }

            private String _cocNroCompbte;
            public String cocNroCompbte { get { return _cocNroCompbte; } set { _cocNroCompbte = value; } }

            private DateTime _cocFechaPago;
            public DateTime cocFechaPago { get { return _cocFechaPago; } set { _cocFechaPago = value; } }

            private Decimal _cocImporteRendido;
            public Decimal cocImporteRendido { get { return _cocImporteRendido; } set { _cocImporteRendido = value; } }

            private String _cocObs;
            public String cocObs { get { return _cocObs; } set { _cocObs = value; } }

            private Boolean _cocActivo;
            public Boolean cocActivo { get { return _cocActivo; } set { _cocActivo = value; } }

            private DateTime _cocFechaHoraCreacion;
            public DateTime cocFechaHoraCreacion { get { return _cocFechaHoraCreacion; } set { _cocFechaHoraCreacion = value; } }

            private DateTime _cocFechaHoraUltimaModificacion;
            public DateTime cocFechaHoraUltimaModificacion { get { return _cocFechaHoraUltimaModificacion; } set { _cocFechaHoraUltimaModificacion = value; } }

            private Int32 _ctiId;
            public Int32 ctiId { get { return _ctiId; } set { _ctiId = value; } }

            private Int32 _lupId;
            public Int32 lupId { get { return _lupId; } set { _lupId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }
     

            #endregion

            #region Constructores

            public ComprobantesCabecera() { try { this.cocId = 0; } catch (Exception oError) { throw oError; } }

            public ComprobantesCabecera(Int32 cocId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ComprobantesCabecera.ObtenerUno]", new object[,] { { "@cocId", cocId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["cocId"].ToString().Trim().Length > 0)
                        {
                            this.cocId = Convert.ToInt32(Fila.Rows[0]["cocId"]);
                        }
                        else
                        {
                            this.cocId = 0;
                        }

                        if (Fila.Rows[0]["cocNroPtoVta"].ToString().Trim().Length > 0)
                        {
                            this.cocNroPtoVta = Convert.ToString(Fila.Rows[0]["cocNroPtoVta"]);
                        }
                        else
                        {
                            this.cocNroPtoVta = "";
                        }

                        if (Fila.Rows[0]["cocNroCompbte"].ToString().Trim().Length > 0)
                        {
                            this.cocNroCompbte = Convert.ToString(Fila.Rows[0]["cocNroCompbte"]);
                        }
                        else
                        {
                            this.cocNroCompbte = "";
                        }

                        if (Fila.Rows[0]["cocFechaPago"].ToString().Trim().Length > 0)
                        {
                            this.cocFechaPago = Convert.ToDateTime(Fila.Rows[0]["cocFechaPago"]);
                        }
                        else
                        {
                            this.cocFechaPago = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cocImporteRendido"].ToString().Trim().Length > 0)
                        {
                            this.cocImporteRendido = Convert.ToDecimal(Fila.Rows[0]["cocImporteRendido"]);
                        }
                        else
                        {
                            this.cocImporteRendido = 0;
                        }

                        if (Fila.Rows[0]["cocObs"].ToString().Trim().Length > 0)
                        {
                            this.cocObs = Convert.ToString(Fila.Rows[0]["cocObs"]);
                        }
                        else
                        {
                            this.cocObs = "";
                        }

                        if (Fila.Rows[0]["cocFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cocFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cocFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cocFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cocFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cocFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cocFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cocFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cocActivo"].ToString().Trim().Length > 0)
                        {
                            this.cocActivo = (Convert.ToInt32(Fila.Rows[0]["cocActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.cocActivo = false;
                        }

                        if (Fila.Rows[0]["ctiId"].ToString().Trim().Length > 0)
                        {
                            this.ctiId = Convert.ToInt32(Fila.Rows[0]["ctiId"]);
                        }
                        else
                        {
                            this.ctiId = 0;
                        }

                        if (Fila.Rows[0]["lupId"].ToString().Trim().Length > 0)
                        {
                            this.lupId = Convert.ToInt32(Fila.Rows[0]["lupId"]);
                        }
                        else
                        {
                            this.lupId = 0;
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

            public ComprobantesCabecera(Int32 cocId, String cocNroPtoVta, String cocNroCompbte, DateTime cocFechaPago, Decimal cocImporteRendido, String cocObs, Boolean cocActivo, DateTime cocFechaHoraCreacion, DateTime cocFechaHoraUltimaModificacion, Int32 IctiId, Int32 IlupId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.cocId = cocId;
                    this.cocNroPtoVta = cocNroPtoVta;
                    this.cocNroCompbte = cocNroCompbte;
                    this.cocFechaPago = cocFechaPago;
                    this.cocImporteRendido = cocImporteRendido;
                    this.cocObs = cocObs;
                    this.cocActivo = cocActivo;
                    this.cocFechaHoraCreacion = cocFechaHoraCreacion;
                    this.cocFechaHoraUltimaModificacion = cocFechaHoraUltimaModificacion;
                    this.ctiId = ctiId;
                    this.lupId = lupId;
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesCabecera.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 cocId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesCabecera.ObtenerUno]", new object[,] { { "@cocId", cocId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 cocId, Int32 ctiId, String cocNroPtoVta, String cocNroCompbte, DateTime cocFechaPago, Decimal cocImporteRendido, Int32 lupId, String cocObs, Boolean cocActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cocFechaHoraCreacion, DateTime cocFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesCabecera.Actualizar]", new object[,] { { "@cocId", cocId }, { "@ctiId", ctiId }, { "@cocNroPtoVta", cocNroPtoVta }, { "@cocNroCompbte", cocNroCompbte }, { "@cocFechaPago", cocFechaPago }, { "@cocImporteRendido", cocImporteRendido }, { "@lupId", lupId }, { "@cocObs", cocObs }, { "@cocActivo", cocActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cocFechaHoraCreacion", cocFechaHoraCreacion }, { "@cocFechaHoraUltimaModificacion", cocFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarObservacion(Int32 cocId, String cocObs, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cocFechaHoraCreacion, DateTime cocFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesCabecera.ActualizarObservacion]", new object[,] { { "@cocId", cocId }, { "@cocObs", cocObs }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cocFechaHoraCreacion", cocFechaHoraCreacion }, { "@cocFechaHoraUltimaModificacion", cocFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 cocId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesCabecera.Eliminar]", new object[,] { { "@cocId", cocId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 ctiId, String cocNroPtoVta, String cocNroCompbte, DateTime cocFechaPago, Decimal cocImporteRendido, Int32 lupId, String cocObs, Boolean cocActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cocFechaHoraCreacion, DateTime cocFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesCabecera.Insertar]", new object[,] { { "@ctiId", ctiId }, { "@cocNroPtoVta", cocNroPtoVta }, { "@cocNroCompbte", cocNroCompbte }, { "@cocFechaPago", cocFechaPago }, { "@cocImporteRendido", cocImporteRendido }, { "@lupId", lupId }, { "@cocObs", cocObs }, { "@cocActivo", cocActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cocFechaHoraCreacion", cocFechaHoraCreacion }, { "@cocFechaHoraUltimaModificacion", cocFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 InsertarTraerId(Int32 ctiId, String cocNroPtoVta, String cocNroCompbte, DateTime cocFechaPago, Decimal cocImporteRendido, Int32 lupId, String cocObs, Boolean cocActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cocFechaHoraCreacion, DateTime cocFechaHoraUltimaModificacion)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesCabecera.Insertar]", new object[,] { { "@ctiId", ctiId }, { "@cocNroPtoVta", cocNroPtoVta }, { "@cocNroCompbte", cocNroCompbte }, { "@cocFechaPago", cocFechaPago }, { "@cocImporteRendido", cocImporteRendido }, { "@lupId", lupId }, { "@cocObs", cocObs }, { "@cocActivo", cocActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cocFechaHoraCreacion", cocFechaHoraCreacion }, { "@cocFechaHoraUltimaModificacion", cocFechaHoraUltimaModificacion } });
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
                    if (this.cocId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesCabecera.Actualizar]", new object[,] { { "@cocId", cocId }, { "@ctiId", ctiId }, { "@cocNroPtoVta", cocNroPtoVta }, { "@cocNroCompbte", cocNroCompbte }, { "@cocFechaPago", cocFechaPago }, { "@cocImporteRendido", cocImporteRendido }, { "@lupId", lupId }, { "@cocObs", cocObs }, { "@cocActivo", cocActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cocFechaHoraCreacion", cocFechaHoraCreacion }, { "@cocFechaHoraUltimaModificacion", cocFechaHoraUltimaModificacion } });
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
                    if (this.cocId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesCabecera.Eliminar]", new object[,] { { "@cocId", cocId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesCabecera.Insertar]", new object[,] { { "@ctiId", ctiId }, { "@cocNroPtoVta", cocNroPtoVta }, { "@cocNroCompbte", cocNroCompbte }, { "@cocFechaPago", cocFechaPago }, { "@cocImporteRendido", cocImporteRendido }, { "@lupId", lupId }, { "@cocObs", cocObs }, { "@cocActivo", cocActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cocFechaHoraCreacion", cocFechaHoraCreacion }, { "@cocFechaHoraUltimaModificacion", cocFechaHoraUltimaModificacion } });
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