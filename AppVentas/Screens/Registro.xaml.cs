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


        private string url = App.url + "Usuarios";
        HttpClient client = new HttpClient();
        public Registro()
        {
            InitializeComponent();
        }



        async void btnIr_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(InputCedula.Text) || string.IsNullOrEmpty(InputNombre.Text) || string.IsNullOrEmpty(InputApellido.Text)
                    || string.IsNullOrEmpty(InputEmail.Text) || string.IsNullOrEmpty(InputResidencia.Text) || string.IsNullOrEmpty(InputTelefono.Text)
                    || string.IsNullOrEmpty(InputContrasena.Text) || string.IsNullOrEmpty(InputConfirmar.Text))
                {
                    DisplayAlert("Error al crear usuario", "Ningún campo puede estar vacío", "OK");
                }
                else if (!InputContrasena.Text.Equals(InputConfirmar.Text))
                {
                    DisplayAlert("Error al crear usuario", "Contraseñas deben coincidir", "OK");
                }
                else if (!InputEmail.Text.Contains("@"))
                {
                    DisplayAlert("Error al crear usuario", "Formato de correo es incorrecto", "OK");
                }

                else
                {

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
                    await DisplayAlert("Confirmación", "Usuario " + InputCedula.Text + " agregado con éxito", "OK");

                    ((NavigationPage)this.Parent).PushAsync(new MainPage());
                }
            }
            catch (Exception)
            {

                DisplayAlert("Error", "Ha ocurrido un error inesperado", "OK");
            }


        }



    }
}