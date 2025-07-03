using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class MesaExamenDocente
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _mxdId;
            public Int32 mxdId { get { return _mxdId; } set { _mxdId = value; } }
            private Int32 _meeId;
            public Int32 meeId { get { return _meeId; } set { _meeId = value; } }
           private Int32 _usuId;
            public Int32 usuId { get { return _usuId; } set { _usuId = value; } }
            private Boolean _mxdActivo;
            public Boolean mxdActivo { get { return _mxdActivo; } set { _mxdActivo = value; } }

            private DateTime _mxdFechaHoraCreacion;
            public DateTime mxdFechaHoraCreacion { get { return _mxdFechaHoraCreacion; } set { _mxdFechaHoraCreacion = value; } }

            private DateTime _mxdFechaHoraUltimaModificacion;
            public DateTime mxdFechaHoraUltimaModificacion { get { return _mxdFechaHoraUltimaModificacion; } set { _mxdFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public MesaExamenDocente() { try { this.mxdId = 0; } catch (Exception oError) { throw oError; } }

            public MesaExamenDocente(Int32 mxdId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[MesaExamenDocente.ObtenerUno]", new object[,] { { "@mxdId", mxdId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["mxdId"].ToString().Trim().Length > 0)
                        {
                            this.mxdId = Convert.ToInt32(Fila.Rows[0]["mxdId"]);
                        }
                        else
                        {
                            this.meeId = 0;
                        }
                        if (Fila.Rows[0]["meeId"].ToString().Trim().Length > 0)
                        {
                            this.meeId = Convert.ToInt32(Fila.Rows[0]["meeId"]);
                        }
                        else
                        {
                            this.meeId = 0;
                        }
                      
                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
                        }

                    
                        if (Fila.Rows[0]["mxdFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.mxdFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["mxdFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.mxdFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["mxdFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.mxdFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["mxdFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.mxdFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["mxdActivo"].ToString().Trim().Length > 0)
                        {
                            this.mxdActivo = (Convert.ToInt32(Fila.Rows[0]["mxdActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.mxdActivo = false;
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

            //public MesaExamen(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.banId = banId;
            //        this.banCodigo = banCodigo;
            //        this.banNombre = banNombre;
            //        this.banSucursal = banSucursal;
            //        this.banActivo = banActivo;
            //        this.banFechaHoraCreacion = banFechaHoraCreacion;
            //        this.banFechaHoraUltimaModificacion = banFechaHoraUltimaModificacion;
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




            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamenDocente.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

         
            public DataTable ObtenerUno(Int32 mxdId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamenDocente.ObtenerUno]", new object[,] { { "@mxdId", mxdId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxDNIxmeeId(String dni, int MeeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamenDocente.ObtenerUnoxDNIxmeeId]", new object[,] { { "@dni", dni }, { "@MeeId", MeeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoxDNI(String dni)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamenDocente.ObtenerUnoxDNI]", new object[,] { { "@dni", dni } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

    public DataTable ObtenerTodoBuscarxmeeId(int meeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[MesaExamenDocente.ObtenerTodoBuscarxmeeId]", new object[,] { { "@meeId", meeId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public void Eliminar(Int32 mxdId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[MesaExamenDocente.Eliminar]", new object[,] { { "@mxdId", mxdId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void EliminarxActivo(Int32 meeId, Int32 usuEliminar, Int32 usuId, DateTime fecha)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[MesaExamenDocente.EliminarxActivo]", new object[,] { { "@meeId", meeId } ,{ "@usuEliminar", usuEliminar },{ "@usuId", usuId },{ "@fecha", fecha } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }
            public void EliminarxActivo(Int32 Id,  DateTime FechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[MesaExamenDocente.EliminarxActivo]", new object[,] { { "@Id", Id }, { "@FechaHoraUltimaModificacion", FechaHoraUltimaModificacion }});
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
                    if (this.mxdId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[MesaExamen.Actualizar]", new object[,] { { "@mxdId", mxdId }, { "@meeId", meeId },  { "@usuId", usuId },
                      { "@mxdActivo", mxdActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                        { "@mxdFechaHoraCreacion", mxdFechaHoraCreacion }, { "@mxdFechaHoraUltimaModificacion", mxdFechaHoraUltimaModificacion } });
                    }
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }



            //         public void Eliminar()
            //         {
            //             try
            //             {
            //                 if (this.meeId != 0)
            //                 {
            //                     ocdGestor.EjecutarNonQuery("[MesaExamen.Eliminar]", new object[,] { { "@banId", meeId } });
            //                 }
            //             }
            //             catch (Exception oError)
            //             {
            //                 throw oError;
            //             }
            //         }

            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[MesaExamenDocente.Insertar]", new object[,] { { "@meeId", meeId },  { "@usuId", usuId },
                      { "@mxdActivo", mxdActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion },
                        { "@mxdFechaHoraCreacion", mxdFechaHoraCreacion }, { "@mxdFechaHoraUltimaModificacion", mxdFechaHoraUltimaModificacion } });
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