using Roomr.Data;

namespace Roomr;

public partial class Match : ContentView
{
	Data.Models.Person Person;
	public Match()
	{
		InitializeComponent();
	}

	public Match(Data.Models.Person person)
	{

		if(person.ProfilePicture == null)
		{
            person.ProfilePicture = "default.png";
        }
		SetImage(String.Concat("Resources/Images/Profile/", person.ProfilePicture));
		ProfileName.Text = person.Name;
		Person = person;
	}

	public void SetImage(string path)
	{ 
		ProfileImage.Source = path;
	}

	private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		ProfilePage.user = Person;
		await Shell.Current.GoToAsync("//ProfilePage");
	}
}