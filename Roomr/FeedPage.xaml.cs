using Roomr.Data;
using System.Text;

namespace Roomr;

public partial class FeedPage : ContentPage
{
	double lat = 0;
	double lon = 0;
	private CancellationTokenSource _cancelTokenSource;
	RoomrDatabase database;
	List<Data.Models.Person> PeopleBucket = new List<Data.Models.Person>();
	Data.Models.Person CurrentPerson;

	public FeedPage()
	{
		InitializeComponent();
		//get from database
		database = new RoomrDatabase();
		FindPeople();
		Cards.Add(new Image { Source = "Resources/Images/roomr.png", Margin = new Thickness (10, 280, 10, 20) });
		Cards.Add(new Label { Text = "Swipe to start swiping", HorizontalTextAlignment = TextAlignment.Center });
	}

	public async void FindPeople()
	{
		PeopleBucket = await database.GetPeopleAsync();
		//List<Data.Models.Match> matches = await database.GetMatchesAsync(Globals.loggedInPerson.Id);

		//Cards.Add(new Label { Text = Globals.loggedInPerson.ToString() });

		foreach (var person in PeopleBucket)
		{
			if (person.Id == Globals.loggedInPerson.Id)
			{
				PeopleBucket.Remove(person);
				break;
			}
			// get the logged in user's country
			// compare to person's country
			// if person's country is different, remove from bucket
			if (Globals.loggedInPerson.Country != person.Country)
			{
				PeopleBucket.Remove(person);
				break;
			}
			// repeat for Region
			if (Globals.loggedInPerson.Region != person.Region)
			{
				PeopleBucket.Remove(person);
				break;
			}
			// repeat for city
			if (Globals.loggedInPerson.City != person.City)
			{
				PeopleBucket.Remove(person);
				break;
			}
			// remove people that have already been matched with logged in
			//foreach (var match in matches) 
			//{
			//	if (person.Id == match.Id2)
			//	{
			//		PeopleBucket.Remove(person);
			//		break;
			//	}
			//}
		}

		//Cards.Add(new Label { Text = PeopleBucket.Count().ToString() });
	}

	public async Task<double> GetDistance()
	{
		double distance = 0;
		test.Text = "Calculating...";
		try
		{
			GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

			_cancelTokenSource = new CancellationTokenSource();

			Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

			if (location != null)
			{
				Globals.loggedInPerson.Latitude = location.Latitude;
				Globals.loggedInPerson.Longitude = location.Longitude;
				await database.SavePersonAsync(Globals.loggedInPerson);

				// yay math is so fun
				double a = Math.Sin(((lat - location.Latitude) * Math.PI / 180) / 2) * Math.Sin(((lat - location.Latitude) * Math.PI / 180) / 2) +
					Math.Cos(location.Latitude * Math.PI / 180) * Math.Cos(lat * Math.PI / 180) *
					Math.Sin((lon - location.Longitude) * Math.PI / 180) * Math.Sin((lon - location.Longitude) * Math.PI / 180);
				double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
				distance = 6371.0 * c;
				return distance;
			}
		}
		catch (Exception ex)
		{

		}
		return distance;
	}

	private async void SwipeMatch_Swiped(object sender, SwipedEventArgs e)
	{
		if (Cards.Children.Count() > 1)
		{
			Cards.Clear();
			if (PeopleBucket.Count() != 0)
			{
				CurrentPerson = PeopleBucket.FirstOrDefault();
				Cards.Add(new ProfileCard(CurrentPerson, 0));
				//Cards.Add(new Label { Text = CurrentPerson.ToString() });
			}
		}
		else
		{
			if (PeopleBucket.Count() != 0)
			{
				// create match with current person
				var match = new Data.Models.Match();
				match.Id1 = Globals.loggedInPerson.Id;
				match.Id2 = CurrentPerson.Id;
				await database.SaveMatchAsync(match);

				// testing with both users matching to each other
				var match2 = new Data.Models.Match();
				match2.Id1 = CurrentPerson.Id;
				match2.Id2 = Globals.loggedInPerson.Id;
				await database.SaveMatchAsync(match2);

				// remove that person from the bucket
				PeopleBucket.Remove(CurrentPerson);
				Cards.Clear();

				if (PeopleBucket.Count() > 0)
				{
					CurrentPerson = PeopleBucket.FirstOrDefault();
					//lat = CurrentPerson.Latitude;
					//lon = CurrentPerson.Longitude;

					// create and and data to profile card
					//double o = await GetDistance();
					Cards.Add(new ProfileCard(CurrentPerson, 0));
					//Cards.Add(new Label { Text = "ugh" });
				}
				else // shhh ignore me being dumb
				{
					// idk have a screen that says that you are a loser or something
					Cards.Clear();
					Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
					var matches = await database.GetMatchesAsync(Globals.loggedInPerson.Id);
					//StringBuilder match = new StringBuilder();
					//foreach (var match2 in matches) { match.Append(match2.ToString()); }
					Cards.Add(new Label { Text = matches.Count().ToString() });
				}
			}
			else
			{
				// idk have a screen that says that you are a loser or something
				Cards.Clear();
				Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
				var matches = await database.GetMatchesAsync(Globals.loggedInPerson.Id);
				//StringBuilder match = new StringBuilder();
				//foreach (var match2 in matches) { match.Append(match2.ToString()); }
				Cards.Add(new Label { Text = matches.Count().ToString() });
			}
		}
		
	}
	private async void SwipeReject_Swiped(object sender, SwipedEventArgs e)
	{
		if (Cards.Children.Count() > 1)
		{
			Cards.Clear();
			if (PeopleBucket.Count() != 0)
			{
				CurrentPerson = PeopleBucket.FirstOrDefault();
				Cards.Add(new ProfileCard(CurrentPerson, 0));
				//Cards.Add(new Label { Text = CurrentPerson.ToString() });
			}
		}
		else 
		{ 
			if (PeopleBucket.Count() != 0)
			{

				PeopleBucket.Remove(CurrentPerson);
				Cards.Clear();

				if (PeopleBucket.Count() > 0)
				{
					CurrentPerson = PeopleBucket.FirstOrDefault();
					//lat = CurrentPerson.Latitude;
					//lon = CurrentPerson.Longitude;

					// create and and data to profile card
					//double o = await GetDistance();
					Cards.Add(new ProfileCard(CurrentPerson, 0));
				}
				else
				{
					// idk have a screen that says that you are a loser or something
					Cards.Clear();
					Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
					var matches = await database.GetMatchesAsync(Globals.loggedInPerson.Id);
					//StringBuilder match = new StringBuilder();
					//foreach (var match2 in matches) { match.Append(match2.ToString()); }
					Cards.Add(new Label { Text = matches.Count().ToString() });
				}
			}
			else 
			{
				// idk have a screen that says that you are a loser or something
				Cards.Clear();
				Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
			}
		}
	}
}