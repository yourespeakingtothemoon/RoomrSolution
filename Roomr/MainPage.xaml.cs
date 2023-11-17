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
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());

        }

    }

}
