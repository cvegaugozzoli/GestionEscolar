using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class AlumnosDebitos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _adeId;
            public Int32 adeId { get { return _adeId; } set { _adeId = value; } }

            private Int32 _aluId;
            public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

            private String _adeDNITitular;
            public String adeDNITitular { get { return _adeDNITitular; } set { _adeDNITitular = value; } }

            private String _adeApeNom;
            public String adeApeNom { get { return _adeApeNom; } set { _adeApeNom = value; } }

            private Int32 _banId;
            public Int32 banId { get { return _banId; } set { _banId = value; } }

            private String _adeCBU;
            public String adeCBU { get { return _adeCBU; } set { _adeCBU = value; } }

            private String _adeLugarTrabajo;
            public String adeLugarTrabajo { get { return _adeLugarTrabajo; } set { _adeLugarTrabajo = value; } }

            private Int32 _adeFchProbCobro;
            public Int32 adeFchProbCobro { get { return _adeFchProbCobro; } set { _adeFchProbCobro = value; } }

            private String _adeMail;
            public String adeMail { get { return _adeMail; } set { _adeMail = value; } }

            private String _adeCelular;
            public String adeCelular { get { return _adeCelular; } set { _adeCelular = value; } }

            private Int32 _tcuId;
            public Int32 tcuId { get { return _tcuId; } set { _tcuId = value; } }
            private DateTime _adeFchInicio;
            public DateTime adeFchInicio { get { return _adeFchInicio; } set { _adeFchInicio = value; } }

            private DateTime? _adeFchBaja;
            public DateTime? adeFchBaja { get { return _adeFchBaja; } set { _adeFchBaja = value; } }

            private Int32 _adeUsuarioBaja;
            public Int32 adeUsuarioBaja { get { return _adeUsuarioBaja; } set { _adeUsuarioBaja = value; } }

            private Boolean _adeActivo;
            public Boolean adeActivo { get { return _adeActivo; } set { _adeActivo = value; } }

            private DateTime _adeFechaHoraCreacion;
            public DateTime adeFechaHoraCreacion { get { return _adeFechaHoraCreacion; } set { _adeFechaHoraCreacion = value; } }

            private DateTime _adeFechaHoraUltimaModificacion;
            public DateTime adeFechaHoraUltimaModificacion { get { return _adeFechaHoraUltimaModificacion; } set { _adeFechaHoraUltimaModificacion = value; } }

            private Int32 _usuidCreacion;
            public Int32 usuidCreacion { get { return _usuidCreacion; } set { _usuidCreacion = value; } }

            private Int32 _usuidUltimaModificacion;
            public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public AlumnosDebitos() { try { this._adeId = 0; } catch (Exception oError) { throw oError; } }

            public AlumnosDebitos(Int32 adeId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUno]", new object[,] { { "@adeId", adeId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["adeId"].ToString().Trim().Length > 0)
                        {
                            this.adeId = Convert.ToInt32(Fila.Rows[0]["adeId"]);
                        }
                        else
                        {
                            this.adeId = 0;
                        }

                        if (Fila.Rows[0]["aluId"].ToString().Trim().Length > 0)
                        {
                            this.aluId = Convert.ToInt32(Fila.Rows[0]["aluId"]);
                        }
                        else
                        {
                            this.aluId = 0;
                        }

                        if (Fila.Rows[0]["adeDNITitular"].ToString().Trim().Length > 0)
                        {
                            this.adeDNITitular = Convert.ToString(Fila.Rows[0]["adeDNITitular"]);
                        }
                        else
                        {
                            this.adeDNITitular = "";
                        }

                        if (Fila.Rows[0]["adeApeNom"].ToString().Trim().Length > 0)
                        {
                            this.adeApeNom = Convert.ToString(Fila.Rows[0]["adeApeNom"]);
                        }
                        else
                        {
                            this.adeApeNom = "";
                        }

                        if (Fila.Rows[0]["banId"].ToString().Trim().Length > 0)
                        {
                            this.banId = Convert.ToInt32(Fila.Rows[0]["banId"]);
                        }
                        else
                        {
                            this.banId = 0;
                        }

                        if (Fila.Rows[0]["adeCBU"].ToString().Trim().Length > 0)
                        {
                            this.adeCBU = Convert.ToString(Fila.Rows[0]["adeCBU"]);
                        }
                        else
                        {
                            this.adeCBU = "";
                        }

                        if (Fila.Rows[0]["adeLugarTrabajo"].ToString().Trim().Length > 0)
                        {
                            this.adeLugarTrabajo = Convert.ToString(Fila.Rows[0]["adeLugarTrabajo"]);
                        }
                        else
                        {
                            this.adeLugarTrabajo = "";
                        }

                        if (Fila.Rows[0]["adeFchProbCobro"].ToString().Trim().Length > 0)
                        {
                            this.adeFchProbCobro = Convert.ToInt32(Fila.Rows[0]["adeFchProbCobro"]);
                        }
                        else
                        {
                            this.adeFchProbCobro = 0;
                        }

                        if (Fila.Rows[0]["adeMail"].ToString().Trim().Length > 0)
                        {
                            this.adeMail = Convert.ToString(Fila.Rows[0]["adeMail"]);
                        }
                        else
                        {
                            this.adeMail = "";
                        }

                        if (Fila.Rows[0]["adeCelular"].ToString().Trim().Length > 0)
                        {
                            this.adeCelular = Convert.ToString(Fila.Rows[0]["adeCelular"]);
                        }
                        else
                        {
                            this.adeCelular = "";
                        }

                        if (Fila.Rows[0]["tcuId"].ToString().Trim().Length > 0)
                        {
                            this.tcuId = Convert.ToInt32(Fila.Rows[0]["tcuId"]);
                        }
                        else
                        {
                            this.tcuId = 0;
                        }

                        if (Fila.Rows[0]["adeFchInicio"].ToString().Trim().Length > 0)
                        {
                            this.adeFchInicio = Convert.ToDateTime(Fila.Rows[0]["adeFchInicio"]);
                        }
                        else
                        {
                            this.adeFchInicio = DateTime.Now;
                        }
                        if (Fila.Rows[0]["adeFchBaja"].ToString().Trim().Length > 0)
                        {
                            this.adeFchBaja = Convert.ToDateTime(Fila.Rows[0]["adeFchBaja"]);
                        }
                        else
                        {
                            this.adeFchBaja = null;
                        }

                        if (Fila.Rows[0]["adeUsuarioBaja"].ToString().Trim().Length > 0)
                        {
                            this.adeUsuarioBaja = Convert.ToInt32(Fila.Rows[0]["adeUsuarioBaja"]);
                        }
                        else
                        {
                            this.adeUsuarioBaja = 0;
                        }


                        if (Fila.Rows[0]["adeActivo"].ToString().Trim().Length > 0)
                        {
                            this.adeActivo = Convert.ToBoolean(Fila.Rows[0]["adeActivo"]);
                        }
                        else
                        {
                            this.adeActivo = true;
                        }

                        if (Fila.Rows[0]["adeFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.adeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["adeFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.adeFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["adeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.adeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["adeFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.adeFechaHoraUltimaModificacion = DateTime.Now;
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

            public AlumnosDebitos(Int32 adeId, Int32 aluId, String adeDNITitular, String adeApeNom, Int32 banId,
                String adeCBU, String adeLugarTrabajo, Int32 adeFchProbCobro, String adeMail, String adeCelular,
                Int32 tcuId, DateTime adeFchInicio, DateTime? adeFchBaja, Int32 adeUsuarioBaja, Boolean adeActivo, DateTime adeFechaHoraCreacion, DateTime adeFechaHoraUltimaModificacion, Int32 usuidCreacion, Int32 usuidUltimaModificacion)
            {
                try
                {
                    this.adeId = adeId;
                    this.aluId = aluId;
                    this.adeDNITitular = adeDNITitular;
                    this.adeApeNom = adeApeNom;
                    this.banId = banId;
                    this.adeCBU = adeCBU;
                    this.adeLugarTrabajo = adeLugarTrabajo;
                    this.adeFchProbCobro = adeFchProbCobro;
                    this.adeMail = adeMail;
                    this.adeCelular = adeCelular;
                    this.tcuId = tcuId;
                    this.adeFchInicio = adeFchInicio;
                    this.adeFchBaja = adeFchBaja;
                    this.adeUsuarioBaja = adeUsuarioBaja;
                    this.adeActivo = adeActivo;
                    this.adeFechaHoraCreacion = adeFechaHoraCreacion;
                    this.adeFechaHoraUltimaModificacion = adeFechaHoraUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUno]", new object[,] { { "@adeId", adeId } });
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUnoxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxNombrexBajas(String Nombre, Boolean chkBajas)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUnoxNombrexBajas]", new object[,] { { "@Nombre", Nombre } ,{ "@chkBajas", chkBajas } });
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
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUnoxDoc]", new object[,] { { "@dni", dni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerAlumnosxDoc(string dni)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerAlumnosxDoc]", new object[,] { { "@dni", dni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxaluId(int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUnoxaluId]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUnoxDocxaluId(string dni, int aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[AlumnosDebitos.ObtenerUnoxDocxaluId]", new object[,] { { "@dni", dni }, { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            //public void Actualizar(Int32 doc_id, String doc_doc, String doc_nombre, String doc_apellido, String doc_domicilio, String doc_telef, String doc_mail, Int32 usu_id, Int32 usuidCreacion, Int32 usuidUltimaModificacion, DateTime docFechaHoraCreacion, DateTime docFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[AlumnosDebitos.Actualizar]", new object[,] { { "@doc_id", doc_id }, { "@doc_doc", doc_doc }, { "@doc_nombre", doc_nombre }, { "@doc_apellido", doc_apellido }, { "@doc_cuit", doc_cuit }, { "@doc_domicilio", doc_domicilio }, { "@doc_telef", doc_telef }, { "@doc_mail", doc_mail }, { "@usu_id", usu_id }, { "@perId", perId }, { "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@docFechaHoraCreacion", docFechaHoraCreacion }, { "@docFechaHoraUltimaModificacion", docFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void Eliminar(Int32 adeId, Int32 UsuarioBaja, DateTime FchBaja)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[AlumnosDebitos.Eliminar]", new object[,] { { "@adeId", adeId },{ "@UsuarioBaja", UsuarioBaja }, { "@FchBaja", FchBaja } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public void Insertar(String doc_doc, String doc_nombre, String doc_apellido, String doc_domicilio, String doc_telef, String doc_mail, Int32 usu_id, Int32 perId, Int32 usuidCreacion, Int32 usuidUltimaModificacion, DateTime docFechaHoraCreacion, DateTime docFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[AlumnosDebitos.Insertar]", new object[,] { { "@doc_doc", doc_doc }, { "@doc_nombre", doc_nombre }, { "@doc_apellido", doc_apellido }, { "@doc_cuit", doc_cuit }, { "@doc_domicilio", doc_domicilio }, { "@doc_telef", doc_telef }, { "@doc_mail", doc_mail }, { "@usu_id", usu_id }, { "@perId", perId }, { "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@docFechaHoraCreacion", docFechaHoraCreacion }, { "@docFechaHoraUltimaModificacion", docFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void Actualizar()
            {
                try
                {
                    if (this.adeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery2("[AlumnosDebitos.Actualizar]", new object[,] { { "@adeId", adeId }, { "@aluId", aluId }, { "@adeDNITitular", adeDNITitular }, { "@adeApeNom", adeApeNom }, { "@banId", banId }, { "@adeCBU", adeCBU }, { "@adeLugarTrabajo", adeLugarTrabajo }, { "@adeFchProbCobro", adeFchProbCobro }, { "@adeMail", adeMail }, { "@adeCelular", adeCelular }, { "@tcuId", tcuId }, { "@adeFchInicio", adeFchInicio }, { "@adeFchBaja", adeFchBaja },{ "@adeUsuarioBaja", adeUsuarioBaja }, { "@adeActivo", adeActivo }, { "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@adeFechaHoraCreacion", adeFechaHoraCreacion }, { "@adeFechaHoraUltimaModificacion", adeFechaHoraUltimaModificacion } });
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
                    if (this.adeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[AlumnosDebitos.Eliminar]", new object[,] { { "@adeId", adeId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId2("[AlumnosDebitos.Insertar]", new object[,] {{ "@aluId", aluId }, { "@adeDNITitular", adeDNITitular }, { "@adeApeNom", adeApeNom }, { "@banId", banId }, { "@adeCBU", adeCBU }, { "@adeLugarTrabajo", adeLugarTrabajo }, { "@adeFchProbCobro", adeFchProbCobro }, { "@adeMail", adeMail }, { "@adeCelular", adeCelular }, { "@tcuId", tcuId }, { "@adeFchInicio", adeFchInicio }, { "@adeFchBaja", adeFchBaja }, { "@adeUsuarioBaja", adeUsuarioBaja }, { "@adeActivo", adeActivo }, { "@usuidCreacion", usuidCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@adeFechaHoraCreacion", adeFechaHoraCreacion }, { "@adeFechaHoraUltimaModificacion", adeFechaHoraUltimaModificacion } });
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