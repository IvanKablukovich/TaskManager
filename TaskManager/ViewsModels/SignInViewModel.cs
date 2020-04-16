using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.ViewsModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SignInCommand { protected set; get; }
        public ICommand SignUpCommand { protected set; get; }
        public User user { get; set; }

        public SignInViewModel()
        {
            SignInCommand = new Command(SignIn);
            SignUpCommand = new Command(SignUp);
            user = new User();
        }

        private void SignUp()
        {
            App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        private void SignIn()
        {
            var my = DBRepository.getInstance.CheckUser(Name, Password);

            if (my != null)
            {
                var userQuery = DBRepository.getInstance.GetUserByName(Name);
                User currentUser = userQuery.ElementAt(0);
                App.Current.MainPage = new NavigationPage(new HomePage(currentUser));
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ooops!", "This match of user and password doesnt find in database", "Ok");
                App.Current.MainPage = new NavigationPage(new SignInPage());
            }

        }

        public string Name
        {
            get { return user.Name; }
            set
            {
                if (user.Name != value)
                {
                    user.Name = value; 
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Password
        {
            get { return user.Password; }
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
