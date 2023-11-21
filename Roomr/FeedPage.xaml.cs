using Roomr.Data;

namespace Roomr;

public partial class FeedPage : ContentPage
{
	double lat = 0;
	double lon = 0;
	private CancellationTokenSource _cancelTokenSource;
	RoomrDatabase database;
	List<Data.Models.Person> PeopleBucket;
	Data.Models.Person CurrentPerson;

	public FeedPage()
	{
		InitializeComponent();
		//get from database
		database = new RoomrDatabase();
		FindPeople();
	}

	public async void FindPeople()
	{
		PeopleBucket = await database.GetPeopleAsync();
		List<Data.Models.Match> matches = await database.GetMatchesAsync(Globals.loggedInPerson.Id);

		foreach (var person in PeopleBucket)
		{
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
			foreach (var match in matches) 
			{
				if (person.Id == match.Id2)
				{
					PeopleBucket.Remove(person);
					break;
				}
			}
		}
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
		if (PeopleBucket.Count() != 0)
		{
			CurrentPerson = PeopleBucket.FirstOrDefault();
			lat = CurrentPerson.Latitude;
			lon = CurrentPerson.Longitude;

			// create and and data to profile card
			double o = await GetDistance();

			var match = new Data.Models.Match();
			match.Id1 = Globals.loggedInPerson.Id;
			match.Id2 = CurrentPerson.Id;
			await database.SaveMatchAsync(match);

			PeopleBucket.Remove(CurrentPerson);
		}
		else 
		{ 
			// idk have a screen that says that you are a loser or something
		}
		
	}
	private async void SwipeReject_Swiped(object sender, SwipedEventArgs e)
	{
		if (PeopleBucket.Count() != 0)
		{
			CurrentPerson = PeopleBucket.FirstOrDefault();
			lat = CurrentPerson.Latitude;
			lon = CurrentPerson.Longitude;

			// create and and data to profile card
			double o = await GetDistance();


			PeopleBucket.Remove(CurrentPerson);
		}
		else 
		{
			// idk have a screen that says that you are a loser or something
		}
	}
}