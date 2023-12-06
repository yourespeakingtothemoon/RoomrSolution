using Roomr.Data.Models;
using Roomr.Data;
using System.Collections.ObjectModel;
namespace Roomr;

struct HobbyCheck
{
    

  public CheckBox checkBox;
    public String hobby;

    public HobbyCheck(CheckBox checkBox, String hobb)
    {
        this.checkBox = checkBox;
        this.hobby = hobb;
    }
}

struct ChoreCheck
{
   
   public CheckBox checkBox;
   public String chore;

    public ChoreCheck(CheckBox checkBox, String chor)
    {
        this.checkBox = checkBox;
        this.chore = chor;
    }
}


public partial class ProfileBuilder : ContentPage
{
    List<CheckBox> checkBoxes = new List<CheckBox>();
    List<HobbyCheck> checkBoxesHobbies = new List<HobbyCheck>();
    List<ChoreCheck> checkBoxesChores = new List<ChoreCheck>();
    bool isEditing = false;
    RoomrDatabase database = new RoomrDatabase();
    //ObservableCollection<Hobby> Hobbies;
    //ObservableCollection<Chore> Chores;
    Roomr.Data.Models.Person loggedIn = Globals.loggedInPerson;
    public ProfileBuilder()
    {
        InitializeComponent();
       // var loggedIn = Globals.loggedInPerson;
        if (loggedIn.Name != null)
        {
            isEditing = true;
            PictureChanger.Source = loggedIn.ProfilePicture;
            nameEntry.Text = loggedIn.Name;
            //hobbies and chores here
        }

       // Hobbies = Globals.Hobbies;
        //Chores chores = Globals.Chores;

        checkBoxes.Add(hourOne);
        checkBoxes.Add(hourTwo);
        checkBoxes.Add(hourThree);
        checkBoxes.Add(hourFour);
        checkBoxes.Add(hourFive);
        checkBoxes.Add(hourSix);
        checkBoxes.Add(hourSeven);
        checkBoxes.Add(hourEight);
        checkBoxes.Add(hourNine);
        checkBoxes.Add(hourTen);
        checkBoxes.Add(hourEleven);
        checkBoxes.Add(hourTwelve);
        checkBoxes.Add(hourThirteen);
        checkBoxes.Add(hourFourteen);
        checkBoxes.Add(hourFifteen);
        checkBoxes.Add(hourSixteen);
        checkBoxes.Add(hourSeventeen);
        checkBoxes.Add(hourEighteen);
        checkBoxes.Add(hourNineteen);
        checkBoxes.Add(hourTwenty);
        checkBoxes.Add(hourTwentyOne);
        checkBoxes.Add(hourTwentyTwo);
        checkBoxes.Add(hourTwentyThree);
        checkBoxes.Add(hourTwentyFour);

        //checkBoxesHobbies.Add(Art);
        //checkBoxesHobbies.Add(Baking);
        //checkBoxesHobbies.Add(Biking);
        //checkBoxesHobbies.Add(Cooking);
        //checkBoxesHobbies.Add(Fitness);
        //checkBoxesHobbies.Add(Gaming);
        //checkBoxesHobbies.Add(Gardening);
        //checkBoxesHobbies.Add(Music);
        //checkBoxesHobbies.Add(Reading);
        //checkBoxesHobbies.Add(Hiking);

        checkBoxesHobbies.Add(new HobbyCheck(Art, "Art"));
        checkBoxesHobbies.Add(new HobbyCheck(Baking, "Baking"));
        checkBoxesHobbies.Add(new HobbyCheck(Biking, "Biking"));
        checkBoxesHobbies.Add(new HobbyCheck(Cooking, "Cooking"));
        checkBoxesHobbies.Add(new HobbyCheck(Fitness, "Fitness"));
        checkBoxesHobbies.Add(new HobbyCheck(Gaming, "Gaming"));
        checkBoxesHobbies.Add(new HobbyCheck(Gardening, "Gardening"));
        checkBoxesHobbies.Add(new HobbyCheck(Music, "Music"));
        checkBoxesHobbies.Add(new HobbyCheck(Reading, "Reading"));
        checkBoxesHobbies.Add(new HobbyCheck(Hiking, "Hiking"));
       


        //checkBoxesChores.Add(Vacuuming);
        //checkBoxesChores.Add(Dishes);
        //checkBoxesChores.Add(Trash);
        //checkBoxesChores.Add(Bathroom);
        //checkBoxesChores.Add(Kitchen);
        //checkBoxesChores.Add(Dusting);
        //checkBoxesChores.Add(Mopping);
        //checkBoxesChores.Add(Mowing);
        //checkBoxesChores.Add(Groceries);
        //checkBoxesChores.Add(Sweeping);

        checkBoxesChores.Add(new ChoreCheck(Vacuuming, "Vacuuming"));
        checkBoxesChores.Add(new ChoreCheck(Dishes, "Washing dishes"));
        checkBoxesChores.Add(new ChoreCheck(Trash, "Taking out the Trash"));
        checkBoxesChores.Add(new ChoreCheck(Bathroom, "Cleaning the Bathroom"));
        checkBoxesChores.Add(new ChoreCheck(Kitchen, "Cleaning the Kitchen"));
        checkBoxesChores.Add(new ChoreCheck(Dusting, "Dusting"));
        checkBoxesChores.Add(new ChoreCheck(Mopping, "Mopping"));
        checkBoxesChores.Add(new ChoreCheck(Mowing, "Mowing"));
        checkBoxesChores.Add(new ChoreCheck(Groceries, "Grocery Shopping"));
        checkBoxesChores.Add(new ChoreCheck(Sweeping, "Sweeping"));

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

    private void UpdateHobbyandChoreLists()
    {
      //  //to do, update hobbies and chores lists
      //  List<string> list = new List<string>();
      //  List<Roomr.Data.Models.PersonHobby> hobbos = database.GetPersonHobbiesAsync(loggedIn.Id).Result;

      //  foreach (var item in hobbos)
      //  {
      //      list.Add(item.ToString());
      //  }
      

      //  foreach (var item in list)
      //  {
      //      Hobbies.Text += item + ", ";
      //  }
      //Hobbies.Text = Hobbies.Text.Substring(0, Hobbies.Text.Length - 2);
      
      //  //chores
      //  List<string> list2 = new List<string>();
      //  List<Roomr.Data.Models.PersonChore> chores = database.GetPersonChoresAsync(loggedIn.Id).Result;

      //  foreach (var item in chores)
      //  {
      //      list2.Add(item.ToString());
      //  }

      //  foreach (var item in list2)
      //  {
      //      Chores.Text += item + ", ";
      //  }
      //  Chores.Text = Chores.Text.Substring(0, Chores.Text.Length - 2);        
    }


    private async void saveButton_Clicked_async(object sender, EventArgs e)
    {
        //check if any text entries are empty
        if (nameEntry.Text == null || nameEntry.Text == "")
        {
            await DisplayAlert("Error", "Please enter a name", "OK");
            return;
        }
        if (City.Text == null || City.Text == "")
        {
            await DisplayAlert("Error", "Please enter a City", "OK");
            return;
        }
        if (State.Text == null || State.Text == "")
        {
            await DisplayAlert("Error", "Please enter a State", "OK");
            return;
        }
        if (Country.Text == null || Country.Text == "")
        {
            await DisplayAlert("Error", "Please enter a Country", "OK");
            return;
        }
        if(PictureChanger.Source == null)
        {
            await DisplayAlert("Error", "Please choose a picture", "OK");
            return;
        }
        if(Contact.Text == null || Contact.Text == "")
        {
            await DisplayAlert("Error", "Please enter contact information", "OK");
            return;
        }
        //remove folders from the start of the image source string
        string imageSource = PictureChanger.Source.ToString();
        if (imageSource.Length > 25)
        {
            imageSource = imageSource.Substring(25);
        }

        Person person = Globals.loggedInPerson;
            person.postSignUpSetup(nameEntry.Text, Contact.Text, City.Text, State.Text, Country.Text, imageSource); //new Person(nameEntry.Text,Contact.Text,City.Text,State.Text,Country.Text,imageSource);

        //add hobbies and chores
        foreach (var item in checkBoxesHobbies)
        {
            if (item.checkBox.IsChecked)
            {
                //Hobby hobby = new Hobby(item.Text);
                Hobby h = await database.GetHobbyByName(item.hobby);
              await database.SavePersonHobbyAsync(new PersonHobby(person.Id, h.Id));
               
            }
        }
        //chores
        foreach (var item in checkBoxesChores)
        {
            if (item.checkBox.IsChecked)
            {
                //Chore chore = new Chore(item.Text);
                Chore c = await database.GetChoreByName(item.chore);
                await database.SavePersonChoreAsync(new PersonChore(person.Id, c.Id));
            }
        }

        Globals.loggedInPerson = person;
       // Globals.ProfilePerson = person;
        QuietHours quietHours = new QuietHours(person.Id, hourThirteen.IsChecked, hourFourteen.IsChecked, hourFifteen.IsChecked, hourSixteen.IsChecked, hourSeventeen.IsChecked , hourEighteen.IsChecked, hourNineteen.IsChecked, hourTwenty.IsChecked, hourTwentyOne.IsChecked, hourTwentyTwo.IsChecked, hourTwentyThree.IsChecked, hourTwentyFour.IsChecked, hourOne.IsChecked, hourTwo.IsChecked, hourThree.IsChecked, hourFour.IsChecked, hourFive.IsChecked, hourSix.IsChecked, hourSeven.IsChecked, hourEight.IsChecked, hourNine.IsChecked, hourTen.IsChecked, hourEleven.IsChecked, hourTwelve.IsChecked);
        
        await database.SavePersonAsync(person);

        await database.SavePersonAsync(person);

        await Shell.Current.GoToAsync("//FeedPage");

    }

    private async void AddChoreAsync(object sender, EventArgs e)
    {
       //Chore chore = new Chore();
       // chore.Name = chores.Text;
       // await database.SaveChoreAsync(chore);  
       // PersonChore personChore = new PersonChore();
       // personChore.PersonId = loggedIn.Id;
       // personChore.ChoreId = chore.Id;
       // await database.SavePersonChoreAsync(personChore);
       // UpdateHobbyandChoreLists();
    }

    private async void AddHobbyAsync(object sender, EventArgs e)
    {
       // Hobby hobby = new Hobby();
       // hobby.Name = hobbies.Text;
       //await database.SaveHobbyAsync(hobby);
       // PersonHobby personHobby = new PersonHobby();
       // personHobby.PersonId = loggedIn.Id;
       // personHobby.HobbyId = hobby.Id;
       //await database.SavePersonHobbyAsync(personHobby);
       // UpdateHobbyandChoreLists();

    }

    private void HobbiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}