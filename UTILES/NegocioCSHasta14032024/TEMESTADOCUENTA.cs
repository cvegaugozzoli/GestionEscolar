
using System;
using System.Data;

namespace GESTIONESCOLAR.Negocio

{
    public partial class TEMESTADOCUENTA
    {
        private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
        private DataTable Fila = new DataTable();
        private DataTable Tabla = new DataTable();

        #region Propiedades

        private Int32 _tecId;
        public Int32 tecId { get { return _tecId; } set { _tecId = value; } }
        
        private String _tecConcepto;
        public String tecConcepto { get { return _tecConcepto; } set { _tecConcepto = value; } }

        private Int32 _tecNumCuota;
        public Int32 tecNumCuota { get { return _tecNumCuota; } set { _tecNumCuota = value; } }

        private Decimal _tecImporte;
        public Decimal tecImporte { get { return _tecImporte; } set { _tecImporte = value; } }

        private String _tecColegio;
        public String tecColegio { get { return _tecColegio; } set { _tecColegio = value; } }

        private String _tecCurso;
        public String tecCurso { get { return _tecCurso; } set { _tecCurso = value; } }
        
        private Decimal _tecImpPagado;
        public Decimal tecImpPagado { get { return _tecImpPagado; } set { _tecImpPagado = value; } }

        private String _tecFchPago;
        public String tecFchPago { get { return _tecFchPago; } set { _tecFchPago = value; } }

        private Decimal _tecImpInteres;
        public Decimal tecImpInteres { get { return _tecImpInteres; } set { _tecImpInteres = value; } }

        #endregion

        #region Constructores

        public TEMESTADOCUENTA() { try { this.tecId = 0; } catch (Exception oError) { throw oError; } }

        public TEMESTADOCUENTA (Int32 tecId)
        {
            try
            {
                Fila = new DataTable();
                Fila = ocdGestor.EjecutarReader("[TEMESTADOCUENTA.ObtenerUno]", new object[,] { { "@tecId", tecId } });

                if (Fila.Rows.Count > 0)
                {
                    if (Fila.Rows[0]["tecId"].ToString().Trim().Length > 0)
                    {
                        this.tecId = Convert.ToInt32(Fila.Rows[0]["tecId"]);
                    }
                    else
                    {
                        this.tecId = 0;
                    }
              
                    if (Fila.Rows[0]["tecConcepto"].ToString().Trim().Length > 0)
                    {
                        this.tecConcepto = Convert.ToString(Fila.Rows[0]["tecConcepto"]);
                    }
                    else
                    {
                        this.tecConcepto = "";
                    }

                    if (Fila.Rows[0]["tecNumCuota"].ToString().Trim().Length > 0)
                    {
                        this.tecNumCuota = Convert.ToInt32(Fila.Rows[0]["tecNumCuota"]);
                    }
                    else
                    {
                        this.tecNumCuota = 0;
                    }
                    if (Fila.Rows[0]["tecImporte"].ToString().Trim().Length > 0)
                    {
                        this.tecImporte = Convert.ToDecimal(Fila.Rows[0]["tecImporte"]);
                    }
                    else
                    {
                        this.tecImporte = 0;
                    }
                    if (Fila.Rows[0]["tecColegio"].ToString().Trim().Length > 0)
                    {
                        this.tecColegio = Convert.ToString(Fila.Rows[0]["tecColegio"]);
                    }
                    else
                    {
                        this.tecColegio = "";
                    }

                    if (Fila.Rows[0]["tecCurso"].ToString().Trim().Length > 0)
                    {
                        this.tecCurso = Convert.ToString(Fila.Rows[0]["tecCurso"]);
                    }
                    else
                    {
                        this.tecCurso = "";
                    }
                  
                   
                    if (Fila.Rows[0]["tecFchPago"].ToString().Trim().Length > 0)
                    {
                        this.tecFchPago = Convert.ToString(Fila.Rows[0]["tecFchPago"]);
                    }
                    else
                    {
                        this.tecFchPago = "";
                    }
                    if (Fila.Rows[0]["tecImpPagado"].ToString().Trim().Length > 0)
                    {
                        this.tecImpPagado = Convert.ToDecimal(Fila.Rows[0]["tecImpPagado"]);
                    }
                    else
                    {
                        this.tecImpPagado = 0;
                    }
                    if (Fila.Rows[0]["tecImpInteres"].ToString().Trim().Length > 0)
                    {
                        this.tecImpInteres = Convert.ToDecimal(Fila.Rows[0]["tecImpInteres"]);
                    }
                    else
                    {
                        this.tecImpInteres = 0;
                    }
                }
            }
            catch (Exception oError)
            {
                throw oError;
            }
        }

        #endregion

        #region Metodos


        public DataTable ObtenerUno(Int32 tecId)
        {
            ocdGestor = new Datos.Gestor();
            Tabla = new DataTable();

            try
            {
                Tabla = ocdGestor.EjecutarReader("[TEMESTADOCUENTA.ObtenerUno]", new object[,] { { "@tecId", tecId } });
            }
            catch (Exception oError)
            {
                throw oError;
            }

            return Tabla;
        }

        public Int32 Insertar()
        {
            Int32 IdMax;
            try
            {
                IdMax = ocdGestor.EjecutarNonQueryRetornaId("[TEMESTADOCUENTA.Insertar]", new object[,] { { "@tecConcepto", tecConcepto }, { "@tecNumCuota", tecNumCuota }, { "@tecImporte", tecImporte }, { "@tecColegio", tecColegio }, { "@tecCurso", tecCurso }, { "@tecImpPagado", tecImpPagado }, { "@tecImpInteres", tecImpInteres }, { "@tecFchPago", tecFchPago } });
            }
            catch (Exception oError)
            {
                throw oError;
            }
            return IdMax;
        }
        public void EliminarTodo()
        {

            try
            {
                ocdGestor.EjecutarNonQuery("[TEMESTADOCUENTA.EliminarTodo]", new object[,] { });
            }
            catch (Exception oError)
            {
                throw oError;
            }

        }

        #endregion
    }
}
