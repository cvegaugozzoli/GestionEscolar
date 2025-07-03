using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class EspCurrEvaluacion
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _eceId;
            public Int32 eceId { get { return _eceId; } set { _eceId = value; } }

            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private String _eceNombre;
            public String eceNombre { get { return _eceNombre; } set { _eceNombre = value; } }

            private Int32 _treId;
            public Int32 treId { get { return _treId; } set { _treId = value; } }

            private String _eceDescripcion;
            public String eceDescripcion { get { return _eceDescripcion; } set { _eceDescripcion = value; } }

            private Int32 _eceAnioCur;
            public Int32 eceAnioCur { get { return _eceAnioCur; } set { _eceAnioCur = value; } }

            private Boolean _eceActivo;
            public Boolean eceActivo { get { return _eceActivo; } set { _eceActivo = value; } }

            private DateTime _eceFechaHoraCreacion;
            public DateTime eceFechaHoraCreacion { get { return _eceFechaHoraCreacion; } set { _eceFechaHoraCreacion = value; } }

            private DateTime _eceFechaHoraUltimaModificacion;
            public DateTime eceFechaHoraUltimaModificacion { get { return _eceFechaHoraUltimaModificacion; } set { _eceFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public EspCurrEvaluacion() { try { this.eceId = 0; } catch (Exception oError) { throw oError; } }

            public EspCurrEvaluacion(Int32 eceId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerUno]", new object[,] { { "@eceId", eceId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["eceId"].ToString().Trim().Length > 0)
                        {
                            this.eceId = Convert.ToInt32(Fila.Rows[0]["eceId"]);
                        }
                        else
                        {
                            this.eceId = 0;
                        }
                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
                        }
                        if (Fila.Rows[0]["eceNombre"].ToString().Trim().Length > 0)
                        {
                            this.eceNombre = Convert.ToString(Fila.Rows[0]["eceNombre"]);
                        }
                        else
                        {
                            this.eceNombre = "";
                        }
                        if (Fila.Rows[0]["eceDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.eceDescripcion = Convert.ToString(Fila.Rows[0]["eceDescripcion"]);
                        }
                        else
                        {
                            this.eceDescripcion = "";
                        }
                        if (Fila.Rows[0]["treId"].ToString().Trim().Length > 0)
                        {
                            this.treId = Convert.ToInt32(Fila.Rows[0]["treId"]);
                        }
                        else
                        {
                            this.treId = 0;
                        }

                        if (Fila.Rows[0]["eceAnioCur"].ToString().Trim().Length > 0)
                        {
                            this.eceAnioCur = Convert.ToInt32(Fila.Rows[0]["eceAnioCur"]);
                        }
                        else
                        {
                            this.eceAnioCur = 0;
                        }

                        if (Fila.Rows[0]["eceFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.eceFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["eceFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.eceFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["eceFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.eceFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["eceFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.eceFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["eceActivo"].ToString().Trim().Length > 0)
                        {
                            this.eceActivo = (Convert.ToInt32(Fila.Rows[0]["eceActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.eceActivo = false;
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

            //public Bancos(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.banId = banId;
            //        this.banCodigo = banCodigo;
            //        this.banNombre = banNombre;
            //        this.banSucursal = banSucursal;
            //        this.banActivo = banActivo;
            //        this.banFechaHoraCreacion = banFechaHoraCreacion;
            //        this.banFechaHoraUltimaModificacion = banFechaHoraUltimaModificacion;
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


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerListaxescId(String PrimerItem, Int32 escId,Int32 eceAnioCur)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerListaxescId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@escId", escId } , { "@eceAnioCur", eceAnioCur } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaAnio(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerListaAnio]", new object[,] { { "@PrimerItem", PrimerItem }});
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
                    Tabla = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoBuscarxescId(Int32 escId,Int32 eceAnioCur)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerTodoBuscarxescId]", new object[,] { { "@escId", escId }, { "@eceAnioCur", eceAnioCur } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 banId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerUno]", new object[,] { { "@eceId", eceId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

 public DataTable ObtenerTodoxAnio(Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspCurrEvaluacion.ObtenerTodoxAnio]", new object[,] { { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public void Actualizar(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Actualizar]", new object[,] { { "@banId", banId }, { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar(String banCodigo, String banNombre, String banSucursal, Boolean banActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Copiar]", new object[,] { { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void Eliminar(Int32 eceId, Int32 usuId, DateTime FechaModi )
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspCurrEvaluacion.Eliminar]", new object[,] { { "@eceId", eceId },{ "@usuId", usuId },{ "@FechaModi", FechaModi } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

          
            public void EliminarxEspCurr(Int32 escId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspCurrEvaluacion.EliminarxEspCurr]", new object[,] { { "@escId", escId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void InsertarNewAnio( Int32 AnioCursado, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime eceFechaHoraCreacion, DateTime eceFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspCurrEvaluacion.InsertarNewAnio]", new object[,] { { "@AnioCursado", AnioCursado }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@eceFechaHoraCreacion", eceFechaHoraCreacion }, { "@eceFechaHoraUltimaModificacion", eceFechaHoraUltimaModificacion } });
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
                    if (this.eceId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EspCurrEvaluacion.Actualizar]", new object[,] { { "@eceId", eceId },{ "@escId", escId }, { "@eceNombre", eceNombre },
                            { "@treId", treId }, { "@eceDescripcion", eceDescripcion }, { "@eceAnioCur", eceAnioCur }, { "@eceActivo", eceActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }
                            , { "@eceFechaHoraCreacion", eceFechaHoraCreacion }, { "@eceFechaHoraUltimaModificacion", eceFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public void Copiar()
            //{
            //    try
            //    {
            //        if (this.banId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Bancos.Copiar]", new object[,] { { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void Eliminar()
            {
                try
                {
                    if (this.eceId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EspCurrEvaluacion.Eliminar]", new object[,] { { "@eceId", eceId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[EspCurrEvaluacion.Insertar]", new object[,] {{ "@escId", escId }, { "@eceNombre", eceNombre },
                            { "@treId", treId }, { "@eceDescripcion", eceDescripcion },{ "@eceAnioCur", eceAnioCur } ,{ "@eceActivo", eceActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }
                            , { "@eceFechaHoraCreacion", eceFechaHoraCreacion }, { "@eceFechaHoraUltimaModificacion", eceFechaHoraUltimaModificacion } });
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