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
    public class CreateCommentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveCommentCommand { protected set; get; }
        public Comment comment { get; set; }
        public Task task { get; set; }

        public CreateCommentViewModel(Task ask)
        {
            SaveCommentCommand = new Command(SaveComment);
            task = ask;
            comment = new Comment { IdTask = ask.TaskId};
        }
        private void SaveComment()
        {
            //var comment = (Comment)BindingContext;
            // comment.IdTask = ;
            if (!String.IsNullOrEmpty(comment.Field) && !String.IsNullOrEmpty(comment.UserName))
            {
                //comment.IdTask = ask.TaskId;
                App.Database.SaveComment(comment);
                App.Current.MainPage.Navigation.PopAsync();
                //App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ooops!", "Failed", "Ok");
            }
        }
        public string UserName
        {
            get { return comment.UserName; }
            set
            {
                if (comment.UserName != value)
                {
                    comment.UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
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
