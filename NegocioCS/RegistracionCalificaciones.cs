using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class RegistracionCalificaciones
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _recId;
            public Int32 recId { get { return _recId; } set { _recId = value; } }

            private Int32 _ictId;
            public Int32 ictId { get { return _ictId; } set { _ictId = value; } }

            private Int32 _eceId;
            public Int32 eceId { get { return _eceId; } set { _eceId = value; } }

            private String _recNota;
            public String recNota { get { return _recNota; } set { _recNota = value; } }

            private String _recObservaciones;
            public String recObservaciones { get { return _recObservaciones; } set { _recObservaciones = value; } }

            private Boolean _recActivo;
            public Boolean recActivo { get { return _recActivo; } set { _recActivo = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private DateTime _recFechaHoraCreacion;
            public DateTime recFechaHoraCreacion { get { return _recFechaHoraCreacion; } set { _recFechaHoraCreacion = value; } }

            private DateTime _recFechaHoraUltimaModificacion;
            public DateTime recFechaHoraUltimaModificacion { get { return _recFechaHoraUltimaModificacion; } set { _recFechaHoraUltimaModificacion = value; } }


            #endregion

            #region Constructores

            public RegistracionCalificaciones() { try { this.recId = 0; } catch (Exception oError) { throw oError; } }

            public RegistracionCalificaciones(Int32 recId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerUno]", new object[,] { { "@recId", recId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["recId"].ToString().Trim().Length > 0)
                        {
                            this.recId = Convert.ToInt32(Fila.Rows[0]["recId"]);
                        }
                        else
                        {
                            this.recId = 0;
                        }
                        if (Fila.Rows[0]["ictId"].ToString().Trim().Length > 0)
                        {
                            this.ictId = Convert.ToInt32(Fila.Rows[0]["ictId"]);
                        }
                        else
                        {
                            this.ictId = 0;
                        }

                        if (Fila.Rows[0]["eceId"].ToString().Trim().Length > 0)
                        {
                            this.eceId = Convert.ToInt32(Fila.Rows[0]["eceId"]);
                        }
                        else
                        {
                            this.eceId = 0;
                        }

                        if (Fila.Rows[0]["recNota"].ToString().Trim().Length > 0)
                        {
                            this.recNota = Convert.ToString(Fila.Rows[0]["recNota"]);
                        }
                        else
                        {
                            this.recNota = "";
                        }

                        if (Fila.Rows[0]["recObservaciones"].ToString().Trim().Length > 0)
                        {
                            this.recObservaciones = Convert.ToString(Fila.Rows[0]["recObservaciones"]);
                        }
                        else
                        {
                            this.recObservaciones = "";
                        }

                        if (Fila.Rows[0]["recActivo"].ToString().Trim().Length > 0)
                        {
                            this.recActivo = (Convert.ToInt32(Fila.Rows[0]["recActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.recActivo = false;
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


                        if (Fila.Rows[0]["recFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.recFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["recFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.recFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["recFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.recFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["recFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.recFechaHoraUltimaModificacion = DateTime.Now;
                        }

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public RegistracionCalificaciones(Int32 recId, Int32 ictId, Int32 eceId, String recNota, String recObservaciones, Boolean recActivo,
           Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, DateTime recFechaHoraCreacion, DateTime recFechaHoraUltimaModificacion)
            {
                try
                {
                    this.recId = recId;
                    this.ictId = ictId;
                    this.eceId = eceId;

                    this.recNota = recNota;
                    this.recObservaciones = recObservaciones;
                    this.recActivo = recActivo;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.recFechaHoraCreacion = recFechaHoraCreacion;
                    this.recFechaHoraUltimaModificacion = recFechaHoraUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void AsignarNotaTerc(Int32 recId, String nota, DateTime recFechaHoraUltimaModificacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.AsignarNotaTerc]", new object[,] { { "@recId", recId }, { "@nota", nota }, { "@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public DataTable ObtenerListadoxEspCurrAsist(Int32 espcurric, Int32 curId, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerListadoxEspCurrAsist]", new object[,] { { "@espcurric", espcurric }, { "@curId", curId }, { "@Anio", Anio } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListadoxEspCurrAsistxclase(Int32 espcurric, Int32 curId, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerListadoxEspCurrAsistxclase]", new object[,] { { "@espcurric", espcurric }, { "@curId", curId }, { "@Anio", Anio } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListadoxEspCurEval(Int32 espcurric, Int32 eceId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerListadoxEspCurEval]", new object[,] { { "@espcurric", espcurric }, { "@eceId", eceId } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaxCarxPlaxEsc(String Texto, Int32 carId, Int32 plaId, Int32 espcurric)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerListaxCarxPlaxEsc]", new object[,] { { "@Texto", Texto }, { "@carId", carId }, { "@plaId", plaId }, { "@espcurric", espcurric } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 recId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerUno]", new object[,] { { "@recId", recId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable controlarCondicion(Int32 ictId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.controlarCondicion]", new object[,] { { "@ictId", ictId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public Int32 ObtenerUnoxictIdxDescTreg(Int32 recId, String DescTReg)
            {

                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RegistracionCalificaciones.ObtenerUnoxictIdxDescTreg]", new object[,] { { "@recId", recId }, { "@DescTReg", DescTReg } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public DataTable ObtenerTodoporEspCurricularAnio(Int32 espId, Int32 curId, Int32 anio, Int32 tipoReg)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerTodoporEspCurricularAnio]", new object[,] { { "@espId", espId }, { "@curId", curId }, { "@anio", anio }, { "@tipoReg", tipoReg } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoporEspCurricularAnioTodo(Int32 espId, Int32 curId, Int32 anio, Int32 tipoReg)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerTodoporEspCurricularAnioTodo]", new object[,] { { "@espId", espId }, { "@curId", curId }, { "@anio", anio }, { "@tipoReg", tipoReg } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTRegxictId(String PrimerItem, Int32 treId, Int32 ictId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionCalificaciones.ObtenerTRegxictId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@treId", treId }, { "@ictId", ictId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public void Eliminar(Int32 recId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Eliminar]", new object[,] { { "@recId", recId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void EliminarxEvalEspCurr(Int32 eceId, Int32 usuId, DateTime FechaModi)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.EliminarxEvalEspCurr]", new object[,] { { "@eceId", eceId }, { "@usuId", usuId }, { "@FechaModi", FechaModi } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarxictIdAct0(Int32 ictId, Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.EliminarxictIdAct0]", new object[,] { { "@ictId", ictId }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 ictId, Int32 eceId, String recNota, String recObservaciones, Boolean recActivo,
           Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, DateTime recFechaHoraCreacion, DateTime recFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Insertar]", new object[,] { { "@ictId", ictId },{ "@eceId", eceId },{ "@recNota", recNota },
                        {"@recObservaciones", recObservaciones},  {"@recActivo", recActivo},{"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion} });
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
                    if (this.recId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Actualizar]", new object[,] {{ "@ictId", ictId },{ "@eceId", eceId },{ "@recNota", recNota },
                    {"@recObservaciones", recObservaciones},  {"@recActivo", recActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion} });
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
                    if (this.recId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RegistracionCalificaciones.Eliminar]", new object[,] { { "@recId", recId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RegistracionCalificaciones.Insertar]", new object[,] { { "@ictId", ictId },{ "@eceId", eceId },{ "@recNota", recNota },
                      {"@recObservaciones", recObservaciones},  {"@recActivo", recActivo},{"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@recFechaHoraCreacion", recFechaHoraCreacion}, {"@recFechaHoraUltimaModificacion", recFechaHoraUltimaModificacion} });
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