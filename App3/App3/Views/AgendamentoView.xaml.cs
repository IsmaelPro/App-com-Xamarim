using App3.Models;
using App3.ViewModels;
using System;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
                async (msg) =>
                {
                    var confirma = await DisplayAlert("Salvar Agendamento",
                                 "Deseja mesmo salvar o agendamento?",
                                 "Confirmar", "Cancelar");

                    if (confirma)
                    {

                        await DisplayAlert("Agendamento",
                            string.Format(
                                "Veiculo: " + ViewModel.Agendamento.Veiculo.Nome + "\n" +
                                "Nome: " + ViewModel.Agendamento.Nome + "\n" +
                                "Fone: " + ViewModel.Agendamento.Fone + "\n" +
                                "Email: " + ViewModel.Agendamento.Email + "\n" +
                                "DataAgendamento: " + ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy") + "\n" +
                                "HoraAgendamento: " + ViewModel.Agendamento.HoraAgendamento + "\n"), "OK");

                        this.ViewModel.SalvarAgendamento(msg);
                    }
                });
            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
               (msg) =>
               {
                   DisplayAlert("Agendamento", "Agendamento Salvo Com sucesso", "OK");
               });
            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento", msg.Message, "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}