using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class ComprobantesDestinos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cdoId;
            public Int32 cdoId { get { return _cdoId; } set { _cdoId = value; } }

            private String _cdoNombre;
            public String cdoNombre { get { return _cdoNombre; } set { _cdoNombre = value; } }

            private Boolean _cdoActivo;
            public Boolean cdoActivo { get { return _cdoActivo; } set { _cdoActivo = value; } }

            private DateTime _cdoFechaHoraCreacion;
            public DateTime cdoFechaHoraCreacion { get { return _cdoFechaHoraCreacion; } set { _cdoFechaHoraCreacion = value; } }

            private DateTime _cdoFechaHoraUltimaModificacion;
            public DateTime cdoFechaHoraUltimaModificacion { get { return _cdoFechaHoraUltimaModificacion; } set { _cdoFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ComprobantesDestinos() { try { this.cdoId = 0; } catch (Exception oError) { throw oError; } }

            public ComprobantesDestinos(Int32 cdoId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerUno]", new object[,] { { "@cdoId", cdoId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["cdoId"].ToString().Trim().Length > 0)
                        {
                            this.cdoId = Convert.ToInt32(Fila.Rows[0]["cdoId"]);
                        }
                        else
                        {
                            this.cdoId = 0;
                        }

                        if (Fila.Rows[0]["cdoNombre"].ToString().Trim().Length > 0)
                        {
                            this.cdoNombre = Convert.ToString(Fila.Rows[0]["cdoNombre"]);
                        }
                        else
                        {
                            this.cdoNombre = "";
                        }

                        if (Fila.Rows[0]["cdoFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cdoFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cdoFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cdoFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cdoFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cdoFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cdoFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cdoFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["cdoActivo"].ToString().Trim().Length > 0)
                        {
                            this.cdoActivo = (Convert.ToInt32(Fila.Rows[0]["cdoActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.cdoActivo = false;
                        }

                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuidUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuidUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuidUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuidUltimaModificacion = 0;
                        }

                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public ComprobantesDestinos(Int32 cdoId, String cdoNombre, Boolean cdoActivo, DateTime cdoFechaHoraCreacion, DateTime cdoFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.cdoId = cdoId;
                    this.cdoNombre = cdoNombre;
                    this.cdoActivo = cdoActivo;
                    this.cdoFechaHoraCreacion = cdoFechaHoraCreacion;
                    this.cdoFechaHoraUltimaModificacion = cdoFechaHoraUltimaModificacion;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuidUltimaModificacion = usuidUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 cdoId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerUno]", new object[,] { { "@cdoId", cdoId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(Int32 cdoId, String cdoNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesDestinos.ObtenerValidarRepetido]", new object[,] { { "@cdoId", cdoId }, { "@cdoNombre", cdoNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 cdoId, String cdoNombre, Boolean cdoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdoFechaHoraCreacion, DateTime cdoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Actualizar]", new object[,] { { "@cdoId", cdoId }, { "@cdoNombre", cdoNombre }, { "@cdoActivo", cdoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdoFechaHoraCreacion", cdoFechaHoraCreacion }, { "@cdoFechaHoraUltimaModificacion", cdoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(String cdoNombre, Boolean cdoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdoFechaHoraCreacion, DateTime cdoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Copiar]", new object[,] { { "@cdoNombre", cdoNombre }, { "@cdoActivo", cdoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdoFechaHoraCreacion", cdoFechaHoraCreacion }, { "@cdoFechaHoraUltimaModificacion", cdoFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 cdoId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Eliminar]", new object[,] { { "@cdoId", cdoId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String cdoNombre, Boolean cdoActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime cdoFechaHoraCreacion, DateTime cdoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Insertar]", new object[,] { { "@cdoNombre", cdoNombre }, { "@cdoActivo", cdoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdoFechaHoraCreacion", cdoFechaHoraCreacion }, { "@cdoFechaHoraUltimaModificacion", cdoFechaHoraUltimaModificacion } });
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
                    if (this.cdoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Actualizar]", new object[,] { { "@cdoId", cdoId }, { "@cdoNombre", cdoNombre }, { "@cdoActivo", cdoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdoFechaHoraCreacion", cdoFechaHoraCreacion }, { "@cdoFechaHoraUltimaModificacion", cdoFechaHoraUltimaModificacion } });
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
                    if (this.cdoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Copiar]", new object[,] { { "@cdoNombre", cdoNombre }, { "@cdoActivo", cdoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdoFechaHoraCreacion", cdoFechaHoraCreacion }, { "@cdoFechaHoraUltimaModificacion", cdoFechaHoraUltimaModificacion } });
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
                    if (this.cdoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesDestinos.Eliminar]", new object[,] { { "@cdoId", cdoId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesDestinos.Insertar]", new object[,] { { "@cdoNombre", cdoNombre }, { "@cdoActivo", cdoActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@cdoFechaHoraCreacion", cdoFechaHoraCreacion }, { "@cdoFechaHoraUltimaModificacion", cdoFechaHoraUltimaModificacion } });
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