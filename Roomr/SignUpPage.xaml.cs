namespace Roomr;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

	private void OnSignUpClicked(object sender, EventArgs e)
	{
		Console.WriteLine("Username: " + UsernameField.Text);
		Console.WriteLine("Password: " + PasswordFieldOne.Text);
		Console.WriteLine("Password Check: " + PasswordFieldTwo.Text);

	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}