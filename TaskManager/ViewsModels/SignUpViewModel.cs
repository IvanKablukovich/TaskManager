using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Views;
using Xamarin.Forms;

namespace TaskManager.ViewsModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveUserCommand { protected set; get; }
        public User user { get; set; }

        public SignUpViewModel()
        {
            SaveUserCommand = new Command(SaveUser);
            user = new User();
        }
        private void SaveUser()
        {
            var email = Email;
            var emailCheck = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";

            if (!String.IsNullOrEmpty(user.Name) && Regex.IsMatch(email, emailCheck))
            {
                //user.Role = true;
                DBRepository.getInstance.SaveItem(user);
                App.Current.MainPage = new NavigationPage(new SignInPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ooops!", "Failed", "Ok");
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
        public string Email
        {
            get { return user.Email; }
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    OnPropertyChanged(nameof(Email));
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

