/*
Proyecto WebForms en C# para integrar un Botón de Pago con SIRO
Estructura del Proyecto:
- /PagoOnline.aspx
- /PagoOnline.aspx.cs
- /RespuestaPago.aspx
- /RespuestaPago.aspx.cs
- /web.config
*/

// ---------------- PagoOnline.aspx ----------------
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoOnline.aspx.cs" Inherits="SIRO_Web.PagoOnline" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>Pagar con SIRO</title></head>
<body>
  <form id="form1" runat="server">
    <asp:Button ID="btnPagar" runat="server" Text="Pagar con SIRO" OnClick="btnPagar_Click" />
  </form>
</body>
</html>

// ---------------- PagoOnline.aspx.cs ----------------
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace SIRO_Web
{
    public partial class PagoOnline : Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected async void btnPagar_Click(object sender, EventArgs e)
        {
            string referencia = "TEST-0001";
            decimal monto = 750.00M;
            string cuit = "20333455669";

            string baseUrl = "https://api.onlinesiro.com.ar/";
            string usuario = "MI_USUARIO_API";
            string pass = "MI_PASS_API";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usuario}:{pass}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

                var payload = new { referencia = referencia, monto = monto, cuit = cuit };
                HttpResponseMessage resp = await client.PostAsJsonAsync("boton-pagos", payload);

                if (resp.IsSuccessStatusCode)
                {
                    dynamic json = await resp.Content.ReadAsAsync<dynamic>();
                    string urlPago = json.url_pago;
                    Response.Redirect(urlPago);
                }
                else
                {
                    Response.Write($"Error {resp.StatusCode}: {await resp.Content.ReadAsStringAsync()}");
                }
            }
        }
    }
}

// ---------------- RespuestaPago.aspx ----------------
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RespuestaPago.aspx.cs" Inherits="SIRO_Web.RespuestaPago" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>Resultado Pago SIRO</title></head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblMensaje" runat="server" />
    </form>
</body>
</html>

// ---------------- RespuestaPago.aspx.cs ----------------
using System;
using System.Web.UI;

namespace SIRO_Web
{
    public partial class RespuestaPago : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string estado = Request.QueryString["estado"] ?? "desconocido";
            string referencia = Request.QueryString["referencia"] ?? "";

            lblMensaje.Text = estado == "aprobado"
                ? $"✅ Pago aprobado! Referencia: {referencia}"
                : $"❌ Pago NO aprobado. Estado: {estado}";
        }
    }
}

// ---------------- web.config (fragmento relevante) ----------------
<configuration>
  <system.web>
    <compilation debug="true" targetFramework="4.5" />
    <httpRuntime targetFramework="4.5" />
  </system.web>
  <system.net>
    <defaultProxy enabled="true" />
  </system.net>
</configuration>
