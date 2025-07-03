using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class GrupoSanguineo
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _gsaId; 
			public Int32 gsaId { get { return _gsaId; } set { _gsaId = value; } }

            private String _gsaNombre; 
			public String gsaNombre { get { return _gsaNombre; } set { _gsaNombre = value; } }

     
            #endregion

            #region Constructores

            public GrupoSanguineo() { try { this.gsaId = 0; } catch (Exception oError) { throw oError; } }            

            public GrupoSanguineo(Int32 gsaId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[FormasPago.ObtenerUno]", new object[,] {{ "@gsaId", gsaId } });

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["gsaId"].ToString().Trim().Length > 0)
                        {
                            this.gsaId = Convert.ToInt32(Fila.Rows[0]["gsaId"]);
                        }
                        else
                        {
                            this.gsaId = 0;
                        }

					    if(Fila.Rows[0]["gsaNombre"].ToString().Trim().Length > 0)
                        {
                            this.gsaNombre = Convert.ToString(Fila.Rows[0]["gsaNombre"]);
                        }
                        else
                        {
                            this.gsaNombre = "";
                        }				
					}
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public GrupoSanguineo(Int32 gsaId, String gsaNombre)
			{
                try
                {
				    this.gsaId = gsaId;
				    this.gsaNombre = gsaNombre;
				  
                }
			    catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos

                			
      
                			
            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[GrupoSanguineo.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerTodo]", new object[,] {});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}
                			
            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[FormasPago.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}
                			
            public DataTable ObtenerUno(Int32 gsaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[GrupoSanguineo.ObtenerUno]", new object[,] {{ "@gsaId", gsaId } });
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