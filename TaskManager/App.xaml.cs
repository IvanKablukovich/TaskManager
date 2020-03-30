using System;
using System.IO;
using System.Reflection;
using TaskManager.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskManager.Tables;

namespace TaskManager
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "User.db";
        public static DBRepository database;
        public static DBRepository Database
        {
               get
               {
                    if (database == null)
                    {
                        database = new DBRepository(
                            Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                    }
                    return database;
                }
        }
 
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
