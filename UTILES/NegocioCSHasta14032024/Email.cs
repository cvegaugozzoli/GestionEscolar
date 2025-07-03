using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace GESTIONESCOLAR
{
    namespace Negocio
    {
        public partial class Email

        {
            /*
             * Cliente SMTP
             * Gmail:  smtp.gmail.com  puerto:587
             * Hotmail: smtp.liva.com  puerto:25
             */
            SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

            public Email()
            {
                /* Autenticacion en el Servidor */
                server.Credentials = new System.Net.NetworkCredential("misericordistasgo@gmail.com", "App$1977");
                server.EnableSsl = true;
            }

            public void MandarCorreo(MailMessage mensaje)
            {
                server.Send(mensaje);
            }
        }

    }
}


