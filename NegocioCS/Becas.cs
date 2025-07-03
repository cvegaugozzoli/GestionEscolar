using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Becas
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _becId; 
			public Int32 becId { get { return _becId; } set { _becId = value; } }

            private Decimal _becInteres; 
			public Decimal becInteres { get { return _becInteres; } set { _becInteres = value; } }

            private String _becNombre; 
			public String becNombre { get { return _becNombre; } set { _becNombre = value; } }

            private Boolean _becActivo; 
			public Boolean becActivo { get { return _becActivo; } set { _becActivo = value; } }

            private DateTime _becFechaHoraCreacion; 
			public DateTime becFechaHoraCreacion { get { return _becFechaHoraCreacion; } set { _becFechaHoraCreacion = value; } }

            private DateTime _becFechaHoraUltimaModificacion; 
			public DateTime becFechaHoraUltimaModificacion { get { return _becFechaHoraUltimaModificacion; } set { _becFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Becas() { try { this.becId = 0; } catch (Exception oError) { throw oError; } }            

            public Becas(Int32 becId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Becas.ObtenerUno]", new object[,] {{"@becId", becId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["becId"].ToString().Trim().Length > 0)
                        {
                            this.becId = Convert.ToInt32(Fila.Rows[0]["becId"]);
                        }
                        else
                        {
                            this.becId = 0;
                        }

					    if(Fila.Rows[0]["becInteres"].ToString().Trim().Length > 0)
                        {
                            this.becInteres = Convert.ToDecimal(Fila.Rows[0]["becInteres"]);
                        }
                        else
                        {
                            this.becInteres = 0;
                        }

					    if(Fila.Rows[0]["becNombre"].ToString().Trim().Length > 0)
                        {
                            this.becNombre = Convert.ToString(Fila.Rows[0]["becNombre"]);
                        }
                        else
                        {
                            this.becNombre = "";
                        }

					    if(Fila.Rows[0]["becFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.becFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["becFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.becFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["becFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.becFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["becFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.becFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["becActivo"].ToString().Trim().Length > 0)
                        {
                            this.becActivo = (Convert.ToInt32(Fila.Rows[0]["becActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.becActivo = false;
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

            public Becas(Int32 becId, Decimal becInteres, String becNombre, Boolean becActivo, DateTime becFechaHoraCreacion, DateTime becFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.becId = becId;
				    this.becInteres = becInteres;
				    this.becNombre = becNombre;
				    this.becActivo = becActivo;
				    this.becFechaHoraCreacion = becFechaHoraCreacion;
				    this.becFechaHoraUltimaModificacion = becFechaHoraUltimaModificacion;
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
                	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 becId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerUno]", new object[,] {{"@becId", becId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 becId, String becNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerValidarRepetido]", new object[,] {{"@becId", becId}, {"@becNombre", becNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 becId, Decimal becInteres, String becNombre, Boolean becActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime becFechaHoraCreacion, DateTime becFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Becas.Actualizar]", new object[,] {{"@becId", becId}, {"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(Decimal becInteres, String becNombre, Boolean becActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime becFechaHoraCreacion, DateTime becFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Becas.Copiar]", new object[,] {{"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 becId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Becas.Eliminar]", new object[,] {{"@becId", becId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(Decimal becInteres, String becNombre, Boolean becActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime becFechaHoraCreacion, DateTime becFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Becas.Insertar]", new object[,] {{"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
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
                    if(this.becId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Becas.Actualizar]", new object[,] {{"@becId", becId}, {"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
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
                    if(this.becId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Becas.Copiar]", new object[,] {{"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
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
                    if(this.becId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Becas.Eliminar]", new object[,] {{"@becId", becId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Becas.Insertar]", new object[,] {{"@becInteres", becInteres}, {"@becNombre", becNombre}, {"@becActivo", becActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@becFechaHoraCreacion", becFechaHoraCreacion}, {"@becFechaHoraUltimaModificacion", becFechaHoraUltimaModificacion}});
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