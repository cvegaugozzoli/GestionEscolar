using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Regimen
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _regId; 
			public Int32 regId { get { return _regId; } set { _regId = value; } }

            private String _regNombre; 
			public String regNombre { get { return _regNombre; } set { _regNombre = value; } }

            private Boolean _regActivo; 
			public Boolean regActivo { get { return _regActivo; } set { _regActivo = value; } }

            private DateTime _regFechaHoraCreacion; 
			public DateTime regFechaHoraCreacion { get { return _regFechaHoraCreacion; } set { _regFechaHoraCreacion = value; } }

            private DateTime _regFechaHoraUltimaModificacion; 
			public DateTime regFechaHoraUltimaModificacion { get { return _regFechaHoraUltimaModificacion; } set { _regFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Regimen() { try { this.regId = 0; } catch (Exception oError) { throw oError; } }            

            public Regimen(Int32 regId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Regimen.ObtenerUno]", new object[,] {{"@regId", regId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["regId"].ToString().Trim().Length > 0)
                        {
                            this.regId = Convert.ToInt32(Fila.Rows[0]["regId"]);
                        }
                        else
                        {
                            this.regId = 0;
                        }

					    if(Fila.Rows[0]["regNombre"].ToString().Trim().Length > 0)
                        {
                            this.regNombre = Convert.ToString(Fila.Rows[0]["regNombre"]);
                        }
                        else
                        {
                            this.regNombre = "";
                        }

					    if(Fila.Rows[0]["regFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.regFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["regFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.regFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["regFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.regFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["regFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.regFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["regActivo"].ToString().Trim().Length > 0)
                        {
                            this.regActivo = (Convert.ToInt32(Fila.Rows[0]["regActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.regActivo = false;
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

            public Regimen(Int32 regId, String regNombre, Boolean regActivo, DateTime regFechaHoraCreacion, DateTime regFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.regId = regId;
				    this.regNombre = regNombre;
				    this.regActivo = regActivo;
				    this.regFechaHoraCreacion = regFechaHoraCreacion;
				    this.regFechaHoraUltimaModificacion = regFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[Regimen.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Regimen.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Regimen.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Regimen.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 regId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Regimen.ObtenerUno]", new object[,] {{"@regId", regId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 regId, String regNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Regimen.ObtenerValidarRepetido]", new object[,] {{"@regId", regId}, {"@regNombre", regNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 regId, String regNombre, Boolean regActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime regFechaHoraCreacion, DateTime regFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Regimen.Actualizar]", new object[,] {{"@regId", regId}, {"@regNombre", regNombre}, {"@regActivo", regActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@regFechaHoraCreacion", regFechaHoraCreacion}, {"@regFechaHoraUltimaModificacion", regFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String regNombre, Boolean regActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime regFechaHoraCreacion, DateTime regFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Regimen.Copiar]", new object[,] {{"@regNombre", regNombre}, {"@regActivo", regActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@regFechaHoraCreacion", regFechaHoraCreacion}, {"@regFechaHoraUltimaModificacion", regFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 regId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Regimen.Eliminar]", new object[,] {{"@regId", regId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String regNombre, Boolean regActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime regFechaHoraCreacion, DateTime regFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Regimen.Insertar]", new object[,] {{"@regNombre", regNombre}, {"@regActivo", regActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@regFechaHoraCreacion", regFechaHoraCreacion}, {"@regFechaHoraUltimaModificacion", regFechaHoraUltimaModificacion}});
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
                    if(this.regId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Regimen.Actualizar]", new object[,] {{"@regId", regId}, {"@regNombre", regNombre}, {"@regActivo", regActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@regFechaHoraCreacion", regFechaHoraCreacion}, {"@regFechaHoraUltimaModificacion", regFechaHoraUltimaModificacion}});
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
                    if(this.regId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Regimen.Copiar]", new object[,] {{"@regNombre", regNombre}, {"@regActivo", regActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@regFechaHoraCreacion", regFechaHoraCreacion}, {"@regFechaHoraUltimaModificacion", regFechaHoraUltimaModificacion}});
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
                    if(this.regId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Regimen.Eliminar]", new object[,] {{"@regId", regId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Regimen.Insertar]", new object[,] {{"@regNombre", regNombre}, {"@regActivo", regActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@regFechaHoraCreacion", regFechaHoraCreacion}, {"@regFechaHoraUltimaModificacion", regFechaHoraUltimaModificacion}});
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