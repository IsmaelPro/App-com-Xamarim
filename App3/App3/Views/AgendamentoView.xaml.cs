using App3.Models;
using App3.ViewModels;

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
                (msg) =>
                {
                    DisplayAlert("Agendamento",
                        string.Format(
                            "Veiculo: " + ViewModel.Agendamento.Veiculo.Nome + "\n"+
                            "Nome: " + ViewModel.Agendamento.Nome + "\n"+
                            "Fone: " + ViewModel.Agendamento.Fone + "\n"+
                            "Email: " + ViewModel.Agendamento.Email + "\n"+
                            "DataAgendamento: " + ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy") + "\n"+
                            "HoraAgendamento: " + ViewModel.Agendamento.HoraAgendamento + "\n"), "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }
    }
}