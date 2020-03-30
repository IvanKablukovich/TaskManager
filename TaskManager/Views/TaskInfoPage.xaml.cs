using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskInfoPage : ContentPage
    {
        public TaskInfoPage()
        {
            InitializeComponent();
        }

        private void DeleteTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            App.Database.DeleteItem(task.TaskId);
            this.Navigation.PopAsync();
        }
        private void EditTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (!String.IsNullOrEmpty(task.Title))
            {
                App.Database.SaveTask(task);
            }
            this.Navigation.PopAsync();
        }
    }
}