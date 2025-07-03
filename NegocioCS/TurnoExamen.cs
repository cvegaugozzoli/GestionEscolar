using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TurnoExamen
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tueId;
            public Int32 tueId { get { return _tueId; } set { _tueId = value; } }

            private String _tueNombre;
            public String tueNombre { get { return _tueNombre; } set { _tueNombre = value; } }

            private Int32 _tueAnio;
            public Int32 tueAnio { get { return _tueAnio; } set { _tueAnio = value; } }

            private Int32 _llaId;
            public Int32 llaId { get { return _llaId; } set { _llaId = value; } }

            private DateTime _tueFchInicio;
            public DateTime tueFchInicio { get { return _tueFchInicio; } set { _tueFchInicio = value; } }

            private DateTime _tueFchFin;
            public DateTime tueFchFin { get { return _tueFchFin; } set { _tueFchFin = value; } }

            private Int32 _tueCantMesas;
            public Int32 tueCantMesas { get { return _tueCantMesas; } set { _tueCantMesas = value; } }

            private Boolean _tueActivo;
            public Boolean tueActivo { get { return _tueActivo; } set { _tueActivo = value; } }

            private DateTime _tueFechaHoraCreacion;
            public DateTime tueFechaHoraCreacion { get { return _tueFechaHoraCreacion; } set { _tueFechaHoraCreacion = value; } }

            private DateTime _tueFechaHoraUltimaModificacion;
            public DateTime tueFechaHoraUltimaModificacion { get { return _tueFechaHoraUltimaModificacion; } set { _tueFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public TurnoExamen() { try { this.tueId = 0; } catch (Exception oError) { throw oError; } }

            public TurnoExamen(Int32 tueId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerUno]", new object[,] { { "@tueId", tueId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["tueId"].ToString().Trim().Length > 0)
                        {
                            this.tueId = Convert.ToInt32(Fila.Rows[0]["tueId"]);
                        }
                        else
                        {
                            this.tueId = 0;
                        }
                        if (Fila.Rows[0]["tueNombre"].ToString().Trim().Length > 0)
                        {
                            this.tueNombre = Convert.ToString(Fila.Rows[0]["tueNombre"]);
                        }
                        else
                        {
                            this.tueNombre = "";
                        }
                        if (Fila.Rows[0]["tueAnio"].ToString().Trim().Length > 0)
                        {
                            this.tueAnio = Convert.ToInt32(Fila.Rows[0]["tueAnio"]);
                        }
                        else
                        {
                            this.tueAnio = 0;
                        }
                        if (Fila.Rows[0]["llaId"].ToString().Trim().Length > 0)
                        {
                            this.llaId = Convert.ToInt32(Fila.Rows[0]["llaId"]);
                        }
                        else
                        {
                            this.llaId = 0;
                        }

                        if (Fila.Rows[0]["tueFchInicio"].ToString().Trim().Length > 0)
                        {
                            this.tueFchInicio = Convert.ToDateTime(Fila.Rows[0]["tueFchInicio"]);
                        }
                        else
                        {
                            this.tueFchInicio = DateTime.Now;
                        }
                        if (Fila.Rows[0]["tueFchFin"].ToString().Trim().Length > 0)
                        {
                            this.tueFchFin = Convert.ToDateTime(Fila.Rows[0]["tueFchFin"]);
                        }
                        else
                        {
                            this.tueFchFin = DateTime.Now;
                        }
                        if (Fila.Rows[0]["tueCantMesas"].ToString().Trim().Length > 0)
                        {
                            this.tueCantMesas = Convert.ToInt32(Fila.Rows[0]["tueCantMesas"]);
                        }
                        else
                        {
                            this.tueCantMesas = 0;
                        }

                        if (Fila.Rows[0]["tueFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.tueFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["tueFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.tueFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["tueFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.tueFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["tueFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.tueFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["tueActivo"].ToString().Trim().Length > 0)
                        {
                            this.tueActivo = (Convert.ToInt32(Fila.Rows[0]["tueActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.tueActivo = false;
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

            public TurnoExamen(Int32 tueId, String tueNombre, Int32 tueAnio, Int32 llaId, DateTime tueFchInicio, DateTime tueFchFin, Int32 tueCantMesas, Boolean tueActivo, DateTime tueFechaHoraCreacion, DateTime tueFechaHoraUltimaModificacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion)
            {
                try
                {
                    this.tueId = tueId;
 this.tueNombre = tueNombre;
                    this.tueAnio = tueAnio;
                    this.llaId = llaId;
                    this.tueFchInicio = tueFchInicio;
                    this.tueFchFin = tueFchFin;
                    this.tueCantMesas = tueCantMesas;
                    this.tueActivo = tueActivo;
                    this.tueFechaHoraCreacion = tueFechaHoraCreacion;
                    this.tueFechaHoraUltimaModificacion = tueFechaHoraUltimaModificacion;
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



            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerTodoBuscarxAnio(int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerTodoBuscarxAnio]", new object[,] { { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaxDate(String PrimerItem, DateTime date)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerListaxDate]", new object[,] { { "@PrimerItem", PrimerItem },{ "@date", date } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return Tabla;
            }

            public DataTable ObtenerListaxAnio(String PrimerItem, Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerListaxAnio]", new object[,] { { "@PrimerItem", PrimerItem }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoBuscarxLlamadoxAnio(String Nombre, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerTodoBuscarxLlamadoxAnio]", new object[,] { { "@Nombre", Nombre }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxLlamado(int llaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerTodoxLlamado]", new object[,] { { "@llaId", llaId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void EliminarxActivo(Int32 Id, int Usuario, DateTime FechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TurnoExamen.EliminarxActivo]", new object[,] { { "@Id", Id }, { "@usuIdUltimaModificacion", Usuario }, { "@FechaHoraUltimaModificacion", FechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public DataTable ObtenerUno(Int32 tueId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TurnoExamen.ObtenerUno]", new object[,] { { "@tueId", tueId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public void Eliminar(Int32 tueId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TurnoExamen.Eliminar]", new object[,] { { "@tueId", tueId } });
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
                    if (this.tueId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[TurnoExamen.Actualizar]", new object[,] { { "@tueId", tueId }, { "@tueNombre", tueNombre }, { "@tueAnio", tueAnio },
                            { "@llaId", llaId }, { "@tueFchInicio", tueFchInicio }, { "@tueFchFin", tueFchFin },{ "@tueCantMesas", tueCantMesas }, { "@tueActivo", tueActivo },
                            { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@tueFechaHoraCreacion", tueFechaHoraCreacion }, { "@tueFechaHoraUltimaModificacion", tueFechaHoraUltimaModificacion } });
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
                    if (this.tueId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[TurnoExamen.Eliminar]", new object[,] { { "@tueId", tueId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[TurnoExamen.Insertar]", new object[,]  {{ "@tueNombre", tueNombre }, { "@tueAnio", tueAnio }, 
                            { "@llaId", llaId }, { "@tueFchInicio", tueFchInicio }, { "@tueFchFin", tueFchFin }, { "@tueCantMesas", tueCantMesas }, { "@tueActivo", tueActivo },
                            { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@tueFechaHoraCreacion", tueFechaHoraCreacion }, { "@tueFechaHoraUltimaModificacion", tueFechaHoraUltimaModificacion } });
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