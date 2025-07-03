using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class CondicionParametrosFijos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades
            private Int32 _cpfId;
            public Int32 cpfId { get { return _cpfId; } set { _cpfId = value; } }

            private Int32 _fodId;
            public Int32 fodId { get { return _fodId; } set { _fodId = value; } }

            private Int32 _regId;
            public Int32 regId { get { return _regId; } set { _regId = value; } }

            private Int32 _cpfCantParciales;
            public Int32 cpfCantParciales { get { return _cpfCantParciales; } set { _cpfCantParciales = value; } }

            private Int32 _cpfCantRecParciales;
            public Int32 cpfCantRecParciales { get { return _cpfCantRecParciales; } set { _cpfCantRecParciales = value; } }

            private Int32 _cpfCantTP;
            public Int32 cpfCantTP { get { return _cpfCantTP; } set { _cpfCantTP = value; } }

            private Int32 _cpfCantRTP;
            public Int32 cpfCantRTP { get { return _cpfCantRTP; } set { _cpfCantRTP = value; } }

            private Int32 _cpfRecAsistencia;
            public Int32 cpfRecAsistencia { get { return _cpfRecAsistencia; } set { _cpfRecAsistencia = value; } }

            private Int32 _cpfCantColoquio;
            public Int32 cpfCantColoquio { get { return _cpfCantColoquio; } set { _cpfCantColoquio = value; } }

            private Int32 _cpfCantRecColoquio;
            public Int32 cpfCantRecColoquio { get { return _cpfCantRecColoquio; } set { _cpfCantRecColoquio = value; } }

            private Int32 _cpfAnioCursado;
            public Int32 cpfAnioCursado { get { return _cpfAnioCursado; } set { _cpfAnioCursado = value; } }

            private DateTime _cpfFechaHoraCreacion;
            public DateTime cpfFechaHoraCreacion { get { return _cpfFechaHoraCreacion; } set { _cpfFechaHoraCreacion = value; } }

            private DateTime _cpfFechaHoraUltimaModificacion;
            public DateTime cpfFechaHoraUltimaModificacion { get { return _cpfFechaHoraUltimaModificacion; } set { _cpfFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public CondicionParametrosFijos() { try { this.cpfId = 0; } catch (Exception oError) { throw oError; } }

            public CondicionParametrosFijos(Int32 cpfId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[CondicionParametrosFijos.ObtenerUno]", new object[,] { { "@cpfId", cpfId } });

                    if (Fila.Rows.Count > 0)
                    {

                        if (Fila.Rows[0]["cpfId"].ToString().Trim().Length > 0)
                        {
                            this.cpfId = Convert.ToInt32(Fila.Rows[0]["cpfId"]);
                        }
                        else
                        {
                            this.cpfId = 0;
                        }

                        if (Fila.Rows[0]["fodId"].ToString().Trim().Length > 0)
                        {
                            this.fodId = Convert.ToInt32(Fila.Rows[0]["fodId"]);
                        }
                        else
                        {
                            this.fodId = 0;
                        }
                        if (Fila.Rows[0]["regId"].ToString().Trim().Length > 0)
                        {
                            this.regId = Convert.ToInt32(Fila.Rows[0]["regId"]);
                        }
                        else
                        {
                            this.regId = 0;
                        }
                        if (Fila.Rows[0]["cpfCantParciales"].ToString().Trim().Length > 0)
                        {
                            this.cpfCantParciales = Convert.ToInt32(Fila.Rows[0]["cpfCantParciales"]);
                        }
                        else
                        {
                            this.cpfCantParciales = 0;
                        }

                        if (Fila.Rows[0]["cpfCantRecParciales"].ToString().Trim().Length > 0)
                        {
                            this.cpfCantRecParciales = Convert.ToInt32(Fila.Rows[0]["cpfCantRecParciales"]);
                        }
                        else
                        {
                            this.cpfCantRecParciales = 0;
                        }

                        if (Fila.Rows[0]["cpfCantTP"].ToString().Trim().Length > 0)
                        {
                            this.cpfCantTP = Convert.ToInt32(Fila.Rows[0]["cpfCantTP"]);
                        }
                        else
                        {
                            this.cpfCantTP = 0;
                        }

                        if (Fila.Rows[0]["cpfCantRTP"].ToString().Trim().Length > 0)
                        {
                            this.cpfCantRTP = Convert.ToInt32(Fila.Rows[0]["cpfCantRTP"]);
                        }
                        else
                        {
                            this.cpfCantRTP = 0;
                        }
                        if (Fila.Rows[0]["cpfRecAsistencia"].ToString().Trim().Length > 0)
                        {
                            this.cpfRecAsistencia = Convert.ToInt32(Fila.Rows[0]["cpfRecAsistencia"]);
                        }
                        else
                        {
                            this.cpfRecAsistencia = 0;
                        }

                        if (Fila.Rows[0]["cpfCantColoquio"].ToString().Trim().Length > 0)
                        {
                            this.cpfCantColoquio = Convert.ToInt32(Fila.Rows[0]["cpfCantColoquio"]);
                        }
                        else
                        {
                            this.cpfCantColoquio = 0;
                        }

                        if (Fila.Rows[0]["cpfCantRecColoquio"].ToString().Trim().Length > 0)
                        {
                            this.cpfCantRecColoquio = Convert.ToInt32(Fila.Rows[0]["cpfCantRecColoquio"]);
                        }
                        else
                        {
                            this.cpfCantRecColoquio = 0;
                        }

    if (Fila.Rows[0]["cpfAnioCursado"].ToString().Trim().Length > 0)
                        {
                            this.cpfAnioCursado = Convert.ToInt32(Fila.Rows[0]["cpfAnioCursado"]);
                        }
                        else
                        {
                            this.cpfAnioCursado = 0;
                        }

                        if (Fila.Rows[0]["cpfFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cpfFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cpfFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cpfFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cpfFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cpfFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cpfFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cpfFechaHoraUltimaModificacion = DateTime.Now;
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

            public CondicionParametrosFijos(Int32 cpfId, Int32 regId, Int32 cdnId, Int32 cpfCantParciales, Int32 cpfCantRecParciales, Int32 cpfCantTP, Int32 cpfCantRTP,
            int cpfRecAsistencia, int cpfCantColoquio, int cpfCantRecColoquio, DateTime cpfFechaHoraCreacion, DateTime cpfFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.cpfId = cpfId;
                    this.fodId = fodId;
                    this.regId = regId;
                    this.cpfCantParciales = cpfCantParciales;
                    this.cpfCantRecParciales = cpfCantRecParciales;
                    this.cpfCantTP = cpfCantTP;
                    this.cpfCantRTP = cpfCantRTP;
                    this.cpfRecAsistencia = cpfRecAsistencia;
                    this.cpfCantColoquio = cpfCantColoquio;
                    this.cpfCantRecColoquio = cpfCantRecColoquio;
 this.cpfAnioCursado = cpfAnioCursado;
                    this.cpfFechaHoraCreacion = cpfFechaHoraCreacion;
                    this.cpfFechaHoraUltimaModificacion = cpfFechaHoraUltimaModificacion;
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


            public DataTable ObtenerTodoxNombre(String Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametrosFijos.ObtenerTodoxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerunoxFDxRegimen(int fodId, int regId, Int32 cpfAnioCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametrosFijos.ObtenerunoxFDxRegimen]", new object[,] { { "@fodId", fodId }, { "@regId", regId }, { "@cpfAnioCursado", cpfAnioCursado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametrosFijos.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerUno(Int32 cpfId, Int32 cpfAnioCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametrosFijos.ObtenerUno]", new object[,] { { "@cpfId", cpfId },{ "@cpfAnioCursado", cpfAnioCursado }  });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
   public DataTable ObtenerTodoxAnio(Int32 cpfAnioCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametrosFijos.ObtenerTodoxAnio]", new object[,] { { "@cpfAnioCursado", cpfAnioCursado }  });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }




            //public void Eliminar(Int32 cdnId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Condicion.Eliminar]", new object[,] { { "@cdnId", cdnId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            protected void btnAplicar_Click(object sender, EventArgs e)
            {
                //GrillaCargar(Grilla.PageIndex);
            }

            public void InsertarNewAnio (Int32 NewAnio, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cpfFechaHoraCreacion, DateTime cpfFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CondicionParametrosFijos.InsertarNewAnio]", new object[,] { { "@NewAnio", NewAnio }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@cpfFechaHoraCreacion", cpfFechaHoraCreacion }, { "@cpfFechaHoraUltimaModificacion", cpfFechaHoraUltimaModificacion } });
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
                    if (this.cpfId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CondicionParametrosFijos.Actualizar]", new object[,] {{ "@cpfId", cpfId },{ "@fodId", fodId },
                            { "@regId", regId },    { "@cpfCantParciales", cpfCantParciales },  { "@cpfCantRecParciales", cpfCantRecParciales },
                            { "@cpfCantTP", cpfCantTP },  { "@cpfCantRTP", cpfCantRTP },  { "@cpfRecAsistencia", cpfRecAsistencia }, { "@cpfCantColoquio", cpfCantColoquio }, { "@cpfCantRecColoquio", cpfCantRecColoquio },
                         { "@cpfAnioCursado", cpfAnioCursado },    { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                          { "@cpfFechaHoraCreacion", cpfFechaHoraCreacion }, { "@cpfFechaHoraUltimaModificacion", cpfFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }



            //public void Eliminar()
            //{
            //    try
            //    {
            //        if (this.cdnId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[CondicionParametros.Eliminar]", new object[,] { { "@cpmId", cpmId } });
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
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[CondicionParametros.Insertar]", new object[,] { { "@fodId", fodId },{ "@cdnId", cdnId },   { "@cpmCantParciales", cpmCantParciales },   { "@cpmCantRecParciales", cpmCantRecParciales }, 
            //            { "@cpmCantTP", cpmCantTP },   { "@cpmCantRTP", cpmCantRTP },
            //            { "@cpmAsistencia", cpmAsistencia }, { "@cpmAsistenciaRec", cpmAsistenciaRec },
            //              { "@cpmPracticasAprob", cpmPracticasAprob }, { "@cpmNota", cpmNota },  { "@cpmActivo", cpmActivo },
            //              { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
            //              { "@cpmFechaHoraCreacion", cpmFechaHoraCreacion }, { "@cpmFechaHoraUltimaModificacion", cpmFechaHoraUltimaModificacion } });
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