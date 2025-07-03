using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class EspacioCurricular
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _escId;
            public Int32 escId { get { return _escId; } set { _escId = value; } }

            private Int32 _insId;
            public Int32 insId { get { return _insId; } set { _insId = value; } }

            private String _escNombre;
            public String escNombre { get { return _escNombre; } set { _escNombre = value; } }

            private Int32 _escHorasSemanalesReloj;
            public Int32 escHorasSemanalesReloj { get { return _escHorasSemanalesReloj; } set { _escHorasSemanalesReloj = value; } }

            private Int32 _escHorasSemanalesCatedra;
            public Int32 escHorasSemanalesCatedra { get { return _escHorasSemanalesCatedra; } set { _escHorasSemanalesCatedra = value; } }

            private Int32 _escCantidadParciales;
            public Int32 escCantidadParciales { get { return _escCantidadParciales; } set { _escCantidadParciales = value; } }

            private Int32 _escCantidadRecuperatorios;
            public Int32 escCantidadRecuperatorios { get { return _escCantidadRecuperatorios; } set { _escCantidadRecuperatorios = value; } }

            private Boolean _escActivo;
            public Boolean escActivo { get { return _escActivo; } set { _escActivo = value; } }

            private DateTime _escFechaHoraCreacion;
            public DateTime escFechaHoraCreacion { get { return _escFechaHoraCreacion; } set { _escFechaHoraCreacion = value; } }

            private DateTime _escFechaHoraUltimaModificacion;
            public DateTime escFechaHoraUltimaModificacion { get { return _escFechaHoraUltimaModificacion; } set { _escFechaHoraUltimaModificacion = value; } }

            private Int32 _carId;
            public Int32 carId { get { return _carId; } set { _carId = value; } }

            private Int32 _plaId;
            public Int32 plaId { get { return _plaId; } set { _plaId = value; } }

            private Int32 _curId;
            public Int32 curId { get { return _curId; } set { _curId = value; } }

            private Int32 _camId;
            public Int32 camId { get { return _camId; } set { _camId = value; } }

            private Int32 _fodId;
            public Int32 fodId { get { return _fodId; } set { _fodId = value; } }

            private Int32 _regId;
            public Int32 regId { get { return _regId; } set { _regId = value; } }

            private Int32 _cdnId;
            public Int32 cdnId { get { return _cdnId; } set { _cdnId = value; } }

            private Int32 _usuIdCreacion;
            public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

            private Int32 _usuIdUltimaModificacion;
            public Int32 usuIdUltimaModificacion { get { return _usuIdUltimaModificacion; } set { _usuIdUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public EspacioCurricular() { try { this.escId = 0; } catch (Exception oError) { throw oError; } }

            public EspacioCurricular(Int32 escId, Int32 insId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerUno]", new object[,] { { "@escId", escId },{ "@insId", insId }  });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["escId"].ToString().Trim().Length > 0)
                        {
                            this.escId = Convert.ToInt32(Fila.Rows[0]["escId"]);
                        }
                        else
                        {
                            this.escId = 0;
                        }
                        if (Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

                        if (Fila.Rows[0]["escNombre"].ToString().Trim().Length > 0)
                        {
                            this.escNombre = Convert.ToString(Fila.Rows[0]["escNombre"]);
                        }
                        else
                        {
                            this.escNombre = "";
                        }

                        if (Fila.Rows[0]["escHorasSemanalesReloj"].ToString().Trim().Length > 0)
                        {
                            this.escHorasSemanalesReloj = Convert.ToInt32(Fila.Rows[0]["escHorasSemanalesReloj"]);
                        }
                        else
                        {
                            this.escHorasSemanalesReloj = 0;
                        }

                        if (Fila.Rows[0]["escHorasSemanalesCatedra"].ToString().Trim().Length > 0)
                        {
                            this.escHorasSemanalesCatedra = Convert.ToInt32(Fila.Rows[0]["escHorasSemanalesCatedra"]);
                        }
                        else
                        {
                            this.escHorasSemanalesCatedra = 0;
                        }

                        if (Fila.Rows[0]["escCantidadParciales"].ToString().Trim().Length > 0)
                        {
                            this.escCantidadParciales = Convert.ToInt32(Fila.Rows[0]["escCantidadParciales"]);
                        }
                        else
                        {
                            this.escCantidadParciales = 0;
                        }

                        if (Fila.Rows[0]["escCantidadRecuperatorios"].ToString().Trim().Length > 0)
                        {
                            this.escCantidadRecuperatorios = Convert.ToInt32(Fila.Rows[0]["escCantidadRecuperatorios"]);
                        }
                        else
                        {
                            this.escCantidadRecuperatorios = 0;
                        }

                        if (Fila.Rows[0]["escFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.escFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["escFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.escFechaHoraCreacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["escFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.escFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["escFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.escFechaHoraUltimaModificacion = DateTime.Now;
                        }

                        if (Fila.Rows[0]["escActivo"].ToString().Trim().Length > 0)
                        {
                            this.escActivo = (Convert.ToInt32(Fila.Rows[0]["escActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.escActivo = false;
                        }

                        if (Fila.Rows[0]["carId"].ToString().Trim().Length > 0)
                        {
                            this.carId = Convert.ToInt32(Fila.Rows[0]["carId"]);
                        }
                        else
                        {
                            this.carId = 0;
                        }

                        if (Fila.Rows[0]["plaId"].ToString().Trim().Length > 0)
                        {
                            this.plaId = Convert.ToInt32(Fila.Rows[0]["plaId"]);
                        }
                        else
                        {
                            this.plaId = 0;
                        }

                        if (Fila.Rows[0]["curId"].ToString().Trim().Length > 0)
                        {
                            this.curId = Convert.ToInt32(Fila.Rows[0]["curId"]);
                        }
                        else
                        {
                            this.curId = 0;
                        }

                        if (Fila.Rows[0]["camId"].ToString().Trim().Length > 0)
                        {
                            this.camId = Convert.ToInt32(Fila.Rows[0]["camId"]);
                        }
                        else
                        {
                            this.camId = 0;
                        }

                        if (Fila.Rows[0]["fodId"].ToString().Trim().Length > 0)
                        {
                            this.fodId = Convert.ToInt32(Fila.Rows[0]["fodId"]);
                        }
                        else
                        {
                            this.fodId = 0;
                        }

                        if (Fila.Rows[0]["regId"].ToString().Trim().Length > 0)
                        {
                            this.regId = Convert.ToInt32(Fila.Rows[0]["regId"]);
                        }
                        else
                        {
                            this.regId = 0;
                        }

                        if (Fila.Rows[0]["cdnId"].ToString().Trim().Length > 0)
                        {
                            this.cdnId = Convert.ToInt32(Fila.Rows[0]["cdnId"]);
                        }
                        else
                        {
                            this.cdnId = 0;
                        }

                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
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

            public EspacioCurricular(Int32 escId, int insId, String escNombre, Int32 escHorasSemanalesReloj, Int32 escHorasSemanalesCatedra, Int32 escCantidadParciales, Int32 escCantidadRecuperatorios, Boolean escActivo, DateTime escFechaHoraCreacion, DateTime escFechaHoraUltimaModificacion, Int32 IcarId, Int32 IplaId, Int32 IcurId, Int32 IcamId, Int32 IfodId, Int32 IregId, Int32 IcdnId, Int32 IusuIdCreacion, Int32 IusuIdUltimaModificacion)
            {
                try
                {
                    this.escId = escId;
                    this.insId = insId;
                    this.escNombre = escNombre;
                    this.escHorasSemanalesReloj = escHorasSemanalesReloj;
                    this.escHorasSemanalesCatedra = escHorasSemanalesCatedra;
                    this.escCantidadParciales = escCantidadParciales;
                    this.escCantidadRecuperatorios = escCantidadRecuperatorios;
                    this.escActivo = escActivo;
                    this.escFechaHoraCreacion = escFechaHoraCreacion;
                    this.escFechaHoraUltimaModificacion = escFechaHoraUltimaModificacion;
                    this.carId = carId;
                    this.plaId = plaId;
                    this.curId = curId;
                    this.camId = camId;
                    this.fodId = fodId;
                    this.regId = regId;
                    this.cdnId = cdnId;
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
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(String PrimerItem,int insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }



            public DataTable ObtenerListaPorUnCampo(String PrimerItem, Int32 camId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerListaPorUnCampo]", new object[,] { { "@PrimerItem", PrimerItem }, { "@camId", camId }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaPorUnCurso(Int32 curId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerListaPorUnCurso]", new object[,] { { "@curId", curId }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerListaPorUnCurso2(String Texto, Int32 curId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerListaPorUnCurso2]", new object[,] { { "@Texto", Texto }, { "@curId", curId } , { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }
            public DataTable ObtenerListaPorUnCampoporAlumno(String PrimerItem, Int32 camId, Int32 aluId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerListaPorUnCampoporAlumno]", new object[,] { { "@PrimerItem", PrimerItem }, { "@camId", camId }, { "@aluId", aluId } , { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerPorCarPorPlanporCurporNombreEC(Int32 carId, Int32 plaId, Int32 curId, Int32 camId, String Nombre, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerPorCarPorPlanporCurporNombreEC]", new object[,] { { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@Nombre", Nombre } , { "@insId", insId } });
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
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerTodo]", new object[,] { });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoBuscarxNombre(String Nombre, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(Int32 escId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerUno]", new object[,] { { "@escId", escId }, { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerCorrelativas(Int32 escId, Int32 cotId, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerCorrelativas]", new object[,] { { "@escId", escId }, { "@cotId", cotId } , { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }




            public DataTable ObtenerValidarRepetido(Int32 escId, String escNombre, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EspacioCurricular.ObtenerValidarRepetido]", new object[,] { { "@escId", escId }, { "@escNombre", escNombre } , { "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }

            public void ActualizarOrden(int insId, Int32 escId, Int32 orden )
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspacioCurricular.ActualizarOrden]", new object[,] {{ "@insId", insId } ,{ "@escId", escId }, { "@orden", orden } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Actualizar(Int32 escId, Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, String escNombre, Int32 fodId, Int32 regId, Int32 escHorasSemanalesReloj, Int32 escHorasSemanalesCatedra, Int32 cdnId, Int32 escCantidadParciales, Int32 escCantidadRecuperatorios, Boolean escActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime escFechaHoraCreacion, DateTime escFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspacioCurricular.Actualizar]", new object[,] { { "@escId", escId }, { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escNombre", escNombre }, { "@fodId", fodId }, { "@regId", regId }, { "@escHorasSemanalesReloj", escHorasSemanalesReloj }, { "@escHorasSemanalesCatedra", escHorasSemanalesCatedra }, { "@cdnId", cdnId }, { "@escCantidadParciales", escCantidadParciales }, { "@escCantidadRecuperatorios", escCantidadRecuperatorios }, { "@escActivo", escActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@escFechaHoraCreacion", escFechaHoraCreacion }, { "@escFechaHoraUltimaModificacion", escFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Copiar(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, String escNombre, Int32 fodId, Int32 regId, Int32 escHorasSemanalesReloj, Int32 escHorasSemanalesCatedra, Int32 cdnId, Int32 escCantidadParciales, Int32 escCantidadRecuperatorios, Boolean escActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime escFechaHoraCreacion, DateTime escFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspacioCurricular.Copiar]", new object[,] { { "@insId", insId },{ "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escNombre", escNombre }, { "@fodId", fodId }, { "@regId", regId }, { "@escHorasSemanalesReloj", escHorasSemanalesReloj }, { "@escHorasSemanalesCatedra", escHorasSemanalesCatedra }, { "@cdnId", cdnId }, { "@escCantidadParciales", escCantidadParciales }, { "@escCantidadRecuperatorios", escCantidadRecuperatorios }, { "@escActivo", escActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@escFechaHoraCreacion", escFechaHoraCreacion }, { "@escFechaHoraUltimaModificacion", escFechaHoraUltimaModificacion } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Eliminar(Int32 escId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspacioCurricular.Eliminar]", new object[,] { { "@escId", escId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }
            }

            public void Insertar(Int32 insId, Int32 carId, Int32 plaId, Int32 curId, Int32 camId, String escNombre, Int32 fodId, Int32 regId, Int32 escHorasSemanalesReloj, Int32 escHorasSemanalesCatedra, Int32 cdnId, Int32 escCantidadParciales, Int32 escCantidadRecuperatorios, Boolean escActivo, Int32 usuIdCreacion, Int32 usuIdUltimaModificacion, DateTime escFechaHoraCreacion, DateTime escFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EspacioCurricular.Insertar]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escNombre", escNombre }, { "@fodId", fodId }, { "@regId", regId }, { "@escHorasSemanalesReloj", escHorasSemanalesReloj }, { "@escHorasSemanalesCatedra", escHorasSemanalesCatedra }, { "@cdnId", cdnId }, { "@escCantidadParciales", escCantidadParciales }, { "@escCantidadRecuperatorios", escCantidadRecuperatorios }, { "@escActivo", escActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@escFechaHoraCreacion", escFechaHoraCreacion }, { "@escFechaHoraUltimaModificacion", escFechaHoraUltimaModificacion } });
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
                    if (this.escId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EspacioCurricular.Actualizar]", new object[,] { { "@escId", escId }, { "@insId", insId },{ "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escNombre", escNombre }, { "@fodId", fodId }, { "@regId", regId }, { "@escHorasSemanalesReloj", escHorasSemanalesReloj }, { "@escHorasSemanalesCatedra", escHorasSemanalesCatedra }, { "@cdnId", cdnId }, { "@escCantidadParciales", escCantidadParciales }, { "@escCantidadRecuperatorios", escCantidadRecuperatorios }, { "@escActivo", escActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@escFechaHoraCreacion", escFechaHoraCreacion }, { "@escFechaHoraUltimaModificacion", escFechaHoraUltimaModificacion } });
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
                    if (this.escId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EspacioCurricular.Copiar]", new object[,] { { "@insId", insId },{ "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escNombre", escNombre }, { "@fodId", fodId }, { "@regId", regId }, { "@escHorasSemanalesReloj", escHorasSemanalesReloj }, { "@escHorasSemanalesCatedra", escHorasSemanalesCatedra }, { "@cdnId", cdnId }, { "@escCantidadParciales", escCantidadParciales }, { "@escCantidadRecuperatorios", escCantidadRecuperatorios }, { "@escActivo", escActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@escFechaHoraCreacion", escFechaHoraCreacion }, { "@escFechaHoraUltimaModificacion", escFechaHoraUltimaModificacion } });
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
                    if (this.escId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EspacioCurricular.Eliminar]", new object[,] { { "@escId", escId } });
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[EspacioCurricular.Insertar]", new object[,] { { "@insId", insId }, { "@carId", carId }, { "@plaId", plaId }, { "@curId", curId }, { "@camId", camId }, { "@escNombre", escNombre }, { "@fodId", fodId }, { "@regId", regId }, { "@escHorasSemanalesReloj", escHorasSemanalesReloj }, { "@escHorasSemanalesCatedra", escHorasSemanalesCatedra }, { "@cdnId", cdnId }, { "@escCantidadParciales", escCantidadParciales }, { "@escCantidadRecuperatorios", escCantidadRecuperatorios }, { "@escActivo", escActivo }, { "@usuIdCreacion", usuIdCreacion }, { "@usuIdUltimaModificacion", usuIdUltimaModificacion }, { "@escFechaHoraCreacion", escFechaHoraCreacion }, { "@escFechaHoraUltimaModificacion", escFechaHoraUltimaModificacion } });
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