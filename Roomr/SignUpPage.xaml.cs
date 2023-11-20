using Roomr.Data;

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
				await database.SavePersonAsync(new Data.Models.Person(UsernameField.Text, PasswordFieldOne.Text)); // Make Person Object & Save To Database
				
			}
			else
			{
				Console.WriteLine("Passwords DO NOT Match."); // Inform Dev That Passwords Do Not Match. Add Validation To Textbox To Inform User.
			}
		}
        #endregion

    }

    private async void OnLoginClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}