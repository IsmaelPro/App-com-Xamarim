using App3.Models;
using App3.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMEnsagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void AssinarMEnsagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil",
                (msg) =>
                {
                    CurrentPage = Children[1];
                });

            MessagingCenter.Subscribe<Usuario>(this, "SucessoSalvarUsuario",
                async (msg) =>
                {
                    CurrentPage = Children[0];
                    await DisplayAlert("Usuario", "Usuario Cadastrado Com Sucesso", "OK");
                });
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoSalvarUsuario");
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
        }
    }
}