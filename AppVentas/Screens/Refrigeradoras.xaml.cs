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

namespace AppVentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Refrigeradoras : ContentPage
    {
        private string url = App.url+ "Articulos";

        HttpClient cliente = new HttpClient();
        public Refrigeradoras()
        {
            InitializeComponent();
            btnCarrito.Clicked += BtnCarrito_Clicked;
            btnLogout.Clicked += BtnLogout_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
            listaRefri.SelectionChanged += ListaRefri_SelectionChanged;
            btnAgregar.Clicked += BtnAgregar_Clicked;
           
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            App.Carrito.Add(articuloSeleccionado);
            await DisplayAlert("Producto agregado", "El producto " + articuloSeleccionado.nombre + " fue agregado exitosamente", "OK");
        }

        private ArticuloModel articuloSeleccionado = new ArticuloModel();
        private void ListaRefri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var articulos = e.CurrentSelection;
            for (int i = 0; i < articulos.Count; i++)
            {
                var articulo = articulos[i] as ArticuloModel;
                articuloSeleccionado = articulo;
            }
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
        }

        IList<ArticuloModel> lista = new ObservableCollection<ArticuloModel>();
        IList<ArticuloModel> Refris = new ObservableCollection<ArticuloModel>();
        protected override async void OnAppearing()//Mostrar articulos disponibles (filtrar por categoria 1, que seria refris)
        {
            string contenido = await cliente.GetStringAsync(url);
           lista =  JsonConvert.DeserializeObject<IList<ArticuloModel>>(contenido);
            for (int i = 0; i < lista.Count(); i++)
            {
                //Categoria 1 es para refris
                if (lista[i].categoriaId==1) {
                    Refris.Add(lista[i]);
                }
            }
            listaRefri.ItemsSource = new ObservableCollection<ArticuloModel>(Refris);
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


    }
}