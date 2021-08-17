using AppVentas.Backend.Interfaces;
using AppVentas.Backend.Models;
using Localhost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppVentas.Backend.Services
{
    class ServiceRegistration : IRegistration
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? @"http://10.0.2.2:5000/api/Login" : @"http://localhost:5000/api/Login";

        private string ResultadoInsert;
        public async Task<string> CreateUser(DTOUser newUser)
        {
           

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var clienteWeb = new HttpClient(clientHandler);
 
            var jsonUser = JsonConvert.SerializeObject(newUser);

            var contentJsonUser = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            var response = await clienteWeb.PostAsync(RestUrl, contentJsonUser);

            ResultadoInsert = response.StatusCode.ToString();

            if (ResultadoInsert.Equals("200"))
            {
                return "EL USUARIO FUE REGISTRADO EXITOSAMENTE";
            }
            else
            {
                return "OCURRIO UN ERROR AL REGISTRAR EL USUARIO";
            }
            
        }


    }


}

 
