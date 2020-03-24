using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaskManager.Views
{
    public class SignInPage : ContentPage
    {
        private Label headerLabel;
        private Entry emailEntry;
        private Entry passwordEntry;
        private Button signInButton;

        public SignInPage()
        {
            StackLayout stackLayout = new StackLayout();

            headerLabel = new Label();
            headerLabel.Text = "SignIn Page";
            headerLabel.FontAttributes = FontAttributes.Bold;
            headerLabel.Margin = new Thickness(10, 10, 10, 10);
            headerLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
            stackLayout.Children.Add(headerLabel);

            emailEntry = new Entry();
            emailEntry.Keyboard = Keyboard.Email;
            emailEntry.Placeholder = "Email";
            stackLayout.Children.Add(emailEntry);

            passwordEntry = new Entry();
            passwordEntry.Keyboard = Keyboard.Text;
            passwordEntry.Placeholder = "Password";
            passwordEntry.IsPassword = true;
            stackLayout.Children.Add(passwordEntry);

            signInButton = new Button();
            signInButton.Text = "Sign In";
            signInButton.Clicked += SignInButton_Clicked;
            stackLayout.Children.Add(signInButton);

            Content = stackLayout;
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
        }
    }
}