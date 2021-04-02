using App3.Models;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
           string.Format(
           @"Veiculo: {0}
            Nome: {1}
            Fone: {2}
            E-mail: {3}
            Data Agendamento: {4}
            Hora Agendamento: {5}",
           ViewModel.Agendamento.Veiculo.Nome,
           ViewModel.Agendamento.Nome,
           ViewModel.Agendamento.Fone,
           ViewModel.Agendamento.Email,
           ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
           ViewModel.Agendamento.HoraAgendamento), "OK");
        }
    }
}