using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.Views
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado => string.Format("R$ {0}", Preco);
            
    }
    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemView()
        {
            InitializeComponent();
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 85000},
                new Veiculo { Nome = "Fiesta 2.0", Preco = 52000},
                new Veiculo { Nome = "Onix 1.6", Preco = 35000},
                new Veiculo { Nome = "C3 1.0", Preco = 22000},
                new Veiculo { Nome = "Uno Fire", Preco = 11000},
                new Veiculo { Nome = "Sentra 2.0", Preco = 53000},
                new Veiculo { Nome = "Astra Sedan", Preco = 39000},
                new Veiculo { Nome = "Vectra 2.0", Preco = 37000},
                new Veiculo { Nome = "Hilux 4x4", Preco = 90000},
                new Veiculo { Nome = "Montana", Preco = 57000},
                new Veiculo { Nome = "Outlander 2.4", Preco = 90000}
            };

            this.BindingContext = this;

        }



        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheView(veiculo));

        }
    }
}
