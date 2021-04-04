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
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil",
                (msg) =>
                {
                    this.CurrentPage = this.Children[1];
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
        }
    }
}