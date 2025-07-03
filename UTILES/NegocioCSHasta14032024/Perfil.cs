using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Perfil
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _perId; 
			public Int32 perId { get { return _perId; } set { _perId = value; } }

            private String _perNombre; 
			public String perNombre { get { return _perNombre; } set { _perNombre = value; } }

            private String _perDescripcion; 
			public String perDescripcion { get { return _perDescripcion; } set { _perDescripcion = value; } }

            private Boolean _perEsAdministrador; 
			public Boolean perEsAdministrador { get { return _perEsAdministrador; } set { _perEsAdministrador = value; } }

            private DateTime _perFechaHoraCreacion; 
			public DateTime perFechaHoraCreacion { get { return _perFechaHoraCreacion; } set { _perFechaHoraCreacion = value; } }

            private DateTime _perFechaHoraUltimaModificacion; 
			public DateTime perFechaHoraUltimaModificacion { get { return _perFechaHoraUltimaModificacion; } set { _perFechaHoraUltimaModificacion = value; } }

            private Boolean _perActivo; 
			public Boolean perActivo { get { return _perActivo; } set { _perActivo = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Perfil() { try { this.perId = 0; } catch (Exception oError) { throw oError; } }            

            public Perfil(Int32 perId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Perfil.ObtenerUno]", new object[,] {{"@perId", perId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
                        }

					    if(Fila.Rows[0]["perNombre"].ToString().Trim().Length > 0)
                        {
                            this.perNombre = Convert.ToString(Fila.Rows[0]["perNombre"]);
                        }
                        else
                        {
                            this.perNombre = "";
                        }

					    if(Fila.Rows[0]["perDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.perDescripcion = Convert.ToString(Fila.Rows[0]["perDescripcion"]);
                        }
                        else
                        {
                            this.perDescripcion = "";
                        }

					    if(Fila.Rows[0]["perFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.perFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["perFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.perFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["perFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.perFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["perFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.perFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["perEsAdministrador"].ToString().Trim().Length > 0)
                        {
                            this.perEsAdministrador = (Convert.ToInt32(Fila.Rows[0]["perEsAdministrador"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.perEsAdministrador = false;
                        }
                        
					    if(Fila.Rows[0]["perActivo"].ToString().Trim().Length > 0)
                        {
                            this.perActivo = (Convert.ToInt32(Fila.Rows[0]["perActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.perActivo = false;
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

            public Perfil(Int32 perId, String perNombre, String perDescripcion, Boolean perEsAdministrador, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.perId = perId;
				    this.perNombre = perNombre;
				    this.perDescripcion = perDescripcion;
				    this.perEsAdministrador = perEsAdministrador;
				    this.perFechaHoraCreacion = perFechaHoraCreacion;
				    this.perFechaHoraUltimaModificacion = perFechaHoraUltimaModificacion;
				    this.perActivo = perActivo;
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
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerNovedad(Int32 novId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerNovedad]", new object[,] {{"@novId", novId}});
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
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerUno]", new object[,] {{"@perId", perId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 perId, String perNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerValidarRepetido]", new object[,] {{"@perId", perId}, {"@perNombre", perNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 perId, String perNombre, String perDescripcion, Boolean perEsAdministrador, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", new object[,] {{"@perId", perId}, {"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String perNombre, String perDescripcion, Boolean perEsAdministrador, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", new object[,] {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 perId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Eliminar]", new object[,] {{"@perId", perId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String perNombre, String perDescripcion, Boolean perEsAdministrador, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime perFechaHoraCreacion, DateTime perFechaHoraUltimaModificacion, Boolean perActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Insertar]", new object[,] {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}});
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
                    if(this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", new object[,] {{"@perId", perId}, {"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}});
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
                    if(this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", new object[,] {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}});
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
                    if(this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Perfil.Eliminar]", new object[,] {{"@perId", perId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Perfil.Insertar]", new object[,] {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}});
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