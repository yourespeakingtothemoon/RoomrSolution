using Roomr.Data;

namespace Roomr;

public partial class ProfilePage : ContentPage
{
    public static Data.Models.Person user;
    private RoomrDatabase database;

	public ProfilePage()
	{
		InitializeComponent();
        database = new RoomrDatabase();

        //get person from database
	}

    public ProfilePage(int id)
    {
        InitializeComponent();
        database = new RoomrDatabase();

        //get person from database
        //person = database.GetPersonAsync(id).Result;   
    }

    //public ProfilePage()
    //{
    //    database = db;
    //    InitializeComponent();
    //}

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
	
    }
	//private Roomr.Data.Models.Person person;

	private async void HobbyListAsync()
	{
		string hobbs = "";
		//to do, get reference to hobbies list
//	person.Hobbies
List<string> list = new List<string>();
        List<Roomr.Data.Models.PersonHobby> hobbos = database.GetPersonHobbyAsync(user.Id).Result;
            
        

       foreach (var item in hobbos)
        {
            list.Add(item.ToString());
        }


		foreach (var item in list)
		{
			hobbs+= item + ", ";
        }
		hobbs = hobbs.Substring(0, hobbs.Length - 2);
		hobbies.Text = hobbs;
	}
    private void ChoresList()
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
    private void LocationAndDist()
    {
        //to do, get reference to location

     
        string loc = "";
        
       loc= user.City + ", " + user.Region + ", " + user.Country;

        location.Text = loc;
       
    }

    private void QuietHours()
    {
        //to do get references to quiet hours
        string qh = "";
        int beginHour = 0;
        int endHour = 0;
        int beginMin = 0;
        int endMin = 0;
        //Or do we wanna round up to the nearest half hour with a float?

        qh = database.GetUserQuietHours(user.Id).Result.ToString();



       // qh = beginHour + ":" + beginMin + " - " + endHour + ":" + endMin;
        quiet.Text = qh; 
        
    }
}