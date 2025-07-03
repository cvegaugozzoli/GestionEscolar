using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FEAFIPTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FEAFIPLib.BIWSFEV1 wsfev1;

        private void button1_Click(object sender, EventArgs e)
        {

            long nroComprobante = 0;
            int ptoVta = 101;
            System.DateTime FechaComp = DateAndTime.Now;
            string cae = "";
            System.DateTime vencimiento = default(System.DateTime);
            string resultado = "";

            wsfev1 = new FEAFIPLib.BIWSFEV1();
            if (wsfev1.login("..\\..\\..\\certificado.pfx", "feafip"))
            {
                if (wsfev1.recuperaLastCMP(ptoVta, 1, ref nroComprobante))
                {
                    nroComprobante += 1;
                    wsfev1.reset();
                    wsfev1.agregaFactura(1, 80, 30707219072L, nroComprobante, nroComprobante, FechaComp, 121, 0, 100, 0, null, null, null, "PES", 1);
                    wsfev1.agregaIVA(5, 100, 21);
                    if (wsfev1.autorizar(ptoVta, 1))
                    {
                        wsfev1.autorizarRespuesta(0, ref cae, ref vencimiento, ref resultado);
                        if (resultado == "A")
                        {
                            MessageBox.Show("Felicitaciones! Si ve este mensaje instalo correctamente FEAFIP. CAE y Vencimiento: " + cae + " " + vencimiento);

                        }
                        else
                        {
                            MessageBox.Show(wsfev1.autorizarRespuestaObs(0));
                        }
                    }
                    else
                    {
                        MessageBox.Show(wsfev1.ErrorDesc);
                    }
                }
                else
                {
                    MessageBox.Show(wsfev1.ErrorDesc);
                }
            }
            else
            {
                MessageBox.Show(wsfev1.ErrorDesc);
            }
        }
    }
}
