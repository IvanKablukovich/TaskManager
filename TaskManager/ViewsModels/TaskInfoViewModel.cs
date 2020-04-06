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
    public class TaskInfoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Comment> Comments { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateCommentCommand { protected set; get; }
        public ICommand DeleteTaskCommand { protected set; get; }
        public Task Task { get; private set; }
        public TaskInfoViewModel(Task selectedTask)
        {
            //var task = (Task)BindingContext;
            Task = selectedTask;
            Comments = new ObservableCollection<Comment>(App.Database.GetComments(selectedTask.TaskId));
            CreateCommentCommand = new Command(CreateComment);
            DeleteTaskCommand = new Command(DeleteTask);
        }

        private void CreateComment()
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateCommentPage(Task));
        }
        private void DeleteTask()
        {
            App.Database.DeleteItem(Task.TaskId);
            //App.Current.MainPage.Navigation.PopAsync();
            App.Current.MainPage = new NavigationPage(new HomePage());
        }

        public string Title
        {
            get { return Task.Title; }
            set
            {
                if (Task.Title != value)
                {
                    Task.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Description
        {
            get { return Task.Description; }
            set
            {
                if (Task.Description != value)
                {
                    Task.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Status
        {
            get { return Task.Status; }
            set
            {
                if (Task.Status != value)
                {
                    Task.Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public string Created_by
        {
            get { return Task.Created_by; }
            set
            {
                if (Task.Created_by != value)
                {
                    Task.Created_by = value;
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
