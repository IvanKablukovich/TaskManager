using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public User currentUser { get; private set; }
        public HomePage(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new HomePageViewModel(currentUser);
            base.OnAppearing();
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignInPage());
        }
    }
}