using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  FormatoDictado
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _fodId; 
			public Int32 fodId { get { return _fodId; } set { _fodId = value; } }

            private String _fodNombre; 
			public String fodNombre { get { return _fodNombre; } set { _fodNombre = value; } }

            private Boolean _fodActivo; 
			public Boolean fodActivo { get { return _fodActivo; } set { _fodActivo = value; } }

            private DateTime _fodFechaHoraCreacion; 
			public DateTime fodFechaHoraCreacion { get { return _fodFechaHoraCreacion; } set { _fodFechaHoraCreacion = value; } }

            private DateTime _fodFechaHoraUltimaModificacion; 
			public DateTime fodFechaHoraUltimaModificacion { get { return _fodFechaHoraUltimaModificacion; } set { _fodFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public FormatoDictado() { try { this.fodId = 0; } catch (Exception oError) { throw oError; } }            

            public FormatoDictado(Int32 fodId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerUno]", new object[,] {{"@fodId", fodId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["fodId"].ToString().Trim().Length > 0)
                        {
                            this.fodId = Convert.ToInt32(Fila.Rows[0]["fodId"]);
                        }
                        else
                        {
                            this.fodId = 0;
                        }

					    if(Fila.Rows[0]["fodNombre"].ToString().Trim().Length > 0)
                        {
                            this.fodNombre = Convert.ToString(Fila.Rows[0]["fodNombre"]);
                        }
                        else
                        {
                            this.fodNombre = "";
                        }

					    if(Fila.Rows[0]["fodFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.fodFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["fodFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.fodFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["fodFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.fodFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["fodFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.fodFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["fodActivo"].ToString().Trim().Length > 0)
                        {
                            this.fodActivo = (Convert.ToInt32(Fila.Rows[0]["fodActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.fodActivo = false;
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

            public FormatoDictado(Int32 fodId, String fodNombre, Boolean fodActivo, DateTime fodFechaHoraCreacion, DateTime fodFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.fodId = fodId;
				    this.fodNombre = fodNombre;
				    this.fodActivo = fodActivo;
				    this.fodFechaHoraCreacion = fodFechaHoraCreacion;
				    this.fodFechaHoraUltimaModificacion = fodFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 fodId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerUno]", new object[,] {{"@fodId", fodId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 fodId, String fodNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[FormatoDictado.ObtenerValidarRepetido]", new object[,] {{"@fodId", fodId}, {"@fodNombre", fodNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 fodId, String fodNombre, Boolean fodActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime fodFechaHoraCreacion, DateTime fodFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormatoDictado.Actualizar]", new object[,] {{"@fodId", fodId}, {"@fodNombre", fodNombre}, {"@fodActivo", fodActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@fodFechaHoraCreacion", fodFechaHoraCreacion}, {"@fodFechaHoraUltimaModificacion", fodFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String fodNombre, Boolean fodActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime fodFechaHoraCreacion, DateTime fodFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormatoDictado.Copiar]", new object[,] {{"@fodNombre", fodNombre}, {"@fodActivo", fodActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@fodFechaHoraCreacion", fodFechaHoraCreacion}, {"@fodFechaHoraUltimaModificacion", fodFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 fodId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormatoDictado.Eliminar]", new object[,] {{"@fodId", fodId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String fodNombre, Boolean fodActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime fodFechaHoraCreacion, DateTime fodFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[FormatoDictado.Insertar]", new object[,] {{"@fodNombre", fodNombre}, {"@fodActivo", fodActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@fodFechaHoraCreacion", fodFechaHoraCreacion}, {"@fodFechaHoraUltimaModificacion", fodFechaHoraUltimaModificacion}});
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
                    if(this.fodId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[FormatoDictado.Actualizar]", new object[,] {{"@fodId", fodId}, {"@fodNombre", fodNombre}, {"@fodActivo", fodActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@fodFechaHoraCreacion", fodFechaHoraCreacion}, {"@fodFechaHoraUltimaModificacion", fodFechaHoraUltimaModificacion}});
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
                    if(this.fodId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[FormatoDictado.Copiar]", new object[,] {{"@fodNombre", fodNombre}, {"@fodActivo", fodActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@fodFechaHoraCreacion", fodFechaHoraCreacion}, {"@fodFechaHoraUltimaModificacion", fodFechaHoraUltimaModificacion}});
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
                    if(this.fodId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[FormatoDictado.Eliminar]", new object[,] {{"@fodId", fodId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[FormatoDictado.Insertar]", new object[,] {{"@fodNombre", fodNombre}, {"@fodActivo", fodActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@fodFechaHoraCreacion", fodFechaHoraCreacion}, {"@fodFechaHoraUltimaModificacion", fodFechaHoraUltimaModificacion}});
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