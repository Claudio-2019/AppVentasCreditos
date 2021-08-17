using AppVentas.Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.Backend.Interfaces
{
    interface IRegistration
    {
        Task<string> CreateUser(DTOUser newUser);
        
        
    }
}
