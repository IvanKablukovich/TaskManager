﻿using System;
using TaskManager.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SignInPage();
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
