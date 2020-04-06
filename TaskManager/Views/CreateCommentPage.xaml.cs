using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models;
using TaskManager.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateCommentPage : ContentPage
    {
        public Task Task { get; private set; }
        public CreateCommentPage(Task task)
        {
            InitializeComponent();
            Task = task;
            this.BindingContext = new CreateCommentViewModel(task);      
        }
        //private async void saveComment(object sender, EventArgs e)
        //{

        //    var comment = (Comment)BindingContext;
        //   // comment.IdTask = ;
        //    if (!String.IsNullOrEmpty(comment.Field) && !String.IsNullOrEmpty(comment.UserName))
        //    {
        //        App.Database.SaveComment(comment);
        //        await this.Navigation.PopAsync();
        //    }
        //}
        //private async void backButton(object sender, EventArgs e)
        //{
        //        await this.Navigation.PopAsync();
        //}
    }
}