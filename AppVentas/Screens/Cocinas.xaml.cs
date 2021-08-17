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
    public partial class Cocinas : ContentPage
    {
        private string url = App.url + "Articulos";

        HttpClient cliente = new HttpClient();
        public Cocinas()
        {
            InitializeComponent();
            btnCarrito.Clicked += BtnCarrito_Clicked;
            btnLogout.Clicked += BtnLogout_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
            btnAgregar.Clicked += BtnAgregar_Clicked;
            listaCo.SelectionChanged += ListaCo_SelectionChanged;
        }

        private ArticuloModel articuloSeleccionado = new ArticuloModel();
        private void ListaCo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var articulos = e.CurrentSelection;
            for (int i = 0; i < articulos.Count; i++)
            {
                var articulo = articulos[i] as ArticuloModel;
                articuloSeleccionado = articulo;
            }
        }

        IList<ArticuloModel> lista = new ObservableCollection<ArticuloModel>();
        IList<ArticuloModel> listaCocinas = new ObservableCollection<ArticuloModel>();
        protected override async void OnAppearing()//Mostrar articulos disponibles (filtrar por categoria)
        {
            string contenido = await cliente.GetStringAsync(url);
            lista = JsonConvert.DeserializeObject<IList<ArticuloModel>>(contenido);
            for (int i = 0; i < lista.Count(); i++)
            {
                //Categoria 3 es para cocinas
                if (lista[i].categoriaId == 3)
                {
                    listaCocinas.Add(lista[i]);
                }
            }
            listaCo.ItemsSource = new ObservableCollection<ArticuloModel>(listaCocinas);
            base.OnAppearing();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            App.Carrito.Add(articuloSeleccionado);
            await DisplayAlert("Producto agregado", "El producto " + articuloSeleccionado.nombre + " fue agregado exitosamente", "OK");
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
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