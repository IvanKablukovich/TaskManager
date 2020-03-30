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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            if (!String.IsNullOrEmpty(user.Name))
            {
                App.Database.SaveItem(user);
            }
            //this.Navigation.PopAsync();
            App.Current.MainPage = new NavigationPage(new SignInPage());
        }
    }
}