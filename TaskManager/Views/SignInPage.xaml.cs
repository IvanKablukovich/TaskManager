using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);

            InitializeComponent();
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            SignUpPage signupPage = new SignUpPage();
            signupPage.BindingContext = user;
            await Navigation.PushModalAsync(signupPage);
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db");
            var db = new SQLiteConnection(dbpath);


            var myquery = db.Table<User>().Where(u => u.Name.Equals(EntryUserName.Text) && u.Password.Equals(EntryUserPassword.Text)).FirstOrDefault();

            if (myquery!=null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                var result = this.DisplayAlert("Oops", "Failed", "Ok", "Cancel");
                App.Current.MainPage = new NavigationPage(new SignInPage());
            }
                //App.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}