using Roomr.Data;

namespace Roomr;

public partial class ProfilePage : ContentPage
{
    public static Data.Models.Person user;

	public ProfilePage()
	{
		InitializeComponent();
        user = Globals.loggedInPerson;
        Console.WriteLine(user.ToString());
        //get person from database
    }

    public ProfilePage(int id)
    {
        InitializeComponent();
        //person = database.GetPersonAsync(id).Result;   
    }

    public static void setUser(Data.Models.Person person)
    {
        user = person;
    }

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {

    }

	//private Roomr.Data.Models.Person person;

	public async void HobbyListAsync()
	{
		string hobbs = "";
		//to do, get reference to hobbies list
//	person.Hobbies
List<string> list = new List<string>();
        List<Roomr.Data.Models.PersonHobby> hobbos = Globals.database.GetPersonHobbiesAsync(user.Id).Result;

        foreach (var item in hobbos)
        {
            list.Add(item.ToString());
        }


        foreach (var item in list)
        {
            hobbs += item + ", ";
        }
        hobbs = hobbs.Substring(0, hobbs.Length - 2);
        hobbies.Text = hobbs;
    }
    public void ChoresList()
    {
        string chorz = "";
        //to do, get reference to hobbies list
        //	person.Hobbies
        List<string> list = new List<string>();
        foreach (var item in list)
        {
            chorz += item + ", ";
        }
        chorz = chorz.Substring(0, chorz.Length - 2);
        chores.Text = chorz;
    }
    public void LocationAndDist()
    {
        //to do, get reference to location


string loc="";
        
       loc= user.City + ", " + user.Region + ", " + user.Country;


        location.Text = loc;

    }

    public void QuietHours()
    {
        //to do get references to quiet hours
        string qh = "";
        int beginHour = 0;
        int endHour = 0;
        int beginMin = 0;
        int endMin = 0;
        //Or do we wanna round up to the nearest half hour with a float?

        qh = Globals.database.GetUserQuietHours(user.Id).Result.ToString();

        // qh = beginHour + ":" + beginMin + " - " + endHour + ":" + endMin;
        quiet.Text = qh;

    }

	private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
	{
        //HobbyListAsync();
		//ChoresList();
		//LocationAndDist();
		//QuietHours();
        Image.Source = String.Concat("Resources/Images/Profile/", user.ProfilePicture);
        name.Text = user.Name;
        Console.WriteLine("owo");
	}
}