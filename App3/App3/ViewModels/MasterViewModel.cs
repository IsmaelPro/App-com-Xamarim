using App3.Midia;
using App3.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class MasterViewModel : BaseViewModel
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

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; ; }
            set { this.usuario.telefone = value; }
        }

        public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand TirarFotoCommand { get; private set; }

        private readonly Usuario usuario;

        private bool editando = false;

        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        private ImageSource fotoPerfil = "perfil.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set { fotoPerfil = value; }
        }



        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos();
        }

        private void DefinirComandos()
        {
            EditarPerfilCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(new Usuario(), "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(new Usuario(), "SucessoSalvarUsuario");
            });

            EditarCommand = new Command(() =>
            {
                this.Editando = true;
            });

            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

        }
    }
}