using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr;

public partial class LoginPage : ContentPage
{
    RoomrDatabase database;
    public LoginPage()
	{
		InitializeComponent();
		database = new RoomrDatabase();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        //TODO: Grab the data from the database base and login using that information
        if (database.GetPersonLogin(UsernameField.Text, PasswordField.Text).Result != null)
        {
            Console.WriteLine("Valid Login. Logging In.");
            await Shell.Current.GoToAsync("//FeedPage");
        }
        else
        {
            Console.WriteLine("Invalid Login.");
        }
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//SignUpPage");
	}
}