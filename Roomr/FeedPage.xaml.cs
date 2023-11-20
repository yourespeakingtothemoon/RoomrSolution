using static System.Net.Mime.MediaTypeNames;
using Roomr.Data;

namespace Roomr;

public partial class FeedPage : ContentPage
{
	double lat = 0;
	double lon = 0;
	private CancellationTokenSource _cancelTokenSource;
	RoomrDatabase database;
	List<Data.Models.Person> PeopleBucket;

	public FeedPage()
	{
		InitializeComponent();
		//get from database
		database = new RoomrDatabase();
	}

	public async void FindPeople()
	{
		PeopleBucket = await database.GetPeopleAsync();

		foreach (var person in PeopleBucket)
		{
			// get the logged in user's state
			// compare to person's country
			// if person's country is different, remove from bucket
			// repeate for state
			// repeate for city
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
		double o = await GetDistance();
		test.Text = o.ToString();
	}
	private async void SwipeReject_Swiped(object sender, SwipedEventArgs e)
	{
		double o = await GetDistance();
		test.Text = o.ToString();
	}
}