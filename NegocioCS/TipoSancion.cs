
using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TipoSancion
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tsaId;
            public Int32 tsaId { get { return _tsaId; } set { _tsaId = value; } }

            private String _tsaDescripcion;
            public String tsaDescripcion { get { return _tsaDescripcion; } set { _tsaDescripcion = value; } }

            private DateTime _tsaFechaHoraCreacion;
            public DateTime tsaFechaHoraCreacion { get { return _tsaFechaHoraCreacion; } set { _tsaFechaHoraCreacion = value; } }

            private DateTime _tsaFechaHoraUltimaModificacion;
            public DateTime tsaFechaHoraUltimaModificacion { get { return _tsaFechaHoraUltimaModificacion; } set { _tsaFechaHoraUltimaModificacion = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region TipoSancion

            public TipoSancion() { try { this.tsaId = 0; } catch (Exception oError) { throw oError; } }

            public TipoSancion(Int32 tsaId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[TipoSancion.ObtenerUno]", new object[,] { { "@tsaId", tsaId } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["tsaId"].ToString().Trim().Length > 0)
                        {
                            this.tsaId = Convert.ToInt32(Fila.Rows[0]["tsaId"]);
                        }
                        else
                        {
                            this.tsaId = 0;
                        }

                        if (Fila.Rows[0]["tsaDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.tsaDescripcion = Convert.ToString(Fila.Rows[0]["tsaDescripcion"]);
                        }
                        else
                        {
                            this.tsaDescripcion = "";
                        }

                        if (Fila.Rows[0]["tsaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.tsaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["tsaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.tsaFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["tsaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.tsaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["tsaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.tsaFechaHoraUltimaModificacion = DateTime.Now;
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

            public TipoSancion(Int32 tsaId, String tsaDescripcion, DateTime tsaFechaHoraCreacion, DateTime tsaFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.tsaId = tsaId;
                    this.tsaDescripcion = tsaDescripcion;
                    this.tsaFechaHoraCreacion = tsaFechaHoraCreacion;
                    this.tsaFechaHoraUltimaModificacion = tsaFechaHoraUltimaModificacion;
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


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
            //    	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerLista(String Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[TipoSancion.ObtenerLista]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerUno(Int32 tcaId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerUno]", new object[,] {{"@tcaId", tcaId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerValidarRepetido(Int32 tcaId, String tcaNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerValidarRepetido]", new object[,] {{"@tcaId", tcaId}, {"@tcaNombre", tcaNombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 sexId, String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Copiar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Eliminar(Int32 sexId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Insertar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Insertar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Actualizar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Copiar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Eliminar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public Int32 Insertar()
            //{
            //    Int32 IdMax;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Sexo.Insertar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //    return IdMax;
            //}


            #endregion
        }
    }
}
