using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Descripción breve de logic
/// </summary>
public class logic
{
    //
    // TODO: Agregar aquí la lógica del constructor
    //
    public MySqlConnection getConnection()
    {
        MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionMYSQL"].ConnectionString.ToString());
        return cn;
    }

    public bool validateLogin(string email, string pass)
    {
        bool valid = false;
        try
        {
            using (MySqlConnection cn = getConnection())
            {
                cn.Open();
                string query = @"CALL `egestion`.`getLoginEmpleados`('" + email + "','" + pass + "');";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    valid = true;
                }
                cn.Close();
            }


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return valid;
    }

    public DataTable getTraerEmpleadoporDNI(string dni)
    {
        DataTable Tabla = new DataTable();
        try
        {
            using (MySqlConnection cn = getConnection())
            {
                cn.Open();
                string query = @"CALL `egestion`.`getTraerEmpleadosporDNI`('" + dni + "');";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                Tabla.Load(dr);
                cn.Close();
            }


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return Tabla;
    }


    public DataTable ObtenerLiquidaciones(String Estado)
    {
        DataTable Tabla = new DataTable();
        try
        {
            using (MySqlConnection cn = getConnection())
            {
                cn.Open();
                string query = @"CALL `egestion`.`getObtenerLiquidaciones`('" + Estado + "');";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                Tabla.Load(dr);
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return Tabla;
    }


    public DataSet TraerRecibo(int liqid, String dni)
    {
        DataTable Tabla = new DataTable();
        DataSet datasetRecibo = new DataSet();
        try
        {
            using (MySqlConnection cn = getConnection())
            {
                cn.Open();
                string query = @"CALL `egestion`.`getReciboSueldoWeb`('" + liqid + "','" + dni + "');";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                Tabla.Load(dr);
                datasetRecibo.Tables.Add(Tabla);
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return datasetRecibo;
    }


    public DataTable TraerReciboDT(int liqid, String dni)
    {
        DataTable Tabla = new DataTable();
        DataSet datasetRecibo = new DataSet();
        try
        {
            using (MySqlConnection cn = getConnection())
            {
                cn.Open();
                string query = @"CALL `egestion`.`getReciboSueldoWeb`('" + liqid + "','" + dni + "');";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                Tabla.Load(dr);
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return Tabla;
    }


}







