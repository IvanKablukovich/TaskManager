using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public User User { get; private set; }
        public TaskInfoPage(Task task, User user)
        {
            InitializeComponent();
            Task = task;
            User = user;
            if (Task.Image!=null)
            {
                xfImage.IsVisible = true;
                byte[] Base64Stream = Convert.FromBase64String(Task.Image);
                xfImage.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            }
            if (!String.IsNullOrEmpty(Task.File))

            {

                fileB.IsVisible = true;

            }
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new TaskInfoViewModel(Task, User);
            base.OnAppearing();
        }
    }
}