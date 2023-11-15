using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr
{
    public partial class MainPage : ContentPage
    {
        PersonDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new PersonDatabase();
        }


        private async void OnLoginClicked(object sender, EventArgs e)
        {
            //Move to Login Page
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            //Move to Sign Up Page
        }

    }
}