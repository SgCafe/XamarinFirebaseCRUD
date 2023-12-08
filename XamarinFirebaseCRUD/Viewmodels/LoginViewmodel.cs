using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFirebaseCRUD.Service;
using XamarinFirebaseCRUD.Views;

namespace XamarinFirebaseCRUD.Viewmodels
{
    public class LoginViewmodel : BaseViewmodel
    {
        #region properties
        public INavigation Navigation;

        private readonly IUserService _userService;

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        #endregion

        #region constructor
        public LoginViewmodel(INavigation navigation)
        {
            Navigation = navigation;
            _userService = new UserService();
            LoginCommand = new Command(ExecuteLoginCommand);
            RegisterCommand = new Command(ExecuteRegisterCommand);
            AboutCommand = new Command(ExecuteAboutCommand);
        }

        


        #endregion

        #region commands
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand AboutCommand { get; set; }
        #endregion

        #region methods
        private async void ExecuteLoginCommand()
        {
            try
            {
                var verifyLogin = _userService.UserExist(Email, Password);

                if (verifyLogin != null)
                {
                    await Shell.Current.DisplayAlert("Sucesso", "Usuário Logado.", "Ok");
                    await Navigation.PushAsync(new ContactsPage());
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Usuário e senha não correspondem.", "Ok");

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", $"Ocorreu um erro. {ex.Message}", "Ok");
            }
        }

        private async void ExecuteRegisterCommand()
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }

        private async void ExecuteAboutCommand()
        {
            await Navigation.PushAsync(new AboutPage());
        }
        #endregion
    }
}
