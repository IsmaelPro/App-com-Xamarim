using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS => string.Format("Freio ABS - R$ {0}", FREIO_ABS);

        private bool temFreioABS;

        public bool TemFreioABS
        {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ArCondicionado => string.Format("Freio ABS - R$ {0}", AR_CONDICIONADO);
        private bool TemAr;

        public bool TemArCondicionado
        {
            get
            {
                return TemAr;
            }
            set
            {
                TemAr = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string MP3Player => string.Format("Freio ABS - R$ {0}", MP3_PLAYER);
        private bool Mp3;

        public bool TemMP3Player
        {
            get
            {
                return Mp3;
            }
            set
            {
                Mp3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal => string.Format("Valor Total: R${0}", Veiculo.Preco
            + (TemFreioABS ? FREIO_ABS : 0)
            + (TemArCondicionado ? AR_CONDICIONADO : 0)
            + (TemMP3Player ? MP3_PLAYER : 0));

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}