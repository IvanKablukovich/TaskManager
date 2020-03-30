using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskManager.Tables;
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
        }

        protected override void OnAppearing()
        {
            usersList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void CreateTask(object sender, EventArgs e)
        {
            Task task = new Task();
            CreateTaskPage createPage = new CreateTaskPage();
            createPage.BindingContext = task;
            await Navigation.PushAsync(createPage);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Task selectedTask = (Task)e.SelectedItem;
            TaskInfoPage taskInfoPage = new TaskInfoPage();
            taskInfoPage.BindingContext = selectedTask;
            await Navigation.PushAsync(taskInfoPage);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignInPage());
        }
    }
}