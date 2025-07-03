using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facturas_E
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FEAFIPLib.BIWSFEXV1 wsfex = new FEAFIPLib.BIWSFEXV1();
            if (wsfex.login("..\\..\\..\\certificado.pfx", "feafip"))
            {
                long Id = 0;
                long nro = 0;
                short ptoVta = 1000;
                short tipoCbte = 19;

                if (!wsfex.recuperaLastID(ref Id))
                {
                    MessageBox.Show(wsfex.ErrorDesc);
                }
                Id++;

                if (!wsfex.recuperaLastCMP(ptoVta, tipoCbte, ref nro))
                {
                    MessageBox.Show(wsfex.ErrorDesc);
                }
                nro++;

                wsfex.agregaFactura(Id, DateTime.Now, tipoCbte, ptoVta, nro, 2, "", 208, "chile sa", 50000000032L, "naaaaa", "", "DOL", 15, "", 100, "", "", "CIF", "", 1);
                wsfex.agregaItem("11111", "remera ", 1, 1, 100, 100, 0);

                if (wsfex.autorizar())
                {
                    string CAE = "";
                    string Resultado = "";
                    string Reproceso = "";
                    DateTime Vencimiento = default(DateTime);
                    wsfex.autorizarRespuesta(ref CAE, ref Vencimiento, ref Resultado, ref Reproceso);
                    if (Resultado == "A")
                        MessageBox.Show("Felicitaciones! Si ve este mensaje instalo correctamente FEAFIP. CAE y Vencimiento: " + CAE + " " + Vencimiento.ToString());
                    else
                        MessageBox.Show(wsfex.autorizarRespuestaObs());
                }
                else
                {
                    MessageBox.Show(wsfex.ErrorDesc);

                }
            }
            else
            {
                MessageBox.Show(wsfex.ErrorDesc);
            }

        }
    }
}
