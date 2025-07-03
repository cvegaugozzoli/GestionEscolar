using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Campo
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _camId; 
			public Int32 camId { get { return _camId; } set { _camId = value; } }

            private String _camNombre; 
			public String camNombre { get { return _camNombre; } set { _camNombre = value; } }

            private Boolean _camActivo; 
			public Boolean camActivo { get { return _camActivo; } set { _camActivo = value; } }

            private DateTime _camFechaHoraCreacion; 
			public DateTime camFechaHoraCreacion { get { return _camFechaHoraCreacion; } set { _camFechaHoraCreacion = value; } }

            private DateTime _camFechaHoraUltimaModificacion; 
			public DateTime camFechaHoraUltimaModificacion { get { return _camFechaHoraUltimaModificacion; } set { _camFechaHoraUltimaModificacion = value; } }

			private Int32 _plaId; 
			public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

			private Int32 _curId; 
			public Int32 curId { get { return _curId; } set { _curId = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public Campo() { try { this.camId = 0; } catch (Exception oError) { throw oError; } }            

            public Campo(Int32 camId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Campo.ObtenerUno]", new object[,] {{"@camId", camId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["camId"].ToString().Trim().Length > 0)
                        {
                            this.camId = Convert.ToInt32(Fila.Rows[0]["camId"]);
                        }
                        else
                        {
                            this.camId = 0;
                        }

					    if(Fila.Rows[0]["camNombre"].ToString().Trim().Length > 0)
                        {
                            this.camNombre = Convert.ToString(Fila.Rows[0]["camNombre"]);
                        }
                        else
                        {
                            this.camNombre = "";
                        }

					    if(Fila.Rows[0]["camFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.camFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["camFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.camFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["camFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.camFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["camFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.camFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["camActivo"].ToString().Trim().Length > 0)
                        {
                            this.camActivo = (Convert.ToInt32(Fila.Rows[0]["camActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.camActivo = false;
                        }
                        
					    if(Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
						    this.plaId = 0;
                        }
                        
					    if(Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
						    this.curId = 0;
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

            public Campo(Int32 camId, String camNombre, Boolean camActivo, DateTime camFechaHoraCreacion, DateTime camFechaHoraUltimaModificacion, Int32 IplaId, Int32 IcurId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
			{
                try
                {
				    this.camId = camId;
				    this.camNombre = camNombre;
				    this.camActivo = camActivo;
				    this.camFechaHoraCreacion = camFechaHoraCreacion;
				    this.camFechaHoraUltimaModificacion = camFechaHoraUltimaModificacion;
				    this.plaId = plaId;
				    this.curId = curId;
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
                	Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerListaPorUnCurso(String PrimerItem, Int32 curId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerListaPorUnCurso]", new object[,] { { "@PrimerItem", PrimerItem }, { "@curId", curId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaPorUnCursoporAlumno(String PrimerItem, Int32 curId, Int32 aluId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerListaPorUnCursoporAlumno]", new object[,] { { "@PrimerItem", PrimerItem }, { "@curId", curId }, { "@aluId", aluId } });
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
                	Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 camId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerUno]", new object[,] {{"@camId", camId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 camId, String camNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Campo.ObtenerValidarRepetido]", new object[,] {{"@camId", camId}, {"@camNombre", camNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 camId, String camNombre, Int32 plaId, Int32 curId, Boolean camActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime camFechaHoraCreacion, DateTime camFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Campo.Actualizar]", new object[,] {{"@camId", camId}, {"@camNombre", camNombre}, {"@plaId", plaId}, {"@curId", curId}, {"@camActivo", camActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@camFechaHoraCreacion", camFechaHoraCreacion}, {"@camFechaHoraUltimaModificacion", camFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String camNombre, Int32 plaId, Int32 curId, Boolean camActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime camFechaHoraCreacion, DateTime camFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Campo.Copiar]", new object[,] {{"@camNombre", camNombre}, {"@plaId", plaId}, {"@curId", curId}, {"@camActivo", camActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@camFechaHoraCreacion", camFechaHoraCreacion}, {"@camFechaHoraUltimaModificacion", camFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 camId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Campo.Eliminar]", new object[,] {{"@camId", camId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String camNombre, Int32 plaId, Int32 curId, Boolean camActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime camFechaHoraCreacion, DateTime camFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Campo.Insertar]", new object[,] {{"@camNombre", camNombre}, {"@plaId", plaId}, {"@curId", curId}, {"@camActivo", camActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@camFechaHoraCreacion", camFechaHoraCreacion}, {"@camFechaHoraUltimaModificacion", camFechaHoraUltimaModificacion}});
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
                    if(this.camId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Campo.Actualizar]", new object[,] {{"@camId", camId}, {"@camNombre", camNombre}, {"@plaId", plaId}, {"@curId", curId}, {"@camActivo", camActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@camFechaHoraCreacion", camFechaHoraCreacion}, {"@camFechaHoraUltimaModificacion", camFechaHoraUltimaModificacion}});
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
                    if(this.camId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Campo.Copiar]", new object[,] {{"@camNombre", camNombre}, {"@plaId", plaId}, {"@curId", curId}, {"@camActivo", camActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@camFechaHoraCreacion", camFechaHoraCreacion}, {"@camFechaHoraUltimaModificacion", camFechaHoraUltimaModificacion}});
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
                    if(this.camId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Campo.Eliminar]", new object[,] {{"@camId", camId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Campo.Insertar]", new object[,] {{"@camNombre", camNombre}, {"@plaId", plaId}, {"@curId", curId}, {"@camActivo", camActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@camFechaHoraCreacion", camFechaHoraCreacion}, {"@camFechaHoraUltimaModificacion", camFechaHoraUltimaModificacion}});
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