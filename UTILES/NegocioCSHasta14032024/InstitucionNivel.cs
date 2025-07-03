using System;
using System.Data;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class InstitucionNivel
        {
            private GESTIONESCOLAR.Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila = new DataTable();
            private DataTable Tabla = new DataTable();

            #region Propiedades

            private Int32 _invId; 
			public Int32 invId { get { return _invId; } set { _invId = value; } }

            private Int32 _insId; 
			public Int32 insId { get { return _insId; } set { _insId = value; } }

            private Int32 _tcaId; 
			public Int32 tcaId { get { return _tcaId; } set { _tcaId = value; } }
                    
            private Boolean _invActivo; 
			public Boolean invActivo { get { return _invActivo; } set { _invActivo = value; } }

            private DateTime _invFechaHoraCreacion; 
			public DateTime invFechaHoraCreacion { get { return _invFechaHoraCreacion; } set { _invFechaHoraCreacion = value; } }

            private DateTime _invFechaHoraUltimaModificacion; 
			public DateTime invFechaHoraUltimaModificacion { get { return _invFechaHoraUltimaModificacion; } set { _invFechaHoraUltimaModificacion = value; } }

			private Int32 _usuIdCreacion; 
			public Int32 usuIdCreacion { get { return _usuIdCreacion; } set { _usuIdCreacion = value; } }

			private Int32 _usuidUltimaModificacion; 
			public Int32 usuidUltimaModificacion { get { return _usuidUltimaModificacion; } set { _usuidUltimaModificacion = value; } }

            #endregion

            #region Constructores

            public InstitucionNivel() { try { this.invId = 0; } catch (Exception oError) { throw oError; } }            

            public InstitucionNivel(Int32 invId)
			{
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[InstitucionNivel.ObtenerUno]", new object[,] {{"@invId", invId}});

				    if(Fila.Rows.Count > 0)
                    {
					    if(Fila.Rows[0]["invsId"].ToString().Trim().Length > 0)
                        {
                            this.invId = Convert.ToInt32(Fila.Rows[0]["invId"]);
                        }
                        else
                        {
                            this.invId = 0;
                        }

					    if(Fila.Rows[0]["insId"].ToString().Trim().Length > 0)
                        {
                            this.insId = Convert.ToInt32(Fila.Rows[0]["insId"]);
                        }
                        else
                        {
                            this.insId = 0;
                        }

					    if(Fila.Rows[0]["tcaId"].ToString().Trim().Length > 0)
                        {
                            this.tcaId = Convert.ToInt32(Fila.Rows[0]["tcaId"]);
                        }
                        else
                        {
                            this.tcaId = 0;
                        }

                        if (Fila.Rows[0]["invActivo"].ToString().Trim().Length > 0)
                        {
                            this.invActivo = (Convert.ToInt32(Fila.Rows[0]["invActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.invActivo = false;
                        }

                        if (Fila.Rows[0]["invFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.invFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["invFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.invFechaHoraCreacion = DateTime.Now;
                        }

					    if(Fila.Rows[0]["insFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.invFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["invFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.invFechaHoraUltimaModificacion = DateTime.Now;
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

            public InstitucionNivel(Int32 invId,Int32 insId, Int32 tcaId, Boolean invActivo, DateTime invFechaHoraCreacion, DateTime invFechaHoraUltimaModificacion, Int32 IusuIdCreacion, Int32 IusuidUltimaModificacion)
			{
                try
                {this.invId = invId;
				    this.insId = insId;
				    this.tcaId = tcaId;
				    this.invActivo = invActivo;				 
				    this.invFechaHoraCreacion = invFechaHoraCreacion;
				    this.invFechaHoraUltimaModificacion = invFechaHoraUltimaModificacion;
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


            //public DataTable ObtenerBuscador(String ValorABuscar)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerBuscador]", new object[,] {{"@ValorABuscar", ValorABuscar}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            public DataTable ObtenerListaxIns(String PrimerItem, Int32 insId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InstitucionNivel.ObtenerListaxIns]", new object[,] { { "@PrimerItem", PrimerItem },{ "@insId", insId } });
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Tabla;
            }


            public DataTable ObtenerListaxInsxNivel(String PrimerItem, Int32 insId, Int32 nivId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[InstitucionNivel.ObtenerListaxInsxNivel]", new object[,] { { "@PrimerItem", PrimerItem }, { "@insId", insId }, { "@nivId", nivId } });
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
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerTodo]", new object[,] {});
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
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerTodoBuscarxNombre]", new object[,] {{"@Nombre", Nombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerUno(Int32 insId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUno]", new object[,] {{"@insId", insId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerValidarRepetido(Int32 insId, String insNombre)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //    	Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerValidarRepetido]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }

            //    return Tabla;
            //}

            //public void Actualizar(Int32 insId, String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Actualizar]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Copiar(String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Copiar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Eliminar(Int32 insId)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Eliminar]", new object[,] {{"@insId", insId}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //}

            //public void Insertar(String insNombre, String insCodigo, String insDireccion, String insTelefono, String insCUIT, String insMail, Boolean insGrupo, Boolean insActivo, Int32 usuIdCreacion, Int32 usuidUltimaModificacion, DateTime insFechaHoraCreacion, DateTime insFechaHoraUltimaModificacion)
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[Instituciones.Insertar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion}});
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
            //        if(this.insId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Instituciones.Actualizar]", new object[,] {{"@insId", insId}, {"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion}});
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
            //        if(this.insId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Instituciones.Copiar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion}});
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
            //        if(this.insId != 0)
            //        {
            //            ocdGestor.EjecutarNonQuery("[Instituciones.Eliminar]", new object[,] {{"@insId", insId}});
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
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Instituciones.Insertar]", new object[,] {{"@insNombre", insNombre}, {"@insCodigo", insCodigo}, {"@insDireccion", insDireccion}, {"@insTelefono", insTelefono}, {"@insCUIT", insCUIT}, {"@insMail", insMail}, {"@insGrupo", insGrupo}, {"@insActivo", insActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuidUltimaModificacion", usuidUltimaModificacion}, {"@insFechaHoraCreacion", insFechaHoraCreacion}, {"@insFechaHoraUltimaModificacion", insFechaHoraUltimaModificacion}});
            //    }
            //    catch (Exception oError)
            //    {
            //    	throw oError;
            //    }
            //    return IdMax;
            //}


            //public DataTable ObtenerUnoPorCodigo(String insCodigo)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();

            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Instituciones.ObtenerUnoporCodigo]", new object[,] { { "@insCodigo", insCodigo } });
            //    }
            //    catch (Exception oError)
            //    {
            //        throw oError;
            //    }

            //    return Tabla;
            //}


            #endregion
        }
    }
}