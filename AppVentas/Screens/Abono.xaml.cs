using AppVentas.Backend.Models;
using AppVentas.Backend.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace AppVentas.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Abono : ContentPage
    {
        private string url = App.url + "Facturas";
        HttpClient client = new HttpClient();
        public Abono()
        {
            InitializeComponent();
            btnInicio.Clicked += BtnInicio_Clicked;
            btnCarrito.Clicked += BtnCarrito_Clicked;
            btnLogout.Clicked += BtnLogout_Clicked;
            btnFinalizar.Clicked += BtnFinalizar_Clicked;
        }

        private async void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            //si la factura esta cancelada
            if (Facturas.facturaSeleccionada.estadoId == 3)
            {
                await DisplayAlert("Factura ya ha sido cancelada", "La factura ID " + Facturas.facturaSeleccionada.facturaId + " ya ha sido cancelada (no posee cuotas pendientes)", "OK");

                ((NavigationPage)this.Parent).PushAsync(new Facturas());
            }
            else
            {

                int estado = 0;
                //Si el saldo queda en 0 entonces el estado pasa a ser "cancelado"
                if ((Facturas.facturaSeleccionada.saldo - Facturas.facturaSeleccionada.pagoPorMes) == 0)
                {
                    estado = 3;
                }
                else
                {
                    estado = 1;
                }

                //se reducen las cuotas pendientes y el saldo total
                FacturaModel factura = new FacturaModel
                {
                    facturaId = Facturas.facturaSeleccionada.facturaId,
                    estadoId = estado,
                    plazoId = Facturas.facturaSeleccionada.plazoId,
                    garantiaMeses = 12,
                    pagoPorMes = Facturas.facturaSeleccionada.pagoPorMes,
                    saldo = Facturas.facturaSeleccionada.saldo - Facturas.facturaSeleccionada.pagoPorMes,
                    cedula = App.cedula,
                    fecha = Facturas.facturaSeleccionada.fecha,
                    cuotasPendientes = Facturas.facturaSeleccionada.cuotasPendientes - 1
                };

                Correo correo = new Correo();
                correo.Enviar("Abono realizado con éxito", Facturas.facturaSeleccionada.facturaId, 12, Facturas.facturaSeleccionada.pagoPorMes, Facturas.facturaSeleccionada.saldo - Facturas.facturaSeleccionada.pagoPorMes, App.cedula,
                    Facturas.facturaSeleccionada.cuotasPendientes - 1, Facturas.facturaSeleccionada.fecha, App.correo);

                var response = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json"));
                await DisplayAlert("Confirmación de abono", "El abono a la factura ID " + Facturas.facturaSeleccionada.facturaId + " se ha realizado con éxito", "OK");

                ((NavigationPage)this.Parent).PushAsync(new Facturas());
            }
        }

        protected override void OnAppearing()
        {//jalar datos de variable estatica

            //si el estado es 1 entonces no hay mora
            if (Facturas.facturaSeleccionada.estadoId == 1)
            {
                lblEstado.Text = "Estado: Al día";
            }
            else if (Facturas.facturaSeleccionada.estadoId == 2)
            {
                lblEstado.Text = "Estado: Cuota mensual pendiente";
            }
            else if (Facturas.facturaSeleccionada.estadoId == 3)
            {
                lblEstado.Text = "Estado: Factura cancelada";
            }


            lblFacturaID.Text = "Factura ID: " + Facturas.facturaSeleccionada.facturaId;

            lblCuotasPendientes.Text = "Abonos restantes: " + Facturas.facturaSeleccionada.cuotasPendientes;
            lblCuota.Text = "Monto de abono: " + Facturas.facturaSeleccionada.pagoPorMes;
            lblSaldo.Text = "Saldo: " + Facturas.facturaSeleccionada.saldo;
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