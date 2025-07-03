using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Docentes
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _doc_id;
            public Int32 doc_id { get { return _doc_id; } set { _doc_id = value; } }

            private String _doc_doc;
            public String doc_doc { get { return _doc_doc; } set { _doc_doc = value; } }

            private String _doc_nombre;
            public String doc_nombre { get { return _doc_nombre; } set { _doc_nombre = value; } }

            private String _doc_apellido;
            public String doc_apellido { get { return _doc_apellido; } set { _doc_apellido = value; } }

            private String _doc_cuit;
            public String doc_cuit { get { return _doc_cuit; } set { _doc_cuit = value; } }

            private String _doc_domicilio;
            public String doc_domicilio { get { return _doc_domicilio; } set { _doc_domicilio = value; } }

            private String _doc_telef;
            public String doc_telef { get { return _doc_telef; } set { _doc_telef = value; } }

            private String _doc_mail;
            public String doc_mail { get { return _doc_mail; } set { _doc_mail = value; } }

            private Int32 _usu_id;
            public Int32 usu_id { get { return _usu_id; } set { _usu_id = value; } }

            private Int32 _perId;
            public Int32 perId { get { return _perId; } set { _perId = value; } }

            private DateTime _docFechaHoraCreacion;
            public DateTime docFechaHoraCreacion { get { return _docFechaHoraCreacion; } set { _docFechaHoraCreacion = value; } }

            private DateTime _docFechaHoraUltimaModificacion;
            public DateTime docFechaHoraUltimaModificacion { get { return _docFechaHoraUltimaModificacion; } set { _docFechaHoraUltimaModificacion = value; } }

            private Int32 _usuidCreacion;
            public Int32 usuidCreacion { get { return _usuidCreacion; } set { _usuidCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Docentes() { try { this.doc_id = 0; } catch (Exception oError) { throw oError; } }

            public Docentes(Int32 doc_id)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Docentes.ObtenerUno]", new object[,] { { "@doc_id", doc_id } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["doc_id"].ToString().Trim().Length > 0)
                        {
                            this.doc_id = Convert.ToInt32(Fila.Rows[0]["doc_id"]);
                        }
                        else
                        {
                            this.doc_id = 0;
                        }

                        if (Fila.Rows[0]["doc_doc"].ToString().Trim().Length > 0)
                        {
                            this.doc_doc = Convert.ToString(Fila.Rows[0]["doc_doc"]);
                        }
                        else
                        {
                            this.doc_doc = "";
                        }

                        if (Fila.Rows[0]["doc_nombre"].ToString().Trim().Length > 0)
                        {
                            this.doc_nombre = Convert.ToString(Fila.Rows[0]["doc_nombre"]);
                        }
                        else
                        {
                            this.doc_nombre = "";
                        }

                        if (Fila.Rows[0]["doc_apellido"].ToString().Trim().Length > 0)
                        {
                            this.doc_apellido = Convert.ToString(Fila.Rows[0]["doc_apellido"]);
                        }
                        else
                        {
                            this.doc_apellido = "";
                        }

                        if (Fila.Rows[0]["doc_cuit"].ToString().Trim().Length > 0)
                        {
                            this.doc_cuit = Convert.ToString(Fila.Rows[0]["doc_cuit"]);
                        }
                        else
                        {
                            this.doc_cuit = "";
                        }

                        if (Fila.Rows[0]["doc_domicilio"].ToString().Trim().Length > 0)
                        {
                            this.doc_domicilio = Convert.ToString(Fila.Rows[0]["doc_domicilio"]);
                        }
                        else
                        {
                            this.doc_domicilio = "";
                        }

                        if (Fila.Rows[0]["doc_telef"].ToString().Trim().Length > 0)
                        {
                            this.doc_telef = Convert.ToString(Fila.Rows[0]["doc_telef"]);
                        }
                        else
                        {
                            this.doc_telef = "";
                        }

                        if (Fila.Rows[0]["doc_mail"].ToString().Trim().Length > 0)
                        {
                            this.doc_mail = Convert.ToString(Fila.Rows[0]["doc_mail"]);
                        }
                        else
                        {
                            this.doc_mail = "";
                        }

                        if (Fila.Rows[0]["usu_id"].ToString().Trim().Length > 0)
                        {
                            this.usu_id = Convert.ToInt32(Fila.Rows[0]["usu_id"]);
                        }
                        else
                        {
                            this.usu_id = 0;
                        }

                        if (Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
                        }
                        if (Fila.Rows[0]["docFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.docFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["docFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.docFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["docFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.docFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["docFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.docFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["usuidCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuidCreacion = Convert.ToInt32(Fila.Rows[0]["usuidCreacion"]);
                        }
                        else
                        {
                            this.usuidCreacion = 0;
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

            public Docentes(Int32 doc_id, String doc_doc, String doc_nombre, String doc_apellido, String doc_cuit, String doc_domicilio, String doc_telef, String doc_mail, Int32 usu_id, Int32 perId, DateTime docFechaHoraCreacion, DateTime docFechaHoraUltimaModificacion, Int32 IusuidCreacion, Int32 IusuidUltimaModificacion)
            {
                try
                {
                    this.doc_id = doc_id;
                    this.doc_doc = doc_doc;
                    this.doc_nombre = doc_nombre;
                    this.doc_apellido = doc_apellido;
                    this.doc_cuit = doc_cuit;
                    this.doc_domicilio = doc_domicilio;
                    this.doc_telef = doc_telef;
                    this.doc_mail = doc_mail;
                    this.usu_id = usu_id;
                    this.perId = perId;
                    this.docFechaHoraCreacion = docFechaHoraCreacion;
                    this.docFechaHoraUltimaModificacion = docFechaHoraUltimaModificacion;
                    this.usuidCreacion = usuidCreacion;
                    this.usuidUltimaModificacion = usuidUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[Docentes.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 doc_id)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Docentes.ObtenerUno]", new object[,] { { "@doc_id", doc_id } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUnoxNombre(String Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Docentes.ObtenerUnoxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxDoc(string dni)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Docentes.ObtenerUnoxDoc]", new object[,] { { "@dni", dni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void Actualizar(Int32 doc_id, String doc_doc, String doc_nombre, String doc_apellido, String doc_domicilio, String doc_telef, String doc_mail, Int32 usu_id, Int32 usuidCreacion, Int32 usuidUltimaModificacion, DateTime docFechaHoraCreacion, DateTime docFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Docentes.Actualizar]", new object[,] { { "@doc_id", doc_id }, { "@doc_doc", doc_doc }, { "@doc_nombre", doc_nombre }, { "@doc_apellido", doc_apellido }, { "@doc_cuit", doc_cuit }, { "@doc_domicilio", doc_domicilio }, { "@doc_telef", doc_telef }, { "@doc_mail", doc_mail }, { "@usu_id", usu_id }, { "@perId", perId },{ "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@docFechaHoraCreacion", docFechaHoraCreacion }, { "@docFechaHoraUltimaModificacion", docFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 doc_id)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Docentes.Eliminar]", new object[,] { { "@doc_id", doc_id } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String doc_doc, String doc_nombre, String doc_apellido, String doc_domicilio, String doc_telef, String doc_mail, Int32 usu_id, Int32 perId, Int32 usuidCreacion, Int32 usuidUltimaModificacion, DateTime docFechaHoraCreacion, DateTime docFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Docentes.Insertar]", new object[,] { { "@doc_doc", doc_doc }, { "@doc_nombre", doc_nombre }, { "@doc_apellido", doc_apellido }, { "@doc_cuit", doc_cuit }, { "@doc_domicilio", doc_domicilio }, { "@doc_telef", doc_telef }, { "@doc_mail", doc_mail }, { "@usu_id", usu_id }, { "@perId", perId },{ "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@docFechaHoraCreacion", docFechaHoraCreacion }, { "@docFechaHoraUltimaModificacion", docFechaHoraUltimaModificacion } });
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
                    if (this.doc_id != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Docentes.Actualizar]", new object[,] { { "@doc_id", doc_id }, { "@doc_doc", doc_doc }, { "@doc_nombre", doc_nombre }, { "@doc_apellido", doc_apellido }, { "@doc_cuit", doc_cuit }, { "@doc_domicilio", doc_domicilio }, { "@doc_telef", doc_telef }, { "@doc_mail", doc_mail }, { "@usu_id", usu_id }, { "@perId", perId },{ "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@docFechaHoraCreacion", docFechaHoraCreacion }, { "@docFechaHoraUltimaModificacion", docFechaHoraUltimaModificacion } });
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
                    if (this.doc_id != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Docentes.Eliminar]", new object[,] { { "@doc_id", doc_id } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Docentes.Insertar]", new object[,] { { "@doc_doc", doc_doc }, { "@doc_nombre", doc_nombre }, { "@doc_apellido", doc_apellido }, { "@doc_cuit", doc_cuit }, { "@doc_domicilio", doc_domicilio }, { "@doc_telef", doc_telef }, { "@doc_mail", doc_mail }, { "@usu_id", usu_id }, { "@perId", perId },{ "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@docFechaHoraCreacion", docFechaHoraCreacion }, { "@docFechaHoraUltimaModificacion", docFechaHoraUltimaModificacion } });
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