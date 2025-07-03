using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class PlanEstudio
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _plaId;
            public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

            private String _plaNombre;
            public String plaNombre { get { return _plaNombre; } set { _plaNombre = value; } }

            private Int32 _plaAnoInicioVigencia;
            public Int32 plaAnoInicioVigencia { get { return _plaAnoInicioVigencia; } set { _plaAnoInicioVigencia = value; } }

            private Int32 _plaAnoFinVigencia;
            public Int32 plaAnoFinVigencia { get { return _plaAnoFinVigencia; } set { _plaAnoFinVigencia = value; } }

            private Boolean _plaActivo;
            public Boolean plaActivo { get { return _plaActivo; } set { _plaActivo = value; } }

            private DateTime _plaFechaHoraCreacion;
            public DateTime plaFechaHoraCreacion { get { return _plaFechaHoraCreacion; } set { _plaFechaHoraCreacion = value; } }

            private DateTime _plaFechaHoraUltimaModificacion;
            public DateTime plaFechaHoraUltimaModificacion { get { return _plaFechaHoraUltimaModificacion; } set { _plaFechaHoraUltimaModificacion = value; } }

            private Int32 _carId;
            public Int32 carId { get { return _carId; } set { _carId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public PlanEstudio() { try { this.plaId = 0; } catch (Exception oError) { throw oError; } }

            public PlanEstudio(Int32 plaId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerUno]", new object[,] { { "@plaId", plaId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
                            this.plaId = 0;
                        }

                        if (Fila.Rows[0]["plaNombre"].ToString().Trim().Length > 0)
                        {
                            this.plaNombre = Convert.ToString(Fila.Rows[0]["plaNombre"]);
                        }
                        else
                        {
                            this.plaNombre = "";
                        }

                        if (Fila.Rows[0]["plaAnoInicioVigencia"].ToString().Trim().Length > 0)
                        {
                            this.plaAnoInicioVigencia = Convert.ToInt32(Fila.Rows[0]["plaAnoInicioVigencia"]);
                        }
                        else
                        {
                            this.plaAnoInicioVigencia = 0;
                        }

                        if (Fila.Rows[0]["plaAnoFinVigencia"].ToString().Trim().Length > 0)
                        {
                            this.plaAnoFinVigencia = Convert.ToInt32(Fila.Rows[0]["plaAnoFinVigencia"]);
                        }
                        else
                        {
                            this.plaAnoFinVigencia = 0;
                        }

                        if (Fila.Rows[0]["plaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.plaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["plaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.plaFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["plaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.plaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["plaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.plaFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["plaActivo"].ToString().Trim().Length > 0)
                        {
                            this.plaActivo = (Convert.ToInt32(Fila.Rows[0]["plaActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.plaActivo = false;
                        }

                        if (Fila.Rows[0]["carId"].ToString().Trim().Length > 0)
                        {
                            this.carId = Convert.ToInt32(Fila.Rows[0]["carId"]);
                        }
                        else
                        {
                            this.carId = 0;
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

            public PlanEstudio(Int32 plaId, String plaNombre, Int32 plaAnoInicioVigencia, Int32 plaAnoFinVigencia, Boolean plaActivo, DateTime plaFechaHoraCreacion, DateTime plaFechaHoraUltimaModificacion, Int32 IcarId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.plaId = plaId;
                    this.plaNombre = plaNombre;
                    this.plaAnoInicioVigencia = plaAnoInicioVigencia;
                    this.plaAnoFinVigencia = plaAnoFinVigencia;
                    this.plaActivo = plaActivo;
                    this.plaFechaHoraCreacion = plaFechaHoraCreacion;
                    this.plaFechaHoraUltimaModificacion = plaFechaHoraUltimaModificacion;
                    this.carId = carId;
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
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
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
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 plaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerUno]", new object[,] { { "@plaId", plaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxCarrera(Int32 carId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerUnoxCarrera]", new object[,] { { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaPorUnaCarrera(String PrimerItem, Int32 carId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerListaPorUnaCarrera]", new object[,] { { "@PrimerItem", PrimerItem }, { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaPorUnaCarreraParaPreInscripcion(String PrimerItem, Int32 carId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerListaPorUnaCarreraParaPreInscripcion]", new object[,] { { "@PrimerItem", PrimerItem }, { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaPorUnaCarreraporAlumno(String PrimerItem, Int32 carId, Int32 aluid)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerListaPorUnaCarreraporAlumno]", new object[,] { { "@PrimerItem", PrimerItem }, { "@carId", carId }, { "@aluid", aluid } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerValidarRepetido(Int32 plaId, String plaNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PlanEstudio.ObtenerValidarRepetido]", new object[,] { { "@plaId", plaId }, { "@plaNombre", plaNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 plaId, String plaNombre, Int32 plaAnoInicioVigencia, Int32 plaAnoFinVigencia, Int32 carId, Boolean plaActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime plaFechaHoraCreacion, DateTime plaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PlanEstudio.Actualizar]", new object[,] { { "@plaId", plaId }, { "@plaNombre", plaNombre }, { "@plaAnoInicioVigencia", plaAnoInicioVigencia }, { "@plaAnoFinVigencia", plaAnoFinVigencia }, { "@carId", carId }, { "@plaActivo", plaActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@plaFechaHoraCreacion", plaFechaHoraCreacion }, { "@plaFechaHoraUltimaModificacion", plaFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(String plaNombre, Int32 plaAnoInicioVigencia, Int32 plaAnoFinVigencia, Int32 carId, Boolean plaActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime plaFechaHoraCreacion, DateTime plaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PlanEstudio.Copiar]", new object[,] { { "@plaNombre", plaNombre }, { "@plaAnoInicioVigencia", plaAnoInicioVigencia }, { "@plaAnoFinVigencia", plaAnoFinVigencia }, { "@carId", carId }, { "@plaActivo", plaActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@plaFechaHoraCreacion", plaFechaHoraCreacion }, { "@plaFechaHoraUltimaModificacion", plaFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 plaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PlanEstudio.Eliminar]", new object[,] { { "@plaId", plaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String plaNombre, Int32 plaAnoInicioVigencia, Int32 plaAnoFinVigencia, Int32 carId, Boolean plaActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime plaFechaHoraCreacion, DateTime plaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PlanEstudio.Insertar]", new object[,] { { "@plaNombre", plaNombre }, { "@plaAnoInicioVigencia", plaAnoInicioVigencia }, { "@plaAnoFinVigencia", plaAnoFinVigencia }, { "@carId", carId }, { "@plaActivo", plaActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@plaFechaHoraCreacion", plaFechaHoraCreacion }, { "@plaFechaHoraUltimaModificacion", plaFechaHoraUltimaModificacion } });
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
                    if (this.plaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PlanEstudio.Actualizar]", new object[,] { { "@plaId", plaId }, { "@plaNombre", plaNombre }, { "@plaAnoInicioVigencia", plaAnoInicioVigencia }, { "@plaAnoFinVigencia", plaAnoFinVigencia }, { "@carId", carId }, { "@plaActivo", plaActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@plaFechaHoraCreacion", plaFechaHoraCreacion }, { "@plaFechaHoraUltimaModificacion", plaFechaHoraUltimaModificacion } });
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
                    if (this.plaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PlanEstudio.Copiar]", new object[,] { { "@plaNombre", plaNombre }, { "@plaAnoInicioVigencia", plaAnoInicioVigencia }, { "@plaAnoFinVigencia", plaAnoFinVigencia }, { "@carId", carId }, { "@plaActivo", plaActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@plaFechaHoraCreacion", plaFechaHoraCreacion }, { "@plaFechaHoraUltimaModificacion", plaFechaHoraUltimaModificacion } });
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
                    if (this.plaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PlanEstudio.Eliminar]", new object[,] { { "@plaId", plaId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PlanEstudio.Insertar]", new object[,] { { "@plaNombre", plaNombre }, { "@plaAnoInicioVigencia", plaAnoInicioVigencia }, { "@plaAnoFinVigencia", plaAnoFinVigencia }, { "@carId", carId }, { "@plaActivo", plaActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@plaFechaHoraCreacion", plaFechaHoraCreacion }, { "@plaFechaHoraUltimaModificacion", plaFechaHoraUltimaModificacion } });
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