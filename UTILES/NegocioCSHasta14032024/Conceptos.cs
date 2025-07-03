using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Conceptos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _conId;
            public Int32 conId { get { return _conId; } set { _conId = value; } }

            private String _conNombre;
            public String conNombre { get { return _conNombre; } set { _conNombre = value; } }

            private Int32 _conAnioLectivo;
            public Int32 conAnioLectivo { get { return _conAnioLectivo; } set { _conAnioLectivo = value; } }

            private Decimal _conImporte;
            public Decimal conImporte { get { return _conImporte; } set { _conImporte = value; } }

            private Int32 _conCantCuotas;
            public Int32 conCantCuotas { get { return _conCantCuotas; } set { _conCantCuotas = value; } }

            private Int32 _conCantVtos;
            public Int32 conCantVtos { get { return _conCantVtos; } set { _conCantVtos = value; } }

            private Int32 _conMesInicio;
            public Int32 conMesInicio { get { return _conMesInicio; } set { _conMesInicio = value; } }

            private Int32 _conValorSeleccionado;
            public Int32 conValorSeleccionado { get { return _conValorSeleccionado; } set { _conValorSeleccionado = value; } }

            private Decimal _conRecargoVtoAbierto;
            public Decimal conRecargoVtoAbierto { get { return _conRecargoVtoAbierto; } set { _conRecargoVtoAbierto = value; } }

            private Boolean _conTieneVtoAbierto;
            public Boolean conTieneVtoAbierto { get { return _conTieneVtoAbierto; } set { _conTieneVtoAbierto = value; } }

            private String _conNotas;
            public String conNotas { get { return _conNotas; } set { _conNotas = value; } }

            private Decimal _conInteresMensual;
            public Decimal conInteresMensual { get { return _conInteresMensual; } set { _conInteresMensual = value; } }

            private Boolean _conActivo;
            public Boolean conActivo { get { return _conActivo; } set { _conActivo = value; } }

            private DateTime _conFechaHoraCreacion;
            public DateTime conFechaHoraCreacion { get { return _conFechaHoraCreacion; } set { _conFechaHoraCreacion = value; } }

            private DateTime _conFechaHoraUltimaModificacion;
            public DateTime conFechaHoraUltimaModificacion { get { return _conFechaHoraUltimaModificacion; } set { _conFechaHoraUltimaModificacion = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private Int32 _cntId;
            public Int32 cntId { get { return _cntId; } set { _cntId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Conceptos() { try { this.conId = 0; } catch (Exception oError) { throw oError; } }

            public Conceptos(Int32 conId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Conceptos.ObtenerUno]", new object[,] { { "@conId", conId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["conId"].ToString().Trim().Length > 0)
                        {
                            this.conId = Convert.ToInt32(Fila.Rows[0]["conId"]);
                        }
                        else
                        {
                            this.conId = 0;
                        }

                        if (Fila.Rows[0]["conNombre"].ToString().Trim().Length > 0)
                        {
                            this.conNombre = Convert.ToString(Fila.Rows[0]["conNombre"]);
                        }
                        else
                        {
                            this.conNombre = "";
                        }

                        if (Fila.Rows[0]["conAnioLectivo"].ToString().Trim().Length > 0)
                        {
                            this.conAnioLectivo = Convert.ToInt32(Fila.Rows[0]["conAnioLectivo"]);
                        }
                        else
                        {
                            this.conAnioLectivo = 0;
                        }

                        if (Fila.Rows[0]["conImporte"].ToString().Trim().Length > 0)
                        {
                            this.conImporte = Convert.ToDecimal(Fila.Rows[0]["conImporte"]);
                        }
                        else
                        {
                            this.conImporte = 0;
                        }

                        if (Fila.Rows[0]["conCantCuotas"].ToString().Trim().Length > 0)
                        {
                            this.conCantCuotas = Convert.ToInt32(Fila.Rows[0]["conCantCuotas"]);
                        }
                        else
                        {
                            this.conCantCuotas = 0;
                        }

                        if (Fila.Rows[0]["conCantVtos"].ToString().Trim().Length > 0)
                        {
                            this.conCantVtos = Convert.ToInt32(Fila.Rows[0]["conCantVtos"]);
                        }
                        else
                        {
                            this.conCantVtos = 0;
                        }

                        if (Fila.Rows[0]["conMesInicio"].ToString().Trim().Length > 0)
                        {
                            this.conMesInicio = Convert.ToInt32(Fila.Rows[0]["conMesInicio"]);
                        }
                        else
                        {
                            this.conMesInicio = 0;
                        }

                        if (Fila.Rows[0]["conValorSeleccionado"].ToString().Trim().Length > 0)
                        {
                            this.conValorSeleccionado = (Convert.ToInt32(Fila.Rows[0]["conValorSeleccionado"]));
                        }
                        else
                        {
                            this.conValorSeleccionado = 0;
                        }

                        if (Fila.Rows[0]["conRecargoVtoAbierto"].ToString().Trim().Length > 0)
                        {
                            this.conRecargoVtoAbierto = Convert.ToDecimal(Fila.Rows[0]["conRecargoVtoAbierto"]);
                        }
                        else
                        {
                            this.conRecargoVtoAbierto = 0;
                        }

                        if (Fila.Rows[0]["conNotas"].ToString().Trim().Length > 0)
                        {
                            this.conNotas = Convert.ToString(Fila.Rows[0]["conNotas"]);
                        }
                        else
                        {
                            this.conNotas = "";
                        }

                        if (Fila.Rows[0]["conInteresMensual"].ToString().Trim().Length > 0)
                        {
                            this.conInteresMensual = Convert.ToDecimal(Fila.Rows[0]["conInteresMensual"]);
                        }
                        else
                        {
                            this.conInteresMensual = 0;
                        }

                        if (Fila.Rows[0]["conFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.conFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["conFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.conFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["conFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.conFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["conFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.conFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["conTieneVtoAbierto"].ToString().Trim().Length > 0)
                        {
                            this.conTieneVtoAbierto = (Convert.ToInt32(Fila.Rows[0]["conTieneVtoAbierto"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.conTieneVtoAbierto = false;
                        }

                        if (Fila.Rows[0]["conActivo"].ToString().Trim().Length > 0)
                        {
                            this.conActivo = (Convert.ToInt32(Fila.Rows[0]["conActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.conActivo = false;
                        }

                        if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

                        if (Fila.Rows[0]["cntId"].ToString().Trim().Length > 0)
                        {
                            this.cntId = Convert.ToInt32(Fila.Rows[0]["cntId"]);
                        }
                        else
                        {
                            this.cntId = 0;
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

            public Conceptos(Int32 conId, String conNombre, Int32 conAnioLectivo, Decimal conImporte, Int32 conCantCuotas, Int32 conCantVtos, Int32 conMesInicio, Int32 conValorSeleccionado, Decimal conRecargoVtoAbierto, Boolean conTieneVtoAbierto, String conNotas, Decimal conInteresMensual, Boolean conActivo, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion, Int32 IinsId, Int32 IcntId, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.conId = conId;
                    this.conNombre = conNombre;
                    this.conAnioLectivo = conAnioLectivo;
                    this.conImporte = conImporte;
                    this.conCantCuotas = conCantCuotas;
                    this.conCantVtos = conCantVtos;
                    this.conMesInicio = conMesInicio;
                    this.conValorSeleccionado = conValorSeleccionado;
                    this.conRecargoVtoAbierto = conRecargoVtoAbierto;
                    this.conTieneVtoAbierto = conTieneVtoAbierto;
                    this.conNotas = conNotas;
                    this.conInteresMensual = conInteresMensual;
                    this.conActivo = conActivo;
                    this.conFechaHoraCreacion = conFechaHoraCreacion;
                    this.conFechaHoraUltimaModificacion = conFechaHoraUltimaModificacion;
                    this.insId = insId;
                    this.cntId = cntId;
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


            public DataTable ObtenerBuscador(String ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(String PrimerItem, int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
   public DataTable ObtenerListaxConxAnio(String PrimerItem, int insId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerListaxConxAnio]", new object[,] { { "@PrimerItem", PrimerItem }, { "@insId", insId } , { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaPorUnTipoConcepto(String PrimerItem, int inst, Int32 ConId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerListaPorUnTipoConcepto]", new object[,] { { "@PrimerItem", PrimerItem },{ "@inst", inst }, { "@ConId", ConId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxConIdxAnio(Int32 ConId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerUnoxConIdxAnio]", new object[,] { { "@ConId", ConId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxInsxcntIdxAnio(int insId, Int32 cntId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerUnoxInsxcntIdxAnio]", new object[,] { { "@insId", insId }, { "@cntId", cntId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoBuscarxNombre(String Nombre, int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
    public DataTable ObtenerTodoBuscarxNombrexAnio( int insId, String Nombre, String Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerTodoBuscarxNombrexAnio]", new object[,] { { "@insId", insId }, { "@Nombre", Nombre },  { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 conId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerUno]", new object[,] { { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaPorUnTipoConcepto(Int32 conId, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerListaPorUnTipoConcepto]", new object[,] { { "@conId", conId }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerValidarRepetido(Int32 conId, String conNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Conceptos.ObtenerValidarRepetido]", new object[,] { { "@conId", conId }, { "@conNombre", conNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 conId, String conNombre, Int32 insId, Int32 cntId, Int32 conAnioLectivo, Decimal conImporte, Int32 conCantCuotas, Int32 conCantVtos, Int32 conMesInicio, Int32 conValorSeleccionado, Decimal conRecargoVtoAbierto, Boolean conTieneVtoAbierto, String conNotas, Decimal conInteresMensual, Boolean conActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Conceptos.Actualizar]", new object[,] { { "@conId", conId }, { "@conNombre", conNombre }, { "@insId", insId }, { "@cntId", cntId }, { "@conAnioLectivo", conAnioLectivo }, { "@conImporte", conImporte }, { "@conCantCuotas", conCantCuotas }, { "@conCantVtos", conCantVtos }, { "@conMesInicio", conMesInicio }, { "@conValorSeleccionado", conValorSeleccionado }, { "@conRecargoVtoAbierto", conRecargoVtoAbierto }, { "@conTieneVtoAbierto", conTieneVtoAbierto }, { "@conNotas", conNotas }, { "@conInteresMensual", conInteresMensual }, { "@conActivo", conActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@conFechaHoraCreacion", conFechaHoraCreacion }, { "@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(String conNombre, Int32 insId, Int32 cntId, Int32 conAnioLectivo, Decimal conImporte, Int32 conCantCuotas, Int32 conCantVtos, Int32 conMesInicio, Int32 conValorSeleccionado, Decimal conRecargoVtoAbierto, Boolean conTieneVtoAbierto, String conNotas, Decimal conInteresMensual, Boolean conActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Conceptos.Copiar]", new object[,] { { "@conNombre", conNombre }, { "@insId", insId }, { "@cntId", cntId }, { "@conAnioLectivo", conAnioLectivo }, { "@conImporte", conImporte }, { "@conCantCuotas", conCantCuotas }, { "@conCantVtos", conCantVtos }, { "@conMesInicio", conMesInicio }, { "@conValorSeleccionado", conValorSeleccionado } ,{ "@conRecargoVtoAbierto", conRecargoVtoAbierto }, { "@conTieneVtoAbierto", conTieneVtoAbierto }, { "@conNotas", conNotas }, { "@conInteresMensual", conInteresMensual }, { "@conActivo", conActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@conFechaHoraCreacion", conFechaHoraCreacion }, { "@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 conId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Conceptos.Eliminar]", new object[,] { { "@conId", conId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String conNombre, Int32 insId, Int32 cntId, Int32 conAnioLectivo, Decimal conImporte, Int32 conCantCuotas, Int32 conCantVtos, Int32 conMesInicio, Int32 conValorSeleccionado, Decimal conRecargoVtoAbierto, Boolean conTieneVtoAbierto, String conNotas, Decimal conInteresMensual, Boolean conActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Conceptos.Insertar]", new object[,] { { "@conNombre", conNombre }, { "@insId", insId }, { "@cntId", cntId }, { "@conAnioLectivo", conAnioLectivo }, { "@conImporte", conImporte }, { "@conCantCuotas", conCantCuotas }, { "@conCantVtos", conCantVtos }, { "@conMesInicio", conMesInicio }, { "@conValorSeleccionado", conValorSeleccionado }, { "@conRecargoVtoAbierto", conRecargoVtoAbierto }, { "@conTieneVtoAbierto", conTieneVtoAbierto }, { "@conNotas", conNotas }, { "@conInteresMensual", conInteresMensual }, { "@conActivo", conActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@conFechaHoraCreacion", conFechaHoraCreacion }, { "@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion } });
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
                    if (this.conId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Conceptos.Actualizar]", new object[,] { { "@conId", conId }, { "@conNombre", conNombre }, { "@insId", insId }, { "@cntId", cntId }, { "@conAnioLectivo", conAnioLectivo }, { "@conImporte", conImporte }, { "@conCantCuotas", conCantCuotas }, { "@conCantVtos", conCantVtos }, { "@conMesInicio", conMesInicio },  { "@conValorSeleccionado", conValorSeleccionado },{ "@conRecargoVtoAbierto", conRecargoVtoAbierto }, { "@conTieneVtoAbierto", conTieneVtoAbierto }, { "@conNotas", conNotas }, { "@conInteresMensual", conInteresMensual }, { "@conActivo", conActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@conFechaHoraCreacion", conFechaHoraCreacion }, { "@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar()
            {
                try
                {
                    if (this.conId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Conceptos.Copiar]", new object[,] { { "@conNombre", conNombre }, { "@insId", insId }, { "@cntId", cntId }, { "@conAnioLectivo", conAnioLectivo }, { "@conImporte", conImporte }, { "@conCantCuotas", conCantCuotas }, { "@conCantVtos", conCantVtos }, { "@conMesInicio", conMesInicio }, { "@conValorSeleccionado", conValorSeleccionado }, { "@conRecargoVtoAbierto", conRecargoVtoAbierto }, { "@conTieneVtoAbierto", conTieneVtoAbierto }, { "@conNotas", conNotas }, { "@conInteresMensual", conInteresMensual }, { "@conActivo", conActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@conFechaHoraCreacion", conFechaHoraCreacion }, { "@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion } });
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
                    if (this.conId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Conceptos.Eliminar]", new object[,] { { "@conId", conId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Conceptos.Insertar]", new object[,] { { "@conNombre", conNombre }, { "@insId", insId }, { "@cntId", cntId }, { "@conAnioLectivo", conAnioLectivo }, { "@conImporte", conImporte }, { "@conCantCuotas", conCantCuotas }, { "@conCantVtos", conCantVtos }, { "@conMesInicio", conMesInicio }, { "@conValorSeleccionado", conValorSeleccionado }, { "@conRecargoVtoAbierto", conRecargoVtoAbierto }, { "@conTieneVtoAbierto", conTieneVtoAbierto }, { "@conNotas", conNotas }, { "@conInteresMensual", conInteresMensual }, { "@conActivo", conActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@conFechaHoraCreacion", conFechaHoraCreacion }, { "@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion } });
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