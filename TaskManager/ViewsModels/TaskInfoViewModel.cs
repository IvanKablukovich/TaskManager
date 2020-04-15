using DocumentFormat.OpenXml.Packaging;
using Rg.Plugins.Popup.Services;
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
using Xamarin.Essentials;
using Xamarin.Forms;


namespace TaskManager.ViewsModels
{
    public class TaskInfoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Comment> Comments { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateCommentCommand { protected set; get; }
        public ICommand DeleteTaskCommand { protected set; get; }
        public ICommand EditTaskCommand { protected set; get; }
        public ICommand TapImageCommand { protected set; get; }
        //public ICommand TapFileCommand { protected set; get; }
        public Comment comment { get; set; }
        public Task Task { get; private set; }
        public User User { get; private set; }
        public TaskInfoViewModel(Task selectedTask, User currentUser)
        {
            User = currentUser;
            Task = selectedTask;
            Comments = new ObservableCollection<Comment>(DBRepository.getInstance.GetComments(selectedTask.TaskId));
            TapImageCommand = new Command(TapImage);
            //TapFileCommand = new Command(TapFile);
            EditTaskCommand = new Command(EditTask);
            CreateCommentCommand = new Command(CreateComment);
            DeleteTaskCommand = new Command(DeleteTask);
            comment = new Comment { IdTask = selectedTask.TaskId};

        }

        //private async void TapFile()
        //{
            
        //    //var file = new MemoryStream(Task.File);
        //    //using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(file, true))
        //    //{
        //    //}


        //    //xfImage.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //    //byte[] newBytes = Convert.FromBase64String(Task.File);
        //    //var fn = BitConverter.ToString(newBytes); ;
        //    //var file = Path.Combine(FileSystem.CacheDirectory, fn);
        //    //await Launcher.OpenAsync(new OpenFileRequest
        //    //{
        //    //    File = new ReadOnlyFile(file)
        //    //});
        //    await Launcher.TryOpenAsync(Task.File);
        //}
        private async void TapImage()
        {
            await PopupNavigation.Instance.PushAsync(new ImagePage(Task.Image));
        }
        private void EditTask()
        {
            DBRepository.getInstance.SaveTask(Task);
            App.Current.MainPage.DisplayAlert("Success", "Status changed!", "Ok");
        }
        private async void CreateComment()
        {
            if (!String.IsNullOrEmpty(comment.Field))
            {
                comment.UserName = User.Name;
                DBRepository.getInstance.SaveComment(comment);
                Comments.Add(comment);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Ooops!", "Failed", "Ok");
            }
        }
        private void DeleteTask()
        {
            if (User.Role)
            {
                DBRepository.getInstance.DeleteItem(Task.TaskId);
                App.Current.MainPage = new NavigationPage(new HomePage(User));
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ooops!", "Only for admin", "Ok");
            }
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
        public string Image
        {
            get { return Task.Image; }
            set
            {
                if (Task.Image != value)
                {
                    Task.Image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        //public string FileName
        //{
        //    get { return Task.FileName; }
        //    set
        //    {
        //        if (Task.FileName != value)
        //        {
        //            Task.FileName = value;
        //            OnPropertyChanged("FileName");
        //        }
        //    }
        //}
        public string Field
        {
            get { return comment.Field; }
            set
            {
                if (comment.Field != value)
                {
                    comment.Field = value;
                    OnPropertyChanged("Field");
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
