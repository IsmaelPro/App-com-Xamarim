using App3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public ObservableCollection<Usuario> Usuarios { get; set; }

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public ICommand EntrarCommand { get; set; }

        public LoginViewModel()
        {
            this.Usuarios = new ObservableCollection<Usuario>();
            EntrarCommand = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha));
            },
            () =>
                    {
                        return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(Senha); ;
                    });
        }

 

        //public async Task GetUsuario()
        //{
        //    Aguarde = true;
        //    HttpClient cliente = new HttpClient();
        //    var resultado = await cliente.GetStringAsync("https://aluracar.herokuapp.com/");

        //    var deSerialized = JsonConvert.DeserializeObject<UsuarioJson[]>(resultado);

        //    foreach (var item in deSerialized)
        //    {
        //        this.Usuarios.Add(new Usuario
        //        {
        //            Id = item.id,
        //            Nome = item.nome,
        //            DataNascimento = item.dataNascimento,
        //            Telefone = item.telefone,
        //            Email = item.email
        //        });
        //    }

        //    Aguarde = false;
        //}

        //private class UsuarioJson
        //{
        //    public int id { get; set; }
        //    public string nome { get; set; }
        //    public DateTime dataNascimento { get; set; }
        //    public string telefone { get; set; }
        //    public string email { get; set; }
        //}
    }
}