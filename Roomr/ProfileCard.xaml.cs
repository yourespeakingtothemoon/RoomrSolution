namespace Roomr;

public partial class ProfileCard : ContentView
{
	//private Roomr.Data.Models.Person person;


	public ProfileCard()
	{
		InitializeComponent();

		//get person from database

		//set person to person from database

		//set all labels to person's info
		//name.Text = person.Name;
		//location.Text = person.City + ", " + person.Region + ", " + person.Country;
		//photo.Source = person.ProfilePicture;
		//distance.Text = "NOT FOUND";
	}

	public ProfileCard(Roomr.Data.Models.Person person, double dist)
	{
		//set all labels to person's info
		InitializeComponent();
		name.Text = person.Name;
        location.Text = person.City + ", " + person.Region + ", " + person.Country;
        photo.Source = String.Concat("Resources/Images/Profile/", person.ProfilePicture);
		distance.Text = dist.ToString() + "km";
    }
}