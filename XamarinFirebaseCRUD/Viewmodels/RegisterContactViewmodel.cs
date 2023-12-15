using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFirebaseCRUD.Models;

namespace XamarinFirebaseCRUD.Viewmodels
{
    public class RegisterContactViewmodel : BaseViewmodel
    {
        #region properties
        public INavigation Navigation;

        private string _cepTxt;
        public string CepTxt
        {
            get => _cepTxt;
            set => SetProperty(ref _cepTxt, value);
        }

        private string _logradouroTxt;
        public string LogradouroTxt
        {
            get => _logradouroTxt;
            set => SetProperty(ref _logradouroTxt, value);
        }

        private string _bairroTxt;
        public string BairroTxt
        {
            get => _bairroTxt;
            set => SetProperty(ref _bairroTxt, value);
        }

        private string _cidadeTxt;
        public string CidadeTxt
        {
            get => _cidadeTxt;
            set => SetProperty(ref _cidadeTxt, value);
        }

        private string _ufTxt;
        public string UfTxt
        {
            get => _ufTxt;
            set => SetProperty(ref _ufTxt, value);
        }

        private string _numberTxt;
        public string NumberTxt
        {
            get => _numberTxt;
            set => SetProperty(ref _numberTxt, value);
        }


        #endregion

        #region constructor
        public RegisterContactViewmodel(INavigation navigation)
        {
            Navigation = navigation;
            FindCepCommand = new Command(ExecuteFindCepCommand);
        }

        
        #endregion

        #region commands
        public ICommand FindCepCommand { get; set; }
        #endregion

        #region methods
        private async void ExecuteFindCepCommand()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync($"https://viacep.com.br/ws/{CepTxt}/json/");
                var data = JsonConvert.DeserializeObject<Address>(json);

                LogradouroTxt = data.Logradouro;
                BairroTxt = data.Bairro;
                CidadeTxt = data.Localidade;
                UfTxt = data.Uf;
               
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "O cep não foi encontrado, tente novamente.", "Ok");
                CepTxt = string.Empty;
                return;
            }
        }
        #endregion
    }
}
