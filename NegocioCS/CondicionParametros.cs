using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class CondicionParametros
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades
            private Int32 _cpmId;
            public Int32 cpmId { get { return _cpmId; } set { _cpmId = value; } }

            private Int32 _fodId;
            public Int32 fodId { get { return _fodId; } set { _fodId = value; } }

            private Int32 _cdnId;
            public Int32 cdnId { get { return _cdnId; } set { _cdnId = value; } }

            private String _cpmAsistencia;
            public String cpmAsistencia { get { return _cpmAsistencia; } set { _cpmAsistencia = value; } }


            private String _cpmAsistenciaRec;
            public String cpmAsistenciaRec { get { return _cpmAsistenciaRec; } set { _cpmAsistenciaRec = value; } }

            private String _cpmPracticasAprob;
            public String cpmPracticasAprob { get { return _cpmPracticasAprob; } set { _cpmPracticasAprob = value; } }

            private String _cpmNota;
            public String cpmNota { get { return _cpmNota; } set { _cpmNota = value; } }

            private String _cpmNotaColoquio;
            public String cpmNotaColoquio { get { return _cpmNotaColoquio; } set { _cpmNotaColoquio = value; } }

            private Int32 _cpmAnioCursado;
            public Int32 cpmAnioCursado { get { return _cpmAnioCursado; } set { _cpmAnioCursado = value; } }

            private Boolean _cpmActivo;
            public Boolean cpmActivo { get { return _cpmActivo; } set { _cpmActivo = value; } }

            private DateTime _cpmFechaHoraCreacion;
            public DateTime cpmFechaHoraCreacion { get { return _cpmFechaHoraCreacion; } set { _cpmFechaHoraCreacion = value; } }

            private DateTime _cpmFechaHoraUltimaModificacion;
            public DateTime cpmFechaHoraUltimaModificacion { get { return _cpmFechaHoraUltimaModificacion; } set { _cpmFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public CondicionParametros() { try { this.cpmId = 0; } catch (Exception oError) { throw oError; } }

            public CondicionParametros(Int32 cpmId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[CondicionParametros.ObtenerUno]", new object[,] { { "@cpmId", cpmId } });

                    if (Fila.Rows.Count > 0)
                    {

                        if (Fila.Rows[0]["cpmId"].ToString().Trim().Length > 0)
                        {
                            this.cpmId = Convert.ToInt32(Fila.Rows[0]["cpmId"]);
                        }
                        else
                        {
                            this.cpmId = 0;
                        }
                        if (Fila.Rows[0]["fodId"].ToString().Trim().Length > 0)
                        {
                            this.fodId = Convert.ToInt32(Fila.Rows[0]["fodId"]);
                        }
                        else
                        {
                            this.fodId = 0;
                        }
                        if (Fila.Rows[0]["cdnId"].ToString().Trim().Length > 0)
                        {
                            this.cdnId = Convert.ToInt32(Fila.Rows[0]["cdnId"]);
                        }
                        else
                        {
                            this.cdnId = 0;
                        }

                        if (Fila.Rows[0]["cpmAsistencia"].ToString().Trim().Length > 0)
                        {
                            this.cpmAsistencia = Convert.ToString(Fila.Rows[0]["cpmAsistencia"]);
                        }
                        else
                        {
                            this.cpmAsistencia = "";
                        }

                        if (Fila.Rows[0]["cpmAsistenciaRec"].ToString().Trim().Length > 0)
                        {
                            this.cpmAsistenciaRec = Convert.ToString(Fila.Rows[0]["cpmAsistenciaRec"]);
                        }
                        else
                        {
                            this.cpmAsistenciaRec = "";
                        }

                        if (Fila.Rows[0]["cpmPracticasAprob"].ToString().Trim().Length > 0)
                        {
                            this.cpmPracticasAprob = Convert.ToString(Fila.Rows[0]["cpmPracticasAprob"]);
                        }
                        else
                        {
                            this.cpmPracticasAprob = "";
                        }


                        if (Fila.Rows[0]["cpmNota"].ToString().Trim().Length > 0)
                        {
                            this.cpmNota = Convert.ToString(Fila.Rows[0]["cpmNota"]);
                        }
                        else
                        {
                            this.cpmNota = "";
                        }
                        if (Fila.Rows[0]["cpmNotaColoquio"].ToString().Trim().Length > 0)
                        {
                            this.cpmNotaColoquio = Convert.ToString(Fila.Rows[0]["cpmNotaColoquio"]);
                        }
                        else
                        {
                            this.cpmNotaColoquio = "";
                        }
                        if (Fila.Rows[0]["cpmFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cpmFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cpmFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cpmFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cpmFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cpmFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cpmFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cpmFechaHoraUltimaModificacion = DateTime.Now;
                        }
                        if (Fila.Rows[0]["cpmAnioCursado"].ToString().Trim().Length > 0)
                        {
                            this.cpmAnioCursado = Convert.ToInt32(Fila.Rows[0]["cpmAnioCursado"]);
                        }
                        else
                        {
                            this.cpmAnioCursado = 0;
                        }

                        if (Fila.Rows[0]["cpmActivo"].ToString().Trim().Length > 0)
                        {
                            this.cpmActivo = (Convert.ToInt32(Fila.Rows[0]["cpmActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.cpmActivo = false;
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

            public CondicionParametros(Int32 cpmId, Int32 fodId, Int32 cdnId, String cpmAsistencia, String cpmAsistenciaRec, String cpmPracticasAprob, String cpmNota, Boolean cpmActivo, DateTime cpmFechaHoraCreacion, DateTime cpmFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.cpmId = cpmId;
                    this.fodId = fodId;
                    this.cdnId = cdnId;
                    this.cpmAsistencia = cpmAsistencia;
                    this.cpmAsistenciaRec = cpmAsistenciaRec;
                    this.cpmPracticasAprob = cpmPracticasAprob;
                    this.cpmNota = cpmNota;
                    this.cpmAnioCursado = cpmAnioCursado;
                    this.cpmActivo = cpmActivo;                 
                    this.cpmFechaHoraCreacion = cpmFechaHoraCreacion;
                    this.cpmFechaHoraUltimaModificacion = cpmFechaHoraUltimaModificacion;
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


            public DataTable ObtenerunoxFD(Int32 fodId, Int32 cpmAnioCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametros.ObtenerunoxFD]", new object[,] { { "@fodId", fodId }, { "@cpmAnioCursado", cpmAnioCursado } });
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

            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}



            public DataTable ObtenerUno(Int32 cpmId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametros.ObtenerUno]", new object[,] { { "@cpmId", cpmId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTodoBuscarxNombre(String Nombre, Int32 cpmAnioCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametros.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } ,{ "@cpmAnioCursado", cpmAnioCursado } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
    public DataTable ObtenerTodoBuscarxAnio( Int32 cpmAnioCursado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[CondicionParametros.ObtenerTodoBuscarxAnio]", new object[,] { { "@cpmAnioCursado", cpmAnioCursado } });
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


            public void Actualizar()
            {
                try
                {
                    if (this.cpmId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CondicionParametros.Actualizar]", new object[,] {{ "@cpmId", cpmId },{ "@fodId", fodId },
                            { "@cdnId", cdnId },  { "@cpmAsistencia", cpmAsistencia }, { "@cpmAsistenciaRec", cpmAsistenciaRec },
                          { "@cpmPracticasAprob", cpmPracticasAprob }, { "@cpmNota", cpmNota }, { "@cpmNotaColoquio", cpmNotaColoquio },   { "@cpmAnioCursado", cpmAnioCursado },{ "@cpmActivo", cpmActivo },
                          { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                          { "@cpmFechaHoraCreacion", cpmFechaHoraCreacion }, { "@cpmFechaHoraUltimaModificacion", cpmFechaHoraUltimaModificacion } });
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
                    if (this.cdnId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[CondicionParametros.Eliminar]", new object[,] { { "@cpmId", cpmId } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
  public void InsertarNewAnio( Int32 AnioCursado, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime cpmFechaHoraCreacion, DateTime cpmFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[CondicionParametros.InsertarNewAnio]", new object[,] { { "@AnioCursado", AnioCursado }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@cpmFechaHoraCreacion", cpmFechaHoraCreacion }, { "@cpmFechaHoraUltimaModificacion", cpmFechaHoraUltimaModificacion } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[CondicionParametros.Insertar]", new object[,] { { "@fodId", fodId },{ "@cdnId", cdnId },
              { "@cpmAsistencia", cpmAsistencia }, { "@cpmAsistenciaRec", cpmAsistenciaRec },
                          { "@cpmPracticasAprob", cpmPracticasAprob }, { "@cpmNota", cpmNota },{ "@cpmNotaColoquio", cpmNotaColoquio },{ "@cpmAnioCursado", cpmAnioCursado },  { "@cpmActivo", cpmActivo },
                          { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                          { "@cpmFechaHoraCreacion", cpmFechaHoraCreacion }, { "@cpmFechaHoraUltimaModificacion", cpmFechaHoraUltimaModificacion } });
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