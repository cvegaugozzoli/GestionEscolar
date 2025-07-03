using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class TipoCarrera
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _tcaId; 
			public Int32 tcaId { get { return _tcaId; } set { _tcaId = value; } }

            private String _tcaNombre; 
			public String tcaNombre { get { return _tcaNombre; } set { _tcaNombre = value; } }

            private Boolean _tcaSinPC;
            public Boolean tcaSinPC { get { return _tcaSinPC; } set { _tcaSinPC = value; } }

            private DateTime _tcaFechaHoraCreacion; 
			public DateTime tcaFechaHoraCreacion { get { return _tcaFechaHoraCreacion; } set { _tcaFechaHoraCreacion = value; } }

            private DateTime _tcaFechaHoraUltimaModificacion; 
			public DateTime tcaFechaHoraUltimaModificacion { get { return _tcaFechaHoraUltimaModificacion; } set { _tcaFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public TipoCarrera() { try { this.tcaId = 0; } catch (Exception oError) { throw oError; } }            

            public TipoCarrera(Int32 tcaId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerUno]", new object[,] {{"@tcaId", tcaId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["tcaId"].ToString().Trim().Length > 0)
                        {
                            this.tcaId = Convert.ToInt32(Fila.Rows[0]["tcaId"]);
                        }
                        else
                        {
                            this.tcaId = 0;
                        }

					    if(Fila.Rows[0]["tcaNombre"].ToString().Trim().Length > 0)
                        {
                            this.tcaNombre = Convert.ToString(Fila.Rows[0]["tcaNombre"]);
                        }
                        else
                        {
                            this.tcaNombre = "";
                        }

                        if (Fila.Rows[0]["tcaSinPC"].ToString().Trim().Length > 0)
                        {
                            this.tcaSinPC = (Convert.ToInt32(Fila.Rows[0]["tcaSinPC"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.tcaSinPC = false;
                        }

                        if (Fila.Rows[0]["tcaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.tcaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["tcaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.tcaFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["tcaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.tcaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["tcaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.tcaFechaHoraUltimaModificacion = DateTime.Now;
                        }

					  
					    if(Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
						    this.usuIdCreacion = 0;
                        }
                        
					    if(Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
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

            public TipoCarrera(Int32 tcaId, String tcaNombre, Boolean tcaSinPC, DateTime tcaFechaHoraCreacion, DateTime tcaFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.tcaId = tcaId;
				    this.tcaNombre = tcaNombre;
				    this.tcaSinPC = tcaSinPC;
				    this.tcaFechaHoraCreacion = tcaFechaHoraCreacion;
				    this.tcaFechaHoraUltimaModificacion = tcaFechaHoraUltimaModificacion;
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

                			
            public DataTable ObtenerBuscador(String ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 tcaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerUno]", new object[,] {{"@tcaId", tcaId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 tcaId, String tcaNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[TipoCarrera.ObtenerValidarRepetido]", new object[,] {{"@tcaId", tcaId}, {"@tcaNombre", tcaNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
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