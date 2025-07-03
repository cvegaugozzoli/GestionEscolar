
using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class LibroDisciplina
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _lddId;
            public Int32 lddId { get { return _lddId; } set { _lddId = value; } }

            private Int32 _aluId;
            public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

            private Int32 _icuId;
            public Int32 icuId { get { return _icuId; } set { _icuId = value; } }

            private Int32 _tsaId;
            public Int32 tsaId { get { return _tsaId; } set { _tsaId = value; } }


            private Int32 _lddAnioLectivo;
            public Int32 lddAnioLectivo { get { return _lddAnioLectivo; } set { _lddAnioLectivo = value; } }

            private Int32 _lddCant;
            public Int32 lddCant { get { return _lddCant; } set { _lddCant = value; } }

            private String _lddObservacion;
            public String lddObservacion { get { return _lddObservacion; } set { _lddObservacion = value; } }


            private String _lddCargo;
            public String lddCargo { get { return _lddCargo; } set { _lddCargo = value; } }

            private DateTime _lddFecha;
            public DateTime lddFecha { get { return _lddFecha; } set { _lddFecha = value; } }


            private DateTime _lddFechaHoraCreacion;
            public DateTime lddFechaHoraCreacion { get { return _lddFechaHoraCreacion; } set { _lddFechaHoraCreacion = value; } }

            private DateTime _lddFechaHoraUltimaModificacion;
            public DateTime lddFechaHoraUltimaModificacion { get { return _lddFechaHoraUltimaModificacion; } set { _lddFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public LibroDisciplina() { try { this.lddId = 0; } catch (Exception oError) { throw oError; } }

            public LibroDisciplina(Int32 lddId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[LibroDisciplina.ObtenerUno]", new object[,] { { "@lddId", lddId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["lddId"].ToString().Trim().Length > 0)
                        {
                            this.lddId = Convert.ToInt32(Fila.Rows[0]["lddId"]);
                        }
                        else
                        {
                            this.lddId = 0;
                        }
                        if (Fila.Rows[0]["aluId"].ToString().Trim().Length > 0)
                        {
                            this.aluId = Convert.ToInt32(Fila.Rows[0]["aluId"]);
                        }
                        else
                        {
                            this.aluId = 0;
                        }

                        if (Fila.Rows[0]["icuId"].ToString().Trim().Length > 0)
                        {
                            this.icuId = Convert.ToInt32(Fila.Rows[0]["icuId"]);
                        }
                        else
                        {
                            this.icuId = 0;
                        }

                        if (Fila.Rows[0]["tsaId"].ToString().Trim().Length > 0)
                        {
                            this.tsaId = Convert.ToInt32(Fila.Rows[0]["tsaId"]);
                        }
                        else
                        {
                            this.tsaId = 0;
                        }

                        if (Fila.Rows[0]["lddAnioLectivo"].ToString().Trim().Length > 0)
                        {
                            this.lddAnioLectivo = Convert.ToInt32(Fila.Rows[0]["lddAnioLectivo"]);
                        }
                        else
                        {
                            this.lddAnioLectivo = 0;
                        }

                        if (Fila.Rows[0]["lddCant"].ToString().Trim().Length > 0)
                        {
                            this.lddCant = Convert.ToInt32(Fila.Rows[0]["lddCant"]);
                        }
                        else
                        {
                            this.lddCant = 0;
                        }


                        if (Fila.Rows[0]["lddObservacion"].ToString().Trim().Length > 0)
                        {
                            this.lddObservacion = Convert.ToString(Fila.Rows[0]["lddObservacion"]);
                        }
                        else
                        {
                            this.lddObservacion = "";
                        }

                        if (Fila.Rows[0]["lddCargo"].ToString().Trim().Length > 0)
                        {
                            this.lddCargo = Convert.ToString(Fila.Rows[0]["lddCargo"]);
                        }
                        else
                        {
                            this.lddCargo = "";
                        }

                        if (Fila.Rows[0]["lddFecha"].ToString().Trim().Length > 0)
                        {
                            this.lddFecha = Convert.ToDateTime(Fila.Rows[0]["lddFecha"]);
                        }
                        else
                        {
                            this.lddFecha = DateTime.Now;
                        }

                        if (Fila.Rows[0]["lldFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.lddFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["lddFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.lddFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["lddFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.lddFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["lddFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.lddFechaHoraUltimaModificacion = DateTime.Now;
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

            public LibroDisciplina(Int32 lddId, Int32 aluId, Int32 icuId, Int32 tsaId, Int32 lddAnioLectivo, Int32 lddCant, String lddObservacion, String lddCargo, DateTime lddFecha, DateTime lddFechaHoraCreacion, DateTime lddFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.lddId = lddId;
                    this.aluId = aluId;
                    this.icuId = icuId;
                    this.tsaId = tsaId;
                    this.lddAnioLectivo = lddAnioLectivo;
                    this.lddCant = lddCant;
                    this.lddObservacion = lddObservacion;
                    this.lddCargo = lddCargo;
                    this.lddFecha = lddFecha;
                    this.lddFechaHoraCreacion = lddFechaHoraCreacion;
                    this.lddFechaHoraUltimaModificacion = lddFechaHoraUltimaModificacion;
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


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
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
            //        Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerTodoxaluId(int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LibroDisciplina.ObtenerTodoxaluId]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerUno(Int32 tcaId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerUno]", new object[,] { { "@tcaId", tcaId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerValidarRepetido(Int32 tcaId, String tcaNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerValidarRepetido]", new object[,] { { "@tcaId", tcaId }, { "@tcaNombre", tcaNombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 sexId, String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Copiar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Eliminar(Int32 sexId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            public void Insertar(Int32 aluId, Int32 curId, Int32 tsaId, Int32 lldAnioLectivo, Int32 lddCant,  String Solicitante, String lddCargo, DateTime? lddFecha, String lddObservacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime lddFechaHoraCreacion, DateTime lddFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LibroDisciplina.Insertar]", new object[,] { { "@aluId", aluId }, { "@curId", curId }, { "@tsaId", tsaId }, { "@lldAnioLectivo", lldAnioLectivo }, { "@lddCant", lddCant },  { "@Solicitante", Solicitante }, { "@lddCargo", lddCargo }, { "@lddFecha", lddFecha }, { "@lddObservacion", lddObservacion }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@lddFechaHoraCreacion", lddFechaHoraCreacion }, { "@lddFechaHoraUltimaModificacion", lddFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public void Actualizar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}



            public void Eliminar(int lddId)
            {
                try
                {
                    if (this.lddId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[LibroDisciplina.Eliminar]", new object[,] { { "@lddId", lddId } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public Int32 Insertar()
            //{
            //    Int32 IdMax;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Sexo.Insertar]", new object[,] { { "@sexNombre", sexNombre }, { "@sexActivo", sexActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@sexFechaHoraCreacion", sexFechaHoraCreacion }, { "@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion } });
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




