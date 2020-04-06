using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using TaskManager.ViewsModels;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            this.BindingContext = new SignUpViewModel();
        }
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    var email = EntryEmail.Text;
        //    var emailCheck = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";


        //    var user = (User)BindingContext;
        //    if (!String.IsNullOrWhiteSpace(user.Name) && Regex.IsMatch(email, emailCheck))
        //    {
        //        App.Database.SaveItem(user);
        //        App.Current.MainPage = new NavigationPage(new SignInPage());
        //    }
        //    else
        //    {
        //        var result = this.DisplayAlert("Oops", "Failed", "Ok", "Cancel");
        //    }
        //}
    }
}