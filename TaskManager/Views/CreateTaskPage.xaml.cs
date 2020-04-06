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
    public partial class CreateTaskPage : ContentPage
    {
        public CreateTaskPage()
        {
            InitializeComponent();
            //this.BindingContext = new Task();
            this.BindingContext = new CreateTaskViewModel();
        }
        //private void SaveTask(object sender, EventArgs e)
        //{
        //    var task = (Task)BindingContext;
        //    if (!String.IsNullOrEmpty(task.Title))
        //    {
        //        App.Database.SaveTask(task);
        //    }
        //    this.Navigation.PopAsync();
        //}
        //private void Cancel(object sender, EventArgs e)
        //{
        //    this.Navigation.PopAsync();
        //}
    }
}