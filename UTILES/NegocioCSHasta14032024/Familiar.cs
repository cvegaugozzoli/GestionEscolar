using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Familiar
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _famId;
            public Int32 famId { get { return _famId; } set { _famId = value; } }

            private String _famApellido;
            public String famApellido { get { return _famApellido; } set { _famApellido = value; } }

            private String _famNombre;
            public String famNombre { get { return _famNombre; } set { _famNombre = value; } }

            private String _famDni;
            public String famDni { get { return _famDni; } set { _famDni = value; } }

            private String _famOcupacion;
            public String famOcupacion { get { return _famOcupacion; } set { _famOcupacion = value; } }

            private String _famTelefonoCel;
            public String famTelefonoCel { get { return _famTelefonoCel; } set { _famTelefonoCel = value; } }

            private String _famTelefonoFijo;
            public String famTelefonoFijo { get { return _famTelefonoFijo; } set { _famTelefonoFijo = value; } }

            private String _famCuit;
            public String famCuit { get { return _famCuit; } set { _famCuit = value; } }

            private String _famMail;
            public String famMail { get { return _famMail; } set { _famMail = value; } }

            private Int32 _usuId;
            public Int32 usuId { get { return _usuId; } set { _usuId = value; } }

            private DateTime _famFechaHoraCreacion;
            public DateTime famFechaHoraCreacion { get { return _famFechaHoraCreacion; } set { _famFechaHoraCreacion = value; } }

            private DateTime _famFechaHoraUltimaModificacion;
            public DateTime famFechaHoraUltimaModificacion { get { return _famFechaHoraUltimaModificacion; } set { _famFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }


            #endregion

            #region Constructores

            public Familiar() { try { this.famId = 0; } catch (Exception oError) { throw oError; } }

            public Familiar(Int32 famId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Familiar.ObtenerUno]", new object[,] { { "@famId", famId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["famId"].ToString().Trim().Length > 0)
                        {
                            this.famId = Convert.ToInt32(Fila.Rows[0]["famId"]);
                        }
                        else
                        {
                            this.famId = 0;
                        }

                        if (Fila.Rows[0]["famApellido"].ToString().Trim().Length > 0)
                        {
                            this.famApellido = Convert.ToString(Fila.Rows[0]["famApellido"]);
                        }
                        else
                        {
                            this.famApellido = "";
                        }

                        if (Fila.Rows[0]["famNombre"].ToString().Trim().Length > 0)
                        {
                            this.famNombre = Convert.ToString(Fila.Rows[0]["famNombre"]);
                        }
                        else
                        {
                            this.famNombre = "";
                        }

                        if (Fila.Rows[0]["famDni"].ToString().Trim().Length > 0)
                        {
                            this.famDni = Convert.ToString(Fila.Rows[0]["famDni"]);
                        }
                        else
                        {
                            this.famDni = "";
                        }

                        if (Fila.Rows[0]["famOcupacion"].ToString().Trim().Length > 0)
                        {
                            this.famOcupacion = Convert.ToString(Fila.Rows[0]["famOcupacion"]);
                        }
                        else
                        {
                            this.famOcupacion = "";
                        }

                        if (Fila.Rows[0]["famTelefonoCel"].ToString().Trim().Length > 0)
                        {
                            this.famTelefonoCel = Convert.ToString(Fila.Rows[0]["famTelefonoCel"]);
                        }
                        else
                        {
                            this.famTelefonoCel = "";
                        }

                        if (Fila.Rows[0]["famTelefonoFijo"].ToString().Trim().Length > 0)
                        {
                            this.famTelefonoFijo = Convert.ToString(Fila.Rows[0]["famTelefonoFijo"]);
                        }
                        else
                        {
                            this.famTelefonoFijo = "";
                        }


                        if (Fila.Rows[0]["famCuit"].ToString().Trim().Length > 0)
                        {
                            this.famCuit = Convert.ToString(Fila.Rows[0]["famCuit"]);
                        }
                        else
                        {
                            this.famCuit = "";
                        }

                        if (Fila.Rows[0]["famMail"].ToString().Trim().Length > 0)
                        {
                            this.famMail = Convert.ToString(Fila.Rows[0]["famMail"]);
                        }
                        else
                        {
                            this.famMail = "";
                        }

                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
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
                        if (Fila.Rows[0]["famFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.famFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["famFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.famFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["famFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.famFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["famFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.famFechaHoraUltimaModificacion = DateTime.Now;
                        }
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Familiar(Int32 famId, String famApellido, String famNombre, String famOcupacion, String famDni, String famTelefonoCel, String famTelefonoFijo, String famCuit, String famMail, Int32 usuId)
            {
                try
                {
                    this.famId = famId;
                    this.famApellido = famApellido;
                    this.famNombre = famNombre;
                    this.famOcupacion = famOcupacion;
                    this.famDni = famDni;
                    this.famTelefonoCel = famTelefonoCel;
                    this.famTelefonoFijo = famTelefonoFijo;
                    this.famCuit = famCuit;
                    this.famMail = famMail;
                    this.usuId = usuId;
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
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
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
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 famId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerUno]", new object[,] { { "@famId", famId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public Int32 ObtenerUnoFamId(Int32 famId)
            {
                Int32 IdMax;
                try

                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Familiar.ObtenerUnoFamId]", new object[,] { { "@famId", famId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return IdMax;
            }

            public DataTable ObtenerUnoPorDocString(String famDni)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerUnoPorDocString]", new object[,] { { "@famDni", famDni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoPorDoc(String famDni)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerUnoPorDoc]", new object[,] { { "@famDni", famDni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUnoxUsuId(int PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerUnoxUsuId]", new object[,] { { "@PrimerItem", PrimerItem } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerValidarRepetido(Int32 famId, String famApellido, String famNombre, String famOcupacion, String famDni, String famTelefonoCel, String famTelefonoFijo, String famCuit, String famMail, Int32 usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Familiar.ObtenerValidarRepetido]", new object[,] { { "@famId", famId }, { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel }, { "@famTelefonoFijo", famTelefonoFijo },{ "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 famId, String famApellido, String famNombre, String famOcupacion, String famDni, String famTelefonoCel, String famTelefonoFijo, String famCuit, String famMail, Int32 usuId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Familiar.Actualizar]", new object[,] { { "@famId", famId }, { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel }, { "@famTelefonoFijo", famTelefonoFijo },{ "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(Int32 famId, String famApellido, String famNombre, String famOcupacion, String famDni, String famTelefonoCel, String famTelefonoFijo, String famCuit, String famMail, int usuId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Familiar.Copiar]", new object[,] { { "@famId", famId }, { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel }, { "@famTelefonoFijo", famTelefonoFijo }, { "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });

                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void Eliminar(Int32 famId, Int32 aluId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Familiar.Eliminar]", new object[,] { { "@famId", famId }, { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 Insertar(String famApellido, String famNombre, String famOcupacion, String famDni, String famTelefonoCel, String famTelefonoFijo, String famCuit, String famMail, Int32 usuId, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime afaFechaHoraCreacion, DateTime afaFechaHoraUltimaModificacion)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Familiar.Insertar]", new object[,] { { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel }, { "@famTelefonoFijo", famTelefonoFijo },{ "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", afaFechaHoraCreacion }, { "@afaFechaHoraUltimaModificacion", afaFechaHoraUltimaModificacion } });

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
                    if (this.famId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Familiar.Actualizar]", new object[,] { { "@famId", famId }, { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel }, { "@famTelefonoFijo", famTelefonoFijo },{ "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@famFechaHoraCreacion", famFechaHoraCreacion }, { "@famFechaHoraUltimaModificacion", famFechaHoraUltimaModificacion } });

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
                    if (this.famId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Familiar.Copiar]", new object[,] { { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel },  { "@famTelefonoFijo", famTelefonoFijo },{ "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@afaFechaHoraCreacion", famFechaHoraCreacion }, { "@famFechaHoraUltimaModificacion", famFechaHoraUltimaModificacion } });

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
                    if (this.famId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Familiar.Eliminar]", new object[,] { { "@famId", famId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Familiar.Insertar]", new object[,] { { "@famApellido", famApellido }, { "@famNombre", famNombre }, { "@famOcupacion", famOcupacion }, { "@famDni", famDni }, { "@famTelefonoCel", famTelefonoCel },  { "@famTelefonoFijo", famTelefonoFijo }, { "@famCuit", famCuit }, { "@famMail", famMail }, { "@usuId", usuId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@famFechaHoraCreacion", famFechaHoraCreacion }, { "@famFechaHoraUltimaModificacion", famFechaHoraUltimaModificacion } });

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