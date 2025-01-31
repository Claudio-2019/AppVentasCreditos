﻿using AppVentas.ViewModels;
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
    public partial class DetalleCompra : ContentPage
    {
        private string url = App.url + "Facturas";
        HttpClient client = new HttpClient();
        decimal pagoPorMes = 0;
        decimal saldo = 0;
        int plazoSeleccionado = 0;
        int cuotasPendientes = 0;
        int facturaID = 0;
        public DetalleCompra()
        {
            InitializeComponent();
            btnCarrito.Clicked += BtnCarrito_Clicked;
            btnInicio.Clicked += BtnInicio_Clicked;
            btnLogout.Clicked += BtnLogout_Clicked;
            plazo.SelectedIndexChanged += Plazo_SelectedIndexChanged;
            btnFinalizar.Clicked += BtnFinalizar_Clicked;
        }

        private async void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                FacturaModel factura = new FacturaModel
                {
                    estadoId = 2,//automaticamente queda cuota pendiente, una vez que se haga el abono el estado pasa a 1 (al dia)
                    plazoId = plazoSeleccionado,
                    garantiaMeses = 12,
                    pagoPorMes = pagoPorMes,
                    saldo = saldo,
                    cedula = App.cedula,
                    fecha = DateTime.Today,
                    cuotasPendientes = cuotasPendientes
                };


                var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json"));

                Correo correo = new Correo();
                correo.Enviar("Compra realizada con éxito", facturaID, 12, pagoPorMes, saldo, App.cedula,
                    cuotasPendientes, DateTime.Today, App.correo);
                await DisplayAlert("Confirmación de compra", "Su compra ha sido procesada con éxito", "OK");
                App.Carrito.Clear();

                ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
            }
            catch (Exception)
            {

                DisplayAlert("Error", "Ha ocurrido un error inesperado", "OK");
            }
        }

        IList<FacturaModel> lista = new ObservableCollection<FacturaModel>();
        protected override async void OnAppearing()
        {
            string contenido = await client.GetStringAsync(url);
            lista = JsonConvert.DeserializeObject<IList<FacturaModel>>(contenido);
            facturaID = lista.Count() + 1;
            btnFinalizar.IsEnabled = false;
            base.OnAppearing();
        }

        private decimal Cuota(decimal porcentaje, int plazo) {
            decimal cuota = 0;

            for (int i = 0; i < App.Carrito.Count(); i++)
            {
                cuota = cuota + App.Carrito[i].precio;
            }


            cuota = cuota + cuota * (porcentaje/100);

            cuota = cuota / plazo;

            return cuota ;
        }

        private decimal Total(decimal porcentaje)
        {
            decimal total = 0;

            for (int i = 0; i < App.Carrito.Count(); i++)
            {
                total = total + App.Carrito[i].precio;
            }


            total = total + total * (porcentaje / 100);

            return total;
        }


        private void Plazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFinalizar.IsEnabled = true;
            if (plazo.SelectedIndex==0) {
                lblInteres.Text = "Tasa de interés: 4%";
                lblCuota.Text = "Cuota por mes: "+decimal.Round(Cuota(4, 12),2)+" colones";
                lblFechaPago.Text = "Fechas de pago: "+DateTime.Today.Day.ToString()+" de cada mes";
                lblCantidad.Text = "Cantidad de artículos: "+App.Carrito.Count();
                lblGarantia.Text = "Garantía: 12 meses";
                lblMonto.Text = "Total: " + decimal.Round(Total(12), 2) +" colones";
                pagoPorMes = decimal.Round(Cuota(4, 12), 2);
                saldo = decimal.Round(Total(12), 2);
                cuotasPendientes = 12;
                plazoSeleccionado = 1;
            }
            else if (plazo.SelectedIndex == 1)
            {
                lblInteres.Text = "Tasa de interés: 5%";
                lblCuota.Text = "Cuota por mes: " + decimal.Round(Cuota(5, 18), 2) + " colones";
                lblFechaPago.Text = "Fechas de pago: " + DateTime.Today.Day.ToString() + " de cada mes";
                lblCantidad.Text = "Cantidad de artículos: " + App.Carrito.Count();
                lblGarantia.Text = "Garantía: 12 meses";
                lblMonto.Text = "Total: " + decimal.Round(Total(18), 2) + " colones";
                pagoPorMes = decimal.Round(Cuota(5, 18), 2);
                saldo = decimal.Round(Total(18), 2);
                cuotasPendientes = 18;
                plazoSeleccionado = 2;
            }
            else if (plazo.SelectedIndex == 2)
            {
                lblInteres.Text = "Tasa de interés: 6%";
                lblCuota.Text = "Cuota por mes: " + decimal.Round(Cuota(6, 24), 2) + " colones";
                lblFechaPago.Text = "Fechas de pago: " + DateTime.Today.Day.ToString() + " de cada mes";
                lblCantidad.Text = "Cantidad de artículos: " + App.Carrito.Count();
                lblGarantia.Text = "Garantía: 12 meses";
                lblMonto.Text = "Total: " + decimal.Round(Total(24), 2) + " colones";
                pagoPorMes = decimal.Round(Cuota(6, 24), 2);
                saldo = decimal.Round(Total(24), 2);
                cuotasPendientes = 24;
                plazoSeleccionado = 3;
            }
            else if (plazo.SelectedIndex == 3)
            {
                lblInteres.Text = "Tasa de interés: 7%";
                lblCuota.Text = "Cuota por mes: " + decimal.Round(Cuota(7, 36), 2) + " colones";
                lblFechaPago.Text = "Fechas de pago: " + DateTime.Today.Day.ToString() + " de cada mes";
                lblCantidad.Text = "Cantidad de artículos: " + App.Carrito.Count();
                lblGarantia.Text = "Garantía: 12 meses";
                lblMonto.Text = "Total: " + decimal.Round(Total(36), 2) + " colones";
                pagoPorMes = decimal.Round(Cuota(7, 36), 2);
                saldo = decimal.Round(Total(36), 2);
                cuotasPendientes = 36;
                plazoSeleccionado = 4;
            }
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuPrincipal());
        }

        private void BtnCarrito_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Carrito());
        }
    }
}