using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class RegistracionNotaPrevia
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _rprId;
            public Int32 rprId { get { return _rprId; } set { _rprId = value; } }

            private String _rprCalificacion;
            public String rprCalificacion { get { return _rprCalificacion; } set { _rprCalificacion = value; } }

            private DateTime? _rprFecha;
            public DateTime? rprFecha { get { return _rprFecha; } set { _rprFecha = value; } }


            #endregion

            #region Constructores

            public RegistracionNotaPrevia() { try { this.rprId = 0; } catch (Exception oError) { throw oError; } }

            public RegistracionNotaPrevia(Int32 rprId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[RegistracionNota.ObtenerUno]", new object[,] { { "@rprId", rprId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["rprId"].ToString().Trim().Length > 0)
                        {
                            this.rprId = Convert.ToInt32(Fila.Rows[0]["rprId"]);
                        }
                        else
                        {
                            this.rprId = 0;
                        }


                        if (Fila.Rows[0]["rprCalificacion"].ToString().Trim().Length > 0)
                        {
                            this.rprCalificacion = Convert.ToString(Fila.Rows[0]["rprCalificacion"]);
                        }
                        else
                        {
                            this.rprCalificacion = "";
                        }

                        if (Fila.Rows[0]["rprFecha"].ToString().Trim().Length > 0)
                        {
                            this.rprFecha = Convert.ToDateTime(Fila.Rows[0]["rprFecha"]);
                        }
                        else
                        {
                            this.rprFecha = null;
                        }
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public RegistracionNotaPrevia(Int32 rprId, String rprCalificacion, DateTime rprFecha, String renPCuat, String renSCuat, String renPTrim, String renSTrim, String renTTrim, String renDic, String renMar, String renCalfDef, String renEvaluacionFinal, String renObservaciones, DateTime renFechaHoraCreacion, DateTime renFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.rprId = rprId;
                    this.rprCalificacion = rprCalificacion;
                    this.rprFecha = rprFecha;
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
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxicuId(int icuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ObtenerTodoxicuId]", new object[,] { { "@icuId", icuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
    public DataTable ControlRepetida(int icuId, int anio, int renId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ControlRepetida]", new object[,] { { "@icuId", icuId }, { "@anio", anio }, { "@renId", renId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxrenId(int renId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ObtenerTodoxrenId]", new object[,] { { "@renId", renId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerSoloPrevias(int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ObtenerSoloPrevias]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxaluId(int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ObtenerTodoxaluId]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 rprId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RegistracionNotaPrevia.ObtenerUno]", new object[,] { { "@rprId", rprId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void AsignarNotaPrev(Int32 rprId, String rprCalificacion, DateTime rprFecha)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNotaPrevia.AsignarNotaPrev]", new object[,] { { "@rprId", rprId }, { "@rprCalificacion", rprCalificacion }, { "@rprFecha", rprFecha } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void Actualizar(Int32 rprId, String rprCalificacion, DateTime? rprFecha)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNotaPrevia.Actualizar]", new object[,] { { "@rprId", rprId }, { "@rprCalificacion", rprCalificacion }, { "@rprFecha", rprFecha } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 renId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNotaPrevia.Insertar]", new object[,] { { "@renId", renId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 rprId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RegistracionNotaPrevia.Eliminar]", new object[,] { { "@rprId", rprId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion
        }
    }
}