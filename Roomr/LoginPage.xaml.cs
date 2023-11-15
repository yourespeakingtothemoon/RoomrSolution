using Roomr.Data;

namespace Roomr;

public partial class LoginPage : ContentPage
{
    PersonDatabase database;
    public LoginPage()
	{
		InitializeComponent();
		database = new PersonDatabase();
	}

	private void OnSubmitClicked(object sender, EventArgs e)
	{
        //TODO: add login form, call login request to check user/pass, set user as logged in:

        //Person loggedInPerson = await database.LoginPerson(username, password);
    }

    private void OnSignUpClicked(object sender, EventArgs e)
	{
        //Move to Sign Up Page

        //In Sign Up Page:
        //TODO: Add sign up form, create Person object with validated data, save it:

        //Person person = new Person("David", "sampleUsername", "samplePass", "Phone number: 867-5309", "Salt Lake City", "Utah", "United States of America", "");
        //await database.SavePersonAsync(person);
    }
}