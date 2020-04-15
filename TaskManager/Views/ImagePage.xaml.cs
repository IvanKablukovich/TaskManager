using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : PopupPage
    {
        public ImagePage(string Image)
        {
            InitializeComponent();
            byte[] Base64Stream = Convert.FromBase64String(Image);
            xImage.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        }
    }
}