using AppVentas.Backend.Models;
using AppVentas.Backend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppVentas
{
    public partial class MainPage : ContentPage
    {
        private ServiceLogin serviceLogin = new ServiceLogin();
        private DTOUser usuario;

        public MainPage()
        {
            InitializeComponent();
            btnIr.Clicked += BtnIr_Clicked;
            btnRegistro.Clicked += BtnRegistro_Clicked;
        }

        private void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }

        private void BtnIr_Clicked(object sender, EventArgs e)
        {
          
            usuario = new DTOUser
            {
                nombre = "",
                cedula = "",
                apellidos = "",
                email = this.inputCorreo.Text,
                telefono = "",
                residencia = "",
                rolId = 1,
                contraseña = this.inputContrasena.Text
            };

            string rol = serviceLogin.authentication(usuario);

            if (rol.Equals("Admin"))
            {
                ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
            }
            else
            {
                DisplayAlert("Error en autenticacion","Credenciales ivalidas","Ok");
            }
        }
    }
}
