using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Curso
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _curId;
            public Int32 curId { get { return _curId; } set { _curId = value; } }

            private String _curNombre;
            public String curNombre { get { return _curNombre; } set { _curNombre = value; } }

            private Boolean _curActivo;
            public Boolean curActivo { get { return _curActivo; } set { _curActivo = value; } }

            private DateTime _curFechaHoraCreacion;
            public DateTime curFechaHoraCreacion { get { return _curFechaHoraCreacion; } set { _curFechaHoraCreacion = value; } }

            private DateTime _curFechaHoraUltimaModificacion;
            public DateTime curFechaHoraUltimaModificacion { get { return _curFechaHoraUltimaModificacion; } set { _curFechaHoraUltimaModificacion = value; } }

            private Int32 _plaId;
            public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Curso() { try { this.curId = 0; } catch (Exception oError) { throw oError; } }

            public Curso(Int32 curId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Curso.ObtenerUno]", new object[,] { { "@curId", curId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
                            this.curId = 0;
                        }

                        if (Fila.Rows[0]["curNombre"].ToString().Trim().Length > 0)
                        {
                            this.curNombre = Convert.ToString(Fila.Rows[0]["curNombre"]);
                        }
                        else
                        {
                            this.curNombre = "";
                        }

                        if (Fila.Rows[0]["curFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.curFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["curFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.curFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["curFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.curFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["curFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.curFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["curActivo"].ToString().Trim().Length > 0)
                        {
                            this.curActivo = (Convert.ToInt32(Fila.Rows[0]["curActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.curActivo = false;
                        }

                        if (Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
                            this.plaId = 0;
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

            public Curso(Int32 curId, String curNombre, Boolean curActivo, DateTime curFechaHoraCreacion, DateTime curFechaHoraUltimaModificacion, Int32 IplaId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.curId = curId;
                    this.curNombre = curNombre;
                    this.curActivo = curActivo;
                    this.curFechaHoraCreacion = curFechaHoraCreacion;
                    this.curFechaHoraUltimaModificacion = curFechaHoraUltimaModificacion;
                    this.plaId = plaId;
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


            public DataTable ObtenerBuscador(String ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerporCarporPlaporCur(Int32 carId, Int32 plaId, Int32 curId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerporCarporPlaporCur]", new object[,] { { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }         


            public DataTable ObtenerListaPorUnPlanEstudio(String PrimerItem, Int32 plaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerListaPorUnPlanEstudio]", new object[,] { { "@PrimerItem", PrimerItem }, { "@plaId", plaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerListaxPreinscripcion(String PrimerItem, Int32 plaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerListaxPreinscripcion]", new object[,] { { "@PrimerItem", PrimerItem }, { "@plaId", plaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaPorUnPlanEstudioporAlumno(String PrimerItem, Int32 plaId, Int32 aluid)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerListaPorUnPlanEstudioporAlumno]", new object[,] { { "@PrimerItem", PrimerItem }, { "@plaId", plaId }, { "@aluid", aluid } });
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
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }




            public DataTable ObtenerListadoxCurso(Int32 Curso, String Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerListadoxCurso]", new object[,] { { "@Curso", Curso }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 curId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerUno]", new object[,] { { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable InformeCalificacionesPC(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesPC]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable InformeCalificacionesSC(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesSC]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable InformeCalificacionesPTrim(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesPTrim]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable InformeCalificacionesSTrim(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesSTrim]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable InformeCalificacionesTTrim(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesTTrim]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable InformeCalificacionesPromAnual(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesPromAnual]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable InformeCalificacionesDic(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesDic]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable InformeCalificacionesMar(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesMar]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable InformeCalificacionesCalfDef(Int32 curso, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeCalificacionesCalfDef]", new object[,] { { "@curso", curso }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerCalificacionesSC(Int32 curId, Int32 anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerCalificacionesSC]", new object[,] { { "@curId", curId }, { "@anio", anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(Int32 curId, String curNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Curso.ObtenerValidarRepetido]", new object[,] { { "@curId", curId }, { "@curNombre", curNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 curId, String curNombre, Int32 plaId, Boolean curActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime curFechaHoraCreacion, DateTime curFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Curso.Actualizar]", new object[,] { { "@curId", curId }, { "@curNombre", curNombre }, { "@plaId", plaId }, { "@curActivo", curActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@curFechaHoraCreacion", curFechaHoraCreacion }, { "@curFechaHoraUltimaModificacion", curFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(String curNombre, Int32 plaId, Boolean curActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime curFechaHoraCreacion, DateTime curFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Curso.Copiar]", new object[,] { { "@curNombre", curNombre }, { "@plaId", plaId }, { "@curActivo", curActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@curFechaHoraCreacion", curFechaHoraCreacion }, { "@curFechaHoraUltimaModificacion", curFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 curId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Curso.Eliminar]", new object[,] { { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String curNombre, Int32 plaId, Boolean curActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime curFechaHoraCreacion, DateTime curFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Curso.Insertar]", new object[,] { { "@curNombre", curNombre }, { "@plaId", plaId }, { "@curActivo", curActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@curFechaHoraCreacion", curFechaHoraCreacion }, { "@curFechaHoraUltimaModificacion", curFechaHoraUltimaModificacion } });
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
                    if (this.curId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Curso.Actualizar]", new object[,] { { "@curId", curId }, { "@curNombre", curNombre }, { "@plaId", plaId }, { "@curActivo", curActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@curFechaHoraCreacion", curFechaHoraCreacion }, { "@curFechaHoraUltimaModificacion", curFechaHoraUltimaModificacion } });
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
                    if (this.curId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Curso.Copiar]", new object[,] { { "@curNombre", curNombre }, { "@plaId", plaId }, { "@curActivo", curActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@curFechaHoraCreacion", curFechaHoraCreacion }, { "@curFechaHoraUltimaModificacion", curFechaHoraUltimaModificacion } });
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
                    if (this.curId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Curso.Eliminar]", new object[,] { { "@curId", curId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Curso.Insertar]", new object[,] { { "@curNombre", curNombre }, { "@plaId", plaId }, { "@curActivo", curActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@curFechaHoraCreacion", curFechaHoraCreacion }, { "@curFechaHoraUltimaModificacion", curFechaHoraUltimaModificacion } });
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