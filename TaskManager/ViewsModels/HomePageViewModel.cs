using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
        public User user { get; private set; }
        public HomePageViewModel(User currentUser)
        {
            user = currentUser;
            Tasks = new ObservableCollection<Task>(DBRepository.getInstance.GetTasks());
            CreateTaskCommand = new Command(CreateTask);
        }
        private Task selectedTask { get; set; }
        public Task SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (selectedTask != value)
                {
                    selectedTask = value;
                    OnPropertyChanged("SelectedTask");
                    App.Current.MainPage.Navigation.PushAsync(new TaskInfoPage(selectedTask,user));
                }
            }
        }
        private void CreateTask()
        {
            if (user.Role)
            {
                App.Current.MainPage.Navigation.PushAsync(new CreateTaskPage(user));
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ooops!", "Only for admin", "Ok");
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
