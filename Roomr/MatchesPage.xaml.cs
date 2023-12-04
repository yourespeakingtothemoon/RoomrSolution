using Roomr.Data;
namespace Roomr;

public partial class MatchesPage : ContentPage
{
	List<Data.Models.Match> matches;
	List<Data.Models.Person> people;

	public MatchesPage()
	{
		InitializeComponent();
		AddMatches();
	}

	private async Task<bool> AddMatches()
	{
		// find all matches
		matches = await Globals.database.GetMatchesAsync(Globals.loggedInPerson.Id);

		foreach (var match in matches) 
		{
			Console.WriteLine(match.Id2);
			var person = await Globals.database.GetPersonAsync(match.Id2);
			Console.WriteLine(person.ToString());
			MatchStack.Add(new Match(person));
		}

		return true;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		string result = await DisplayActionSheet("Pick a Photo", "Cancel", null, "fish_candy.png", "wheezer.jpg", "joker.jpg", "tyrunt.jpg", "pickel.png");
		result = String.Concat("Resources/Images/Profile/", result);
		//owo.SetImage(result);
	}

	private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
	{
		MatchStack.Clear();
		await AddMatches();
		Console.WriteLine("owo");
	}
}