using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Backend.Models
{
    class DTOUser
    {
       
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string residencia { get; set; }
        public int rolId { get; set; }
        public string contraseña { get; set; }
    }
}
