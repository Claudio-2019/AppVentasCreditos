using AppVentas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppVentas.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Producto> productos { get; set; }

        public MainPageViewModel()
        {
            productos = new ObservableCollection<Producto> {
              new Producto
            {
                nombre = "Refrigerador 1",
                precio = 1000000,
                descripcion = "Descripcion",
                imagen="refri1.png"
            },
            new Producto
            {
                nombre = "Refrigerador 2",
                precio = 1200000,
                descripcion = "Descripcion",
                imagen="refri2.png"
            },
            new Producto
            {
                nombre = "Refrigerador 3",
                precio = 1300000,
                descripcion = "Descripcion",
                imagen="refri3.png"
            },
            new Producto
            {
                nombre = "Refrigerador 4",
                precio = 1400000,
                descripcion = "Descripcion",
                imagen="refri4.png"
            },
            new Producto
            {
                nombre = "Refrigerador 5",
                precio = 1500000,
                descripcion = "Descripcion",
                imagen="refri5.png"
            }
        };


        }
    }
}
