using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class AlumnoFamiliar
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _afaId;
            public Int32 afaId { get { return _afaId; } set { _afaId = value; } }

            private Int32 _aluId;
            public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

            private Int32 _famId;
            public Int32 famId { get { return _famId; } set { _famId = value; } }
            private Int32 _patId;
            public Int32 patId { get { return _patId; } set { _patId = value; } }

            private Boolean _afaEsTutor;
            public Boolean afaEsTutor { get { return _afaEsTutor; } set { _afaEsTutor = value; } }

            private DateTime _afaFechaHoraCreacion;
            public DateTime afaFechaHoraCreacion { get { return _afaFechaHoraCreacion; } set { _afaFechaHoraCreacion = value; } }

            private DateTime _afaFechaHoraUltimaModificacion;
            public DateTime afaFechaHoraUltimaModificacion { get { return _afaFechaHoraUltimaModificacion; } set { _afaFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public AlumnoFamiliar() { try { this.afaId = 0; } catch (Exception oError) { throw oError; } }

            public AlumnoFamiliar(Int32 afaId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerUno]", new object[,] { { "@afaId", afaId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["afaId"].ToString().Trim().Length > 0)
                        {
                            this.afaId = Convert.ToInt32(Fila.Rows[0]["afaId"]);
                        }
                        else
                        {
                            this.afaId = 0;
                        }

                        if (Fila.Rows[0]["aluId"].ToString().Trim().Length > 0)
                        {
                            this.aluId = Convert.ToInt32(Fila.Rows[0]["aluId"]);
                        }
                        else
                        {
                            this.aluId = 0;
                        }

                        if (Fila.Rows[0]["famId"].ToString().Trim().Length > 0)
                        {
                            this.famId = Convert.ToInt32(Fila.Rows[0]["famId"]);
                        }
                        else
                        {
                            this.famId = 0;
                        }

                        if (Fila.Rows[0]["patId"].ToString().Trim().Length > 0)
                        {
                            this.patId = Convert.ToInt32(Fila.Rows[0]["patId"]);
                        }
                        else
                        {
                            this.patId = 0;
                        }

                        if (Fila.Rows[0]["afaEsTutor"].ToString().Trim().Length > 0)
                        {
                            this.afaEsTutor = Convert.ToBoolean(Fila.Rows[0]["afaEsTutor"]);
                        }
                        else
                        {
                            this.afaEsTutor = false;
                        }


                        if (Fila.Rows[0]["afaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.afaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["afaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.afaFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["afaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.afaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["afaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.afaFechaHoraUltimaModificacion = DateTime.Now;
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

            public AlumnoFamiliar(Int32 afaId, Int32 aluId, Int32 famId, Int32 patId, Boolean afaEsTutor, DateTime afaFechaHoraCreacion, DateTime afaFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.afaId = afaId;
                    this.aluId = aluId;
                    this.famId = famId;
                    this.afaEsTutor = afaEsTutor;
                    this.afaFechaHoraCreacion = afaFechaHoraCreacion;
                    this.afaFechaHoraUltimaModificacion = afaFechaHoraUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaFamiliar(int PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerListaFamiliar]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaHijos(String PrimerItem, int famId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerListaHijos]", new object[,] { { "@PrimerItem", PrimerItem }, { "@FamId", famId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerHijosxfamIdxAnio(int famId, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerHijosxfamIdxAnio]", new object[,] {
                         { "@famId", famId },{ "@Anio", Anio }
                    });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerCantHijos(int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerCantHijos]", new object[,] { { "@Anio", Anio } });
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 afaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerUno]", new object[,] { { "@afaId", afaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerValidarRepetido(Int32 afaId, String cotNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerValidarRepetido]", new object[,] {{"@cotId", cotId}, {"@cotNombre", cotNombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            public void Actualizar(Int32 aluId, Int32 famId, Int32 patId, int afaEsTutor, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime afaFechaHoraCreacion, DateTime afaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[AlumnoFamiliar.Actualizar]", new object[,] { { "@aluId", aluId }, { "@famId", famId }, { "@patId", patId }, { "@afaEsTutor", afaEsTutor }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(Int32 aluId, Int32 famId, Int32 patId, int afaEsTutor, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime afaFechaHoraCreacion, DateTime afaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[AlumnoFamiliar.Copiar]", new object[,] { { "@aluId", aluId }, { "@famId", famId }, { "@patId", patId }, { "@afaEsTutor", afaEsTutor }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 afaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[AlumnoFamiliar.Eliminar]", new object[,] { { "@afaId", afaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 Insertar(Int32 aluId, Int32 famId, Int32 patId, int afaEsTutor, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime afaFechaHoraCreacion, DateTime afaFechaHoraUltimaModificacion)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[AlumnoFamiliar.Insertar]", new object[,] { { "@aluId", aluId }, { "@famId", famId }, { "@patId", patId }, { "@afaEsTutor", afaEsTutor }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public void Actualizar()
            {
                try
                {
                    if (this.afaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[AlumnoFamiliar.Actualizar]", new object[,] { { "@aluId", aluId }, { "@famId", famId }, { "@patId", patId }, { "@afaEsTutor", afaEsTutor }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });
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
                    if (this.afaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[AlumnoFamiliar.Copiar]", new object[,] { { "@aluId", aluId }, { "@famId", famId }, { "@patId", patId }, { "@afaEsTutor", afaEsTutor }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });
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
                    if (this.afaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[AlumnoFamiliar.Eliminar]", new object[,] { { "@afaId", afaId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[AlumnoFamiliar.Insertar]", new object[,] { { "@aluId", aluId }, { "@famId", famId }, { "@patId", patId }, { "@afaEsTutor", afaEsTutor }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }
 

            public DataTable ObtenerUnoxaluId(Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla =  ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerUnoxaluId]", new object[,] { { "@aluId", aluId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }
     public DataTable ObtenerTodoxaluId(Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla =  ocdGestor.EjecutarReader("[AlumnoFamiliar.ObtenerTodoxaluId]", new object[,] { { "@aluId", aluId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }
            public Int32 ObtenerUnoIdFam(Int32 aluId, String Dni)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[AlumnoFamiliar.ObtenerUnoIdFam]", new object[,] { { "@aluId", aluId }, { "@dni", Dni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }

            public Int32 ObtenerUnoAfaId(Int32 aluId, String Dni)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[AlumnoFamiliar.ObtenerUnoafaId]", new object[,] { { "@aluId", aluId }, { "@dni", Dni } });
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