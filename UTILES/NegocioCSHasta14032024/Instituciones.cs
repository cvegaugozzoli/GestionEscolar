using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Instituciones
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _insId; 
			public Int32 insId { get { return _insId; } set { _insId = value; } }

            private String _insNombre; 
			public String insNombre { get { return _insNombre; } set { _insNombre = value; } }

            private String _insCodigo; 
			public String insCodigo { get { return _insCodigo; } set { _insCodigo = value; } }

            private String _insDireccion; 
			public String insDireccion { get { return _insDireccion; } set { _insDireccion = value; } }

            private String _insTelefono; 
			public String insTelefono { get { return _insTelefono; } set { _insTelefono = value; } }

            private String _insCUIT; 
			public String insCUIT { get { return _insCUIT; } set { _insCUIT = value; } }

            private String _insMail; 
			public String insMail { get { return _insMail; } set { _insMail = value; } }

            private Boolean _insGrupo; 
			public Boolean insGrupo { get { return _insGrupo; } set { _insGrupo = value; } }

            private Boolean _insActivo; 
			public Boolean insActivo { get { return _insActivo; } set { _insActivo = value; } }

            private DateTime _insFechaHoraCreacion; 
			public DateTime insFechaHoraCreacion { get { return _insFechaHoraCreacion; } set { _insFechaHoraCreacion = value; } }

            private DateTime _insFechaHoraUltimaModificacion; 
			public DateTime insFechaHoraUltimaModificacion { get { return _insFechaHoraUltimaModificacion; } set { _insFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }
			private Int32 _insRecaxUsuario; 
			public Int32 insRecaxUsuario { get { return _insRecaxUsuario; } set { _insRecaxUsuario = value; } }

            #endregion

            #region Constructores

            public Instituciones() { try { this.insId = 0; } catch (Exception oError) { throw oError; } }            

            public Instituciones(Int32 insId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Instituciones.ObtenerUno]", new object[,] {{"@insId", insId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

					    if(Fila.Rows[0]["insNombre"].ToString().Trim().Length > 0)
                        {
                            this.insNombre = Convert.ToString(Fila.Rows[0]["insNombre"]);
                        }
                        else
                        {
                            this.insNombre = "";
                        }

					    if(Fila.Rows[0]["insCodigo"].ToString().Trim().Length > 0)
                        {
                            this.insCodigo = Convert.ToString(Fila.Rows[0]["insCodigo"]);
                        }
                        else
                        {
                            this.insCodigo = "";
                        }

					    if(Fila.Rows[0]["insDireccion"].ToString().Trim().Length > 0)
                        {
                            this.insDireccion = Convert.ToString(Fila.Rows[0]["insDireccion"]);
                        }
                        else
                        {
                            this.insDireccion = "";
                        }

					    if(Fila.Rows[0]["insTelefono"].ToString().Trim().Length > 0)
                        {
                            this.insTelefono = Convert.ToString(Fila.Rows[0]["insTelefono"]);
                        }
                        else
                        {
                            this.insTelefono = "";
                        }

					    if(Fila.Rows[0]["insCUIT"].ToString().Trim().Length > 0)
                        {
                            this.insCUIT = Convert.ToString(Fila.Rows[0]["insCUIT"]);
                        }
                        else
                        {
                            this.insCUIT = "";
                        }

					    if(Fila.Rows[0]["insMail"].ToString().Trim().Length > 0)
                        {
                            this.insMail = Convert.ToString(Fila.Rows[0]["insMail"]);
                        }
                        else
                        {
                            this.insMail = "";
                        }

					    if(Fila.Rows[0]["insFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.insFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["insFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.insFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["insFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.insFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["insFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.insFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["insGrupo"].ToString().Trim().Length > 0)
                        {
                            this.insGrupo = (Convert.ToInt32(Fila.Rows[0]["insGrupo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.insGrupo = false;
                        }
                        
					    if(Fila.Rows[0]["insActivo"].ToString().Trim().Length > 0)
                        {
                            this.insActivo = (Convert.ToInt32(Fila.Rows[0]["insActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.insActivo = false;
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
                          if(Fila.Rows[0]["insRecaxUsuario"].ToString().Trim().Length > 0)
                        {
                            this.insRecaxUsuario = Convert.ToInt32(Fila.Rows[0]["insRecaxUsuario"]);
                        }
                        else
                        {
						    this.insRecaxUsuario = 0;
                        }
					}
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Instituciones(Int32 insId, String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion, Int32 insRecaxUsuario)
			{
                try
                {
				    this.insId = insId;
				    this.insNombre = insNombre;
				    this.insCodigo = insCodigo;
				    this.insDireccion = insDireccion;
				    this.insTelefono = insTelefono;
				    this.insCUIT = insCUIT;
				    this.insMail = insMail;
				    this.insGrupo = insGrupo;
				    this.insActivo = insActivo;
				    this.insFechaHoraCreacion = insFechaHoraCreacion;
				    this.insFechaHoraUltimaModificacion = insFechaHoraUltimaModificacion;
				    this.usuIdCreacion = usuIdCreacion;
				    this.usuidUltimaModificacion = usuidUltimaModificacion;
				    this.insRecaxUsuario = insRecaxUsuario;

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
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUno]", new object[,] {{"@insId", insId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                   public DataTable ObtenerUnoxaluIdxAnio(Int32 aluId,Int32 Anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUnoxaluIdxAnio]", new object[,] {{"@insId", insId}, { "@Anio", Anio } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }			
            public DataTable ObtenerValidarRepetido(Int32 insId, String insNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerValidarRepetido]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 insId, String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 insRecaxUsuario)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Instituciones.Actualizar]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 insRecaxUsuario)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Instituciones.Copiar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 insId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Instituciones.Eliminar]", new object[,] {{"@insId", insId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion, Int32 insRecaxUsuario)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Instituciones.Insertar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
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
                    if(this.insId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Instituciones.Actualizar]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
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
                    if(this.insId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Instituciones.Copiar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
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
                    if(this.insId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Instituciones.Eliminar]", new object[,] {{"@insId", insId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Instituciones.Insertar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion},{ "@insRecaxUsuario", insRecaxUsuario } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
                return IdMax;
            }


            public DataTable ObtenerUnoPorCodigo(String insCodigo)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUnoporCodigo]", new object[,] { { "@insCodigo", insCodigo } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            #endregion
        }
    }
}