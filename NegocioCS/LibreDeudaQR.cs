using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class LibreDeudaQR
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _ldpId;
            public Int32 ldpId { get { return _ldpId; } set { _ldpId = value; } }

            private Int32 _ldpaluId;
            public Int32 ldpaluId { get { return _ldpaluId; } set { _ldpaluId = value; } }

            private String _ldpNombre;
            public String ldpNombre { get { return _ldpNombre; } set { _ldpNombre = value; } }

            private String _ldpDNI;
            public String ldpDNI { get { return _ldpDNI; } set { _ldpDNI = value; } }

            private String _ldpCurso;
            public String ldpCurso { get { return _ldpCurso; } set { _ldpCurso = value; } }

            private String _ldpInst;
            public String ldpInst { get { return _ldpInst; } set { _ldpInst = value; } }

            private String _ldpMes;
            public String ldpMes { get { return _ldpMes; } set { _ldpMes = value; } }

            private String _ldpAnio;
            public String ldpAnio { get { return _ldpAnio; } set { _ldpAnio = value; } }

            private Boolean _ldpFecImpresion;
            public Boolean ldpFecImpresion { get { return _ldpFecImpresion; } set { _ldpFecImpresion = value; } }

            private String _ldpConcepto;
            public String ldpConcepto { get { return _ldpConcepto; } set { _ldpConcepto = value; } }

            private String _ldpMesPago;
            public String ldpMesPago { get { return _ldpMesPago; } set { _ldpMesPago = value; } }

            #endregion

            #region Constructores

            public LibreDeudaQR() { try { this.ldpId = 0; } catch (Exception oError) { throw oError; } }

            public LibreDeudaQR(Int32 ldpId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[LibreDeudaQR.ObtenerUno]", new object[,] { { "@ldpId", ldpId } });

                    if (Fila.Rows.Count > 0)
                    {
                        //if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        //{
                        //    this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        //}
                        //else
                        //{
                        //    this.insId = 0;
                        //}

                        //if (Fila.Rows[0]["insNombre"].ToString().Trim().Length > 0)
                        //{
                        //    this.insNombre = Convert.ToString(Fila.Rows[0]["insNombre"]);
                        //}
                        //else
                        //{
                        //    this.insNombre = "";
                        //}

                        //if (Fila.Rows[0]["insCodigo"].ToString().Trim().Length > 0)
                        //{
                        //    this.insCodigo = Convert.ToString(Fila.Rows[0]["insCodigo"]);
                        //}
                        //else
                        //{
                        //    this.insCodigo = "";
                        //}

                        //if (Fila.Rows[0]["insDireccion"].ToString().Trim().Length > 0)
                        //{
                        //    this.insDireccion = Convert.ToString(Fila.Rows[0]["insDireccion"]);
                        //}
                        //else
                        //{
                        //    this.insDireccion = "";
                        //}

                        //if (Fila.Rows[0]["insTelefono"].ToString().Trim().Length > 0)
                        //{
                        //    this.insTelefono = Convert.ToString(Fila.Rows[0]["insTelefono"]);
                        //}
                        //else
                        //{
                        //    this.insTelefono = "";
                        //}

                        //if (Fila.Rows[0]["insCUIT"].ToString().Trim().Length > 0)
                        //{
                        //    this.insCUIT = Convert.ToString(Fila.Rows[0]["insCUIT"]);
                        //}
                        //else
                        //{
                        //    this.insCUIT = "";
                        //}

                        //if (Fila.Rows[0]["insMail"].ToString().Trim().Length > 0)
                        //{
                        //    this.insMail = Convert.ToString(Fila.Rows[0]["insMail"]);
                        //}
                        //else
                        //{
                        //    this.insMail = "";
                        //}

                        //if (Fila.Rows[0]["insFechaHoraCreacion"].ToString().Trim().Length > 0)
                        //{
                        //    this.insFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["insFechaHoraCreacion"]);
                        //}
                        //else
                        //{
                        //    this.insFechaHoraCreacion = DateTime.Now;
                        //}

                        //if (Fila.Rows[0]["insFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        //{
                        //    this.insFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["insFechaHoraUltimaModificacion"]);
                        //}
                        //else
                        //{
                        //    this.insFechaHoraUltimaModificacion = DateTime.Now;
                        //}

                        //if (Fila.Rows[0]["insGrupo"].ToString().Trim().Length > 0)
                        //{
                        //    this.insGrupo = (Convert.ToInt32(Fila.Rows[0]["insGrupo"]) == 1 ? true : false);
                        //}
                        //else
                        //{
                        //    this.insGrupo = false;
                        //}

                        //if (Fila.Rows[0]["insActivo"].ToString().Trim().Length > 0)
                        //{
                        //    this.insActivo = (Convert.ToInt32(Fila.Rows[0]["insActivo"]) == 1 ? true : false);
                        //}
                        //else
                        //{
                        //    this.insActivo = false;
                        //}

                        //if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        //{
                        //    this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        //}
                        //else
                        //{
                        //    this.usuIdCreacion = 0;
                        //}

                        //if (Fila.Rows[0]["usuidUltimaModificacion"].ToString().Trim().Length > 0)
                        //{
                        //    this.usuidUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuidUltimaModificacion"]);
                        //}
                        //else
                        //{
                        //    this.usuidUltimaModificacion = 0;
                        //}
                        //if (Fila.Rows[0]["insRecaxUsuario"].ToString().Trim().Length > 0)
                        //{
                        //    this.insRecaxUsuario = Convert.ToInt32(Fila.Rows[0]["insRecaxUsuario"]);
                        //}
                        //else
                        //{
                        //    this.insRecaxUsuario = 0;
                        //}
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //         public Instituciones(Int32 insId, String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion, Int32 insRecaxUsuario)
            //{
            //             try
            //             {
            //	    this.insId = insId;
            //	    this.insNombre = insNombre;
            //	    this.insCodigo = insCodigo;
            //	    this.insDireccion = insDireccion;
            //	    this.insTelefono = insTelefono;
            //	    this.insCUIT = insCUIT;
            //	    this.insMail = insMail;
            //	    this.insGrupo = insGrupo;
            //	    this.insActivo = insActivo;
            //	    this.insFechaHoraCreacion = insFechaHoraCreacion;
            //	    this.insFechaHoraUltimaModificacion = insFechaHoraUltimaModificacion;
            //	    this.usuIdCreacion = usuIdCreacion;
            //	    this.usuidUltimaModificacion = usuidUltimaModificacion;
            //	    this.insRecaxUsuario = insRecaxUsuario;

            //             }
            //    catch (Exception oError)
            //             {
            //                 throw oError;
            //             }
            //         }
            #endregion

            #region Metodos


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable VerificarQR(String Inst, Int32 aluId, Int32 mes, Int32 Anio, String Concepto,String MesPago)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LibreDeudaQR.VerificarQR]", new object[,] { { "@Inst", Inst }, { "@aluId", aluId }, { "@mes", mes }, { "@Anio", Anio } , { "@Concepto", Concepto }, { "@MesPago", MesPago } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerUno(Int32 insId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUno]", new object[,] {{"@insId", insId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}
            //       public DataTable ObtenerUnoxaluIdxAnio(Int32 aluId,Int32 Anio)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUnoxaluIdxAnio]", new object[,] {{"@insId", insId}, { "@Anio", Anio } });
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}			
            public DataTable InformeLibreDeudaQR(Int32 aluId, Int32 mes, Int32 inst)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InformeLibreDeudaQR]", new object[,] { { "@aluId", aluId }, { "@mes", mes }, { "@inst", inst } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public void Actualizar(Int32 insId, String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 insRecaxUsuario)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Actualizar]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Copiar(String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 insRecaxUsuario)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Copiar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Eliminar(Int32 insId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Eliminar]", new object[,] {{"@insId", insId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            public void Insertar(Int32 ldpaluId, String ldpNombre, String ldpDNI, String ldpCurso, String ldpInst, String ldpMes, Int32 ldpAnio, DateTime ldpFecImpresion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LibreDeudaQR.Insertar]", new object[,] { { "@ldpaluId", ldpaluId }, { "@ldpNombre", ldpNombre }, { "@ldpDNI", ldpDNI }, { "@ldpCurso", ldpCurso }, { "@ldpInst", ldpInst }, { "@ldpMes", ldpMes }, { "@ldpAnio", ldpAnio }, { "@ldpFecImpresion", ldpFecImpresion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void InsertarSinoExiste(Int32 ldpaluId, String ldpNombre, String ldpDNI, String ldpCurso, String ldpInst, String ldpMes, Int32 ldpAnio, DateTime ldpFecImpresion, String ldpConcepto, String ldpMesPago)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LibreDeudaQR.InsertarSinoExiste]", new object[,] { { "@ldpaluId", ldpaluId }, { "@ldpNombre", ldpNombre }, { "@ldpDNI", ldpDNI }, { "@ldpCurso", ldpCurso }, { "@ldpInst", ldpInst }, { "@ldpMes", ldpMes }, { "@ldpAnio", ldpAnio }, { "@ldpFecImpresion", ldpFecImpresion }, { "@ldpConcepto", ldpConcepto }, { "@ldpMesPago", ldpMesPago } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            //public void Actualizar()
            //{
            //    try
            //    {
            //        if(this.insId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Instituciones.Actualizar]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}




            //        public void InformeLibreDeudaQR()
            //        {
            //            try
            //            {
            //                //if (this.insId != 0)
            //                //{
            //                ocdGestor.EjecutarNonQuery("[LibreDeudaQR.Insertar]", new object[,] { { "@insNombre", insNombre }, { "@insCodigo", insCodigo }, { "@insDireccion", insDireccion }, { "@insTelefono", insTelefono }, { "@insCUIT", insCUIT }, { "@insMail", insMail }, { "@insGrupo", insGrupo }, { "@insActivo", insActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuidUltimaModificacion", usuidUltimaModificacion }, { "@insFechaHoraCreacion", insFechaHoraCreacion }, { "@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion }, { "@insRecaxUsuario", insRecaxUsuario } });
            //            }
            //            }
            //            catch (Exception oError)
            //            {
            //                throw oError;
            //            }
            //}

            //public void Eliminar()
            //{
            //    try
            //    {
            //        if(this.insId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Instituciones.Eliminar]", new object[,] {{"@insId", insId}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[LibreDeudaQR.Insertar]", new object[,] { { "@ldpaluId", ldpaluId }, { "@ldpNombre", ldpNombre }, { "@ldpDNI", ldpDNI }, { "@ldpCurso", ldpCurso }, { "@ldpInst", ldpInst }, { "@ldpMes", ldpMes }, { "@ldpAnio", ldpAnio }, { "@ldpFecImpresion", ldpFecImpresion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            //public DataTable ObtenerUnoPorCodigo(String insCodigo)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUnoporCodigo]", new object[,] { { "@insCodigo", insCodigo } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}


            #endregion
        }
    }
}