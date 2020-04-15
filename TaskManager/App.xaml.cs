using System;
using System.IO;
using System.Reflection;
using TaskManager.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskManager.Models;

namespace TaskManager
{
    public partial class App : Application
    {
        //public static DBRepository db;
        //public static DBRepository Database
        //{
        //       get
        //       {
        //            if (db == null)
        //            {
        //            db = new DBRepository(
        //                    Path.Combine(
        //                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db"));
        //            }
        //            return db;
        //        }
        //}

 
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignInPage());

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
