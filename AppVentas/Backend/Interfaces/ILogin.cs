using System;
using System.Collections.Generic;
using System.Text;
using AppVentas.Backend.Models;

namespace AppVentas.Backend.Interfaces
{
    interface ILogin
    {
        string authentication(DTOUser credentials);
    }
}
