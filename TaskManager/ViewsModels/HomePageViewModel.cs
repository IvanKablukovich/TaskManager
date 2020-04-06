using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Views;
using Xamarin.Forms;

namespace TaskManager.ViewsModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateTaskCommand { protected set; get; }

        public HomePageViewModel()
        {
            Tasks = new ObservableCollection<Task>(App.Database.GetTasks());
            CreateTaskCommand = new Command(CreateTask);
            // BackCommand = new Command(Back);
        }

        //TaskInfoViewModel selectedTask;
        //public TaskInfoViewModel SelectedTask
        //{
        //    get { return selectedTask; }
        //    set
        //    {
        //        if (selectedTask != value)
        //        {
        //            TaskInfoViewModel temp = value;
        //            selectedTask = null;
        //            OnPropertyChanged("SelectedTask");
        //            App.Current.MainPage.Navigation.PushAsync(new TaskInfoPage(temp));
        //        }
        //    }
        //}
        private Task selectedTask { get; set; }
        public Task SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (selectedTask != value)
                {
                    selectedTask = value;
                    //TaskInfoPage taskInfoPage = new TaskInfoPage();
                    // taskInfoPage.BindingContext = selectedTask;
                    OnPropertyChanged("SelectedTask");
                    App.Current.MainPage.Navigation.PushAsync(new TaskInfoPage(selectedTask));
                    //App.Current.MainPage = new NavigationPage(new TaskInfoPage(selectedTask));
                    //Navigation.PushAsync(new TaskInfoPage());
                }
            }
        }
        private void CreateTask()
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateTaskPage());
            // Navigation.PushAsync(new CreateTaskPage());
        }
        //private void Back()
        //{
        //    Navigation.PopAsync();
        //}
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
