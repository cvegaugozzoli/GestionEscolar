using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class UsuarioEspacioCurricular
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _uscId;
            public Int32 uscId { get { return _uscId; } set { _uscId = value; } }

            private Int32 _usuId;
            public Int32 usuId { get { return _usuId; } set { _usuId = value; } }
            
            private Int32 _uscAnoCursado;
            public Int32 uscAnoCursado { get { return _uscAnoCursado; } set { _uscAnoCursado = value; } }

            private Int32 _carId;
            public Int32 carId { get { return _carId; } set { _carId = value; } }

            private Int32 _plaId;
            public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

            private Int32 _curId;
            public Int32 curId { get { return _curId; } set { _curId = value; } }

            private Int32 _camId;
            public Int32 camId { get { return _camId; } set { _camId = value; } }

            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private Boolean _uscActivo;
            public Boolean uscActivo { get { return _uscActivo; } set { _uscActivo = value; } }

            private DateTime _uscFechaHoraCreacion;
            public DateTime uscFechaHoraCreacion { get { return _uscFechaHoraCreacion; } set { _uscFechaHoraCreacion = value; } }

            private DateTime _uscFechaHoraUltimaModificacion;
            public DateTime uscFechaHoraUltimaModificacion { get { return _uscFechaHoraUltimaModificacion; } set { _uscFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public UsuarioEspacioCurricular() { try { this.usuId = 0; } catch (Exception oError) { throw oError; } }

            public UsuarioEspacioCurricular(Int32 uscId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerUno]", new object[,] { { "@uscId", uscId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["uscId"].ToString().Trim().Length > 0)
                        {
                            this.uscId = Convert.ToInt32(Fila.Rows[0]["uscId"]);
                        }
                        else
                        {
                            this.uscId = 0;
                        }

                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
                        }
                       
                        if (Fila.Rows[0]["uscAnoCursado"].ToString().Trim().Length > 0)
                        {
                            this.uscAnoCursado = Convert.ToInt32(Fila.Rows[0]["uscAnoCursado"]);
                        }
                        else
                        {
                            this.uscAnoCursado = 0;
                        }
                        if (Fila.Rows[0]["carId"].ToString().Trim().Length > 0)
                        {
                            this.carId = Convert.ToInt32(Fila.Rows[0]["carId"]);
                        }
                        else
                        {
                            this.carId = 0;
                        }
                        if (Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
                            this.plaId = 0;
                        }
                        if (Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
                            this.curId = 0;
                        }
                        if (Fila.Rows[0]["camId"].ToString().Trim().Length > 0)
                        {
                            this.camId = Convert.ToInt32(Fila.Rows[0]["camId"]);
                        }
                        else
                        {
                            this.camId = 0;
                        }
                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
                        }

                        if (Fila.Rows[0]["uscActivo"].ToString().Trim().Length > 0)
                        {
                            this.uscActivo = (Convert.ToInt32(Fila.Rows[0]["uscActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.uscActivo = false;
                        }

                        if (Fila.Rows[0]["uscFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.uscFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["uscFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.uscFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["uscFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.uscFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["uscFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.uscFechaHoraUltimaModificacion = DateTime.Now;
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

            public UsuarioEspacioCurricular(Int32 UscId, Int32 usuId, String usuNombre, Int32 AnoCursado, Int32 carId, Int32 plaId, Int32 curId, Int32 plaID, Int32 espId, Boolean uscActivo, DateTime uscFechaHoraCreacion, DateTime uscFechaHoraUltimaModificacion, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion)
            {
                try
                {
                    this.uscId = UscId;
                    this.usuId = usuId;                   
                    this.uscAnoCursado = AnoCursado;
                    this.carId = carId;
                    this.plaId = plaId;
                    this.curId = curId;
                    this.camId = camId;
                    this.escId = escId;
                    this.uscActivo = uscActivo;
                    this.uscFechaHoraCreacion = uscFechaHoraCreacion;
                    this.uscFechaHoraUltimaModificacion = uscFechaHoraUltimaModificacion;
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


            //public DataTable ObtenerAutenticar(String usuNombreIngreso, String usuClave)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerAutenticar]", new object[,] { { "@usuNombreIngreso", usuNombreIngreso }, { "@usuClave", usuClave } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerListaxusuId(String PrimerItem, Int32 usuId, Int32 carId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerListaxusuId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId } , { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaxusuIdyCur(String PrimerItem, Int32 usuId, int curId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerListaxusuIdyCur]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId }, { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaCursoxusuId(String PrimerItem, Int32 usuId, Int32 carId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerListaCursoxusuId]", new object[,] { { "@PrimerItem", PrimerItem }, { "@usuId", usuId } , { "@carId", carId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            //public DataTable ObtenerListaCustom(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerListaCustom]", new object[,] { { "@PrimerItem", PrimerItem } });
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
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            //public DataTable ObtenerUnoporDoc(String Doc)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Docente.ObtenerUnoPorDoc]", new object[,] { { "@Doc", Doc } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}


            //public DataTable ObtenerTodoCustom(String Nombre, String Apellido, String Usuario, Int32 perId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoCustom]", new object[,] { { "@Nombre", Nombre }, { "@Apellido", Apellido }, { "@Usuario", Usuario }, { "@perId", perId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerUno(Int32 uscId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerUno]", new object[,] { { "@uscId", uscId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
    public DataTable ObtenerUnoControlExiste(Int32 uscId, Int32 carId, Int32 plaId, Int32 curId, Int32 escId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerUnoControlExiste]", new object[,] { { "@uscId", uscId }, { "@carId", carId },{ "@plaId", plaId },{ "@curId", curId },{ "@escId", escId }});
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

   public DataTable ObtenerxUsuId(Int32 usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioEspacioCurricular.ObtenerxUsuId]", new object[,] { { "@usuId", usuId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void Actualizar(Int32 uscId, Int32 usuId, Int32 uscAnoCursado, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Boolean uscActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioEspacioCurricular.Actualizar]", new object[,] { { "@uscId", uscId }, { "@usuId", usuId }, { "@uscAnoCursado", uscAnoCursado }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@uscActivo", uscActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }


            public void Eliminar(Int32 uscId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioEspacioCurricular.Eliminar]", new object[,] { { "@uscId", uscId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 usuId, Int32 uscAnoCursado, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, Int32 escId, Boolean uscActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime usuFechaHoraCreacion, DateTime usuFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioEspacioCurricular.Insertar]", new object[,] { { "@usuId", usuId }, { "@uscAnoCursado", uscAnoCursado }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@uscActivo", uscActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@usuFechaHoraCreacion", usuFechaHoraCreacion }, { "@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion } });
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[UsuarioEspacioCurricular.Actualizar]", new object[,] { { "@uscId", uscId }, { "@usuId", usuId }, { "@uscAnoCursado", uscAnoCursado }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@uscActivo", uscActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@uscFechaHoraCreacion", uscFechaHoraCreacion }, { "@uscFechaHoraUltimaModificacion", uscFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }



            //public void Eliminar()
            //{
            //    try
            //    {
            //        if (this.usuId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", new object[,] { { "@usuId", usuId } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[UsuarioEspacioCurricular.Insertar]", new object[,] { { "@usuId", usuId }, { "@uscAnoCursado", uscAnoCursado }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escId", escId }, { "@uscActivo", uscActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@uscFechaHoraCreacion", uscFechaHoraCreacion }, { "@uscFechaHoraUltimaModificacion", uscFechaHoraUltimaModificacion } });

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