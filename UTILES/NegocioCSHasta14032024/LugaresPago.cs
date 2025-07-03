using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class  LugaresPago
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _lupId; 
			public Int32 lupId { get { return _lupId; } set { _lupId = value; } }

            private String _lupNombre; 
			public String lupNombre { get { return _lupNombre; } set { _lupNombre = value; } }

            private String _lupDireccion; 
			public String lupDireccion { get { return _lupDireccion; } set { _lupDireccion = value; } }

            private Decimal _lupComision; 
			public Decimal lupComision { get { return _lupComision; } set { _lupComision = value; } }

            private Boolean _lupActivo; 
			public Boolean lupActivo { get { return _lupActivo; } set { _lupActivo = value; } }

            private DateTime _lupFechaHoraCreacion; 
			public DateTime lupFechaHoraCreacion { get { return _lupFechaHoraCreacion; } set { _lupFechaHoraCreacion = value; } }

            private DateTime _lupFechaHoraUltimaModificacion; 
			public DateTime lupFechaHoraUltimaModificacion { get { return _lupFechaHoraUltimaModificacion; } set { _lupFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public LugaresPago() { try { this.lupId = 0; } catch (Exception oError) { throw oError; } }            

            public LugaresPago(Int32 lupId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[LugaresPago.ObtenerUno]", new object[,] {{"@lupId", lupId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["lupId"].ToString().Trim().Length > 0)
                        {
                            this.lupId = Convert.ToInt32(Fila.Rows[0]["lupId"]);
                        }
                        else
                        {
                            this.lupId = 0;
                        }

					    if(Fila.Rows[0]["lupNombre"].ToString().Trim().Length > 0)
                        {
                            this.lupNombre = Convert.ToString(Fila.Rows[0]["lupNombre"]);
                        }
                        else
                        {
                            this.lupNombre = "";
                        }

					    if(Fila.Rows[0]["lupDireccion"].ToString().Trim().Length > 0)
                        {
                            this.lupDireccion = Convert.ToString(Fila.Rows[0]["lupDireccion"]);
                        }
                        else
                        {
                            this.lupDireccion = "";
                        }

					    if(Fila.Rows[0]["lupComision"].ToString().Trim().Length > 0)
                        {
                            this.lupComision = Convert.ToDecimal(Fila.Rows[0]["lupComision"]);
                        }
                        else
                        {
                            this.lupComision = 0;
                        }

					    if(Fila.Rows[0]["lupFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.lupFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["lupFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.lupFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["lupFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.lupFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["lupFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.lupFechaHoraUltimaModificacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["lupActivo"].ToString().Trim().Length > 0)
                        {
                            this.lupActivo = (Convert.ToInt32(Fila.Rows[0]["lupActivo"]) == 1 ? true : false);
                        }
                        else
                        {
						    this.lupActivo = false;
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

            public LugaresPago(Int32 lupId, String lupNombre, String lupDireccion, Decimal lupComision, Boolean lupActivo, DateTime lupFechaHoraCreacion, DateTime lupFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {
				    this.lupId = lupId;
				    this.lupNombre = lupNombre;
				    this.lupDireccion = lupDireccion;
				    this.lupComision = lupComision;
				    this.lupActivo = lupActivo;
				    this.lupFechaHoraCreacion = lupFechaHoraCreacion;
				    this.lupFechaHoraUltimaModificacion = lupFechaHoraUltimaModificacion;
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

                			
            public DataTable ObtenerLista(String PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[LugaresPago.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
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
                	Tabla = ocdGestor.EjecutarReader("[LugaresPago.ObtenerTodo]", new object[,] {});
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
                	Tabla = ocdGestor.EjecutarReader("[LugaresPago.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 lupId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[LugaresPago.ObtenerUno]", new object[,] {{"@lupId", lupId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerValidarRepetido(Int32 lupId, String lupNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[LugaresPago.ObtenerValidarRepetido]", new object[,] {{"@lupId", lupId}, {"@lupNombre", lupNombre}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public void Actualizar(Int32 lupId, String lupNombre, String lupDireccion, Decimal lupComision, Boolean lupActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime lupFechaHoraCreacion, DateTime lupFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LugaresPago.Actualizar]", new object[,] {{"@lupId", lupId}, {"@lupNombre", lupNombre}, {"@lupDireccion", lupDireccion}, {"@lupComision", lupComision}, {"@lupActivo", lupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@lupFechaHoraCreacion", lupFechaHoraCreacion}, {"@lupFechaHoraUltimaModificacion", lupFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Copiar(String lupNombre, String lupDireccion, Decimal lupComision, Boolean lupActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime lupFechaHoraCreacion, DateTime lupFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LugaresPago.Copiar]", new object[,] {{"@lupNombre", lupNombre}, {"@lupDireccion", lupDireccion}, {"@lupComision", lupComision}, {"@lupActivo", lupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@lupFechaHoraCreacion", lupFechaHoraCreacion}, {"@lupFechaHoraUltimaModificacion", lupFechaHoraUltimaModificacion}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 lupId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LugaresPago.Eliminar]", new object[,] {{"@lupId", lupId}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(String lupNombre, String lupDireccion, Decimal lupComision, Boolean lupActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime lupFechaHoraCreacion, DateTime lupFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LugaresPago.Insertar]", new object[,] {{"@lupNombre", lupNombre}, {"@lupDireccion", lupDireccion}, {"@lupComision", lupComision}, {"@lupActivo", lupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@lupFechaHoraCreacion", lupFechaHoraCreacion}, {"@lupFechaHoraUltimaModificacion", lupFechaHoraUltimaModificacion}});
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
                    if(this.lupId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[LugaresPago.Actualizar]", new object[,] {{"@lupId", lupId}, {"@lupNombre", lupNombre}, {"@lupDireccion", lupDireccion}, {"@lupComision", lupComision}, {"@lupActivo", lupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@lupFechaHoraCreacion", lupFechaHoraCreacion}, {"@lupFechaHoraUltimaModificacion", lupFechaHoraUltimaModificacion}});
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
                    if(this.lupId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[LugaresPago.Copiar]", new object[,] {{"@lupNombre", lupNombre}, {"@lupDireccion", lupDireccion}, {"@lupComision", lupComision}, {"@lupActivo", lupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@lupFechaHoraCreacion", lupFechaHoraCreacion}, {"@lupFechaHoraUltimaModificacion", lupFechaHoraUltimaModificacion}});
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
                    if(this.lupId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[LugaresPago.Eliminar]", new object[,] {{"@lupId", lupId}});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[LugaresPago.Insertar]", new object[,] {{"@lupNombre", lupNombre}, {"@lupDireccion", lupDireccion}, {"@lupComision", lupComision}, {"@lupActivo", lupActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@lupFechaHoraCreacion", lupFechaHoraCreacion}, {"@lupFechaHoraUltimaModificacion", lupFechaHoraUltimaModificacion}});
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