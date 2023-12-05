using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr;

public partial class ProfilePage : ContentPage
{
    public static Data.Models.Person user;

	public ProfilePage()
	{
		InitializeComponent();
       //database = new RoomrDatabase();
        user = Globals.loggedInPerson;
        Console.WriteLine(user.ToString());
        // user = Globals.database.GetPersonAsync(id).Result;
        user = Globals.ProfilePerson;
        HobbyListAsync();
        ChoresListAsync();
        LocationAndDist();
       // QuietHoursAsync();
        //get name and profile picture
        name.Text = user.Name;
        Image.Source = user.ProfilePicture;
    }



    public ProfilePage(int id)
    {
        InitializeComponent();
       // database = new RoomrDatabase();

        user = Globals.database.GetPersonAsync(id).Result;

    
    }

    public async void setUser(int id)
    {
      
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
      //  List<string> list = new List<string>();
        List<Roomr.Data.Models.PersonHobby> hobbos = await Globals.database.GetPersonHobbiesAsync(user.Id);

      
        //string hobby = "";
        Hobby hobbyObj;

        foreach (var item in hobbos)
        {
            hobbyObj = await Globals.database.GetHobbyAsync(item.HobbyId);


            hobbs += hobbyObj.Name + ", ";
        }
        hobbs = hobbs.Substring(0, hobbs.Length - 2);
        hobbies.Text = hobbs;
    }


    public async void ChoresListAsync()
    {
        string chorz = "";
        //to do, get reference to hobbies list
        //	person.Hobbies
        List<Roomr.Data.Models.PersonChore> choresList = await Globals.database.GetPersonChoresAsync(user.Id);

        Chore choreObj;
        foreach (var item in choresList)
        {
            choreObj = await Globals.database.GetChoreAsync(item.ChoreId);

            chorz += choreObj.Name + ", ";
        }
        chorz = chorz.Substring(0, chorz.Length - 2);
       // chores.Text = chorz;
       chores.Text = chorz;
    }
    public void LocationAndDist()
    {
        //to do, get reference to location


string loc="";
        
       loc= user.City + ", " + user.Region + ", " + user.Country;


        location.Text = loc;

    }

    public async void QuietHoursAsync()
    {
        //to do get references to quiet hours
        //string qh = "";
       
        //Or do we wanna round up to the nearest half hour with a float?

        var qh = await Globals.database.GetUserQuietHours(user.Id);

        

        // qh = beginHour + ":" + beginMin + " - " + endHour + ":" + endMin;
        quiet.Text = qh.ToString();

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