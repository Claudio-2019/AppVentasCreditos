using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Models
{
    public class DTOProducto
    {
        public int id { get; set; }
        public string nombre{get; set;}
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public decimal precio { get; set; }
    }
}
