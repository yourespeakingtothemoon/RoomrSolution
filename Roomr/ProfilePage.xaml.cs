using Roomr.Data;
using Roomr.Data.Models;
using System.Timers;

namespace Roomr;

public partial class ProfilePage : ContentPage
{
	public static System.Timers.Timer aTimer;
	public ProfilePage()
	{
		InitializeComponent();
       //database = new RoomrDatabase();
        // Globals.ProfilePerson = Globals.database.GetPersonAsync(id).Result;
        HobbyListAsync();
        ChoresListAsync();
        LocationAndDist();
       // QuietHoursAsync();
        //get name and profile picture
        name.Text = Globals.ProfilePerson.Name;
        Image.Source = Globals.ProfilePerson.ProfilePicture;
        contact.Text = Globals.ProfilePerson.ContactInfo;
        Globals.ProfilePerson = Globals.loggedInPerson;

		//aTimer = new System.Timers.Timer(5000);
		//aTimer.Elapsed += new ElapsedEventHandler(RunThis);
		//aTimer.AutoReset = true;
		//aTimer.Enabled = true;
	}



    public ProfilePage(int id)
    {
        InitializeComponent();
       // database = new RoomrDatabase();

        Globals.ProfilePerson = Globals.database.GetPersonAsync(id).Result;

    
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
        List<Roomr.Data.Models.PersonHobby> hobbos = await Globals.database.GetPersonHobbiesAsync(Globals.ProfilePerson.Id);

        if (hobbos.Count > 0) 
        { 
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
    }


    public async void ChoresListAsync()
    {
        string chorz = "";
        //to do, get reference to hobbies list
        //	person.Hobbies
        List<Roomr.Data.Models.PersonChore> choresList = await Globals.database.GetPersonChoresAsync(Globals.ProfilePerson.Id);

        if (choresList.Count > 0) 
        { 
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
    }
    public void LocationAndDist()
    {
        //to do, get reference to location


string loc="";
        
       loc= Globals.ProfilePerson.City + ", " + Globals.ProfilePerson.Region + ", " + Globals.ProfilePerson.Country;


        location.Text = loc;

    }

    public async void QuietHoursAsync()
    {
        //to do get references to quiet hours
        //string qh = "";
       
        //Or do we wanna round up to the nearest half hour with a float?

        var qh = await Globals.database.GetUserQuietHours(Globals.ProfilePerson.Id);

        

        // qh = beginHour + ":" + beginMin + " - " + endHour + ":" + endMin;
        quiet.Text = qh.ToString();

    }

	private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
	{
        Globals.ProfilePerson = Globals.ProfilePerson;
        HobbyListAsync();
        ChoresListAsync();
        LocationAndDist();
        // QuietHoursAsync();
        //get name and profile picture
        name.Text = Globals.ProfilePerson.Name;
        Image.Source = Globals.ProfilePerson.ProfilePicture;
        Globals.ProfilePerson = Globals.loggedInPerson;
    }

	private async void RunThis(object source, ElapsedEventArgs e)
	{
		Globals.ProfilePerson = Globals.ProfilePerson;
		HobbyListAsync();
		ChoresListAsync();
		LocationAndDist();
		// QuietHoursAsync();
		//get name and profile picture
		name.Text = Globals.ProfilePerson.Name;
		Image.Source = Globals.ProfilePerson.ProfilePicture;
		Globals.ProfilePerson = Globals.loggedInPerson;
		Console.WriteLine("Print this in every 10 seconds");
	}
}