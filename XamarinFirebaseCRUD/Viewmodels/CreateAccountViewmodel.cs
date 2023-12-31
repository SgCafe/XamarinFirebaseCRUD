﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFirebaseCRUD.Service;

namespace XamarinFirebaseCRUD.Viewmodels
{
    public class CreateAccountViewmodel : BaseViewmodel
    {
        #region properties
        public INavigation Navigation;
        private readonly IUserService _userService;

        private string _emailCreateCommand;
        public string EmailCreate
        {
            get => _emailCreateCommand;
            set => SetProperty(ref _emailCreateCommand, value);
        }

        private string _passwordCreate;
        public string PasswordCreate
        {
            get => _passwordCreate;
            set => SetProperty(ref _passwordCreate, value);
        }

        private string _passwordConfirm;
        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        #endregion

        #region constructor
        public CreateAccountViewmodel(INavigation navigation)
        {
            Navigation = navigation;
            _userService = new UserService();
            CreateUserCommand = new Command(ExecuteCreateUserCommand);
            CancelCommand = new Command(ExecuteCancelCommand);
        }
        #endregion

        #region commands
        public ICommand CreateUserCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region methods

        private void IsLoading()
        {
            if (IsBusy)
            {
                IsBusy = false;
            }
            else
            {
                IsBusy = true;
            }
        }

        private async void ExecuteCreateUserCommand()
        {

            if (EmailCreate == null || PasswordCreate == null || PasswordCreate == null)
            {
                IsLoading();
                await Shell.Current.DisplayAlert("Erro", "Os Campos não podem ser vazios.", "Ok");
                return;
            }

            if (PasswordCreate != PasswordConfirm)
            {
                IsLoading();
                await Shell.Current.DisplayAlert("Erro", "As senhas devem ser iguais.", "Ok");
                return;
            }

            try
            {
                IsLoading();
                //TODO -> Criar criptografia de senha, Colocar 
                var verifyAccountExist = await _userService.UserExist(EmailCreate, PasswordCreate);
                if (verifyAccountExist)
                {
                    IsLoading();
                    await Shell.Current.DisplayAlert("Erro", "Usuário ja criado", "Ok");
                    return;
                }

                var createAccount = await _userService.RegisterUser(EmailCreate, PasswordCreate);

                if (createAccount)
                {
                    IsLoading();
                    await Shell.Current.DisplayAlert("Sucesso", "Conta criada com sucesso!", "Ok");
                    await Navigation.PopAsync();
                }

                else
                {
                    IsLoading();
                    await Shell.Current.DisplayAlert("Erro", "Não foi possível criar um usuário!", "Ok");
                    return;
                }


            }
            catch (Exception ex)
            {
                IsLoading();
                await Shell.Current.DisplayAlert("Erro", $"Erro: {ex.Message}", "Ok");
            }
        }

        private void ExecuteCancelCommand()
        {
            EmailCreate = string.Empty;
            PasswordCreate = string.Empty;
            PasswordConfirm = string.Empty;
        }
        #endregion
    }
}
