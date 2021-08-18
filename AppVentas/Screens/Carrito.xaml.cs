using AppVentas.Backend.Models;
using AppVentas.Models;
using AppVentas.ViewModels;
using System;
using System.Collections;
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
    public partial class Carrito : ContentPage
    {
        private string url = App.url + "Articulos";

        HttpClient cliente = new HttpClient();

        public List<DTOProducto> listaRefris = new List<DTOProducto>();
        public Carrito()
        {
            InitializeComponent();
            btnLogout.Clicked += BtnLogout_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
            btnCompra.Clicked += BtnCompra_Clicked;
            btnEliminar.Clicked += BtnEliminar_Clicked;
            listaCarrito.SelectionChanged += ListaCarrito_SelectionChanged;
        }
        private ArticuloModel articuloSeleccionado = new ArticuloModel();
        private void ListaCarrito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var articulos = e.CurrentSelection;
            for (int i = 0; i < articulos.Count; i++)
            {
                var articulo = articulos[i] as ArticuloModel;
                articuloSeleccionado = articulo;
            }
        }

        protected override void OnAppearing()
        {
            if (App.Carrito.Count()==0) { btnCompra.IsEnabled = false; }
            else btnCompra.IsEnabled = true;

            if (App.Carrito.Count() == 0) { btnEliminar.IsEnabled = false; }
            else btnEliminar.IsEnabled = true;


            listaCarrito.ItemsSource = App.Carrito;
            base.OnAppearing();
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            App.Carrito.Remove(articuloSeleccionado);
            await DisplayAlert("Producto eliminado", "El producto " + articuloSeleccionado.nombre + " fue eliminado exitosamente", "OK");

            if (App.Carrito.Count() == 0) { btnCompra.IsEnabled = false; }
            else btnCompra.IsEnabled = true;

            if (App.Carrito.Count() == 0) { btnEliminar.IsEnabled = false; }
            else btnEliminar.IsEnabled = true;

        }

        private void BtnCompra_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new DetalleCompra());
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

    }
}