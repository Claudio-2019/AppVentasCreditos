using AppVentas.Models;
using AppVentas.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carrito : ContentPage
    {
        private DTOProducto Refri1;
        private DTOProducto Refri2;
        private DTOProducto Refri3;
        private DTOProducto Refri4;
        private DTOProducto Refri5;

        public List<DTOProducto> listaRefris = new List<DTOProducto>();
        public Carrito()
        {
            InitializeComponent();
            btnLogout.Clicked += BtnLogout_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
            btnCompra.Clicked += BtnCompra_Clicked;
            BindingContext = new MainPageViewModel();//por cambiar por vista de carrito, elementos seleccionados

             Refri1 = new DTOProducto
            {
                id = 1,
                descripcion = "Refrigeradora 1",
                imagen = "refri1.png",
                nombre = "Refrigeradora 1"

            };
             Refri2 = new DTOProducto
            {
                id = 2,
                descripcion = "Refrigeradora 2",
                imagen = "refri2.png",
                nombre = "Refrigeradora 2"

            };
             Refri3 = new DTOProducto
            {
                id = 3,
                descripcion = "Refrigeradora 3",
                imagen = "refri3.png",
                nombre = "Refrigeradora 3"

            };
             Refri4 = new DTOProducto
            {
                id = 4,
                descripcion = "Refrigeradora 4",
                imagen = "refri4.png",
                nombre = "Refrigeradora 4"

            };
             Refri5 = new DTOProducto
            {
                id = 5,
                descripcion = "Refrigeradora 5",
                imagen = "refri5.png",
                nombre = "Refrigeradora 5"

            };

            listaRefris.Add(Refri1);
            listaRefris.Add(Refri2);
            listaRefris.Add(Refri3);
            listaRefris.Add(Refri4);
            listaRefris.Add(Refri5);
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

        async void EliminarItemCarrito(object sender,EventArgs e)
        {
            
        }
    }
}