using Android.App;
using Roomr.Data.Models;

namespace Roomr;

public partial class ProfilePage : ContentPage
{



	public ProfilePage()
	{
		InitializeComponent();
	}

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
	
    }

	private Roomr.Data.Models.Person person;

	private void HobbyList()
	{
		string hobbs = "";
		//to do, get reference to hobbies list
//	person.Hobbies
List<string> list = new List<string>();
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

        //to do reference ethan's distance getter
        string loc = "";
        float dist = 0.0f;
        distance.Text = dist + " UNITS";
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

        qh = beginHour + ":" + beginMin + " - " + endHour + ":" + endMin;
        QuietHours.Text = qh; 
        
    }
}