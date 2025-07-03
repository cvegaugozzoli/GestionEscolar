using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Carrera
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _carId;
            public Int32 carId { get { return _carId; } set { _carId = value; } }

            private String _carNombre;
            public String carNombre { get { return _carNombre; } set { _carNombre = value; } }

            private Int32 _carTipoCarrera;
            public Int32 carTipoCarrera { get { return _carTipoCarrera; } set { _carTipoCarrera = value; } }

            private Boolean _carActivo;
            public Boolean carActivo { get { return _carActivo; } set { _carActivo = value; } }

            private DateTime _carFechaHoraCreacion;
            public DateTime carFechaHoraCreacion { get { return _carFechaHoraCreacion; } set { _carFechaHoraCreacion = value; } }

            private DateTime _carFechaHoraUltimaModificacion;
            public DateTime carFechaHoraUltimaModificacion { get { return _carFechaHoraUltimaModificacion; } set { _carFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Carrera() { try { this.carId = 0; } catch (Exception oError) { throw oError; } }

            public Carrera(Int32 carId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Carrera.ObtenerUno]", new object[,] { { "@carId", carId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["carId"].ToString().Trim().Length > 0)
                        {
                            this.carId = Convert.ToInt32(Fila.Rows[0]["carId"]);
                        }
                        else
                        {
                            this.carId = 0;
                        }

                        if (Fila.Rows[0]["carNombre"].ToString().Trim().Length > 0)
                        {
                            this.carNombre = Convert.ToString(Fila.Rows[0]["carNombre"]);
                        }
                        else
                        {
                            this.carNombre = "";
                        }

                        if (Fila.Rows[0]["carTipoCarrera"].ToString().Trim().Length > 0)
                        {
                            this.carTipoCarrera = Convert.ToInt32(Fila.Rows[0]["carTipoCarrera"]);
                        }
                        else
                        {
                            this.carTipoCarrera = 0;
                        }

                        if (Fila.Rows[0]["carFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.carFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["carFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.carFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["carFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.carFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["carFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.carFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["carActivo"].ToString().Trim().Length > 0)
                        {
                            this.carActivo = (Convert.ToInt32(Fila.Rows[0]["carActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.carActivo = false;
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

            public Carrera(Int32 carId, String carNombre, Int32 carTipoCarrera, Boolean carActivo, DateTime carFechaHoraCreacion, DateTime carFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.carId = carId;
                    this.carNombre = carNombre;
                    this.carActivo = carActivo;
                    this.carFechaHoraCreacion = carFechaHoraCreacion;
                    this.carTipoCarrera = carTipoCarrera;
                    this.carFechaHoraUltimaModificacion = carFechaHoraUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
    public DataTable ObtenerListaSoloPrimSec(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerListaSoloPrimSec]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaporAlumno(String PrimerItem, Int32 aluid)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerListaporAlumno]", new object[,] { { "@PrimerItem", PrimerItem }, { "@aluid", aluid } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaxtcaId(String PrimerItem, Int32 tcaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerListaxtcaId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@tcaId", tcaId } });
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
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoBuscarxNivel(int niv)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerTodoBuscarxNivel]", new object[,] { { "@niv", niv } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 carId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerUno]", new object[,] { { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxNivel(Int32 tcarId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerUnoxNivel]", new object[,] { { "@tcarId", tcarId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaParaPreInscripcion(String PrimerItem, Int32 carTipoCarrera)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerListaParaPreInscripcion]", new object[,] { { "@PrimerItem", PrimerItem }, { "@carTipoCarrera", carTipoCarrera } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }




            public DataTable ObtenerValidarRepetido(Int32 carId, String carNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Carrera.ObtenerValidarRepetido]", new object[,] { { "@carId", carId }, { "@carNombre", carNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 carId, String carNombre, Int32 carTipoCarrera, Boolean carActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime carFechaHoraCreacion, DateTime carFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Carrera.Actualizar]", new object[,] { { "@carId", carId }, { "@carNombre", carNombre }, { "@carTipoCarrera", carTipoCarrera }, { "@carActivo", carActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@carFechaHoraCreacion", carFechaHoraCreacion }, { "@carFechaHoraUltimaModificacion", carFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(String carNombre, Int32 carTipoCarrera, Boolean carActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime carFechaHoraCreacion, DateTime carFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Carrera.Copiar]", new object[,] { { "@carNombre", carNombre }, { "@carTipoCarrera", carTipoCarrera }, { "@carActivo", carActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@carFechaHoraCreacion", carFechaHoraCreacion }, { "@carFechaHoraUltimaModificacion", carFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 carId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Carrera.Eliminar]", new object[,] { { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String carNombre, Int32 carTipoCarrera, Boolean carActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime carFechaHoraCreacion, DateTime carFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Carrera.Insertar]", new object[,] { { "@carNombre", carNombre }, { "@carTipoCarrera", carTipoCarrera }, { "@carActivo", carActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@carFechaHoraCreacion", carFechaHoraCreacion }, { "@carFechaHoraUltimaModificacion", carFechaHoraUltimaModificacion } });
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
                    if (this.carId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Carrera.Actualizar]", new object[,] { { "@carId", carId }, { "@carNombre", carNombre }, { "@carTipoCarrera", carTipoCarrera }, { "@carActivo", carActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@carFechaHoraCreacion", carFechaHoraCreacion }, { "@carFechaHoraUltimaModificacion", carFechaHoraUltimaModificacion } });
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
                    if (this.carId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Carrera.Copiar]", new object[,] { { "@carNombre", carNombre }, { "@carTipoCarrera", carTipoCarrera }, { "@carActivo", carActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@carFechaHoraCreacion", carFechaHoraCreacion }, { "@carFechaHoraUltimaModificacion", carFechaHoraUltimaModificacion } });
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
                    if (this.carId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Carrera.Eliminar]", new object[,] { { "@carId", carId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Carrera.Insertar]", new object[,] { { "@carNombre", carNombre }, { "@carTipoCarrera", carTipoCarrera }, { "@carActivo", carActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@carFechaHoraCreacion", carFechaHoraCreacion }, { "@carFechaHoraUltimaModificacion", carFechaHoraUltimaModificacion } });
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