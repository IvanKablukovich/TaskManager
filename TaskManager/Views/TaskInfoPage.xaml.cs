using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskManager.Models;
using TaskManager.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskInfoPage : ContentPage
    {
        public Task Task { get; private set; }
        public TaskInfoPage(Task task)
        {
            InitializeComponent();
            Task = task;
            //this.BindingContext = Task;
            this.BindingContext = new TaskInfoViewModel(Task);
        }
        //protected override void OnAppearing()
        //{
        //    var task = (Task)BindingContext;
        //    //commentsList.ItemsSource = App.Database.GetComments();
        //    commentsList.ItemsSource = App.Database.GetComments(task.TaskId);
        //    base.OnAppearing();
        //}

        //private void DeleteTask(object sender, EventArgs e)
        //{
        //    var task = (Task)BindingContext;
        //    //int x = task.TaskId;
        //    App.Database.DeleteItem(task.TaskId);
        //    this.Navigation.PopAsync();
        //}

        //private async void CreateComment(object sender, EventArgs e)
        //{
        //    Comment comment = new Comment();
        //    CreateCommentPage commentPage = new CreateCommentPage();
        //    commentPage.BindingContext = comment;
        //    await Navigation.PushAsync(commentPage);
        //}
        //private void EditTask(object sender, EventArgs e)
        //{
        //    var task = (Task)BindingContext;
        //    if (!String.IsNullOrEmpty(task.Title))
        //    {
        //        App.Database.SaveTask(task);
        //    }
        //    this.Navigation.PopAsync();
        //}
    }
}