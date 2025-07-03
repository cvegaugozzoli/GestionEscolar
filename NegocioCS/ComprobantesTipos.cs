using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  ComprobantesTipos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _ctiId; 
			public Int32 ctiId { get { return _ctiId; } set { _ctiId = value; } }

            private String _ctiNombre; 
			public String ctiNombre { get { return _ctiNombre; } set { _ctiNombre = value; } }

            private Boolean _ctiActivo; 
			public Boolean ctiActivo { get { return _ctiActivo; } set { _ctiActivo = value; } }

            private DateTime _ctiFechaHoraCreacion; 
			public DateTime ctiFechaHoraCreacion { get { return _ctiFechaHoraCreacion; } set { _ctiFechaHoraCreacion = value; } }

            private DateTime _ctiFechaHoraUltimaModificacion; 
			public DateTime ctiFechaHoraUltimaModificacion { get { return _ctiFechaHoraUltimaModificacion; } set { _ctiFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public ComprobantesTipos() { try { this.ctiId = 0; } catch (Exception oError) { throw oError; } }            

            public ComprobantesTipos(Int32 ctiId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerUno]", new object[,] {{"@ctiId", ctiId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["ctiId"].ToString().Trim().Length > 0)
                        {
                            this.ctiId = Convert.ToInt32(Fila.Rows[0]["ctiId"]);
                        }
                        else
                        {
                            this.ctiId = 0;
                        }

					    if(Fila.Rows[0]["ctiNombre"].ToString().Trim().Length > 0)
                        {
                            this.ctiNombre = Convert.ToString(Fila.Rows[0]["ctiNombre"]);
                        }
                        else
                        {
                            this.ctiNombre = "";
                        }

					    if(Fila.Rows[0]["ctiFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.ctiFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["ctiFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.ctiFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["ctiFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.ctiFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["ctiFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.ctiFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["ctiActivo"].ToString().Trim().Length > 0)
                        {
                            this.ctiActivo = (Convert.ToInt32(Fila.Rows[0]["ctiActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.ctiActivo = false;
                        }
                        
					    if(Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
						    this.usuIdCreacion = 0;
                        }
                        
					    if(Fila.Rows[0]["usuidUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuidUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuidUltimaModificacion"]);
                        }
                        else
                        {
						    this.usuidUltimaModificacion = 0;
                        }
                        
					}
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public ComprobantesTipos(Int32 ctiId, String ctiNombre, Boolean ctiActivo, DateTime ctiFechaHoraCreacion, DateTime ctiFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {
				    this.ctiId = ctiId;
				    this.ctiNombre = ctiNombre;
				    this.ctiActivo = ctiActivo;
				    this.ctiFechaHoraCreacion = ctiFechaHoraCreacion;
				    this.ctiFechaHoraUltimaModificacion = ctiFechaHoraUltimaModificacion;
				    this.usuIdCreacion = usuIdCreacion;
				    this.usuidUltimaModificacion = usuidUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaxInst(String PrimerItem, int intId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerListaxInst]", new object[,] { { "@PrimerItem", PrimerItem }, { "@intId", intId } });
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
                	Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 ctiId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerUno]", new object[,] {{"@ctiId", ctiId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 ctiId, String ctiNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[ComprobantesTipos.ObtenerValidarRepetido]", new object[,] {{"@ctiId", ctiId}, {"@ctiNombre", ctiNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 ctiId, String ctiNombre, Boolean ctiActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime ctiFechaHoraCreacion, DateTime ctiFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Actualizar]", new object[,] {{"@ctiId", ctiId}, {"@ctiNombre", ctiNombre}, {"@ctiActivo", ctiActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@ctiFechaHoraCreacion", ctiFechaHoraCreacion}, {"@ctiFechaHoraUltimaModificacion", ctiFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String ctiNombre, Boolean ctiActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime ctiFechaHoraCreacion, DateTime ctiFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Copiar]", new object[,] {{"@ctiNombre", ctiNombre}, {"@ctiActivo", ctiActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@ctiFechaHoraCreacion", ctiFechaHoraCreacion}, {"@ctiFechaHoraUltimaModificacion", ctiFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 ctiId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Eliminar]", new object[,] {{"@ctiId", ctiId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String ctiNombre, Boolean ctiActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime ctiFechaHoraCreacion, DateTime ctiFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Insertar]", new object[,] {{"@ctiNombre", ctiNombre}, {"@ctiActivo", ctiActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@ctiFechaHoraCreacion", ctiFechaHoraCreacion}, {"@ctiFechaHoraUltimaModificacion", ctiFechaHoraUltimaModificacion}});
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
                    if(this.ctiId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Actualizar]", new object[,] {{"@ctiId", ctiId}, {"@ctiNombre", ctiNombre}, {"@ctiActivo", ctiActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@ctiFechaHoraCreacion", ctiFechaHoraCreacion}, {"@ctiFechaHoraUltimaModificacion", ctiFechaHoraUltimaModificacion}});
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
                    if(this.ctiId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Copiar]", new object[,] {{"@ctiNombre", ctiNombre}, {"@ctiActivo", ctiActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@ctiFechaHoraCreacion", ctiFechaHoraCreacion}, {"@ctiFechaHoraUltimaModificacion", ctiFechaHoraUltimaModificacion}});
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
                    if(this.ctiId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[ComprobantesTipos.Eliminar]", new object[,] {{"@ctiId", ctiId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[ComprobantesTipos.Insertar]", new object[,] {{"@ctiNombre", ctiNombre}, {"@ctiActivo", ctiActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@ctiFechaHoraCreacion", ctiFechaHoraCreacion}, {"@ctiFechaHoraUltimaModificacion", ctiFechaHoraUltimaModificacion}});
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