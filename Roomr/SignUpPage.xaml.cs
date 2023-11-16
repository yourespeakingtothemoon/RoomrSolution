namespace Roomr;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

	public async void OnSignUpClicked(object sender, EventArgs e)
	{
        //TODO: Add sign up form, create Person object with validated data, save it:

        //Person person = new Person("David", "sampleUsername", "samplePass", "Phone number: 867-5309", "Salt Lake City", "Utah", "United States of America", "");
        //await database.SavePersonAsync(person);
    }
	private async void OnLoginClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}