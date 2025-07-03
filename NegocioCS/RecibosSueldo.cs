using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class RECIBOSSUELDO
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _REC_ID; 
			public Int32 REC_ID { get { return _REC_ID; } set { _REC_ID = value; } }

            private Int32 _ECLC_EMC_ID; 
			public Int32 ECLC_EMC_ID { get { return _ECLC_EMC_ID; } set { _ECLC_EMC_ID = value; } }

            private String _LUP_DESCRIPCION; 
			public String LUP_DESCRIPCION { get { return _LUP_DESCRIPCION; } set { _LUP_DESCRIPCION = value; } }

            private String _LUP_DIRECCION; 
			public String LUP_DIRECCION { get { return _LUP_DIRECCION; } set { _LUP_DIRECCION = value; } }

            private String _LUP_CUIT; 
			public String LUP_CUIT { get { return _LUP_CUIT; } set { _LUP_CUIT = value; } }

            private String _EMP_APELLIDO; 
			public String EMP_APELLIDO { get { return _EMP_APELLIDO; } set { _EMP_APELLIDO = value; } }

            private String _EMP_NOMBRE; 
			public String EMP_NOMBRE { get { return _EMP_NOMBRE; } set { _EMP_NOMBRE = value; } }

            private DateTime _EMC_FEC_INI; 
			public DateTime EMC_FEC_INI { get { return _EMC_FEC_INI; } set { _EMC_FEC_INI = value; } }

            private String _EMP_DNI; 
			public String EMP_DNI { get { return _EMP_DNI; } set { _EMP_DNI = value; } }

            private String _CON_DESCRIPCION; 
			public String CON_DESCRIPCION { get { return _CON_DESCRIPCION; } set { _CON_DESCRIPCION = value; } }

            private Int32 _LIQ_MES; 
			public Int32 LIQ_MES { get { return _LIQ_MES; } set { _LIQ_MES = value; } }

            private Int32 _LIQ_ANIO; 
			public Int32 LIQ_ANIO { get { return _LIQ_ANIO; } set { _LIQ_ANIO = value; } }

            private Decimal _ECL_IMPORTE; 
			public Decimal ECL_IMPORTE { get { return _ECL_IMPORTE; } set { _ECL_IMPORTE = value; } }

            private Int32 _ECC_UNIDAD; 
			public Int32 ECC_UNIDAD { get { return _ECC_UNIDAD; } set { _ECC_UNIDAD = value; } }

            private Decimal _ECC_VALOR; 
			public Decimal ECC_VALOR { get { return _ECC_VALOR; } set { _ECC_VALOR = value; } }

            private Int32 _ECL_VALOR; 
			public Int32 ECL_VALOR { get { return _ECL_VALOR; } set { _ECL_VALOR = value; } }

            private String _CARGO_NOMBRE; 
			public String CARGO_NOMBRE { get { return _CARGO_NOMBRE; } set { _CARGO_NOMBRE = value; } }

            private Int32 _OBLIG_MENSUALES; 
			public Int32 OBLIG_MENSUALES { get { return _OBLIG_MENSUALES; } set { _OBLIG_MENSUALES = value; } }

            private Int32 _DIAS_HS_TRABAJADOS; 
			public Int32 DIAS_HS_TRABAJADOS { get { return _DIAS_HS_TRABAJADOS; } set { _DIAS_HS_TRABAJADOS = value; } }

            private Decimal _ANTIG_REC; 
			public Decimal ANTIG_REC { get { return _ANTIG_REC; } set { _ANTIG_REC = value; } }

            private Decimal _DESCUENTOS; 
			public Decimal DESCUENTOS { get { return _DESCUENTOS; } set { _DESCUENTOS = value; } }

            private Decimal _BRUTO; 
			public Decimal BRUTO { get { return _BRUTO; } set { _BRUTO = value; } }

            private Decimal _LIQUIDO; 
			public Decimal LIQUIDO { get { return _LIQUIDO; } set { _LIQUIDO = value; } }

            private String _NIV_DESCRIPCION; 
			public String NIV_DESCRIPCION { get { return _NIV_DESCRIPCION; } set { _NIV_DESCRIPCION = value; } }

            private String _PLA_DESCRIPCION; 
			public String PLA_DESCRIPCION { get { return _PLA_DESCRIPCION; } set { _PLA_DESCRIPCION = value; } }

            private Decimal _BONIFICA; 
			public Decimal BONIFICA { get { return _BONIFICA; } set { _BONIFICA = value; } }

            private Decimal _DESCTO; 
			public Decimal DESCTO { get { return _DESCTO; } set { _DESCTO = value; } }

            private Decimal _LIQUIDO2; 
			public Decimal LIQUIDO2 { get { return _LIQUIDO2; } set { _LIQUIDO2 = value; } }

            private Decimal _ECL_CANTIDAD; 
			public Decimal ECL_CANTIDAD { get { return _ECL_CANTIDAD; } set { _ECL_CANTIDAD = value; } }

            private Int32 _LIQ_LIT_ID;
            public Int32 LIQ_LIT_ID { get { return _LIQ_LIT_ID; } set { _LIQ_LIT_ID = value; } }

            private Int32 _CON_COC_ID;
            public Int32 CON_COC_ID { get { return _CON_COC_ID; } set { _CON_COC_ID = value; } }

            private String _ANT_TOTAL; 
			public String ANT_TOTAL { get { return _ANT_TOTAL; } set { _ANT_TOTAL = value; } }


            private String _BAN_NOMBRE;
            public String BAN_NOMBRE { get { return _BAN_NOMBRE; } set { _BAN_NOMBRE = value; } }

            private DateTime _LIQ_FECHA_PAGO;
            public DateTime LIQ_FECHA_PAGO { get { return _LIQ_FECHA_PAGO; } set { _LIQ_FECHA_PAGO = value; } }

            private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuIdUltimaModificacion; 
			public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            private Int32 _LIQ_ID;
            public Int32 LIQ_ID { get { return _LIQ_ID; } set { _LIQ_ID = value; } }

            private Int32 _ECLC_ID;
            public Int32 ECLC_ID { get { return _ECLC_ID; } set { _ECLC_ID = value; } }

            private String _LIQ_DESCRIPCION;
            public String LIQ_DESCRIPCION { get { return _LIQ_DESCRIPCION; } set { _LIQ_DESCRIPCION = value; } }

            #endregion

            #region Constructores

            public RECIBOSSUELDO() { try { this.REC_ID = 0; } catch (Exception oError) { throw oError; } }            

            public RECIBOSSUELDO(Int32 REC_ID)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[RECIBOSSUELDO.ObtenerUno]", new object[,] {{"@REC_ID", REC_ID}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["REC_ID"].ToString().Trim().Length > 0)
                        {
                            this.REC_ID = Convert.ToInt32(Fila.Rows[0]["REC_ID"]);
                        }
                        else
                        {
                            this.REC_ID = 0;
                        }

					    if(Fila.Rows[0]["ECLC_EMC_ID"].ToString().Trim().Length > 0)
                        {
                            this.ECLC_EMC_ID = Convert.ToInt32(Fila.Rows[0]["ECLC_EMC_ID"]);
                        }
                        else
                        {
                            this.ECLC_EMC_ID = 0;
                        }

					    if(Fila.Rows[0]["LUP_DESCRIPCION"].ToString().Trim().Length > 0)
                        {
                            this.LUP_DESCRIPCION = Convert.ToString(Fila.Rows[0]["LUP_DESCRIPCION"]);
                        }
                        else
                        {
                            this.LUP_DESCRIPCION = "";
                        }

					    if(Fila.Rows[0]["LUP_DIRECCION"].ToString().Trim().Length > 0)
                        {
                            this.LUP_DIRECCION = Convert.ToString(Fila.Rows[0]["LUP_DIRECCION"]);
                        }
                        else
                        {
                            this.LUP_DIRECCION = "";
                        }

					    if(Fila.Rows[0]["LUP_CUIT"].ToString().Trim().Length > 0)
                        {
                            this.LUP_CUIT = Convert.ToString(Fila.Rows[0]["LUP_CUIT"]);
                        }
                        else
                        {
                            this.LUP_CUIT = "";
                        }

					    if(Fila.Rows[0]["EMP_APELLIDO"].ToString().Trim().Length > 0)
                        {
                            this.EMP_APELLIDO = Convert.ToString(Fila.Rows[0]["EMP_APELLIDO"]);
                        }
                        else
                        {
                            this.EMP_APELLIDO = "";
                        }

					    if(Fila.Rows[0]["EMP_NOMBRE"].ToString().Trim().Length > 0)
                        {
                            this.EMP_NOMBRE = Convert.ToString(Fila.Rows[0]["EMP_NOMBRE"]);
                        }
                        else
                        {
                            this.EMP_NOMBRE = "";
                        }

					    if(Fila.Rows[0]["EMC_FEC_INI"].ToString().Trim().Length > 0)
                        {
                            this.EMC_FEC_INI = Convert.ToDateTime(Fila.Rows[0]["EMC_FEC_INI"]);
                        }
                        else
                        {
                            this.EMC_FEC_INI = DateTime.Now;
                        }

					    if(Fila.Rows[0]["EMP_DNI"].ToString().Trim().Length > 0)
                        {
                            this.EMP_DNI = Convert.ToString(Fila.Rows[0]["EMP_DNI"]);
                        }
                        else
                        {
                            this.EMP_DNI = "";
                        }

					    if(Fila.Rows[0]["CON_DESCRIPCION"].ToString().Trim().Length > 0)
                        {
                            this.CON_DESCRIPCION = Convert.ToString(Fila.Rows[0]["CON_DESCRIPCION"]);
                        }
                        else
                        {
                            this.CON_DESCRIPCION = "";
                        }

					    if(Fila.Rows[0]["LIQ_MES"].ToString().Trim().Length > 0)
                        {
                            this.LIQ_MES = Convert.ToInt32(Fila.Rows[0]["LIQ_MES"]);
                        }
                        else
                        {
                            this.LIQ_MES = 0;
                        }

					    if(Fila.Rows[0]["LIQ_ANIO"].ToString().Trim().Length > 0)
                        {
                            this.LIQ_ANIO = Convert.ToInt32(Fila.Rows[0]["LIQ_ANIO"]);
                        }
                        else
                        {
                            this.LIQ_ANIO = 0;
                        }

					    if(Fila.Rows[0]["ECL_IMPORTE"].ToString().Trim().Length > 0)
                        {
                            this.ECL_IMPORTE = Convert.ToDecimal(Fila.Rows[0]["ECL_IMPORTE"]);
                        }
                        else
                        {
                            this.ECL_IMPORTE = 0;
                        }

					    if(Fila.Rows[0]["ECC_UNIDAD"].ToString().Trim().Length > 0)
                        {
                            this.ECC_UNIDAD = Convert.ToInt32(Fila.Rows[0]["ECC_UNIDAD"]);
                        }
                        else
                        {
                            this.ECC_UNIDAD = 0;
                        }

					    if(Fila.Rows[0]["ECC_VALOR"].ToString().Trim().Length > 0)
                        {
                            this.ECC_VALOR = Convert.ToDecimal(Fila.Rows[0]["ECC_VALOR"]);
                        }
                        else
                        {
                            this.ECC_VALOR = 0;
                        }

					    if(Fila.Rows[0]["ECL_VALOR"].ToString().Trim().Length > 0)
                        {
                            this.ECL_VALOR = Convert.ToInt32(Fila.Rows[0]["ECL_VALOR"]);
                        }
                        else
                        {
                            this.ECL_VALOR = 0;
                        }

					    if(Fila.Rows[0]["CARGO_NOMBRE"].ToString().Trim().Length > 0)
                        {
                            this.CARGO_NOMBRE = Convert.ToString(Fila.Rows[0]["CARGO_NOMBRE"]);
                        }
                        else
                        {
                            this.CARGO_NOMBRE = "";
                        }

					    if(Fila.Rows[0]["OBLIG_MENSUALES"].ToString().Trim().Length > 0)
                        {
                            this.OBLIG_MENSUALES = Convert.ToInt32(Fila.Rows[0]["OBLIG_MENSUALES"]);
                        }
                        else
                        {
                            this.OBLIG_MENSUALES = 0;
                        }

					    if(Fila.Rows[0]["DIAS_HS_TRABAJADOS"].ToString().Trim().Length > 0)
                        {
                            this.DIAS_HS_TRABAJADOS = Convert.ToInt32(Fila.Rows[0]["DIAS_HS_TRABAJADOS"]);
                        }
                        else
                        {
                            this.DIAS_HS_TRABAJADOS = 0;
                        }

					    if(Fila.Rows[0]["ANTIG_REC"].ToString().Trim().Length > 0)
                        {
                            this.ANTIG_REC = Convert.ToDecimal(Fila.Rows[0]["ANTIG_REC"]);
                        }
                        else
                        {
                            this.ANTIG_REC = 0;
                        }

					    if(Fila.Rows[0]["DESCUENTOS"].ToString().Trim().Length > 0)
                        {
                            this.DESCUENTOS = Convert.ToDecimal(Fila.Rows[0]["DESCUENTOS"]);
                        }
                        else
                        {
                            this.DESCUENTOS = 0;
                        }

					    if(Fila.Rows[0]["BRUTO"].ToString().Trim().Length > 0)
                        {
                            this.BRUTO = Convert.ToDecimal(Fila.Rows[0]["BRUTO"]);
                        }
                        else
                        {
                            this.BRUTO = 0;
                        }

					    if(Fila.Rows[0]["LIQUIDO"].ToString().Trim().Length > 0)
                        {
                            this.LIQUIDO = Convert.ToDecimal(Fila.Rows[0]["LIQUIDO"]);
                        }
                        else
                        {
                            this.LIQUIDO = 0;
                        }

					    if(Fila.Rows[0]["NIV_DESCRIPCION"].ToString().Trim().Length > 0)
                        {
                            this.NIV_DESCRIPCION = Convert.ToString(Fila.Rows[0]["NIV_DESCRIPCION"]);
                        }
                        else
                        {
                            this.NIV_DESCRIPCION = "";
                        }

					    if(Fila.Rows[0]["PLA_DESCRIPCION"].ToString().Trim().Length > 0)
                        {
                            this.PLA_DESCRIPCION = Convert.ToString(Fila.Rows[0]["PLA_DESCRIPCION"]);
                        }
                        else
                        {
                            this.PLA_DESCRIPCION = "";
                        }

					    if(Fila.Rows[0]["BONIFICA"].ToString().Trim().Length > 0)
                        {
                            this.BONIFICA = Convert.ToDecimal(Fila.Rows[0]["BONIFICA"]);
                        }
                        else
                        {
                            this.BONIFICA = 0;
                        }

					    if(Fila.Rows[0]["DESCTO"].ToString().Trim().Length > 0)
                        {
                            this.DESCTO = Convert.ToDecimal(Fila.Rows[0]["DESCTO"]);
                        }
                        else
                        {
                            this.DESCTO = 0;
                        }

					    if(Fila.Rows[0]["LIQUIDO2"].ToString().Trim().Length > 0)
                        {
                            this.LIQUIDO2 = Convert.ToDecimal(Fila.Rows[0]["LIQUIDO2"]);
                        }
                        else
                        {
                            this.LIQUIDO2 = 0;
                        }

					    if(Fila.Rows[0]["ECL_CANTIDAD"].ToString().Trim().Length > 0)
                        {
                            this.ECL_CANTIDAD = Convert.ToDecimal(Fila.Rows[0]["ECL_CANTIDAD"]);
                        }
                        else
                        {
                            this.ECL_CANTIDAD = 0;
                        }

					    if(Fila.Rows[0]["ANT_TOTAL"].ToString().Trim().Length > 0)
                        {
                            this.ANT_TOTAL = Convert.ToString(Fila.Rows[0]["ANT_TOTAL"]);
                        }
                        else
                        {
                            this.ANT_TOTAL = "";
                        }

                        if (Fila.Rows[0]["BAN_NOMBRE"].ToString().Trim().Length > 0)
                        {
                            this.BAN_NOMBRE = Convert.ToString(Fila.Rows[0]["BAN_NOMBRE"]);
                        }
                        else
                        {
                            this.BAN_NOMBRE = "";
                        }


                        if (Fila.Rows[0]["LIQ_FECHA_PAGO"].ToString().Trim().Length > 0)
                        {
                            this.EMC_FEC_INI = Convert.ToDateTime(Fila.Rows[0]["LIQ_FECHA_PAGO"]);
                        }
                        else
                        {
                            this.EMC_FEC_INI = DateTime.Now;
                        }


                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
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

                        if (Fila.Rows[0]["LIQ_ID"].ToString().Trim().Length > 0)
                        {
                            this.LIQ_ID = Convert.ToInt32(Fila.Rows[0]["LIQ_ID"]);
                        }
                        else
                        {
                            this.LIQ_ID = 0;
                        }

                        if (Fila.Rows[0]["ECLC_ID"].ToString().Trim().Length > 0)
                        {
                            this.LIQ_ID = Convert.ToInt32(Fila.Rows[0]["ECLC_ID"]);
                        }
                        else
                        {
                            this.LIQ_ID = 0;
                        }

                        if (Fila.Rows[0]["LIQ_DESCRIPCION"].ToString().Trim().Length > 0)
                        {
                            this.LIQ_DESCRIPCION = Convert.ToString(Fila.Rows[0]["LIQ_DESCRIPCION"]);
                        }
                        else
                        {
                            this.LIQ_DESCRIPCION = "";
                        }

                    }
                }
				catch (Exception oError)
                {
                    throw oError;
                }
            }

            public RECIBOSSUELDO(Int32 REC_ID, Int32 ECLC_EMC_ID, String LUP_DESCRIPCION, String LUP_DIRECCION, String LUP_CUIT, String EMP_APELLIDO, String EMP_NOMBRE, DateTime EMC_FEC_INI, String EMP_DNI, String CON_DESCRIPCION, Int32 LIQ_MES, Int32 LIQ_ANIO, Decimal ECL_IMPORTE, Int32 ECC_UNIDAD, Decimal ECC_VALOR, Int32 ECL_VALOR, String CARGO_NOMBRE, Int32 OBLIG_MENSUALES, Int32 DIAS_HS_TRABAJADOS, Decimal ANTIG_REC, Decimal DESCUENTOS, Decimal BRUTO, Decimal LIQUIDO, String NIV_DESCRIPCION, String PLA_DESCRIPCION, Decimal BONIFICA, Decimal DESCTO, Decimal LIQUIDO2, Decimal ECL_CANTIDAD, Int32 LIQ_LIT_ID, Int32 CON_COC_ID, String ANT_TOTAL, String BAN_NOMBRE, DateTime LIQ_FECHA_PAGO, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion, Int32 LIQ_ID, Int32 ECLC_ID, String LIQ_DESCRIPCION)
			{
                try
                {
				    this.REC_ID = REC_ID;
				    this.ECLC_EMC_ID = ECLC_EMC_ID;
				    this.LUP_DESCRIPCION = LUP_DESCRIPCION;
				    this.LUP_DIRECCION = LUP_DIRECCION;
				    this.LUP_CUIT = LUP_CUIT;
				    this.EMP_APELLIDO = EMP_APELLIDO;
				    this.EMP_NOMBRE = EMP_NOMBRE;
				    this.EMC_FEC_INI = EMC_FEC_INI;
				    this.EMP_DNI = EMP_DNI;
				    this.CON_DESCRIPCION = CON_DESCRIPCION;
				    this.LIQ_MES = LIQ_MES;
				    this.LIQ_ANIO = LIQ_ANIO;
				    this.ECL_IMPORTE = ECL_IMPORTE;
				    this.ECC_UNIDAD = ECC_UNIDAD;
				    this.ECC_VALOR = ECC_VALOR;
				    this.ECL_VALOR = ECL_VALOR;
				    this.CARGO_NOMBRE = CARGO_NOMBRE;
				    this.OBLIG_MENSUALES = OBLIG_MENSUALES;
				    this.DIAS_HS_TRABAJADOS = DIAS_HS_TRABAJADOS;
				    this.ANTIG_REC = ANTIG_REC;
				    this.DESCUENTOS = DESCUENTOS;
				    this.BRUTO = BRUTO;
				    this.LIQUIDO = LIQUIDO;
				    this.NIV_DESCRIPCION = NIV_DESCRIPCION;
				    this.PLA_DESCRIPCION = PLA_DESCRIPCION;
				    this.BONIFICA = BONIFICA;
				    this.DESCTO = DESCTO;
				    this.LIQUIDO2 = LIQUIDO2;
				    this.ECL_CANTIDAD = ECL_CANTIDAD;
                    this.LIQ_LIT_ID = LIQ_LIT_ID;
                    this.CON_COC_ID = CON_COC_ID;
                    this.ANT_TOTAL = ANT_TOTAL;
				    this.usuIdCreacion = usuIdCreacion;
				    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                    this.LIQ_ID = LIQ_ID;
                    this.ECLC_ID = ECLC_ID;
                    this.LIQ_DESCRIPCION = LIQ_DESCRIPCION;
                }
			    catch (Exception oError)
                {
                    throw oError;
                }
            }
            #endregion

            #region Metodos

                			
            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[RECIBOSSUELDO.ObtenerTodo]", new object[,] {});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }
                			
            public DataTable ObtenerUno(Int32 REC_ID)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                	Tabla = ocdGestor.EjecutarReader("[RECIBOSSUELDO.ObtenerUno]", new object[,] {{"@REC_ID", REC_ID}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }

                return Tabla;
            }


            public DataTable ControlarSiExiste(Int32 liqid, String EMP_DNI)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RECIBOSSUELDO.ControlarSiExiste]", new object[,] { { "@liqid", liqid }, { "@EMP_DNI", EMP_DNI } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable MostrarporCargo(Int32 liqid, String EMP_DNI)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RECIBOSSUELDO.MostrarporCargo]", new object[,] { { "@liqid", liqid }, { "@EMP_DNI", EMP_DNI } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ListarLiquidacionporEmpleadoporCargo(Int32 liqid, String EMP_DNI, Int32 ECLC_EMC_ID)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RECIBOSSUELDO.ListarLiquidacionporEmpleadoporCargo]", new object[,] { { "@liqid", liqid }, { "@EMP_DNI", EMP_DNI }, { "@ECLC_EMC_ID", ECLC_EMC_ID } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public void Actualizar(Int32 REC_ID, Int32 ECLC_EMC_ID, String LUP_DESCRIPCION, String LUP_DIRECCION, String LUP_CUIT, String EMP_APELLIDO, String EMP_NOMBRE, DateTime EMC_FEC_INI, String EMP_DNI, String CON_DESCRIPCION, Int32 LIQ_MES, Int32 LIQ_ANIO, Decimal ECL_IMPORTE, Int32 ECC_UNIDAD, Decimal ECC_VALOR, Int32 ECL_VALOR, String CARGO_NOMBRE, Int32 OBLIG_MENSUALES, Int32 DIAS_HS_TRABAJADOS, Decimal ANTIG_REC, Decimal DESCUENTOS, Decimal BRUTO, Decimal LIQUIDO, String NIV_DESCRIPCION, String PLA_DESCRIPCION, Decimal BONIFICA, Decimal DESCTO, Decimal LIQUIDO2, Decimal ECL_CANTIDAD, String ANT_TOTAL, String BAN_NOMBRE, DateTime LIQ_FECHA_PAGO, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, Int32 LIQ_ID, Int32 ECLC_ID, String LIQ_DESCRIPCION)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RECIBOSSUELDO.Actualizar]", new object[,] {{"@REC_ID", REC_ID}, {"@ECLC_EMC_ID", ECLC_EMC_ID}, {"@LUP_DESCRIPCION", LUP_DESCRIPCION}, {"@LUP_DIRECCION", LUP_DIRECCION}, {"@LUP_CUIT", LUP_CUIT}, {"@EMP_APELLIDO", EMP_APELLIDO}, {"@EMP_NOMBRE", EMP_NOMBRE}, {"@EMC_FEC_INI", EMC_FEC_INI}, {"@EMP_DNI", EMP_DNI}, {"@CON_DESCRIPCION", CON_DESCRIPCION}, {"@LIQ_MES", LIQ_MES}, {"@LIQ_ANIO", LIQ_ANIO}, {"@ECL_IMPORTE", ECL_IMPORTE}, {"@ECC_UNIDAD", ECC_UNIDAD}, {"@ECC_VALOR", ECC_VALOR}, {"@ECL_VALOR", ECL_VALOR}, {"@CARGO_NOMBRE", CARGO_NOMBRE}, {"@OBLIG_MENSUALES", OBLIG_MENSUALES}, {"@DIAS_HS_TRABAJADOS", DIAS_HS_TRABAJADOS}, {"@ANTIG_REC", ANTIG_REC}, {"@DESCUENTOS", DESCUENTOS}, {"@BRUTO", BRUTO}, {"@LIQUIDO", LIQUIDO}, {"@NIV_DESCRIPCION", NIV_DESCRIPCION}, {"@PLA_DESCRIPCION", PLA_DESCRIPCION}, {"@BONIFICA", BONIFICA}, {"@DESCTO", DESCTO}, {"@LIQUIDO2", LIQUIDO2}, {"@ECL_CANTIDAD", ECL_CANTIDAD}, {"@ANT_TOTAL", ANT_TOTAL}, { "@BAN_NOMBRE", BAN_NOMBRE }, { "@LIQ_FECHA_PAGO", LIQ_FECHA_PAGO }, { "@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, { "@LIQ_ID", LIQ_ID }, { "@ECLC_ID", ECLC_ID }, { "@LIQ_DESCRIPCION", LIQ_DESCRIPCION } });
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Eliminar(Int32 REC_ID)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RECIBOSSUELDO.Eliminar]", new object[,] {{"@REC_ID", REC_ID}});
                }
                catch (Exception oError)
                {
                	throw oError;
                }
            }
                			
            public void Insertar(Int32 ECLC_EMC_ID, String LUP_DESCRIPCION, String LUP_DIRECCION, String LUP_CUIT, String EMP_APELLIDO, String EMP_NOMBRE, DateTime EMC_FEC_INI, String EMP_DNI, String CON_DESCRIPCION, Int32 LIQ_MES, Int32 LIQ_ANIO, Decimal ECL_IMPORTE, Int32 ECC_UNIDAD, Decimal ECC_VALOR, Int32 ECL_VALOR, String CARGO_NOMBRE, Int32 OBLIG_MENSUALES, Int32 DIAS_HS_TRABAJADOS, Decimal ANTIG_REC, Decimal DESCUENTOS, Decimal BRUTO, Decimal LIQUIDO, String NIV_DESCRIPCION, String PLA_DESCRIPCION, Decimal BONIFICA, Decimal DESCTO, Decimal LIQUIDO2, Decimal ECL_CANTIDAD, Int32 LIQ_LIT_ID, Int32 CON_COC_ID, String ANT_TOTAL, String BAN_NOMBRE, DateTime LIQ_FECHA_PAGO, Int32 LIQ_ID, Int32 ECLC_ID, String LIQ_DESCRIPCION)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RECIBOSSUELDO.Insertar]", new object[,] {{"@ECLC_EMC_ID", ECLC_EMC_ID}, {"@LUP_DESCRIPCION", LUP_DESCRIPCION}, {"@LUP_DIRECCION", LUP_DIRECCION}, {"@LUP_CUIT", LUP_CUIT}, {"@EMP_APELLIDO", EMP_APELLIDO}, {"@EMP_NOMBRE", EMP_NOMBRE}, {"@EMC_FEC_INI", EMC_FEC_INI}, {"@EMP_DNI", EMP_DNI}, {"@CON_DESCRIPCION", CON_DESCRIPCION}, {"@LIQ_MES", LIQ_MES}, {"@LIQ_ANIO", LIQ_ANIO}, {"@ECL_IMPORTE", ECL_IMPORTE}, {"@ECC_UNIDAD", ECC_UNIDAD}, {"@ECC_VALOR", ECC_VALOR}, {"@ECL_VALOR", ECL_VALOR}, {"@CARGO_NOMBRE", CARGO_NOMBRE}, {"@OBLIG_MENSUALES", OBLIG_MENSUALES}, {"@DIAS_HS_TRABAJADOS", DIAS_HS_TRABAJADOS}, {"@ANTIG_REC", ANTIG_REC}, {"@DESCUENTOS", DESCUENTOS}, {"@BRUTO", BRUTO}, {"@LIQUIDO", LIQUIDO}, {"@NIV_DESCRIPCION", NIV_DESCRIPCION}, {"@PLA_DESCRIPCION", PLA_DESCRIPCION}, {"@BONIFICA", BONIFICA}, {"@DESCTO", DESCTO}, {"@LIQUIDO2", LIQUIDO2}, {"@ECL_CANTIDAD", ECL_CANTIDAD}, { "@LIQ_LIT_ID", LIQ_LIT_ID }, { "@CON_COC_ID", CON_COC_ID }, {"@ANT_TOTAL", ANT_TOTAL}, { "@BAN_NOMBRE", BAN_NOMBRE }, { "@LIQ_FECHA_PAGO", LIQ_FECHA_PAGO }, { "@LIQ_ID", LIQ_ID }, { "@ECLC_ID", ECLC_ID }, { "@LIQ_DESCRIPCION", LIQ_DESCRIPCION } });
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
                    if(this.REC_ID != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RECIBOSSUELDO.Actualizar]", new object[,] {{"@REC_ID", REC_ID}, {"@ECLC_EMC_ID", ECLC_EMC_ID}, {"@LUP_DESCRIPCION", LUP_DESCRIPCION}, {"@LUP_DIRECCION", LUP_DIRECCION}, {"@LUP_CUIT", LUP_CUIT}, {"@EMP_APELLIDO", EMP_APELLIDO}, {"@EMP_NOMBRE", EMP_NOMBRE}, {"@EMC_FEC_INI", EMC_FEC_INI}, {"@EMP_DNI", EMP_DNI}, {"@CON_DESCRIPCION", CON_DESCRIPCION}, {"@LIQ_MES", LIQ_MES}, {"@LIQ_ANIO", LIQ_ANIO}, {"@ECL_IMPORTE", ECL_IMPORTE}, {"@ECC_UNIDAD", ECC_UNIDAD}, {"@ECC_VALOR", ECC_VALOR}, {"@ECL_VALOR", ECL_VALOR}, {"@CARGO_NOMBRE", CARGO_NOMBRE}, {"@OBLIG_MENSUALES", OBLIG_MENSUALES}, {"@DIAS_HS_TRABAJADOS", DIAS_HS_TRABAJADOS}, {"@ANTIG_REC", ANTIG_REC}, {"@DESCUENTOS", DESCUENTOS}, {"@BRUTO", BRUTO}, {"@LIQUIDO", LIQUIDO}, {"@NIV_DESCRIPCION", NIV_DESCRIPCION}, {"@PLA_DESCRIPCION", PLA_DESCRIPCION}, {"@BONIFICA", BONIFICA}, {"@DESCTO", DESCTO}, {"@LIQUIDO2", LIQUIDO2}, {"@ECL_CANTIDAD", ECL_CANTIDAD}, {"@ANT_TOTAL", ANT_TOTAL}, { "@BAN_NOMBRE", BAN_NOMBRE }, { "@LIQ_FECHA_PAGO", LIQ_FECHA_PAGO }, { "@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}});
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
                    ocdGestor.EjecutarNonQuery("[RECIBOSSUELDO.Eliminar]", new object[,] {});
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RECIBOSSUELDO.Insertar]", new object[,] {{"@ECLC_EMC_ID", ECLC_EMC_ID}, {"@LUP_DESCRIPCION", LUP_DESCRIPCION}, {"@LUP_DIRECCION", LUP_DIRECCION}, {"@LUP_CUIT", LUP_CUIT}, {"@EMP_APELLIDO", EMP_APELLIDO}, {"@EMP_NOMBRE", EMP_NOMBRE}, {"@EMC_FEC_INI", EMC_FEC_INI}, {"@EMP_DNI", EMP_DNI}, {"@CON_DESCRIPCION", CON_DESCRIPCION}, {"@LIQ_MES", LIQ_MES}, {"@LIQ_ANIO", LIQ_ANIO}, {"@ECL_IMPORTE", ECL_IMPORTE}, {"@ECC_UNIDAD", ECC_UNIDAD}, {"@ECC_VALOR", ECC_VALOR}, {"@ECL_VALOR", ECL_VALOR}, {"@CARGO_NOMBRE", CARGO_NOMBRE}, {"@OBLIG_MENSUALES", OBLIG_MENSUALES}, {"@DIAS_HS_TRABAJADOS", DIAS_HS_TRABAJADOS}, {"@ANTIG_REC", ANTIG_REC}, {"@DESCUENTOS", DESCUENTOS}, {"@BRUTO", BRUTO}, {"@LIQUIDO", LIQUIDO}, {"@NIV_DESCRIPCION", NIV_DESCRIPCION}, {"@PLA_DESCRIPCION", PLA_DESCRIPCION}, {"@BONIFICA", BONIFICA}, {"@DESCTO", DESCTO}, {"@LIQUIDO2", LIQUIDO2}, {"@ECL_CANTIDAD", ECL_CANTIDAD}, { "@LIQ_LIT_ID", LIQ_LIT_ID }, { "@CON_COC_ID", CON_COC_ID }, { "@ANT_TOTAL", ANT_TOTAL}, { "@BAN_NOMBRE", BAN_NOMBRE }, { "@LIQ_FECHA_PAGO", LIQ_FECHA_PAGO }, { "@LIQ_ID", LIQ_ID }, { "@ECLC_ID", ECLC_ID }, { "@LIQ_DESCRIPCION", LIQ_DESCRIPCION } });
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