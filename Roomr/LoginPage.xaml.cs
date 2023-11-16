namespace Roomr;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnSignUpClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SignUpPage());
	}
}