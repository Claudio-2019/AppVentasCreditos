using AppVentas.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVentas.Backend.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace AppVentas.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Facturas : ContentPage
    {
        private string url = App.url + "Facturas";

        HttpClient cliente = new HttpClient();
        public Facturas()
        {
            InitializeComponent();
            btnInicio.Clicked += BtnInicio_Clicked;
            btnCarrito.Clicked += BtnCarrito_Clicked;
            btnLogout.Clicked += BtnLogout_Clicked;
            listaFacturas.SelectionChanged += ListaFacturas_SelectionChanged;
            btnAbono.Clicked += BtnAbono_Clicked;
        }

        private async void BtnAbono_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Factura seleccionada", "Factura ID " + facturaSeleccionada.facturaId+ " fue agregado exitosamente", "OK");
        }

        private FacturaModel facturaSeleccionada = new FacturaModel();
        private void ListaFacturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var facturas = e.CurrentSelection;
            for (int i = 0; i < facturas.Count; i++)
            {
                var factura = facturas[i] as FacturaModel;
                facturaSeleccionada = factura;
            }
        }


        IList<FacturaModel> lista = new ObservableCollection<FacturaModel>();
        IList<FacturaModel> facturasUsu = new ObservableCollection<FacturaModel>();
        protected override async void OnAppearing()
        {
            string contenido = await cliente.GetStringAsync(url);
            lista = JsonConvert.DeserializeObject<IList<FacturaModel>>(contenido);
            for (int i = 0; i < lista.Count(); i++)
            {
                //si corresponde a ced del usuario actual
                if (lista[i].cedula.Equals(App.cedula))
                {
                    facturasUsu.Add(lista[i]);
                }
            }
            listaFacturas.ItemsSource = new ObservableCollection<FacturaModel>(facturasUsu);
            base.OnAppearing();
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private void BtnCarrito_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Carrito());
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
        }
    }
}