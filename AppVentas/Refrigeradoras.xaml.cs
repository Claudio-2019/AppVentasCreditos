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
    public partial class Refrigeradoras : ContentPage
    {
        public Refrigeradoras()
        {
            InitializeComponent();
            bntCarrito.Clicked += BntCarrito_Clicked;
        }

        private void BntCarrito_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Carrito());

        }
    }
}