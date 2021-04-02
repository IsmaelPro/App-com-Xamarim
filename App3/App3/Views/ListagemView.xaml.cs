using App3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.Views
{
       public partial class ListagemView : ContentPage
    {
        public ListagemView()
        {
            InitializeComponent();


        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }

    }
}
