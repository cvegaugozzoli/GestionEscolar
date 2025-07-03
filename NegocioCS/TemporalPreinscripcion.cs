using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TemporalPreinscripcion
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tpiId;
            public Int32 tpiId { get { return _tpiId; } set { _tpiId = value; } }

            private String _aluId;
            public String aluId { get { return _aluId; } set { _aluId = value; } }

            private String _tpihermano;
            public String tpihermano { get { return _tpihermano; } set { _tpihermano = value; } }

            private Boolean _tpiActivo;
            public Boolean tpiActivo { get { return _tpiActivo; } set { _tpiActivo = value; } }

            private String _tpiAfiliacion;
            public String tpiAfiliacion { get { return _tpiAfiliacion; } set { _tpiAfiliacion = value; } }

            private Int32 _usuId;
            public Int32 usuId { get { return _usuId; } set { _usuId = value; } }

            #endregion

            #region Constructores

            //public Empleado() { try { this.emeId = 0; } catch (Exception oError) { throw oError; } }

            //public Empleado(Int32 emeId)
            //{
            //    try
            //    {
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[Alumno.ObtenerUno]", new object[,] { { "@emeId", emeId } });

            //        if (Fila.Rows.Count > 0)
            //        {
            //            if (Fila.Rows[0]["emeId"].ToString().Trim().Length > 0)
            //            {
            //                this.emeId = Convert.ToInt32(Fila.Rows[0]["emeId"]);
            //            }
            //            else
            //            {
            //                this.emeId = 0;
            //            }

            //            if (Fila.Rows[0]["emeNombre"].ToString().Trim().Length > 0)
            //            {
            //                this.emeNombre = Convert.ToString(Fila.Rows[0]["emeNombre"]);
            //            }
            //            else
            //            {
            //                this.emeNombre = "";
            //            }

            //            if (Fila.Rows[0]["emeDoc"].ToString().Trim().Length > 0)
            //            {
            //                this.emeDoc = Convert.ToString(Fila.Rows[0]["emeDoc"]);
            //            }
            //            else
            //            {
            //                this.emeDoc = "";
            //            }


            //        }
            //        if (Fila.Rows[0]["emeFechaHoraCreacion"].ToString().Trim().Length > 0)
            //        {
            //            this.emeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["emeFechaHoraCreacion"]);
            //        }
            //        else
            //        {
            //            this.emeFechaHoraCreacion = DateTime.Now;
            //        }

            //        if (Fila.Rows[0]["emeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
            //        {
            //            this.emeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["emeFechaHoraUltimaModificacion"]);
            //        }
            //        else
            //        {
            //            this.emeFechaHoraUltimaModificacion = DateTime.Now;
            //        }

            //        if (Fila.Rows[0]["emeActivo"].ToString().Trim().Length > 0)
            //        {
            //            this.emeActivo = (Convert.ToInt32(Fila.Rows[0]["emeActivo"]) == 1 ? true : false);
            //        }
            //        else
            //        {
            //            this.emeActivo = false;
            //        }



            //        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
            //        {
            //            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
            //        }
            //        else
            //        {
            //            this.usuIdCreacion = 0;
            //        }

            //        if (Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
            //        {
            //            this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
            //        }
            //        else
            //        {
            //            this.usuIdUltimaModificacion = 0;
            //        }

            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public Alumno(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.aluId = aluId;
            //        this.aluNombre = aluNombre;
            //        this.aluDoc = aluDoc;
            //        this.aluCuit = aluCuit;
            //        this.aluLegajoNumero = aluLegajoNumero;
            //        this.aluDomicilio = aluDomicilio;
            //        this.aluDepto = aluDepto;
            //        this.aluFechaNacimiento = aluFechaNacimiento;
            //        this.aluMail = aluMail;
            //        this.aluPaisNac = aluPaisNac;
            //        this.aluProvNac = aluProvNac;
            //        this.aluDeptoNac = aluDeptoNac;
            //        this.aluLocNac = aluLocNac;
            //        this.aluTelefono = aluTelefono;
            //        this.aluTelefonoCel = aluTelefonoCel;
            //        this.aluActivo = aluActivo;
            //        this.aluFechaHoraCreacion = aluFechaHoraCreacion;
            //        this.aluFechaHoraUltimaModificacion = aluFechaHoraUltimaModificacion;
            //        this.sexId = sexId;
            //        this.usuIdCreacion = usuIdCreacion;
            //        this.usuIdUltimaModificacion = usuIdUltimaModificacion;
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            #endregion

            #region Metodos



            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerUno(Int32 aluId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerUno]", new object[,] { { "@aluId", aluId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerValidarRepetido(Int32 aluId, String aluNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerValidarRepetido]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Alumno.Actualizar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Alumno.Copiar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void Eliminar(Int32 tpiId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TemporalPreinscripcion.Eliminar]", new object[,] { { "@tpiId", tpiId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
   public void EliminarxAluId(Int32 aluId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[TemporalPreinscripcion.EliminarxAluId]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            //public void Insertar(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Alumno.Insertar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Actualizar()
            //{
            //    try
            //    {
            //        if (this.aluId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Alumno.Actualizar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar()
            //{
            //    try
            //    {
            //        if (this.aluId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Alumno.Copiar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Eliminar()
            //{
            //    try
            //    {
            //        if (this.aluId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Alumno.Eliminar]", new object[,] { { "@aluId", aluId } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public Int32 Insertar(string doc, int aluHermano, Boolean tpiActivo, String tpiAfiliacion, String Nombre,int usuId)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[TemporalPreinscripcion.Insertar]", new object[,] { { "@doc", doc }, { "@aluHermano", aluHermano }, { "@tpiActivo", tpiActivo } , { "@tpiAfiliacion", tpiAfiliacion }, { "@Nombre", Nombre }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            public DataTable ObtenerUnoxDoc(string doc)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TemporalPreinscripcion.ObtenerUnoxDoc]", new object[,] { { "@doc", doc } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            #endregion
        }
    }
}