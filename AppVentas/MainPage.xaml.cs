using AppVentas.Backend.Models;
using AppVentas.Backend.Services;
using System;
using System.Collections;
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
        private DTOUser usuario1;
        private DTOUser usuario2;
        private DTOUser usuario3;

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

           
           /* usuario1 = new DTOUser
            {
                nombre = "Claudio",
                cedula = "111144444",
                apellidos = "gonzalez",
                email = "claudio",
                telefono = "88885555",
                residencia = "tibas",
                rolId = 1,
                contrasena = "cliente1"
            };

            usuario2 = new DTOUser
            {
                nombre = "Randolph",
                cedula = "66666666",
                apellidos = "saenz",
                email = "randolph",
                telefono = "88885555",
                residencia = "moravia",
                rolId = 1,
                contrasena = "cliente2"
            };


            ArrayList listaUsuarios = new ArrayList();

            listaUsuarios.Add(usuario1.email);
            listaUsuarios.Add(usuario1.contrasena);


            if (listaUsuarios.Contains(this.txt_email.Text) && listaUsuarios.Contains(this.txt_pass.Text))
            {
                ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
            }
            else
            {
                DisplayAlert("Error en autenticacion","Credenciales invalidas","Ok");
            }*/

            ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
        }
    }
}
