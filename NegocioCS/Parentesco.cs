using System;
using System.Data;

namespace GESTIONESCOLAR
    {
        namespace Negocio
        {
            public partial class Parentesco
            {
                private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
                private DataTable Fila = new DataTable();
                private DataTable Tabla = new DataTable();

                #region Propiedades

                private Int32 _patId;
                public Int32 patId { get { return _patId; } set { _patId = value; } }

                private String _patDescripcion;
                public String patDescripcion { get { return _patDescripcion; } set { _patDescripcion = value; } }
            
            #endregion

                #region Constructores

                public Parentesco() { try { this.patId = 0; } catch (Exception oError) { throw oError; } }

                public Parentesco(Int32 patId)
                {
                    try
                    {
                        Fila = new DataTable();
                        Fila = ocdGestor.EjecutarReader("[Parentesco.ObtenerUno]", new object[,] { { "@patId", patId } });

                        if (Fila.Rows.Count > 0)
                        {
                            if (Fila.Rows[0]["patId"].ToString().Trim().Length > 0)
                            {
                                this.patId = Convert.ToInt32(Fila.Rows[0]["patId"]);
                            }
                            else
                            {
                                this.patId = 0;
                            }

                            if (Fila.Rows[0]["patDescripcion"].ToString().Trim().Length > 0)
                            {
                                this.patDescripcion = Convert.ToString(Fila.Rows[0]["patDescripcion"]);
                            }
                            else
                            {
                                this.patDescripcion = "";
                            }      
                        }
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }
                }

                public Parentesco(Int32 patId, String patDescripcion)
                {
                    try
                    {
                        this.patId = patId;
                        this.patDescripcion = patDescripcion;                       
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
                        Tabla = ocdGestor.EjecutarReader("[Parentesco.ObtenerBuscador]", new object[,] { { "@ValorABuscar", ValorABuscar } });
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
                        Tabla = ocdGestor.EjecutarReader("[Parentesco.ObtenerLista]", new object[,] { { "@PrimerItem", PrimerItem } });
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
                        Tabla = ocdGestor.EjecutarReader("[Parentesco.ObtenerTodo]", new object[,] { });
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
                        Tabla = ocdGestor.EjecutarReader("[Parentesco.ObtenerTodoBuscarxNombre]", new object[,] { { "@Nombre", Nombre } });
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }

                    return Tabla;
                }

                public DataTable ObtenerUno(Int32 parId)
                {
                    ocdGestor = new Datos.Gestor();
                    Tabla = new DataTable();

                    try
                    {
                        Tabla = ocdGestor.EjecutarReader("[Parentesco.ObtenerUno]", new object[,] { { "@patId", patId } });
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }

                    return Tabla;
                }

                public DataTable ObtenerValidarRepetido(Int32 patId, String patDescripcion)
                {
                    ocdGestor = new Datos.Gestor();
                    Tabla = new DataTable();

                    try
                    {
                        Tabla = ocdGestor.EjecutarReader("[Parentesco.ObtenerValidarRepetido]", new object[,] { { "@patId", patId }, { "@patDescripcion", patDescripcion } });
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }

                    return Tabla;
                }

                public void Actualizar(Int32 patId, String patDescripcion)
                {
                    try
                    {
                        ocdGestor.EjecutarNonQuery("[Parentesco.Actualizar]", new object[,] { { "@patId", patId }, { "@patDescripcion", patDescripcion }});
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }
                }

                public void Copiar(String patDescripcion)
                {
                    try
                    {
                        ocdGestor.EjecutarNonQuery("[Parentesco.Copiar]", new object[,] { { "@patDescripcion", patDescripcion }});
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }
                }

                public void Eliminar(Int32 patId)
                {
                    try
                    {
                        ocdGestor.EjecutarNonQuery("[Parentesco.Eliminar]", new object[,] { { "@patId", patId } });
                    }
                    catch (Exception oError)
                    {
                        throw oError;
                    }
                }

                public void Insertar(String patDescripcion)
                {
                    try
                    {
                        ocdGestor.EjecutarNonQuery("[Parentesco.Insertar]", new object[,] { { "@patDescripcion", patDescripcion }});
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
                        if (this.patId != 0)
                        {
                            ocdGestor.EjecutarNonQuery("[Parentesco.Actualizar]", new object[,] { { "@parId", patId }, { "@patDescripcion", patDescripcion }});
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
                        if (this.patId != 0)
                        {
                            ocdGestor.EjecutarNonQuery("[Parentesco.Copiar]", new object[,] { { "@patDescripcion", patDescripcion} });
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
                        if (this.patId != 0)
                        {
                            ocdGestor.EjecutarNonQuery("[Parentesco.Eliminar]", new object[,] { { "@patId", patId } });
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
                        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Parentesco.Insertar]", new object[,] { { "@patDescripcion", patDescripcion }});
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