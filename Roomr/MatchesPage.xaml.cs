using Roomr.Data;
namespace Roomr;

public partial class MatchesPage : ContentPage
{
	RoomrDatabase database;
	List<Data.Models.Match> matches;
	List<Data.Models.Person> people;

	public MatchesPage()
	{
		InitializeComponent();
		database = new RoomrDatabase();
		AddMatches();
	}

	private async void AddMatches()
	{
		// find all matches
		matches = await database.GetMatchesAsync(Globals.loggedInPerson.Id);

		MatchStack.Add(new Label { Text = matches.Count.ToString() });

		foreach (var match in matches) 
		{
			MatchStack.Add(new Match(await database.GetPersonAsync(match.Id2)));
		}
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		string result = await DisplayActionSheet("Pick a Photo", "Cancel", null, "fish_candy.png", "wheezer.jpg", "joker.jpg", "tyrunt.jpg", "pickel.png");
		result = String.Concat("Resources/Images/Profile/", result);
		//owo.SetImage(result);
	}
}