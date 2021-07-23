using AppVentas.Backend.Models;
using AppVentas.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Registro()
        {
            InitializeComponent();
        }

        public async void SetNewUser()
        {

        }

        private void DisplayAlert(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private async void btnIr_Clicked(object sender, EventArgs e)
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
                contraseña = this.InputContrasena.Text
            };

             serviceRegistration.CreateUser(user);

        }

       

    }
}