using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class RegistracionNota
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _renId;
            public Int32 renId { get { return _renId; } set { _renId = value; } }

            private Int32 _icuId;
            public Int32 icuId { get { return _icuId; } set { _icuId = value; } }

            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private String _renPCuat;
            public String renPCuat { get { return _renPCuat; } set { _renPCuat = value; } }

            private String _renSCuat;
            public String renSCuat { get { return _renSCuat; } set { _renSCuat = value; } }

            private String _renPTrim;
            public String renPTrim { get { return _renPTrim; } set { _renPTrim = value; } }

            private String _renSTrim;
            public String renSTrim { get { return _renSTrim; } set { _renSTrim = value; } }

            private String _renTTrim;
            public String renTTrim { get { return _renTTrim; } set { _renTTrim = value; } }

            private String _renDic;
            public String renDic { get { return _renDic; } set { _renDic = value; } }

            private String _renMar;
            public String renMar { get { return _renMar; } set { _renMar = value; } }

            private String _renCalfDef;
            public String renCalfDef { get { return _renCalfDef; } set { _renCalfDef = value; } }

            private String _renEvaluacionFinal;
            public String renEvaluacionFinal { get { return _renEvaluacionFinal; } set { _renEvaluacionFinal = value; } }


            private String _renObservaciones;
            public String renObservaciones { get { return _renObservaciones; } set { _renObservaciones = value; } }

            private DateTime _renFechaHoraCreacion;
            public DateTime renFechaHoraCreacion { get { return _renFechaHoraCreacion; } set { _renFechaHoraCreacion = value; } }

            private DateTime _renFechaHoraUltimaModificacion;
            public DateTime renFechaHoraUltimaModificacion { get { return _renFechaHoraUltimaModificacion; } set { _renFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public RegistracionNota() { try { this.renId = 0; } catch (Exception oError) { throw oError; } }

            public RegistracionNota(Int32 renId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerUno]", new object[,] { { "@renId", renId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["renId"].ToString().Trim().Length > 0)
                        {
                            this.renId = Convert.ToInt32(Fila.Rows[0]["renId"]);
                        }
                        else
                        {
                            this.renId = 0;
                        }


                        if (Fila.Rows[0]["icuId"].ToString().Trim().Length > 0)
                        {
                            this.icuId = Convert.ToInt32(Fila.Rows[0]["icuId"]);
                        }
                        else
                        {
                            this.icuId = 0;
                        }

                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
                        }

                        if (Fila.Rows[0]["renPCuat"].ToString().Trim().Length > 0)
                        {
                            this.renPCuat = Convert.ToString(Fila.Rows[0]["renPCuat"]);
                        }
                        else
                        {
                            this.renPCuat = "";
                        }

                        if (Fila.Rows[0]["renSCuat"].ToString().Trim().Length > 0)
                        {
                            this.renSCuat = Convert.ToString(Fila.Rows[0]["renSCuat"]);
                        }
                        else
                        {
                            this.renSCuat = "";
                        }

                        if (Fila.Rows[0]["renPTrim"].ToString().Trim().Length > 0)
                        {
                            this.renPTrim = Convert.ToString(Fila.Rows[0]["renPTrim"]);
                        }
                        else
                        {
                            this.renPTrim = "";
                        }

                        if (Fila.Rows[0]["renSTrim"].ToString().Trim().Length > 0)
                        {
                            this.renSTrim = Convert.ToString(Fila.Rows[0]["renSTrim"]);
                        }
                        else
                        {
                            this.renSTrim = "";
                        }

                        if (Fila.Rows[0]["renPTrim"].ToString().Trim().Length > 0)
                        {
                            this.renPTrim = Convert.ToString(Fila.Rows[0]["renPTrim"]);
                        }
                        else
                        {
                            this.renPTrim = "";
                        }

                        if (Fila.Rows[0]["renSTrim"].ToString().Trim().Length > 0)
                        {
                            this.renSTrim = Convert.ToString(Fila.Rows[0]["renSTrim"]);
                        }
                        else
                        {
                            this.renSTrim = "";
                        }

                        if (Fila.Rows[0]["renTTrim"].ToString().Trim().Length > 0)
                        {
                            this.renTTrim = Convert.ToString(Fila.Rows[0]["renTTrim"]);
                        }
                        else
                        {
                            this.renTTrim = "";
                        }

                        if (Fila.Rows[0]["renDic"].ToString().Trim().Length > 0)
                        {
                            this.renDic = Convert.ToString(Fila.Rows[0]["renDic"]);
                        }
                        else
                        {
                            this.renDic = "";
                        }

                        if (Fila.Rows[0]["renMar"].ToString().Trim().Length > 0)
                        {
                            this.renMar = Convert.ToString(Fila.Rows[0]["renMar"]);
                        }
                        else
                        {
                            this.renMar = "";
                        }

                        if (Fila.Rows[0]["renCalfDef"].ToString().Trim().Length > 0)
                        {
                            this.renCalfDef = Convert.ToString(Fila.Rows[0]["renCalfDef"]);
                        }
                        else
                        {
                            this.renCalfDef = "";
                        }

                        if (Fila.Rows[0]["renEvaluacionFinal"].ToString().Trim().Length > 0)
                        {
                            this.renEvaluacionFinal = Convert.ToString(Fila.Rows[0]["renEvaluacionFinal"]);
                        }
                        else
                        {
                            this.renEvaluacionFinal = "";
                        }
                        if (Fila.Rows[0]["renObservaciones"].ToString().Trim().Length > 0)
                        {
                            this.renObservaciones = Convert.ToString(Fila.Rows[0]["renObservaciones"]);
                        }
                        else
                        {
                            this.renObservaciones = "";
                        }

                        if (Fila.Rows[0]["renFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.renFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["renFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.renFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["renFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.renFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["renFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.renFechaHoraUltimaModificacion = DateTime.Now;
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

            public RegistracionNota(Int32 renId, Int32 icuId, Int32 escId, String renPCuat, String renSCuat, String renPTrim, String renSTrim, String renTTrim, String renDic, String renMar, String renCalfDef, String renEvaluacionFinal, String renObservaciones, DateTime renFechaHoraCreacion, DateTime renFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.renId = renId;
                    this.icuId = icuId;
                    this.escId = escId;
                    this.renPCuat = renPCuat;
                    this.renSCuat = renSCuat;
                    this.renPTrim = renPTrim;
                    this.renSTrim = renSTrim;
                    this.renTTrim = renTTrim;
                    this.renDic = renDic;
                    this.renMar = renMar;
                    this.renCalfDef = renCalfDef;
                    this.renEvaluacionFinal = renEvaluacionFinal;
                    this.renObservaciones = renObservaciones;
                    this.renFechaHoraCreacion = renFechaHoraCreacion;
                    this.renFechaHoraUltimaModificacion = renFechaHoraUltimaModificacion;
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


            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTodoporInscripcionCursado(Int32 icuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerTodoporInscripcionCursado]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoporCursoAnio(Int32 IdCur, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerTodoporCursoAnio]", new object[,] { { "@IdCur", IdCur }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoporEspCurricular(Int32 espId, Int32 curId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerTodoporEspCurricular]", new object[,] { { "@espId", espId }, { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoporEspCurricularAnio(Int32 espId, Int32 curId, Int32 anio, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerTodoporEspCurricularAnio]", new object[,] { { "@espId", espId }, { "@curId", curId }, { "@anio", anio }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoporInscripcionCursadoAnio(Int32 icuId, Int32 AnioCur)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerTodoporInscripcionCursadoAnio]", new object[,] { { "@icuId", icuId }, { "@AnioCur", AnioCur } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 renId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerUno]", new object[,] { { "@renId", renId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void AsignarNotaPriPT(Int32 renId, String renPTrim)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaPriPT]", new object[,] { { "@renId", renId }, { "@renPTrim", renPTrim } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void AsignarNotaPriST(Int32 renId, String renSTrim)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaPriST]", new object[,] { { "@renId", renId }, { "@renSTrim", renSTrim } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void AsignarNotaPriTT(Int32 renId, String renTTrim)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaPriTT]", new object[,] { { "@renId", renId }, { "@renTTrim", renTTrim } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void AsignarNotaSecPC(Int32 renId, String renPCuat)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaSecPC]", new object[,] { { "@renId", renId }, { "@renPCuat", renPCuat } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void AsignarNotaPromA(Int32 renId, String renPromA)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaPromA]", new object[,] { { "@renId", renId }, { "@renPromA", renPromA } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void AsignarNotaDic(Int32 renId, String renNotaDic)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaDic]", new object[,] { { "@renId", renId }, { "@renNotaDic", renNotaDic } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void AsignarNotaMar(Int32 renId, String renNotaMar)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaMar]", new object[,] { { "@renId", renId }, { "@renNotaMar", renNotaMar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void AsignarNotaCalDef(Int32 renId, String renCalDef)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaCalDef]", new object[,] { { "@renId", renId }, { "@renCalDef", renCalDef } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void AsignarNotaSecSC(Int32 renId, String renSCuat)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.AsignarNotaSecSC]", new object[,] { { "@renId", renId }, { "@renSCuat", renSCuat } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
  

            public void Actualizar(Int32 renId, Int32 icuId, Int32 escId, String renPCuat, String renSCuat, String renPTrim, String renSTrim, String renTTrim, String renDic, String renMar, String renCalfDef, String renEvaluacionFinal, String renObservaciones, DateTime renFechaHoraCreacion, DateTime renFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.Actualizar]", new object[,] { { "@renId", renId }, { "@icuId", icuId }, { "@escId", escId }, { "@renPCuat", renPCuat }, { "@renSCuat", renSCuat }, { "@renPTrim", renPTrim }, { "@renSTrim", renSTrim }, { "@renTTrim", renTTrim }, { "@renDic", renDic }, { "@renCalfDef", renCalfDef }, { "@renEvaluacionFinal", renEvaluacionFinal }, { "@renObservaciones", renObservaciones }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@renFechaHoraCreacion", renFechaHoraCreacion }, { "@renFechaHoraUltimaModificacion", renFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }



            public void Eliminar(Int32 renId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.Eliminar]", new object[,] { { "@renId", renId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void EliminarporIC(Int32 icuId, int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.EliminarporIC]", new object[,] { { "@icuId", icuId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void Insertar(Int32 icuId, Int32 escId, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime renFechaHoraCreacion, DateTime renFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNota.Insertar]", new object[,] { { "@icuId", icuId }, { "@escId", escId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@renFechaHoraCreacion", renFechaHoraCreacion }, { "@renFechaHoraUltimaModificacion", renFechaHoraUltimaModificacion }, });
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
                    if (this.renId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionNota.Actualizar]", new object[,] { { "@renId", renId }, { "@icuId", icuId }, { "@escId", escId }, { "@renPCuat", renPCuat }, { "@renSCuat", renSCuat }, { "@renPTrim", renPTrim }, { "@renSTrim", renSTrim }, { "@renTTrim", renTTrim }, { "@renDic", renDic }, { "@renCalfDef", renCalfDef }, { "@renEvaluacionFinal", renEvaluacionFinal }, { "@renObservaciones", renObservaciones }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@renFechaHoraCreacion", renFechaHoraCreacion }, { "@renFechaHoraUltimaModificacion", renFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void ActualizarPrimaria(Int32 renId, String PTrim, String STrim, String TTrim, String PAnual, String NotaDic, String NotaMar, String renCalfDef, DateTime renFechaHoraCreacion, DateTime renFechaHoraUltimaModificacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion)
            {
                try
                {
                    if (renId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionNota.ActualizarPrimaria]", new object[,] { { "@renId", renId }, { "@PCuatr", PTrim }, { "@SCuatr", STrim }, { "@TCuatr", TTrim }, { "@PAnual", PAnual }, { "@NotaDic", NotaDic }, { "@NotaMar", NotaMar }, { "@renCalfDef", renCalfDef }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@renFechaHoraCreacion", renFechaHoraCreacion }, { "@renFechaHoraUltimaModificacion", renFechaHoraUltimaModificacion } }); 
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void ActualizarSecundaria(Int32 renId, String PCuatr, String SCuatr, String PAnual, String NotaDic, String NotaMar, String renCalfDef, DateTime renFechaHoraCreacion, DateTime renFechaHoraUltimaModificacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion)
            {
                try
                {
                    if (renId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionNota.ActualizarSecundaria]", new object[,] { { "@renId", renId }, { "@PCuatr", PCuatr }, { "@SCuatr", SCuatr }, { "@PAnual", PAnual }, { "@NotaDic", NotaDic }, { "@NotaMar", NotaMar }, { "@renCalfDef", renCalfDef }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@renFechaHoraCreacion", renFechaHoraCreacion }, { "@renFechaHoraUltimaModificacion", renFechaHoraUltimaModificacion } });
          
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
                    if (this.renId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionNota.Eliminar]", new object[,] { { "@renId", renId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RegistracionNota.Insertar]", new object[,] { { "@icuId", icuId }, { "@escId", escId }, { "@renPCuat", renPCuat }, { "@renSCuat", renSCuat }, { "@renPTrim", renPTrim }, { "@renSTrim", renSTrim }, { "@renTTrim", renTTrim }, { "@renDic", renDic }, { "@renCalfDef", renCalfDef }, { "@renEvaluacionFinal", renEvaluacionFinal }, { "@renObservaciones", renObservaciones }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@renFechaHoraCreacion", renFechaHoraCreacion }, { "@renFechaHoraUltimaModificacion", renFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            //public void ActualizarCalificacionExamen(Int32 recId, Int32 icuId, Decimal recCalificacionExamen)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.ActualizarCalificacionExamen]", new object[,] { { "@recId", recId }, { "@icuId", icuId }, { "@recCalificacionExamen", recCalificacionExamen } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void ActualizarCalificacionExamen(Int32 icuId, Decimal recCalificacionExamen)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.ActualizarCalificacionExamen]", new object[,] { { "@icuId", icuId }, { "@recCalificacionExamen", recCalificacionExamen } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}


            #endregion
        }
    }
}