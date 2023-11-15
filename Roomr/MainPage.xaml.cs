using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr
{
    public partial class MainPage : ContentPage
    {
        RoomrDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new RoomrDatabase();
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