using Roomr.Data;

namespace Roomr;

public partial class Match : ContentView
{
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
		GestureRecognizers.Add(new TapGestureRecognizer 
		{ 
			//Command = new Command()
		});
	}

	public void SetImage(string path)
	{ 
		ProfileImage.Source = path;
	}
}