namespace Roomr;

public partial class MatchesPage : ContentPage
{
	public MatchesPage()
	{
		InitializeComponent();
		MatchStack.Add(new Match());
		MatchStack.Add(new Match());
		MatchStack.Add(new Match());
	}
}