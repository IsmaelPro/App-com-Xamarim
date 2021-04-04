using App3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class MasterViewModel
    {
        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        public ICommand EditarPerfilCommand { get; private set; }
        private readonly Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(new Usuario(), "EditarPerfil");
            });
        }

    }
}
