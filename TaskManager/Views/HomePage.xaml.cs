using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using TaskManager.Models;
using TaskManager.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomePageViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    usersList.ItemsSource = App.Database.GetTasks();
        //    base.OnAppearing();
        //}

        //private async void CreateTask(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new CreateTaskPage());
        //}

        //private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Task selectedTask = (Task)e.SelectedItem;
        //    TaskInfoPage taskInfoPage = new TaskInfoPage();
        //    taskInfoPage.BindingContext = selectedTask;
        //    await Navigation.PushAsync(taskInfoPage);
        //}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignInPage());
        }
    }
}