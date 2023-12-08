﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseCRUD.Service;

namespace XamarinFirebaseCRUD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            DependencyService.Register<IUserService, UserService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
