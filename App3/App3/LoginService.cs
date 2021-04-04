using App3.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha)
                });
                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                HttpResponseMessage resultado = null;
                try
                {
                    resultado = await cliente.PostAsync("/login", camposFormulario);

                }
                catch
                {

                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
                Verifique sua senha e tente novamente mais tarde"), "FalhaLogin");
                }
                if (resultado.IsSuccessStatusCode)
                {
                    MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha incorretos!"), "FalhaLogin");
                }
            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
