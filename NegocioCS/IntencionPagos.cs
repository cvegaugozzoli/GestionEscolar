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

            private String _inp_ResultadoPago;
            public String inp_ResultadoPago { get { return _inp_ResultadoPago; } set { _inp_ResultadoPago = value; } }
            
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

            private String _inp_bearerToken;
            public String inp_bearerToken { get { return _inp_bearerToken; } set { _inp_bearerToken = value; } }

            private String _inp_CanalCobro;
            public String inp_CanalCobro { get { return _inp_CanalCobro; } set { _inp_CanalCobro = value; } }

            private String _inp_CodRechazo;
            public String inp_CodRechazo { get { return _inp_CodRechazo; } set { _inp_CodRechazo = value; } }

            private String _inp_DescripcionRechazo;
            public String inp_DescripcionRechazo { get { return _inp_DescripcionRechazo; } set { _inp_DescripcionRechazo = value; } }

            private Int32 _inp_Cuotas;
            public Int32 inp_Cuotas { get { return _inp_Cuotas; } set { _inp_Cuotas = value; } }

            private String _inp_Tarjetas;
            public String inp_Tarjetas { get { return _inp_Tarjetas; } set { _inp_Tarjetas = value; } }

            private Int32 _inp_idPagosSiro;
            public Int32 inp_idPagosSiro { get { return _inp_idPagosSiro; } set { _inp_idPagosSiro = value; } }

            private Decimal _inp_ImportePagado;
            public Decimal inp_ImportePagado { get { return _inp_ImportePagado; } set { _inp_ImportePagado = value; } }

            private DateTime _inp_fechaacreditacion;
            public DateTime inp_fechaacreditacion { get { return _inp_fechaacreditacion; } set { _inp_fechaacreditacion = value; } }

            private DateTime _inp_fechapago;
            public DateTime inp_fechapago { get { return _inp_fechapago; } set { _inp_fechapago = value; } }
            

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
                            this.inp_Monto = Convert.ToDecimal(Fila.Rows[0]["inp_Monto"]);
                        }
                        else
                        {
						    this.inp_Monto = 0;
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
                        if (Fila.Rows[0]["inp_bearerToken"].ToString().Trim().Length > 0)
                        {
                            this.inp_bearerToken = Convert.ToString(Fila.Rows[0]["inp_bearerToken"]);
                        }
                        else
                        {
                            this.inp_bearerToken = "";
                        }


                        if (Fila.Rows[0]["inp_CanalCobro"].ToString().Trim().Length > 0)
                        {
                            this.inp_CanalCobro = Convert.ToString(Fila.Rows[0]["inp_CanalCobro"]);
                        }
                        else
                        {
                            this.inp_CanalCobro = "";
                        }
                        if (Fila.Rows[0]["inp_CodRechazo"].ToString().Trim().Length > 0)
                        {
                            this.inp_CodRechazo = Convert.ToString(Fila.Rows[0]["inp_CodRechazo"]);
                        }
                        else
                        {
                            this.inp_CodRechazo = "";
                        }
                        if (Fila.Rows[0]["inp_DescripcionRechazo"].ToString().Trim().Length > 0)
                        {
                            this.inp_DescripcionRechazo = Convert.ToString(Fila.Rows[0]["inp_DescripcionRechazo"]);
                        }
                        else
                        {
                            this.inp_DescripcionRechazo = "";
                        }
                        if (Fila.Rows[0]["inp_Cuotas"].ToString().Trim().Length > 0)
                        {
                            this.inp_Cuotas = Convert.ToInt32(Fila.Rows[0]["inp_Cuotas"]);
                        }
                        else
                        {
                            this.inp_Cuotas = 0;
                        }
                        if (Fila.Rows[0]["inp_Tarjetas"].ToString().Trim().Length > 0)
                        {
                            this.inp_Tarjetas = Convert.ToString(Fila.Rows[0]["inp_Tarjetas"]);
                        }
                        else
                        {
                            this.inp_Tarjetas = "";
                        }
                        if (Fila.Rows[0]["inp_idPagosSiro"].ToString().Trim().Length > 0)
                        {
                            this.inp_idPagosSiro = Convert.ToInt32(Fila.Rows[0]["inp_idPagosSiro"]);
                        }
                        else
                        {
                            this.inp_idPagosSiro = 0;
                        }
                        if (Fila.Rows[0]["inp_ImportePagado"].ToString().Trim().Length > 0)
                        {
                            this.inp_ImportePagado = Convert.ToDecimal(Fila.Rows[0]["inp_ImportePagado"]);
                        }
                        else
                        {
                            this.inp_ImportePagado = 0;
                        }
                        if (Fila.Rows[0]["inp_fechaacreditacion"].ToString().Trim().Length > 0)
                        {
                            this.inp_fechaacreditacion = Convert.ToDateTime(Fila.Rows[0]["inp_fechaacreditacion"]);
                        }
                        else
                        {
                            this.inp_fechaacreditacion = DateTime.Now;
                        }
                        if (Fila.Rows[0]["inp_fechapago"].ToString().Trim().Length > 0)
                        {
                            this.inp_fechapago = Convert.ToDateTime(Fila.Rows[0]["inp_fechapago"]);
                        }
                        else
                        {
                            this.inp_fechapago = DateTime.Now;
                        }

                    }
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public IntencionPagos(Int32 inpId, String inp_IdReferenciaOperacion, String inp_Hash, DateTime inp_FechaCreacion, String inp_Estado, Decimal _inp_Monto, Int32 inp_UsuId, String inp_comprobantenro, Int32 aluid, DateTime inp_FechaExpiracion, String inp_bearerToken)
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
                    this.inp_bearerToken = inp_bearerToken;
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

            public DataTable ObtenerTodoBuscarxVarios(String inp_hash, Int32 inp_aluid)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[IntencionPagos.ObtenerTodoBuscarxVarios]", new object[,] { { "@inp_hash", inp_hash }, { "@inp_aluid", inp_aluid } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

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

            public void Actualizar(Int32 aluid, String inp_bearerToken, String inp_hash, String inp_ResultadoPago)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[IntencionPagos.Actualizar]", new object[,] {{ "@aluid", aluid }, { "@inp_bearerToken", inp_bearerToken }, { "@inp_hash", inp_hash }, { "@inp_ResultadoPago", inp_ResultadoPago } }); 
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }

            //public void ActualizarResultado_pago(String resultado_pago)
            //{
            //    try
            //    {
            //        if (this.becId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[IntencionPagos.Actualizar]", new object[,] { { "@resultado_pago", resultado_pago }, { "@resultado_pago", resultado_pago } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}


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
                    IdMax =  ocdGestor.EjecutarNonQueryRetornaId("[IntencionPagos.Insertar]", new object[,] { { "@inp_IdReferenciaOperacion", inp_IdReferenciaOperacion }, { "@inp_Hash", inp_Hash }, { "@inp_FechaCreacion", inp_FechaCreacion }, { "@inp_Estado", inp_Estado }, { "@_inp_Monto", _inp_Monto }, { "@inp_UsuId", inp_UsuId }, { "@inp_comprobantenro", inp_comprobantenro }, { "@aluid", aluid }, { "@inp_FechaExpiracion", inp_FechaExpiracion }, { "@inp_bearerToken", inp_bearerToken } });
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