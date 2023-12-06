using Roomr.Data;
using System.Collections.Generic;
using System.Text;

namespace Roomr;

public partial class FeedPage : ContentPage
{
	double lat = 0;
	double lon = 0;
	private CancellationTokenSource _cancelTokenSource;
	List<Data.Models.Person> PeopleBucket = new List<Data.Models.Person>();
	Data.Models.Person CurrentPerson;
	ProfileCard currentCard;

	public FeedPage()
	{
		InitializeComponent();
		//get from database
		FindPeople();
		Cards.Add(new Image { Source = "Resources/Images/roomr.png", Margin = new Thickness (10, 280, 10, 20) });
		Cards.Add(new Label { Text = "Swipe to start swiping", HorizontalTextAlignment = TextAlignment.Center });
	}

	public async void FindPeople()
	{
		PeopleBucket = await Globals.database.GetUsersInSameRegion(Globals.loggedInPerson);
		List<Data.Models.Match> matches = await Globals.database.GetMatchesAsync(Globals.loggedInPerson.Id);
		List <Data.Models.Person> peopleCopy = new List<Data.Models.Person>();

		//Cards.Add(new Label { Text = Globals.loggedInPerson.ToString() });
		//Console.WriteLine(matches.Count());
		foreach (var person in PeopleBucket)
		{
			//remove people that have already been matched with logged in
			foreach (var match in matches)
			{
				//Console.WriteLine(match.ToString());
				if (person.Id == match.Id2)
				{
					peopleCopy.Add(person);
					//Console.WriteLine("BAD");
					//Console.WriteLine(PeopleBucket.Count());
				}
			}
		}

		foreach (var person in peopleCopy)
		{ 
			PeopleBucket.Remove(person);
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
				await Globals.database.SavePersonAsync(Globals.loggedInPerson);

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
            //await currentCard.TranslateTo(-100, -100, 1000);
            Cards.Clear();
			if (PeopleBucket.Count() != 0)
			{
				CurrentPerson = PeopleBucket.FirstOrDefault();
				currentCard = new ProfileCard(CurrentPerson, 0);
				Cards.Add(currentCard);
				//Console.WriteLine(CurrentPerson.Id.ToString());
				//Console.WriteLine(Globals.loggedInPerson.Id.ToString());
			}
		}
		else
		{
            //await Cards.TranslateTo(-100, -100, 1000);

            if (PeopleBucket.Count() != 0)
			{
				// create match with current person
				var match = new Data.Models.Match();
				match.Id1 = Globals.loggedInPerson.Id;
				match.Id2 = CurrentPerson.Id;
				await Globals.database.SaveMatchAsync(match);

				// testing with both users matching to each other
				var match2 = new Data.Models.Match();
				match2.Id1 = CurrentPerson.Id;
				match2.Id2 = Globals.loggedInPerson.Id;
				await Globals.database.SaveMatchAsync(match2);

				Console.WriteLine(CurrentPerson.Id.ToString());
				Console.WriteLine(Globals.loggedInPerson.Id.ToString());
				// remove that person from the bucket
				PeopleBucket.Remove(CurrentPerson);
                await currentCard.TranslateTo(-100, -100, 1000);
                Cards.Clear();

				if (PeopleBucket.Count() > 0)
				{
					CurrentPerson = PeopleBucket.FirstOrDefault();
					//lat = CurrentPerson.Latitude;
					//lon = CurrentPerson.Longitude;

					// create and and data to profile card
					//double o = await GetDistance();
					currentCard = new ProfileCard(CurrentPerson, 0);
					Cards.Add(currentCard);
					Console.WriteLine(CurrentPerson);
				}
				else // shhh ignore me being dumb
				{
                    // idk have a screen that says that you are a loser or something
                    await currentCard.TranslateTo(-100, -100, 1000);
                    Cards.Clear();
					Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
					//var matches = await Globals.database.GetMatchesAsync(Globals.loggedInPerson.Id);
					//StringBuilder matchh = new StringBuilder();
					//foreach (var matchh2 in matches) { matchh.Append(matchh2.ToString()); }
					//Cards.Add(new Label { Text = matchh.ToString() });
				}
			}
			else
			{
                // idk have a screen that says that you are a loser or something
                await currentCard.TranslateTo(-100, -100, 1000);
                Cards.Clear();
				Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
			}
		}
		
	}
	private async void SwipeReject_Swiped(object sender, SwipedEventArgs e)
	{
		if (Cards.Children.Count() > 1)
		{

			//await currentCard.TranslateTo(-100, -100, 1000);
			Cards.Clear();
			if (PeopleBucket.Count() != 0)
			{
				CurrentPerson = PeopleBucket.FirstOrDefault();
				currentCard = new ProfileCard(CurrentPerson, 0);
				Cards.Add(currentCard);
				//Cards.Add(new Label { Text = CurrentPerson.ToString() });
			}
		}
		else 
		{ 

			if (PeopleBucket.Count() != 0)
			{
                await currentCard.TranslateTo(-100, -100, 1000);
                PeopleBucket.Remove(CurrentPerson);
				Cards.Clear();

				if (PeopleBucket.Count() > 0)
				{
					CurrentPerson = PeopleBucket.FirstOrDefault();
					//lat = CurrentPerson.Latitude;
					//lon = CurrentPerson.Longitude;

					// create and and data to profile card
					//double o = await GetDistance();
					currentCard = new ProfileCard(CurrentPerson, 0);
					Cards.Add(currentCard);
				}
				else
				{
					// idk have a screen that says that you are a loser or something
					Cards.Clear();
					Cards.Add(new Label { Text = "Out of matches... loser", Margin = new Thickness(0, 300, 0, 0), HorizontalTextAlignment = TextAlignment.Center, FontSize = 28 });
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