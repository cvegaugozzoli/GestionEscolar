using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Data.OleDb;

[ScriptService()]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Buscador2 : System.Web.Services.WebService
{
    private GESTIONESCOLAR.Datos.Gestor ocdGestor = new GESTIONESCOLAR.Datos.Gestor();

    [WebMethod]
    [ScriptMethod()]
    public string[] ObtenerLista(string prefixText, int count, string contextKey)
    {
        List<string> lista = new List<string>();

        if (contextKey != "")
        {
            try
            {
                OleDbConnection Conexion = new OleDbConnection(ocdGestor.ConexionCadena.ToString());

                string Sql = (contextKey.Split('|'))[0];
                string usuId = "";

                if (contextKey.Split('|').Length > 1)
                {
                    usuId = (contextKey.Split('|'))[1];
                    Sql = Sql.Replace("[cValor]", prefixText);
                    Sql = Sql + "," + usuId;
                }
                else
                {
                    Sql = Sql.Replace("[cValor]", prefixText);
                }

                OleDbCommand Comando = new OleDbCommand(Sql, Conexion);
                OleDbDataReader dr = default(OleDbDataReader);
                Comando.Connection.Open();
                dr = Comando.ExecuteReader();

                int i = 0;

                while (dr.Read() && i < count)
                {
                    lista.Add(dr["Resultado"].ToString());

                    i++;
                }
                Comando.Connection.Close();
            }
            catch (Exception oError)
            {
                lista.Add("Error:" + oError.Message);
            }
        }
        else
        {
            lista.Add("Error: Control sin configurar");
        }

        return lista.ToArray();
    }
}