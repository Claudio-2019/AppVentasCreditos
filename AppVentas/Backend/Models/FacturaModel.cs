using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Backend.Models
{
    public class FacturaModel
    {
        public int facturaId { get; set; }
        public int estadoId { get; set; }
        public int plazoId { get; set; }
        public int garantiaMeses { get; set; }
        public decimal pagoPorMes { get; set; }
        public decimal saldo { get; set; }
        public string cedula { get; set; }
        public System.DateTime fecha { get; set; }
        public int cuotasPendientes { get; set; }
    }
}
