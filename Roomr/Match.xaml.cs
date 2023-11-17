namespace Roomr;

public partial class Match : ContentView
{
	public Match()
	{
		InitializeComponent();
	}

	public void SetImage(string path)
	{ 
		ProfileImage.Source = path;
	}
}