using App3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "https://aluracar.herokuapp.com/";
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
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


        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;
            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

            var deSerialized = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (var item in deSerialized)
            {
                this.Veiculos.Add(new Veiculo
                {
                    Nome = item.nome,
                    Preco = item.preco
                });
            }

            Aguarde = false;
        }
    }
    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
