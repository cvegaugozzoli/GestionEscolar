using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class IntencionPagos
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _inpId; 
			public Int32 inpId { get { return _inpId; } set { _inpId = value; } }

            private String _inp_IdReferenciaOperacion; 
			public String inp_IdReferenciaOperacion { get { return _inp_IdReferenciaOperacion; } set { _inp_IdReferenciaOperacion = value; } }

            private String _inp_Hash; 
			public String inp_Hash { get { return _inp_Hash; } set { _inp_Hash = value; } }

            private DateTime _inp_FechaCreacion;
            public DateTime inp_FechaCreacion { get { return _inp_FechaCreacion; } set { _inp_FechaCreacion = value; } }

            private String _inp_Estado; 
			public String inp_Estado { get { return _inp_Estado; } set { _inp_Estado = value; } }

            private Decimal _inp_Monto; 
			public Decimal inp_Monto { get { return _inp_Monto; } set { _inp_Monto = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _inp_UsuId; 
			public Int32 inp_UsuId { get { return _inp_UsuId; } set { _inp_UsuId = value; } }

            private String _inp_comprobantenro;
            public String inp_comprobantenro { get { return _inp_comprobantenro; } set { _inp_comprobantenro = value; } }

            private Int32 _aluid;
            public Int32 aluid { get { return _aluid; } set { _aluid = value; } }

            private DateTime _inp_FechaExpiracion;
            public DateTime inp_FechaExpiracion { get { return _inp_FechaExpiracion; } set { _inp_FechaExpiracion = value; } }

            #endregion

            #region Constructores

            public IntencionPagos() { try { this.inpId = 0; } catch (Exception oError) { throw oError; } }            

            public IntencionPagos(Int32 becId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[IntencionPagos.ObtenerUno]", new object[,] {{ "@inpId", inpId} });

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["inpId"].ToString().Trim().Length > 0)
                        {
                            this.inpId = Convert.ToInt32(Fila.Rows[0]["inpId"]);
                        }
                        else
                        {
                            this.inpId = 0;
                        }
                        if (Fila.Rows[0]["inp_IdReferenciaOperacion"].ToString().Trim().Length > 0)
                        {
                            this.inp_IdReferenciaOperacion = Convert.ToString(Fila.Rows[0]["inp_IdReferenciaOperacion"]);
                        }
                        else
                        {
                            this.inp_IdReferenciaOperacion = "";
                        }
					    if(Fila.Rows[0]["inp_Hash"].ToString().Trim().Length > 0)
                        {
                            this.inp_Hash = Convert.ToString(Fila.Rows[0]["inp_Hash"]);
                        }
                        else
                        {
                            this.inp_Hash = "";
                        }
					    if(Fila.Rows[0]["inp_FechaCreacion"].ToString().Trim().Length > 0)
                        {
                            this.inp_FechaCreacion = Convert.ToDateTime(Fila.Rows[0]["inp_FechaCreacion"]);
                        }
                        else
                        {
                            this.inp_FechaCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["inp_Estado"].ToString().Trim().Length > 0)
                        {
                            this.inp_Estado = Convert.ToString(Fila.Rows[0]["inp_Estado"]);
                        }
                        else
                        {
                            this.inp_Estado = "";
                        }

					    if(Fila.Rows[0]["inp_Monto"].ToString().Trim().Length > 0)
                        {
                            this._inp_Monto = Convert.ToDecimal(Fila.Rows[0]["inp_Monto"]);
                        }
                        else
                        {
						    this._inp_Monto = 0;
                        }
                        
					    if(Fila.Rows[0]["inp_UsuId"].ToString().Trim().Length > 0)
                        {
                            this.inp_UsuId = Convert.ToInt32(Fila.Rows[0]["inp_UsuId"]);
                        }
                        else
                        {
						    this.inp_UsuId = 0;
                        }
                        if (Fila.Rows[0]["inp_comprobantenro"].ToString().Trim().Length > 0)
                        {
                            this.inp_comprobantenro = Convert.ToString(Fila.Rows[0]["inp_comprobantenro"]);
                        }
                        else
                        {
                            this.inp_comprobantenro = "";
                        }
                        if (Fila.Rows[0]["aluid"].ToString().Trim().Length > 0)
                        {
                            this.aluid = Convert.ToInt32(Fila.Rows[0]["aluid"]);
                        }
                        else
                        {
                            this.aluid = 0;
                        }
                        if (Fila.Rows[0]["inp_FechaExpiracion"].ToString().Trim().Length > 0)
                        {
                            this.inp_FechaExpiracion = Convert.ToDateTime(Fila.Rows[0]["inp_FechaExpiracion"]);
                        }
                        else
                        {
                            this.inp_FechaExpiracion = DateTime.Now;
                        }

                        
                    }
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public IntencionPagos(Int32 inpId, String inp_IdReferenciaOperacion, String inp_Hash, DateTime inp_FechaCreacion, String inp_Estado, Decimal _inp_Monto, Int32 inp_UsuId, String inp_comprobantenro, Int32 aluid, DateTime inp_FechaExpiracion)
			{
                try
                {
				    this.inpId = inpId;
				    this.inp_IdReferenciaOperacion = inp_IdReferenciaOperacion;
				    this.inp_Hash = inp_Hash;
				    this.inp_FechaCreacion = inp_FechaCreacion;
                    this.inp_Estado = inp_Estado;
                    this._inp_Monto = _inp_Monto;
				    this.inp_UsuId = inp_UsuId;
                    this.inp_comprobantenro = inp_comprobantenro;
                    this.aluid = aluid;
                    this.inp_FechaExpiracion = inp_FechaExpiracion;
                }
			    catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerLista]", new object[,] {{"@PrimerItem", PrimerItem}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerTodo]", new object[,] {});
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
            //    	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerUno(Int32 becId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Becas.ObtenerUno]", new object[,] {{"@becId", becId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}


            //  public IntencionPagos(Int32 inpId, String inp_IdReferenciaOperacion, String inp_Hash, DateTime inp_FechaCreacion, String inp_Estado, Decimal _inp_Monto, Int32 inp_UsuId)

            public void Actualizar(Int32 inpId, String inp_IdReferenciaOperacion, String inp_Hash, DateTime inp_FechaCreacion, String inp_Estado, Decimal _inp_Monto, Int32 inp_UsuId, String inp_comprobantenro, Int32 aluid, DateTime inp_FechaExpiracion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[IntencionPagos.Actualizar]", new object[,] {{ "@inpId", inpId}, { "@inp_IdReferenciaOperacion", inp_IdReferenciaOperacion}, {"@inp_Hash", inp_Hash}, { "@inp_FechaCreacion", inp_FechaCreacion }, { "@inp_Estado", inp_Estado }, {"@_inp_Monto", _inp_Monto}, {"@inp_UsuId", inp_UsuId}, { "@inp_comprobantenro", inp_comprobantenro }, { "@aluid", aluid }, { "@inp_FechaExpiracion", inp_FechaExpiracion } }); 
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
		
            //public void Eliminar(Int32 becId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Becas.Eliminar]", new object[,] {{"@becId", becId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}
                			
            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax =  ocdGestor.EjecutarNonQueryRetornaId("[IntencionPagos.Insertar]", new object[,] { { "@inp_IdReferenciaOperacion", inp_IdReferenciaOperacion }, { "@inp_Hash", inp_Hash }, { "@inp_FechaCreacion", inp_FechaCreacion }, { "@inp_Estado", inp_Estado }, { "@_inp_Monto", _inp_Monto }, { "@inp_UsuId", inp_UsuId }, { "@inp_comprobantenro", inp_comprobantenro }, { "@aluid", aluid }, { "@inp_FechaExpiracion", inp_FechaExpiracion } });
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