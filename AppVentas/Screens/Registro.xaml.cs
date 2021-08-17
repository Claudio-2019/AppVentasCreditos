using AppVentas.Backend.Models;
using AppVentas.Backend.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private ServiceRegistration serviceRegistration = new ServiceRegistration();
        private DTOUser user;
        public string RegistroInfo;

        private string url = App.url + "Usuarios";
        HttpClient client = new HttpClient();
        public Registro()
        {
            InitializeComponent();
        }

       

        async void ShowMessage(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", RegistroInfo, "OK");
        }

        async void btnIr_Clicked(object sender, EventArgs e)
        {
            /*try
            {
                user = new DTOUser
                {
                    nombre = this.InputNombre.Text,
                    cedula = this.InputCedula.Text,
                    apellidos = this.InputApellido.Text,
                    email = this.InputEmail.Text,
                    telefono = this.InputTelefono.Text,
                    residencia = this.InputResidencia.Text,
                    rolId = 1,
                    contrasena = this.InputContrasena.Text
                };

                var PostUser = serviceRegistration.CreateUser(user).Result;

                ((NavigationPage)this.Parent).PushAsync(new MainPage());

            }
            catch (Exception error)
            {

                await DisplayAlert("Alert", error.Message, "OK");
            }*/

            DTOUser usu = new DTOUser
            {
                cedula = this.InputCedula.Text,
                nombre = this.InputNombre.Text,
                apellidos = this.InputApellido.Text,
                email = this.InputEmail.Text,
                telefono = this.InputTelefono.Text,
                residencia = this.InputResidencia.Text,
                rolId = 1,
                contrasena = this.InputContrasena.Text
            };


            var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(usu), Encoding.UTF8, "application/json"));
            await DisplayAlert("Confirmación", "Usuario "+InputCedula.Text+" agregado con éxito", "OK");

            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

       

    }
}