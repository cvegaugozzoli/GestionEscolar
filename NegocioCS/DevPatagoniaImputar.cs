using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class DevPatagoniaImputar
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades


            private Int32 _dvpId;
            public Int32 dvpId { get { return _dvpId; } set { _dvpId = value; } }

            private String _cbu;
            public String cbu { get { return _cbu; } set { _cbu = value; } }

            private Decimal _Importe;
            public Decimal Importe { get { return _Importe; } set { _Importe = value; } }

            private DateTime _fchDeb;
            public DateTime fchDeb { get { return _fchDeb; } set { _fchDeb = value; } }

            private String _Observ;
            public String Observ { get { return _Observ; } set { _Observ = value; } }

            private Int32 _aluId;
            public Int32 aluId { get { return _aluId; } set { _aluId = value; } }

            private Int32 _NroCuota;
            public Int32 NroCuota { get { return _NroCuota; } set { _NroCuota = value; } }

            private String _ConId;
            public String ConId { get { return _ConId; } set { _ConId = value; } }

            #endregion

            #region Constructores

            //public Bancos() { try { this.banId = 0; } catch (Exception oError) { throw oError; } }

            //public Bancos(Int32 banId)
            //{
            //    try
            //    {
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[Bancos.ObtenerUno]", new object[,] { { "@banId", banId } });

            //        if (Fila.Rows.Count > 0)
            //        {
            //            if (Fila.Rows[0]["banId"].ToString().Trim().Length > 0)
            //            {
            //                this.banId = Convert.ToInt32(Fila.Rows[0]["banId"]);
            //            }
            //            else
            //            {
            //                this.banId = 0;
            //            }

            //            if (Fila.Rows[0]["banCodigo"].ToString().Trim().Length > 0)
            //            {
            //                this.banCodigo = Convert.ToString(Fila.Rows[0]["banCodigo"]);
            //            }
            //            else
            //            {
            //                this.banCodigo = "";
            //            }

            //            if (Fila.Rows[0]["banNombre"].ToString().Trim().Length > 0)
            //            {
            //                this.banNombre = Convert.ToString(Fila.Rows[0]["banNombre"]);
            //            }
            //            else
            //            {
            //                this.banNombre = "";
            //            }

            //            if (Fila.Rows[0]["banSucursal"].ToString().Trim().Length > 0)
            //            {
            //                this.banSucursal = Convert.ToString(Fila.Rows[0]["banSucursal"]);
            //            }
            //            else
            //            {
            //                this.banSucursal = "";
            //            }

            //            if (Fila.Rows[0]["banFechaHoraCreacion"].ToString().Trim().Length > 0)
            //            {
            //                this.banFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["banFechaHoraCreacion"]);
            //            }
            //            else
            //            {
            //                this.banFechaHoraCreacion = DateTime.Now;
            //            }

            //            if (Fila.Rows[0]["banFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
            //            {
            //                this.banFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["banFechaHoraUltimaModificacion"]);
            //            }
            //            else
            //            {
            //                this.banFechaHoraUltimaModificacion = DateTime.Now;
            //            }

            //            if (Fila.Rows[0]["banActivo"].ToString().Trim().Length > 0)
            //            {
            //                this.banActivo = (Convert.ToInt32(Fila.Rows[0]["banActivo"]) == 1 ? true : false);
            //            }
            //            else
            //            {
            //                this.banActivo = false;
            //            }

            //            if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
            //            {
            //                this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
            //            }
            //            else
            //            {
            //                this.usuIdCreacion = 0;
            //            }

            //            if (Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
            //            {
            //                this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
            //            }
            //            else
            //            {
            //                this.usuIdUltimaModificacion = 0;
            //            }

            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public Bancos(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            //{
            //    try
            //    {
            //        this.banId = banId;
            //        this.banCodigo = banCodigo;
            //        this.banNombre = banNombre;
            //        this.banSucursal = banSucursal;
            //        this.banActivo = banActivo;
            //        this.banFechaHoraCreacion = banFechaHoraCreacion;
            //        this.banFechaHoraUltimaModificacion = banFechaHoraUltimaModificacion;
            //        this.usuIdCreacion = usuIdCreacion;
            //        this.usuIdUltimaModificacion = usuIdUltimaModificacion;
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            #endregion

            #region Metodos


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerLista(String PrimerItem)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodoBuscarxNombre(String Nombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerUno(Int32 banId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerUno]", new object[,] { { "@banId", banId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerValidarRepetido(Int32 banId, String banNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Bancos.ObtenerValidarRepetido]", new object[,] { { "@banId", banId }, { "@banNombre", banNombre } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 banId, String banCodigo, String banNombre, String banSucursal, Boolean banActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Actualizar]", new object[,] { { "@banId", banId }, { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar(String banCodigo, String banNombre, String banSucursal, Boolean banActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime banFechaHoraCreacion, DateTime banFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Copiar]", new object[,] { { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Eliminar(Int32 banId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Bancos.Eliminar]", new object[,] { { "@banId", banId } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}
            public Int32 Insertar()
            {
                Int32 IdMax;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[DevPatagoniaImputar.Insertar]", new object[,] { { "@cbu", cbu }, { "@Importe", Importe }, { "@fchDeb", fchDeb }, { "@Observ", Observ }, { "@aluId", aluId }, { "@NroCuota", NroCuota }, { "@ConId", ConId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
                return IdMax;
            }
            public void Insertar(String cbu, Decimal Importe, DateTime fchDeb, String Observ, Int32 aluId, Int32 NroCuota, String ConId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[DevPatagoniaImputar.Insertar]", new object[,] { { "@cbu", cbu }, { "@Importe", Importe }, { "@fchDeb", fchDeb }, { "@Observ", Observ }, { "@aluId", aluId }, { "@NroCuota", NroCuota }, { "@ConId", ConId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            //public void Actualizar()
            //{
            //    try
            //    {
            //        if (this.banId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Bancos.Actualizar]", new object[,] { { "@banId", banId }, { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Copiar()
            //{
            //    try
            //    {
            //        if (this.banId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Bancos.Copiar]", new object[,] { { "@banCodigo", banCodigo }, { "@banNombre", banNombre }, { "@banSucursal", banSucursal }, { "@banActivo", banActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@banFechaHoraCreacion", banFechaHoraCreacion }, { "@banFechaHoraUltimaModificacion", banFechaHoraUltimaModificacion } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

            //public void Eliminar()
            //{
            //    try
            //    {
            //        if (this.banId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Bancos.Eliminar]", new object[,] { { "@banId", banId } });
            //        }
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }
            //}

         
        }


        #endregion
    }
}
