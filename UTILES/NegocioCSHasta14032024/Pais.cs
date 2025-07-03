using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  Pais
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

        
            private int _CODPAIS; 
			public int CODPAIS { get { return _CODPAIS; } set { _CODPAIS = value; } }

            private String _NOMBREPAIS; 
			public String NOMBREPAIS { get { return _NOMBREPAIS; } set { _NOMBREPAIS = value; } }
            
            #endregion

            #region Constructores

            public Pais() { try { this.CODPAIS = 0; } catch (Exception oError) { throw oError; } }            

            public Pais(Int32 CODPAIS)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Pais.ObtenerUno]", new object[,] {{ "@CODPAIS", CODPAIS } });

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["CODPAIS"].ToString().Trim().Length > 0)
                        {
                            this.CODPAIS = Convert.ToInt32(Fila.Rows[0]["CODPAIS"]);
                        }
                        else
                        {
                            this.CODPAIS = 0;
                        }

					    if(Fila.Rows[0]["NOMBREPAIS"].ToString().Trim().Length > 0)
                        {
                            this.NOMBREPAIS = Convert.ToString(Fila.Rows[0]["NOMBREPAIS"]);
                        }
                        else
                        {
                            this.NOMBREPAIS = "";
                        }

					  
                        
					}
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public Pais(Int32 CODPAIS, String NOMPAIS)
			{
                try
                {
				    this.CODPAIS = CODPAIS;
				    this.NOMBREPAIS = NOMPAIS;
				   
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
                	Tabla = ocdGestor.EjecutarReader("[Pais.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
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
                	Tabla = ocdGestor.EjecutarReader("[Pais.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[Pais.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[Pais.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 CODPAIS)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[pAIS.ObtenerUno]", new object[,] {{"@CODPAIS", CODPAIS}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 CODPAIS, String NOMBREPAIS)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[Pais.ObtenerValidarRepetido]", new object[,] {{ "@CODPAIS", CODPAIS }, { "@NOMBREPAIS", NOMBREPAIS } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 CODPAIS, String NOMBREPAIS)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Pais.Actualizar]", new object[,] {{ "@CODPAIS", CODPAIS }, { "@NOMBREPAIS", NOMBREPAIS },});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            //public void Copiar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                			
            //public void Eliminar(Int32 sexId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                			
            //public void Insertar(String sexNombre, Boolean sexActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime sexFechaHoraCreacion, DateTime sexFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Sexo.Insertar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                			
            //public void Actualizar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Actualizar]", new object[,] {{"@sexId", sexId}, {"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                
            //public void Copiar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Copiar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                
            //public void Eliminar()
            //{
            //    try
            //    {
            //        if(this.sexId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Sexo.Eliminar]", new object[,] {{"@sexId", sexId}});
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                
            //public Int32 Insertar()
            //{
            //    Int32 IdMax;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Sexo.Insertar]", new object[,] {{"@sexNombre", sexNombre}, {"@sexActivo", sexActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@sexFechaHoraCreacion", sexFechaHoraCreacion}, {"@sexFechaHoraUltimaModificacion", sexFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //    return IdMax;
            //}
                

            #endregion
        }
    }
}