using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Condicion
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _cdnId; 
			public Int32 cdnId { get { return _cdnId; } set { _cdnId = value; } }

            private String _conNombre; 
			public String conNombre { get { return _conNombre; } set { _conNombre = value; } }

            private Boolean _conActivo; 
			public Boolean conActivo { get { return _conActivo; } set { _conActivo = value; } }

            private DateTime _conFechaHoraCreacion; 
			public DateTime conFechaHoraCreacion { get { return _conFechaHoraCreacion; } set { _conFechaHoraCreacion = value; } }

            private DateTime _conFechaHoraUltimaModificacion; 
			public DateTime conFechaHoraUltimaModificacion { get { return _conFechaHoraUltimaModificacion; } set { _conFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Condicion() { try { this.cdnId = 0; } catch (Exception oError) { throw oError; } }            

            public Condicion(Int32 cdnId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Condicion.ObtenerUno]", new object[,] {{"@cdnId", cdnId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["cdnId"].ToString().Trim().Length > 0)
                        {
                            this.cdnId = Convert.ToInt32(Fila.Rows[0]["cdnId"]);
                        }
                        else
                        {
                            this.cdnId = 0;
                        }

					    if(Fila.Rows[0]["conNombre"].ToString().Trim().Length > 0)
                        {
                            this.conNombre = Convert.ToString(Fila.Rows[0]["conNombre"]);
                        }
                        else
                        {
                            this.conNombre = "";
                        }

					    if(Fila.Rows[0]["conFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.conFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["conFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.conFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["conFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.conFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["conFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.conFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["conActivo"].ToString().Trim().Length > 0)
                        {
                            this.conActivo = (Convert.ToInt32(Fila.Rows[0]["conActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.conActivo = false;
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

            public Condicion(Int32 cdnId, String conNombre, Boolean conActivo, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.cdnId = cdnId;
				    this.conNombre = conNombre;
				    this.conActivo = conActivo;
				    this.conFechaHoraCreacion = conFechaHoraCreacion;
				    this.conFechaHoraUltimaModificacion = conFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 cdnId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerUno]", new object[,] {{"@cdnId", cdnId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 cdnId, String conNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerValidarRepetido]", new object[,] {{"@cdnId", cdnId}, {"@conNombre", conNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 cdnId, String conNombre, Boolean conActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Condicion.Actualizar]", new object[,] {{"@cdnId", cdnId}, {"@conNombre", conNombre}, {"@conActivo", conActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", conFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String conNombre, Boolean conActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Condicion.Copiar]", new object[,] {{"@conNombre", conNombre}, {"@conActivo", conActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", conFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 cdnId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Condicion.Eliminar]", new object[,] {{"@cdnId", cdnId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String conNombre, Boolean conActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime conFechaHoraCreacion, DateTime conFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Condicion.Insertar]", new object[,] {{"@conNombre", conNombre}, {"@conActivo", conActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", conFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion}});
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
                    if(this.cdnId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Condicion.Actualizar]", new object[,] {{"@cdnId", cdnId}, {"@conNombre", conNombre}, {"@conActivo", conActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", conFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion}});
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
                    if(this.cdnId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Condicion.Copiar]", new object[,] {{"@conNombre", conNombre}, {"@conActivo", conActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", conFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion}});
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
                    if(this.cdnId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Condicion.Eliminar]", new object[,] {{"@cdnId", cdnId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Condicion.Insertar]", new object[,] {{"@conNombre", conNombre}, {"@conActivo", conActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", conFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", conFechaHoraUltimaModificacion}});
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