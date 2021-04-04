using App3.Models;
using App3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
                (msg) =>
                {
                    //MainPage = new NavigationPage(new ListagemView());
                    MainPage = new MasterDetailView(msg);
                });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
