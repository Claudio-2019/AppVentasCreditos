using AppVentas.Backend.Models;
using AppVentas.Backend.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppVentas
{
    public partial class MainPage : ContentPage
    {

        private string url = App.url + "Usuarios";

        HttpClient cliente = new HttpClient();

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

        IList<DTOUser> usuarios = new ObservableCollection<DTOUser>();
        protected override async void OnAppearing()//Mostrar articulos disponibles (filtrar por categoria)
        {
            string contenido = await cliente.GetStringAsync(url);
            usuarios = JsonConvert.DeserializeObject<IList<DTOUser>>(contenido);

            base.OnAppearing();
        }

        private async void BtnIr_Clicked(object sender, EventArgs e)
        {
            bool token = true;

            for (int i = 0; i < usuarios.Count(); i++)
            {
                if (usuarios[i].cedula.Equals(txt_id.Text) && usuarios[i].contrasena.Equals(txt_pass.Text)) {
                    ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
                    App.cedula = usuarios[i].cedula;
                    App.correo = usuarios[i].email;
                    token = false;
                }
            }

            if(token)
            await DisplayAlert("Error al ingresar","Credenciales incorrectas","OK");

           
        }
    }
}
