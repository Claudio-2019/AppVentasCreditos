using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace AppVentas.Backend.Models
{
    public class Correo
    {
        public void Enviar(string asunto, int facturaId, int garantia, decimal cuota, decimal saldo, string cedula,
            int cuotasPen, DateTime fecha, string destinatario)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("golloTiendaApp@gmail.com", "gollo12345"),
                EnableSsl = true
            };

            string body = "\nID de factura: " + facturaId + "" +
                 "\n\nCédula de cliente: " + cedula +
                "\n\nMeses de garantía: " + garantia +
                "\n\nCuota por mes: " + cuota +
                "\n\nCuotas pendientes: " + cuotasPen +
                "\n\nSaldo pendiente: " + saldo +

                "\n\nFecha de compra: " + fecha.ToString("dd-MM-yyyy")
                + "\n\nDías de pago: " + fecha.Day+" de cada mes";

            MailMessage message = new MailMessage();
            message.From = new MailAddress("golloTiendaApp@gmail.com");
            message.To.Add(destinatario);
            message.Subject = asunto;
            message.Body = body;


            client.Send(message);
        }
    }
}
