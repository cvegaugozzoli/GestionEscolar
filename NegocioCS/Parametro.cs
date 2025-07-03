using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Parametro
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _parId; 
			public Int32 parId { get { return _parId; } set { _parId = value; } }

            private String _parNombre; 
			public String parNombre { get { return _parNombre; } set { _parNombre = value; } }

            private String _parValor; 
			public String parValor { get { return _parValor; } set { _parValor = value; } }

            private Boolean _parActivo; 
			public Boolean parActivo { get { return _parActivo; } set { _parActivo = value; } }

            private DateTime _parFechaHoraCreacion; 
			public DateTime parFechaHoraCreacion { get { return _parFechaHoraCreacion; } set { _parFechaHoraCreacion = value; } }

            private DateTime _parFechaHoraUltimaModificacion; 
			public DateTime parFechaHoraUltimaModificacion { get { return _parFechaHoraUltimaModificacion; } set { _parFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Parametro() { try { this.parId = 0; } catch (Exception oError) { throw oError; } }            

            public Parametro(Int32 parId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Parametro.ObtenerUno]", new object[,] {{"@parId", parId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["parId"].ToString().Trim().Length > 0)
                        {
                            this.parId = Convert.ToInt32(Fila.Rows[0]["parId"]);
                        }
                        else
                        {
                            this.parId = 0;
                        }

					    if(Fila.Rows[0]["parNombre"].ToString().Trim().Length > 0)
                        {
                            this.parNombre = Convert.ToString(Fila.Rows[0]["parNombre"]);
                        }
                        else
                        {
                            this.parNombre = "";
                        }

					    if(Fila.Rows[0]["parValor"].ToString().Trim().Length > 0)
                        {
                            this.parValor = Convert.ToString(Fila.Rows[0]["parValor"]);
                        }
                        else
                        {
                            this.parValor = "";
                        }

					    if(Fila.Rows[0]["parFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.parFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["parFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.parFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["parFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.parFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["parFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.parFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["parActivo"].ToString().Trim().Length > 0)
                        {
                            this.parActivo = (Convert.ToInt32(Fila.Rows[0]["parActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.parActivo = false;
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

            public Parametro(Int32 parId, String parNombre, String parValor, Boolean parActivo, DateTime parFechaHoraCreacion, DateTime parFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.parId = parId;
				    this.parNombre = parNombre;
				    this.parValor = parValor;
				    this.parActivo = parActivo;
				    this.parFechaHoraCreacion = parFechaHoraCreacion;
				    this.parFechaHoraUltimaModificacion = parFechaHoraUltimaModificacion;
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


            public string ObtenerValor(string Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (Tabla.Rows.Count == 0)
                {
                    return "";
                }
                else
                {
                    return Tabla.Rows[0]["Valor"].ToString();
                }
            }



            public DataTable ObtenerBuscador(String ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 parId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerUno]", new object[,] {{"@parId", parId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 parId, String parNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerValidarRepetido]", new object[,] {{"@parId", parId}, {"@parNombre", parNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 parId, String parNombre, String parValor, Boolean parActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime parFechaHoraCreacion, DateTime parFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Actualizar]", new object[,] {{"@parId", parId}, {"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String parNombre, String parValor, Boolean parActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime parFechaHoraCreacion, DateTime parFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Copiar]", new object[,] {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 parId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Eliminar]", new object[,] {{"@parId", parId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String parNombre, String parValor, Boolean parActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime parFechaHoraCreacion, DateTime parFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Insertar]", new object[,] {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}});
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
                    if(this.parId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Parametro.Actualizar]", new object[,] {{"@parId", parId}, {"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}});
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
                    if(this.parId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Parametro.Copiar]", new object[,] {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}});
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
                    if(this.parId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Parametro.Eliminar]", new object[,] {{"@parId", parId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Parametro.Insertar]", new object[,] {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}});
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