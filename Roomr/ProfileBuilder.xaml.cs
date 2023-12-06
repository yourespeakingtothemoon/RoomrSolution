using Roomr.Data.Models;
using Roomr.Data;
namespace Roomr;

public partial class ProfileBuilder : ContentPage
{
    List<CheckBox> checkBoxes = new List<CheckBox>();
    bool isEditing = false;
    RoomrDatabase database = new RoomrDatabase();
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

       


        checkBoxes.Add(twelveAM);
        checkBoxes.Add(oneAM);
        checkBoxes.Add(twoAM);
        checkBoxes.Add(threeAM);
        checkBoxes.Add(fourAM);
        checkBoxes.Add(fiveAM);
        checkBoxes.Add(sixAM);
        checkBoxes.Add(sevenAM);
        checkBoxes.Add(eightAM);
        checkBoxes.Add(nineAM);
        checkBoxes.Add(tenAM);
        checkBoxes.Add(elevenAM);
        checkBoxes.Add(twelvePM);
        checkBoxes.Add(onePM);
        checkBoxes.Add(twoPM);
        checkBoxes.Add(threePM);
        checkBoxes.Add(fourPM);
        checkBoxes.Add(fivePM);
        checkBoxes.Add(sixPM);
        checkBoxes.Add(sevenPM);
        checkBoxes.Add(eightPM);
        checkBoxes.Add(ninePM);
        checkBoxes.Add(tenPM);
        checkBoxes.Add(elevenPM);

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
        //to do, update hobbies and chores lists
        List<string> list = new List<string>();
        List<Roomr.Data.Models.PersonHobby> hobbos = database.GetPersonHobbiesAsync(loggedIn.Id).Result;

        foreach (var item in hobbos)
        {
            list.Add(item.ToString());
        }
      

        foreach (var item in list)
        {
            Hobbies.Text += item + ", ";
        }
      Hobbies.Text = Hobbies.Text.Substring(0, Hobbies.Text.Length - 2);
      
        //chores
        List<string> list2 = new List<string>();
        List<Roomr.Data.Models.PersonChore> chores = database.GetPersonChoresAsync(loggedIn.Id).Result;

        foreach (var item in chores)
        {
            list2.Add(item.ToString());
        }

        foreach (var item in list2)
        {
            Chores.Text += item + ", ";
        }
        Chores.Text = Chores.Text.Substring(0, Chores.Text.Length - 2);        
    }


    private async void saveButton_Clicked_async(object sender, EventArgs e)
    {
        if (isEditing)
        {
            //this saves entered data to the database, except chores and hobbies, which will require a seperate button
            if (nameEntry.Text != null)
            {
                Globals.loggedInPerson.Name = nameEntry.Text;
            }
            //if picture is different, save it
            if (PictureChanger.Source != null)
            {
                Globals.loggedInPerson.ProfilePicture = PictureChanger.Source.ToString();
            }

            //quiet hours
            foreach (CheckBox ch in checkBoxes)
            {
                //Globals.loggedInPerson.Id;
                //to do, save quiet hours to database
            }
        }
        else
        {
            {
                //this saves entered data to the database, except chores and hobbies, which will require a seperate button requires every field for new user
                if (nameEntry.Text == null)
                {
                    DisplayAlert("Error", "Please select a profile picture", "OK");

                }
                else
                {
                    Globals.loggedInPerson.Name = nameEntry.Text;
                }
                if (PictureChanger.Source == null)
                {
                    //DisplayAlert("Error", "Please select a profile picture", "OK");
                }
                else
                {
                    Globals.loggedInPerson.ProfilePicture = PictureChanger.Source.ToString();
                }
                //quiet hours
                foreach (CheckBox ch in checkBoxes)
                {
                    //Globals.loggedInPerson.Id;
                    //to do, save quiet hours to database
                }

                //hobbies and chores?

                //database call

            }
        }

        await database.SavePersonAsync(Globals.loggedInPerson);

    }

    private async void AddChoreAsync(object sender, EventArgs e)
    {
       Chore chore = new Chore();
        chore.Name = chores.Text;
        await database.SaveChoreAsync(chore);  
        PersonChore personChore = new PersonChore();
        personChore.PersonId = loggedIn.Id;
        personChore.ChoreId = chore.Id;
        await database.SavePersonChoreAsync(personChore);
        UpdateHobbyandChoreLists();
    }

    private async void AddHobbyAsync(object sender, EventArgs e)
    {
        Hobby hobby = new Hobby();
        hobby.Name = hobbies.Text;
       await database.SaveHobbyAsync(hobby);
        PersonHobby personHobby = new PersonHobby();
        personHobby.PersonId = loggedIn.Id;
        personHobby.HobbyId = hobby.Id;
       await database.SavePersonHobbyAsync(personHobby);
        UpdateHobbyandChoreLists();

    }

    private void HobbiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}