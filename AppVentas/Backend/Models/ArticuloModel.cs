using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppVentas.Backend.Models
{
    public class ArticuloModel
    {
        public int articuloId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int categoriaId { get; set; }
        public string imagen { get; set; }

    }
}
