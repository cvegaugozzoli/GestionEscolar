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

            private String _cdnNombre; 
			public String cdnNombre { get { return _cdnNombre; } set { _cdnNombre = value; } }

            private Boolean _cdnActivo; 
			public Boolean cdnActivo { get { return _cdnActivo; } set { _cdnActivo = value; } }

            private DateTime _cdnFechaHoraCreacion; 
			public DateTime cdnFechaHoraCreacion { get { return _cdnFechaHoraCreacion; } set { _cdnFechaHoraCreacion = value; } }

            private DateTime _cdnFechaHoraUltimaModificacion; 
			public DateTime cdnFechaHoraUltimaModificacion { get { return _cdnFechaHoraUltimaModificacion; } set { _cdnFechaHoraUltimaModificacion = value; } }

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

					    if(Fila.Rows[0]["cdnNombre"].ToString().Trim().Length > 0)
                        {
                            this.cdnNombre = Convert.ToString(Fila.Rows[0]["cdnNombre"]);
                        }
                        else
                        {
                            this.cdnNombre = "";
                        }

					    if(Fila.Rows[0]["cdnFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.cdnFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["cdnFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.cdnFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cdnFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.cdnFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["cdnFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.cdnFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["cdnActivo"].ToString().Trim().Length > 0)
                        {
                            this.cdnActivo = (Convert.ToInt32(Fila.Rows[0]["cdnActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.cdnActivo = false;
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

            public Condicion(Int32 cdnId, String cdnNombre, Boolean cdnActivo, DateTime cdnFechaHoraCreacion, DateTime cdnFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.cdnId = cdnId;
				    this.cdnNombre = cdnNombre;
				    this.cdnActivo = cdnActivo;
				    this.cdnFechaHoraCreacion = cdnFechaHoraCreacion;
				    this.cdnFechaHoraUltimaModificacion = cdnFechaHoraUltimaModificacion;
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
           public DataTable ObtenerListaInsc(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Condicion.ObtenerListaInsc]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                        ocdGestor.EjecutarNonQuery("[Condicion.Actualizar]", new object[,] {{"@cdnId", cdnId}, {"@conNombre", cdnNombre}, {"@conActivo", cdnActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@conFechaHoraCreacion", cdnFechaHoraCreacion}, {"@conFechaHoraUltimaModificacion", cdnFechaHoraUltimaModificacion}});
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
                        ocdGestor.EjecutarNonQuery("[Condicion.Copiar]", new object[,] {{"@cdnNombre", cdnNombre}, {"@cdnActivo", cdnActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cdnFechaHoraCreacion", cdnFechaHoraCreacion}, {"@cdnFechaHoraUltimaModificacion", cdnFechaHoraUltimaModificacion}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Condicion.Insertar]", new object[,] {{"@conNombre", cdnNombre}, {"@cdnActivo", cdnActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@cdnFechaHoraCreacion", cdnFechaHoraCreacion}, {"@cdnFechaHoraUltimaModificacion", cdnFechaHoraUltimaModificacion}});
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