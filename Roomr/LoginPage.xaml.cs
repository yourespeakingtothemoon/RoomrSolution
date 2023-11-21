using Roomr.Data;

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
        await Navigation.PushAsync(new FeedPage());
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//SignUpPage");
	}
}