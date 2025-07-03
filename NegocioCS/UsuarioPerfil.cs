using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class UsuarioPerfil
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _upeId;
            public Int32 upeId { get { return _upeId; } set { _upeId = value; } }

            private Int32 _usuId;
            public Int32 usuId { get { return _usuId; } set { _usuId = value; } }

            private Int32 _perId;
            public Int32 perId { get { return _perId; } set { _perId = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private DateTime _upeFechaHoraCreacion;
            public DateTime upeFechaHoraCreacion { get { return _upeFechaHoraCreacion; } set { _upeFechaHoraCreacion = value; } }

            private DateTime _upeFechaHoraUltimaModificacion;
            public DateTime upeFechaHoraUltimaModificacion { get { return _upeFechaHoraUltimaModificacion; } set { _upeFechaHoraUltimaModificacion = value; } }

            private Boolean _upeActivo;
            public Boolean upeActivo { get { return _upeActivo; } set { _upeActivo = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public UsuarioPerfil() { try { this.upeId = 0; } catch (Exception oError) { throw oError; } }

            public UsuarioPerfil(Int32 upeId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerUno]", new object[,] { { "@upeId", upeId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["upeId"].ToString().Trim().Length > 0)
                        {
                            this.upeId = Convert.ToInt32(Fila.Rows[0]["upeId"]);
                        }
                        else
                        {
                            this.upeId = 0;
                        }

                        if (Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
                        }

                        if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }
                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
                        }



                        if (Fila.Rows[0]["upeFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.upeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["upeFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.upeFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["upeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.upeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["upeFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.upeFechaHoraUltimaModificacion = DateTime.Now;
                        }


                        if (Fila.Rows[0]["upeActivo"].ToString().Trim().Length > 0)
                        {
                            this.upeActivo = (Convert.ToInt32(Fila.Rows[0]["upeActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.upeActivo = false;
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

            //public Perfil(Int32 perId, String perNombre, String perDescripcion, Boolean perEsAdministrador, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.perId = perId;
            //        this.perNombre = perNombre;
            //        this.perDescripcion = perDescripcion;
            //        this.perEsAdministrador = perEsAdministrador;
            //        this.perFechaHoraCreacion = perFechaHoraCreacion;
            //        this.perFechaHoraUltimaModificacion = perFechaHoraUltimaModificacion;
            //        this.perActivo = perActivo;
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



            public DataTable ObtenerListaxusuId(String PrimerItem, Int32 usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerListaxusuId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerLista(String PrimerItem, Int32 usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerTodoxusuIdxInsId(int usuId, int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerTodoxusuIdxInsId]", new object[,] { { "@usuId", usuId }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxusuIdxPerId(int usuId, int perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerTodoxusuIdxPerId]", new object[,] { { "@usuId", usuId }, { "@perId", perId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerPerIdxusuIdxInsId(int usuId, int perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerPerIdxusuIdxInsId]", new object[,] { { "@usuId", usuId }, { "@perId", perId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerunoxusuIdxPerIdxinsId(int usuId, Int32 perId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerunoxusuIdxPerIdxinsId]", new object[,] { { "@usuId", usuId }, { "@perId", perId }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaPerIdxusuId(String PrimerItem, Int32 usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerListaPerIdxusuId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaPerIdxusuIdxInsId(String PrimerItem, Int32 usuId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerListaPerIdxusuIdxInsId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerPerIdxusuId(int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerPerIdxusuId]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerInstxusuId(int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerInstxusuId]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoxusuIdsinProfesorT(int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerTodoxusuIdsinProfesorT]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerTodoxusuId(int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerTodoxusuId]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerUno(Int32 upeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioPerfil.ObtenerUno]", new object[,] { { "@upeId", upeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerValidarRepetido(Int32 perId, String perNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerValidarRepetido]", new object[,] { { "@perId", perId }, { "@perNombre", perNombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 perId, String perNombre, String perDescripcion, Boolean perEsAdministrador, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", new object[,] { { "@perId", perId }, { "@perNombre", perNombre }, { "@perDescripcion", perDescripcion }, { "@perEsAdministrador", perEsAdministrador }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@perFechaHoraCreacion", perFechaHoraCreacion }, { "@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion }, { "@perActivo", perActivo } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar(String perNombre, String perDescripcion, Boolean perEsAdministrador, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", new object[,] { { "@perNombre", perNombre }, { "@perDescripcion", perDescripcion }, { "@perEsAdministrador", perEsAdministrador }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@perFechaHoraCreacion", perFechaHoraCreacion }, { "@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion }, { "@perActivo", perActivo } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public void Eliminar(Int32 upeId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioPerfil.Eliminar]", new object[,] { { "@upeId", upeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Int32 Insertar(Int32 usuId, Int32 perId, Int32 insId, Boolean upeActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime upeFechaHoraCreacion, DateTime upeFechaHoraUltimaModificacion)
            {
                Int32 IdMax;
                try
                {

                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[UsuarioPerfil.Insertar]", new object[,] { { "@usuId", usuId },
                            { "@perId", perId }, { "@insId", insId }, { "@upeActivo", upeActivo },{ "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@upeFechaHoraCreacion", upeFechaHoraCreacion }, { "@upeFechaHoraUltimaModificacion", upeFechaHoraUltimaModificacion }});
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
                    if (this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[UsuarioPerfil.Actualizar]", new object[,] { { "@upeId", upeId },{ "@usuId", usuId },
                            { "@perId", perId },   { "@insId", insId },{ "@upeActivo", upeActivo },{ "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@upeFechaHoraCreacion", upeFechaHoraCreacion }, { "@upeFechaHoraUltimaModificacion", upeFechaHoraUltimaModificacion }});
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
                    if (this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[UsuarioPerfil.Eliminar]", new object[,] { { "@upeId", upeId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[UsuarioPerfil.Insertar]", new object[,] { { "@usuId", usuId },
                            { "@perId", perId },  { "@insId", insId }, { "@upeActivo", upeActivo },{ "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@upeFechaHoraCreacion", upeFechaHoraCreacion }, { "@upeFechaHoraUltimaModificacion", upeFechaHoraUltimaModificacion }});

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