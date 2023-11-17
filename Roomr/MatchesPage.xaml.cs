namespace Roomr;

public partial class MatchesPage : ContentPage
{
	Match owo = new Match();
	public MatchesPage()
	{
		InitializeComponent();
		MatchStack.Add(owo);
		MatchStack.Add(new Match());
		MatchStack.Add(new Match());
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		string result = await DisplayActionSheet("Pick a Photo", "Cancel", null, "fish_candy.png", "wheezer.jpg", "joker.jpg", "tyrunt.jpg", "pickel.png");
		result = String.Concat("Resources/Images/Profile/", result);
		owo.SetImage(result);
	}
}