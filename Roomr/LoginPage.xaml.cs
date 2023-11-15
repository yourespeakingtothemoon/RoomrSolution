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

	private void OnSubmitClicked(object sender, EventArgs e)
	{
        //TODO: add login form, call login request to check user/pass, set user as logged in:

        //Person loggedInPerson = await database.LoginPerson(username, password);
    }

    private void OnSignUpClicked(object sender, EventArgs e)
	{
        //Move to Sign Up Page
    }
}