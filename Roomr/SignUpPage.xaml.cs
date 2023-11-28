using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr;

public partial class SignUpPage : ContentPage
{
	RoomrDatabase database;

	public SignUpPage()
	{
		InitializeComponent();
		database = new RoomrDatabase();
	}
	private async void OnSignUpClicked(object sender, EventArgs e)
	{
		#region Console.Writeline() To See UserData
		Console.WriteLine("Username: " + UsernameField.Text);
		Console.WriteLine("Password: " + PasswordFieldOne.Text);
		Console.WriteLine("Password Check: " + PasswordFieldTwo.Text);
        #endregion

        #region Sending Data To Database
        if (await database.CheckIfUsernameExists(UsernameField.Text)) // If Username Does Exist In Database
		{
			Console.WriteLine("Username is NOT available."); // Inform Dev That Username Is Not Available. Add Validation To Textbox To Inform User.
		}
		else // If Username Does Not Exist In Database
		{
			Console.WriteLine("Username available."); // Inform Dev That Username Is Available. Add Validation To Textbox To Inform User.

			if (PasswordFieldOne.Text == PasswordFieldTwo.Text) // If Passwords Match
			{
				Console.WriteLine("Passwords Match. Profile Can Be Made."); // Inform Dev That Passwords Match & Profile Can Be Made
				Person newPerson = new Data.Models.Person(UsernameField.Text, "", "Salt Lake City", "Utah", "United States", "fish_candy.png");
				Globals.loggedInPerson = newPerson;
				await database.SavePersonAsync(newPerson); // Make Person Object & Save To Database
				await Shell.Current.GoToAsync("//FeedPage"); // Send to Feed Page
			}
			else
			{ 

			}
		}
        #endregion

    }

    private async void OnLoginClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//LoginPage");
    }

	    private async void HomeBtnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}