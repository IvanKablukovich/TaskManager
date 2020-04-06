using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public INavigation Navigation { get; set; }
        public User user { get; set; }

        public SignInViewModel()
        {
            SignInCommand = new Command(SignIn);
            SignUpCommand = new Command(SignUp);
            //Navigation = App.Current.MainPage.Navigation;
            user = new User();
        }

        private void SignUp()
        {
            //User user = new User();
            // SignUpPage signupPage = new SignUpPage();
            //signupPage.BindingContext = user;
            Preferences.Set("un",user.Name);
            App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
            //App.Current.MainPage = new NavigationPage(new SignUpPage());
        }

        private void SignIn()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<User>().Where(u => u.Name.Equals(Name) && u.Password.Equals(Password)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
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
                    OnPropertyChanged("Name");
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
                    OnPropertyChanged("Password");
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
