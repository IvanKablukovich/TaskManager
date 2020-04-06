using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Views;
using Xamarin.Forms;

namespace TaskManager.ViewsModels
{
    class CreateTaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveTaskCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public Task task { get; set; }

        public CreateTaskViewModel()
        {
            BackCommand = new Command(Back);
            SaveTaskCommand = new Command(SaveTask);
            task = new Task();
        }
        private void Back()
        {
           App.Current.MainPage = new NavigationPage(new HomePage());
        }
        private void SaveTask()
        {
           // var task = (Task)BindingContext;
            if (!String.IsNullOrEmpty(task.Title))
            {
                App.Database.SaveTask(task);
                //App.Current.MainPage = new NavigationPage(new HomePage());
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ooops!", "Failed", "Ok");
            }
        }
        public string Title
        {
            get { return task.Title; }
            set
            {
                if (task.Title != value)
                {
                    task.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Description
        {
            get { return task.Description; }
            set
            {
                if (task.Description != value)
                {
                    task.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Status
        {
            get { return task.Status; }
            set
            {
                if (task.Status != value)
                {
                    task.Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public string Created_by
        {
            get { return task.Created_by; }
            set
            {
                if (task.Created_by != value)
                {
                    task.Created_by = value;
                    OnPropertyChanged("Created_by");
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
