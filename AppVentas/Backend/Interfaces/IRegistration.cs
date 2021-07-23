using AppVentas.Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.Backend.Interfaces
{
    interface IRegistration
    {
        void CreateUser(DTOUser newUser);
      
        
    }
}
