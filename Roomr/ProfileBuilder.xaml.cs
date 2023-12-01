namespace Roomr;

public partial class ProfileBuilder : ContentPage
{
	public ProfileBuilder()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayActionSheet("Pick a Photo", "Cancel", null, "fish_candy.png", "wheezer.jpg", "joker.jpg", "tyrunt.jpg", "pickel.png");
        result = String.Concat("Resources/Images/Profile/", result);
        PictureChanger.Source = result;
       // VisualStateManager.GoToState(PictureChanger, "Pressed");
    }

    private void PictureChanger_Released(object sender, EventArgs e)
    {
        PictureChanger.Animate("Pressed", new Animation((d) =>
        {
            PictureChanger.Scale = d;
        }, 0.9, 1, Easing.SpringOut));
    }

    private void PictureChanger_Focused(object sender, FocusEventArgs e)
    {
        VisualStateManager.GoToState(PictureChanger, "Pressed");

    }

    private void PictureChanger_Pressed(object sender, EventArgs e)
    {
        PictureChanger.Animate("Pressed", new Animation((d) =>
        {
            PictureChanger.Scale = d;
        }, 1, 0.9, Easing.SpringOut));

    }

    private void PictureChanger_Unfocused(object sender, FocusEventArgs e)
    {
        VisualStateManager.GoToState(PictureChanger, "Normal");

    }

    private void saveButton_Clicked(object sender, EventArgs e)
    {

    }
}