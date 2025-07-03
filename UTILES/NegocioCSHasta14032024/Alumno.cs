using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Alumno
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _aluId;
            public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

            private String _aluNombre;
            public String aluNombre { get { return _aluNombre; } set { _aluNombre = value; } }

            private String _aluDoc;
            public String aluDoc { get { return _aluDoc; } set { _aluDoc = value; } }

            private String _aluCuit;
            public String aluCuit { get { return _aluCuit; } set { _aluCuit = value; } }

            private String _aluLegajoNumero;
            public String aluLegajoNumero { get { return _aluLegajoNumero; } set { _aluLegajoNumero = value; } }

            private String _aluDomicilio;
            public String aluDomicilio { get { return _aluDomicilio; } set { _aluDomicilio = value; } }

            private Int32 _aluDepto;
            public Int32 aluDepto { get { return _aluDepto; } set { _aluDepto = value; } }

            private DateTime _aluFechaNacimiento;
            public DateTime aluFechaNacimiento { get { return _aluFechaNacimiento; } set { _aluFechaNacimiento = value; } }

            private Int32 _aluPaisNac;
            public Int32 aluPaisNac { get { return _aluPaisNac; } set { _aluPaisNac = value; } }

            private Int32 _aluProvNac;
            public Int32 aluProvNac { get { return _aluProvNac; } set { _aluProvNac = value; } }

            private Int32 _aluDeptoNac;
            public Int32 aluDeptoNac { get { return _aluDeptoNac; } set { _aluDeptoNac = value; } }

            private Int32 _aluLocNac;
            public Int32 aluLocNac { get { return _aluLocNac; } set { _aluLocNac = value; } }

            private String _aluMail;
            public String aluMail { get { return _aluMail; } set { _aluMail = value; } }

            private String _aluTelefono;
            public String aluTelefono { get { return _aluTelefono; } set { _aluTelefono = value; } }

            private String _aluTelefonoCel;
            public String aluTelefonoCel { get { return _aluTelefonoCel; } set { _aluTelefonoCel = value; } }

            private Boolean _aluActivo;
            public Boolean aluActivo { get { return _aluActivo; } set { _aluActivo = value; } }

            private DateTime _aluFechaHoraCreacion;
            public DateTime aluFechaHoraCreacion { get { return _aluFechaHoraCreacion; } set { _aluFechaHoraCreacion = value; } }

            private DateTime _aluFechaHoraUltimaModificacion;
            public DateTime aluFechaHoraUltimaModificacion { get { return _aluFechaHoraUltimaModificacion; } set { _aluFechaHoraUltimaModificacion = value; } }

            private Int32 _sexId;
            public Int32 sexId { get { return _sexId; } set { _sexId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private Int32 _gsaId;
            public Int32 gsaId { get { return _gsaId; } set { _gsaId = value; } }
            private String _aluTelUrgencias;
            public String aluTelUrgencias { get { return _aluTelUrgencias; } set { _aluTelUrgencias = value; } }
            private String _aluDomFliar;
            public String aluDomFliar { get { return _aluDomFliar; } set { _aluDomFliar = value; } }
            private String _aluPreg1;
            public String aluPreg1 { get { return _aluPreg1; } set { _aluPreg1 = value; } }
            private String _aluPreg2;
            public String aluPreg2 { get { return _aluPreg2; } set { _aluPreg2 = value; } }
            private String _aluPreg3;
            public String aluPreg3 { get { return _aluPreg3; } set { _aluPreg3 = value; } }
            private String _aluPreg4;
            public String aluPreg4 { get { return _aluPreg4; } set { _aluPreg4 = value; } }
            private String _aluPreg5;
            public String aluPreg5 { get { return _aluPreg5; } set { _aluPreg5 = value; } }
            private String _aluPreg6;
            public String aluPreg6 { get { return _aluPreg6; } set { _aluPreg6 = value; } }
            private String _aluPreg7;
            public String aluPreg7 { get { return _aluPreg7; } set { _aluPreg7 = value; } }
            private String _aluAclara;
            public String aluAclara { get { return _aluAclara; } set { _aluAclara = value; } }

            #endregion

            #region Constructores

            public Alumno() { try { this.aluId = 0; } catch (Exception oError) { throw oError; } }

            public Alumno(Int32 aluId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Alumno.ObtenerUno]", new object[,] { { "@aluId", aluId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["aluId"].ToString().Trim().Length > 0)
                        {
                            this.aluId = Convert.ToInt32(Fila.Rows[0]["aluId"]);
                        }
                        else
                        {
                            this.aluId = 0;
                        }

                        if (Fila.Rows[0]["aluNombre"].ToString().Trim().Length > 0)
                        {
                            this.aluNombre = Convert.ToString(Fila.Rows[0]["aluNombre"]);
                        }
                        else
                        {
                            this.aluNombre = "";
                        }

                        if (Fila.Rows[0]["aluDoc"].ToString().Trim().Length > 0)
                        {
                            this.aluDoc = Convert.ToString(Fila.Rows[0]["aluDoc"]);
                        }
                        else
                        {
                            this.aluDoc = "";
                        }

                        if (Fila.Rows[0]["aluCuit"].ToString().Trim().Length > 0)
                        {
                            this.aluCuit = Convert.ToString(Fila.Rows[0]["aluCuit"]);
                        }
                        else
                        {
                            this.aluCuit = "";
                        }

                        if (Fila.Rows[0]["aluLegajoNumero"].ToString().Trim().Length > 0)
                        {
                            this.aluLegajoNumero = Convert.ToString(Fila.Rows[0]["aluLegajoNumero"]);
                        }
                        else
                        {
                            this.aluLegajoNumero = "";
                        }

                        if (Fila.Rows[0]["aluDomicilio"].ToString().Trim().Length > 0)
                        {
                            this.aluDomicilio = Convert.ToString(Fila.Rows[0]["aluDomicilio"]);
                        }
                        else
                        {
                            this.aluDomicilio = "";
                        }
                        if (Fila.Rows[0]["aluDepto"].ToString().Trim().Length > 0)
                        {
                            this.aluDepto = Convert.ToInt32(Fila.Rows[0]["aluDepto"]);
                        }
                        else
                        {
                            this.aluDepto = 0;
                        }

                        if (Fila.Rows[0]["aluFechaNacimiento"].ToString().Trim().Length > 0)
                        {
                            this.aluFechaNacimiento = Convert.ToDateTime(Fila.Rows[0]["aluFechaNacimiento"]);
                        }
                        else
                        {
                            this.aluFechaNacimiento = DateTime.Now;
                        }

                        if (Fila.Rows[0]["aluPaisNac"].ToString().Trim().Length > 0)
                        {
                            this.aluPaisNac = Convert.ToInt32(Fila.Rows[0]["aluPaisNac"]);
                        }
                        else
                        {
                            this.aluPaisNac = 0;
                        }

                        if (Fila.Rows[0]["aluProvNac"].ToString().Trim().Length > 0)
                        {
                            this.aluProvNac = Convert.ToInt32(Fila.Rows[0]["aluProvNac"]);
                        }
                        else
                        {
                            this.aluProvNac = 0;
                        }

                        if (Fila.Rows[0]["aluDeptoNac"].ToString().Trim().Length > 0)
                        {
                            this.aluDeptoNac = Convert.ToInt32(Fila.Rows[0]["aluDeptoNac"]);
                        }
                        else
                        {
                            this.aluDeptoNac = 0;
                        }

                        if (Fila.Rows[0]["aluLocNac"].ToString().Trim().Length > 0)
                        {
                            this.aluLocNac = Convert.ToInt32(Fila.Rows[0]["aluLocNac"]);
                        }
                        else
                        {
                            this.aluLocNac = 0;
                        }


                        if (Fila.Rows[0]["aluMail"].ToString().Trim().Length > 0)
                        {
                            this.aluMail = Convert.ToString(Fila.Rows[0]["aluMail"]);
                        }
                        else
                        {
                            this.aluMail = "";
                        }

                        if (Fila.Rows[0]["aluTelefono"].ToString().Trim().Length > 0)
                        {
                            this.aluTelefono = Convert.ToString(Fila.Rows[0]["aluTelefono"]);
                        }
                        else
                        {
                            this.aluTelefono = "";
                        }

                        if (Fila.Rows[0]["aluTelefonoCel"].ToString().Trim().Length > 0)
                        {
                            this.aluTelefonoCel = Convert.ToString(Fila.Rows[0]["aluTelefonoCel"]);
                        }
                        else
                        {
                            this.aluTelefonoCel = "";
                        }
                        if (Fila.Rows[0]["aluFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.aluFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["aluFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.aluFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["aluFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.aluFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["aluFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.aluFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["aluActivo"].ToString().Trim().Length > 0)
                        {
                            this.aluActivo = (Convert.ToInt32(Fila.Rows[0]["aluActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.aluActivo = false;
                        }

                        if (Fila.Rows[0]["sexId"].ToString().Trim().Length > 0)
                        {
                            this.sexId = Convert.ToInt32(Fila.Rows[0]["sexId"]);
                        }
                        else
                        {
                            this.sexId = 0;
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


                        if (Fila.Rows[0]["gsaId"].ToString().Trim().Length > 0)
                        {
                            this.gsaId = Convert.ToInt32(Fila.Rows[0]["gsaId"]);
                        }
                        else
                        {
                            this.gsaId = 0;
                        }

                        if (Fila.Rows[0]["aluTelUrgencias"].ToString().Trim().Length > 0)
                        {
                            this.aluTelUrgencias = Convert.ToString(Fila.Rows[0]["aluTelUrgencias"]);
                        }
                        else
                        {
                            this.aluTelUrgencias = "";
                        }
                        if (Fila.Rows[0]["aluDomFliar"].ToString().Trim().Length > 0)
                        {
                            this.aluDomFliar = Convert.ToString(Fila.Rows[0]["aluDomFliar"]);
                        }
                        else
                        {
                            this.aluDomFliar = "";
                        }
                        if (Fila.Rows[0]["aluPreg1"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg1 = Convert.ToString(Fila.Rows[0]["aluPreg1"]);
                        }
                        else
                        {
                            this.aluPreg2 = "";
                        }
                        if (Fila.Rows[0]["aluPreg1"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg2 = Convert.ToString(Fila.Rows[0]["aluPreg2"]);
                        }
                        else
                        {
                            this.aluPreg2 = "";
                        }
                        if (Fila.Rows[0]["aluPreg3"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg3 = Convert.ToString(Fila.Rows[0]["aluPreg3"]);
                        }
                        else
                        {
                            this.aluDomFliar = "";
                        }
                        if (Fila.Rows[0]["aluDomFliar"].ToString().Trim().Length > 0)
                        {
                            this.aluDomFliar = Convert.ToString(Fila.Rows[0]["aluDomFliar"]);
                        }
                        else
                        {
                            this.aluPreg3 = "";
                        }
                        if (Fila.Rows[0]["aluPreg4"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg4 = Convert.ToString(Fila.Rows[0]["aluPreg4"]);
                        }
                        else
                        {
                            this.aluPreg4 = "";
                        }
                        if (Fila.Rows[0]["aluPreg5"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg5 = Convert.ToString(Fila.Rows[0]["aluPreg5"]);
                        }
                        else
                        {
                            this.aluPreg5 = "";
                        }
                        if (Fila.Rows[0]["aluPreg6"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg6 = Convert.ToString(Fila.Rows[0]["aluPreg6"]);
                        }
                        else
                        {
                            this.aluPreg6 = "";
                        }
                        if (Fila.Rows[0]["aluPreg7"].ToString().Trim().Length > 0)
                        {
                            this.aluPreg7 = Convert.ToString(Fila.Rows[0]["aluPreg7"]);
                        }
                        else
                        {
                            this.aluPreg7 = "";
                        }
                        if (Fila.Rows[0]["aluAclara"].ToString().Trim().Length > 0)
                        {
                            this.aluAclara = Convert.ToString(Fila.Rows[0]["aluAclara"]);
                        }
                        else
                        {
                            this.aluAclara = "";
                        }
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Alumno(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, int gsaId,
                String aluTelUrgencias, String aluDomFliar, String aluPreg1, String aluPreg2, String aluPreg3, String aluPreg4, String aluPreg5, String aluPreg6, String aluPreg7, String aluAclara)
            {
                try
                {
                    this.aluId = aluId;
                    this.aluNombre = aluNombre;
                    this.aluDoc = aluDoc;
                    this.aluCuit = aluCuit;
                    this.aluLegajoNumero = aluLegajoNumero;
                    this.aluDomicilio = aluDomicilio;
                    this.aluDepto = aluDepto;
                    this.aluFechaNacimiento = aluFechaNacimiento;
                    this.aluMail = aluMail;
                    this.aluPaisNac = aluPaisNac;
                    this.aluProvNac = aluProvNac;
                    this.aluDeptoNac = aluDeptoNac;
                    this.aluLocNac = aluLocNac;
                    this.aluTelefono = aluTelefono;
                    this.aluTelefonoCel = aluTelefonoCel;
                    this.aluActivo = aluActivo;
                    this.aluFechaHoraCreacion = aluFechaHoraCreacion;
                    this.aluFechaHoraUltimaModificacion = aluFechaHoraUltimaModificacion;
                    this.sexId = sexId;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.gsaId = gsaId;
                    this.aluTelUrgencias = aluTelUrgencias;
                    this.aluDomFliar = aluDomFliar;
                    this.aluPreg1 = aluPreg1;
                    this.aluPreg2 = aluPreg2;
                    this.aluPreg3 = aluPreg3;
                    this.aluPreg4 = aluPreg4;
                    this.aluPreg5 = aluPreg5;
                    this.aluPreg6 = aluPreg6;
                    this.aluPreg7 = aluPreg7;
                    this.aluAclara = aluAclara;
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
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
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
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoBuscarxNombrexAnio(String Nombre, int Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerTodoBuscarxNombrexAnio]", new object[,] { { "@Nombre", Nombre }, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerUno]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(Int32 aluId, String aluNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerValidarRepetido]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void Actualizar(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, int gsaId, String aluTelUrgencias,String aluDomFliar, String aluPreg1, String aluPreg2,String aluPreg3,String aluPreg4,String aluPreg5,String aluPreg6,String aluPreg7,String aluAclara)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Alumno.Actualizar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion }, { "@gsaId", gsaId }, { "@aluTelUrgencias", aluTelUrgencias } , { "@aluDomFliar", aluDomFliar }, { "@aluPreg1", aluPreg1 },  { "@aluPreg2", aluPreg2 }, { "@aluPreg3", aluPreg3 }, { "@aluPreg4", aluPreg4 }, { "@aluPreg5", aluPreg5 } , { "@aluPreg6", aluPreg6 }, { "@aluPreg7", aluPreg7 }, { "@aluAclara", aluAclara } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(Int32 aluId, String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, int gsaId, String aluTelUrgencias, String aluDomFliar, String aluPreg1, String aluPreg2, String aluPreg3, String aluPreg4, String aluPreg5, String aluPreg6, String aluPreg7, String aluAclara)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Alumno.Copiar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion }, { "@gsaId", gsaId }, { "@aluTelUrgencias", aluTelUrgencias }, { "@aluDomFliar", aluDomFliar }, { "@aluPreg1", aluPreg1 }, { "@aluPreg2", aluPreg2 }, { "@aluPreg3", aluPreg3 }, { "@aluPreg4", aluPreg4 }, { "@aluPreg5", aluPreg5 }, { "@aluPreg6", aluPreg6 }, { "@aluPreg7", aluPreg7 }, { "@aluAclara", aluAclara } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 aluId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Alumno.Eliminar]", new object[,] { { "@aluId", aluId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(String aluNombre, String aluDoc, String aluCuit, String aluLegajoNumero, String aluDomicilio, Int32 aluDepto, DateTime aluFechaNacimiento, Int32 aluPaisNac, Int32 aluProvNac, Int32 aluDeptoNac, Int32 aluLocNac, String aluMail, String aluTelefono, String aluTlefonoCel, Boolean aluActivo, DateTime aluFechaHoraCreacion, DateTime aluFechaHoraUltimaModificacion, Int32 IsexId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, int gsaId, String aluTelUrgencias, String aluDomFliar, String aluPreg1, String aluPreg2, String aluPreg3, String aluPreg4, String aluPreg5, String aluPreg6, String aluPreg7, String aluAclara)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Alumno.Insertar]", new object[,] { { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion }, { "@gsaId", gsaId }, { "@aluTelUrgencias", aluTelUrgencias }, { "@aluDomFliar", aluDomFliar }, { "@aluPreg1", aluPreg1 }, { "@aluPreg2", aluPreg2 }, { "@aluPreg3", aluPreg3 }, { "@aluPreg4", aluPreg4 }, { "@aluPreg5", aluPreg5 }, { "@aluPreg6", aluPreg6 }, { "@aluPreg7", aluPreg7 }, { "@aluAclara", aluAclara } });
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
                    if (this.aluId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Alumno.Actualizar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion }, { "@gsaId", gsaId }, { "@aluTelUrgencias", aluTelUrgencias }, { "@aluDomFliar", aluDomFliar }, { "@aluPreg1", aluPreg1 }, { "@aluPreg2", aluPreg2 }, { "@aluPreg3", aluPreg3 }, { "@aluPreg4", aluPreg4 }, { "@aluPreg5", aluPreg5 }, { "@aluPreg6", aluPreg6 }, { "@aluPreg7", aluPreg7 }, { "@aluAclara", aluAclara } });
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
                    if (this.aluId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Alumno.Copiar]", new object[,] { { "@aluId", aluId }, { "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion }, { "@gsaId", gsaId }, { "@aluTelUrgencias", aluTelUrgencias }, { "@aluDomFliar", aluDomFliar }, { "@aluPreg1", aluPreg1 },  { "@aluPreg2", aluPreg2 }, { "@aluPreg3", aluPreg3 }, { "@aluPreg4", aluPreg4 }, { "@aluPreg5", aluPreg5 }, { "@aluPreg6", aluPreg6 }, { "@aluPreg7", aluPreg7 }, { "@aluAclara", aluAclara } });
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
                    if (this.aluId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Alumno.Eliminar]", new object[,] { { "@aluId", aluId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Alumno.Insertar]", new object[,] {{ "@aluNombre", aluNombre }, { "@aluDoc", aluDoc }, { "@aluCuit", aluCuit }, { "@aluLegajoNumero", aluLegajoNumero }, { "@aluDomicilio", aluDomicilio }, { "@aluDepto", aluDepto }, { "@aluFechaNacimiento", aluFechaNacimiento }, { "@aluPaisNac", aluPaisNac }, { "@aluProvNac", aluProvNac }, { "@aluDeptoNac", aluDeptoNac }, { "@aluLocNac", aluLocNac }, { "@sexId", sexId }, { "@aluMail", aluMail }, { "@aluTelefono", aluTelefono }, { "@aluTelefonoCel", aluTelefonoCel }, { "@aluActivo", aluActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@aluFechaHoraCreacion", aluFechaHoraCreacion }, { "@aluFechaHoraUltimaModificacion", aluFechaHoraUltimaModificacion }, { "@gsaId", gsaId }, { "@aluTelUrgencias", aluTelUrgencias }, { "@aluDomFliar", aluDomFliar }, { "@aluPreg1", aluPreg1 },{ "@aluPreg2", aluPreg2 }, { "@aluPreg3", aluPreg3 }, { "@aluPreg4", aluPreg4 }, { "@aluPreg5", aluPreg5 }, { "@aluPreg6", aluPreg6 }, { "@aluPreg7", aluPreg7 }, { "@aluAclara", aluAclara } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }


            public DataTable ObtenerUnoporDoc(String aluDoc)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerUnoPorDoc]", new object[,] { { "@aluDoc", aluDoc } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerUltimoId()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Alumno.ObtenerUltimoId]", new object[,] { });
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