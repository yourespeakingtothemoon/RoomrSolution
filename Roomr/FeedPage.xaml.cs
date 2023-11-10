namespace Roomr;

public partial class FeedPage : ContentPage
{
	public FeedPage()
	{
		InitializeComponent();
	}

	private void SwipeMatch_Swiped(object sender, SwipedEventArgs e)
	{
		test.Text = "Match";
    }
	private void SwipeReject_Swiped(object sender, SwipedEventArgs e)
	{
		test.Text = "Reject";
	}
}