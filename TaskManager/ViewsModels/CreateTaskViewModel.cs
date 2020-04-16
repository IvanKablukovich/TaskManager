using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        public ICommand SelectImageCommand { protected set; get; }
        public ICommand SelectFileCommand { protected set; get; }
        public Task task { get; set; }
        public User user { get; set; }

        public CreateTaskViewModel(User currentUser)
        {
            user = currentUser;
            SelectImageCommand = new Command(SelectImage);
            SelectFileCommand = new Command(SelectFile);
            BackCommand = new Command(Back);
            SaveTaskCommand = new Command(SaveTask);
            task = new Task();
        }

        private async void SelectImage()
        {
            string[] allowedTypes = { "image/*" };
            var im = await CrossFilePicker.Current.PickFile(allowedTypes);

            if (im != null)
            {
                byte[] b = File.ReadAllBytes(im.FilePath);
                String s = Convert.ToBase64String(b);
                task.Image = s;
                task.ImageName = im.FileName;
            }
        }
        private async void SelectFile()
        {
            string[] allowedTypes = { "application/pdf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
            var file = await CrossFilePicker.Current.PickFile(allowedTypes);

            if (file != null)
            {
                //byte[] b = File.ReadAllBytes(file.FilePath);
                //String s = Convert.ToBase64String(b);
                task.File = file.FilePath;
                task.FileName = file.FileName;
            }
        }
        private void Back()
        {
           App.Current.MainPage = new NavigationPage(new HomePage(user));
        }
        private void SaveTask()
        {
            if (!String.IsNullOrEmpty(task.Title) && !String.IsNullOrEmpty(task.Description) && !String.IsNullOrEmpty(task.Status))
            {
                task.Created_by = user.Name;
                DBRepository.getInstance.SaveTask(task);
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

        public string FileName
        {
            get { return task.FileName; }
            set
            {
                if (task.FileName != value)
                {
                    task.FileName = value;
                    OnPropertyChanged("FileName");
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
