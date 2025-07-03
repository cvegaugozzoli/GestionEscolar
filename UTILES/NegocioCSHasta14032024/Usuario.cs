using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Usuario
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _usuId;
            public Int32 usuId { get { return _usuId; } set { _usuId = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private String _usuApellido;
            public String usuApellido { get { return _usuApellido; } set { _usuApellido = value; } }

            private String _usuNombre;
            public String usuNombre { get { return _usuNombre; } set { _usuNombre = value; } }

            private String _usuNombreIngreso;
            public String usuNombreIngreso { get { return _usuNombreIngreso; } set { _usuNombreIngreso = value; } }

            private String _usuClave;
            public String usuClave { get { return _usuClave; } set { _usuClave = value; } }

            private String _usuClaveProvisoria;
            public String usuClaveProvisoria { get { return _usuClaveProvisoria; } set { _usuClaveProvisoria = value; } }

            private Boolean _usuCambiarClave;
            public Boolean usuCambiarClave { get { return _usuCambiarClave; } set { _usuCambiarClave = value; } }

            private String _usuEmail;
            public String usuEmail { get { return _usuEmail; } set { _usuEmail = value; } }

            private DateTime _usuFechaHoraCreacion;
            public DateTime usuFechaHoraCreacion { get { return _usuFechaHoraCreacion; } set { _usuFechaHoraCreacion = value; } }

            private DateTime _usuFechaHoraUltimaModificacion;
            public DateTime usuFechaHoraUltimaModificacion { get { return _usuFechaHoraUltimaModificacion; } set { _usuFechaHoraUltimaModificacion = value; } }

            private Boolean _usuActivo;
            public Boolean usuActivo { get { return _usuActivo; } set { _usuActivo = value; } }

            private Int32 _perId;
            public Int32 perId { get { return _perId; } set { _perId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Usuario() { try { this.usuId = 0; } catch (Exception oError) { throw oError; } }

            public Usuario(Int32 usuId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Usuario.ObtenerUno]", new object[,] { { "@usuId", usuId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
                        }

                        if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

                        if (Fila.Rows[0]["usuApellido"].ToString().Trim().Length > 0)
                        {
                            this.usuApellido = Convert.ToString(Fila.Rows[0]["usuApellido"]);
                        }
                        else
                        {
                            this.usuApellido = "";
                        }

                        if (Fila.Rows[0]["usuNombre"].ToString().Trim().Length > 0)
                        {
                            this.usuNombre = Convert.ToString(Fila.Rows[0]["usuNombre"]);
                        }
                        else
                        {
                            this.usuNombre = "";
                        }

                        if (Fila.Rows[0]["usuNombreIngreso"].ToString().Trim().Length > 0)
                        {
                            this.usuNombreIngreso = Convert.ToString(Fila.Rows[0]["usuNombreIngreso"]);
                        }
                        else
                        {
                            this.usuNombreIngreso = "";
                        }

                        if (Fila.Rows[0]["usuClave"].ToString().Trim().Length > 0)
                        {
                            this.usuClave = Convert.ToString(Fila.Rows[0]["usuClave"]);
                        }
                        else
                        {
                            this.usuClave = "";
                        }

                        if (Fila.Rows[0]["usuClaveProvisoria"].ToString().Trim().Length > 0)
                        {
                            this.usuClaveProvisoria = Convert.ToString(Fila.Rows[0]["usuClaveProvisoria"]);
                        }
                        else
                        {
                            this.usuClaveProvisoria = "";
                        }

                        if (Fila.Rows[0]["usuEmail"].ToString().Trim().Length > 0)
                        {
                            this.usuEmail = Convert.ToString(Fila.Rows[0]["usuEmail"]);
                        }
                        else
                        {
                            this.usuEmail = "";
                        }

                        if (Fila.Rows[0]["usuFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["usuFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.usuFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["usuFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["usuFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["usuCambiarClave"].ToString().Trim().Length > 0)
                        {
                            this.usuCambiarClave = (Convert.ToInt32(Fila.Rows[0]["usuCambiarClave"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.usuCambiarClave = false;
                        }

                        if (Fila.Rows[0]["usuActivo"].ToString().Trim().Length > 0)
                        {
                            this.usuActivo = (Convert.ToInt32(Fila.Rows[0]["usuActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.usuActivo = false;
                        }

                        if (Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
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

            public Usuario(Int32 usuId,Int32 insId, String usuApellido, String usuNombre, String usuNombreIngreso, String usuClave, String usuClaveProvisoria, Boolean usuCambiarClave, String usuEmail, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion, Boolean usuActivo, Int32 IperId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.usuId = usuId;
                    this.insId = insId;
                    this.usuApellido = usuApellido;
                    this.usuNombre = usuNombre;
                    this.usuNombreIngreso = usuNombreIngreso;
                    this.usuClave = usuClave;
                    this.usuClaveProvisoria = usuClaveProvisoria;
                    this.usuCambiarClave = usuCambiarClave;
                    this.usuEmail = usuEmail;
                    this.usuFechaHoraCreacion = usuFechaHoraCreacion;
                    this.usuFechaHoraUltimaModificacion = usuFechaHoraUltimaModificacion;
                    this.usuActivo = usuActivo;
                    this.perId = perId;
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


            public DataTable ObtenerAutenticar(String usuNombreIngreso, String usuClave)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerAutenticar]", new object[,] { { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerBuscador(String ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(String PrimerItem, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaCustom(String PrimerItem,Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerListaCustom]", new object[,] { { "@PrimerItem", PrimerItem }, { "@insId", insId }  });
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
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoBuscarxNombre(String Nombre,Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoCustom(String Nombre, String Apellido, String Usuario, Int32 perId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoCustom]", new object[,] { { "@Nombre", Nombre }, { "@Apellido", Apellido }, { "@Usuario", Usuario }, { "@perId", perId } , { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerUno]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoUsuarioEmail(String Usuario, String Email)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerUnoUsuarioEmail]", new object[,] { { "@Usuario", Usuario }, { "@Email", Email } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(Int32 usuId, String usuNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerValidarRepetido]", new object[,] { { "@usuId", usuId }, { "@usuNombre", usuNombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarSiExisteEmail(String Usuario, String Email)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerValidarSiExisteEmail]", new object[,] { { "@Usuario", Usuario }, { "@Email", Email } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void ActivarInactivar(Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.ActivarInactivar]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Actualizar(Int32 usuId, Int32 insId, String usuApellido, String usuNombre, String usuNombreIngreso, String usuClave, String usuClaveProvisoria, Boolean usuCambiarClave, String usuEmail, Int32 perId, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion, Boolean usuActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Actualizar]", new object[,] { { "@usuId", usuId },{ "@insId", insId }, { "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void BlanquearClave(Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.BlanquearClave]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void BlanquearClaveUsuarioEmail(String Usuario, String Email)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.BlanquearClaveUsuarioEmail]", new object[,] { { "@Usuario", Usuario }, { "@Email", Email } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void CambiarClave(Int32 usuId, String usuClave)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.CambiarClave]", new object[,] { { "@usuId", usuId }, { "@usuClave", usuClave } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(Int32 insId,String usuApellido, String usuNombre, String usuNombreIngreso, String usuClave, String usuClaveProvisoria, Boolean usuCambiarClave, String usuEmail, Int32 perId, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion, Boolean usuActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Copiar]", new object[,] { { "@insId", insId },  { "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 insId, String usuApellido, String usuNombre, String usuNombreIngreso, String usuClave, String usuClaveProvisoria, Boolean usuCambiarClave, String usuEmail, Int32 perId, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion, Boolean usuActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Insertar]", new object[,] {{ "@insId", insId }, { "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 InsertarTraerId(Int32 insId, String usuApellido, String usuNombre, String usuNombreIngreso, String usuClave, String usuClaveProvisoria, Boolean usuCambiarClave, String usuEmail, Int32 perId, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion, Boolean usuActivo)
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Usuario.Insertar]", new object[,] { { "@insId", insId },{ "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Usuario.Actualizar]", new object[,] { { "@usuId", usuId },{ "@insId", insId }, { "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Usuario.Copiar]", new object[,] { { "@insId", insId }, { "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", new object[,] { { "@usuId", usuId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Usuario.Insertar]", new object[,] { { "@insId", insId },{ "@usuApellido", usuApellido }, { "@usuNombre", usuNombre }, { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave }, { "@usuClaveProvisoria", usuClaveProvisoria }, { "@usuCambiarClave", usuCambiarClave }, { "@usuEmail", usuEmail }, { "@perId", perId }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion }, { "@usuActivo", usuActivo } });
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