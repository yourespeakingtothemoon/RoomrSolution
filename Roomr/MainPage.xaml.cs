using Roomr.Data;
using Roomr.Data.Models;
using System.Text;

namespace Roomr
{
    public partial class MainPage : ContentPage
    {
        RoomrDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new RoomrDatabase();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
            StringBuilder sb = new StringBuilder();

            List<int> ids = new List<int>();
            List<Person> people = await database.GetPeopleAsync();
            foreach (Person person in people)
            {
                sb.Append(person);
                ids.Add(person.Id);
            }
            List<Hobby> hobbies = await database.GetAllHobbies();
            foreach (Hobby hobby in hobbies) { sb.Append(hobby.ToString()); }

            List<Chore> chores = await database.GetChoresAsync();
            foreach (Chore chore in chores) { sb.Append(chore.ToString()); }

            List<PersonChore> personChores = new List<PersonChore>();
            foreach (int id in ids)
            {
                List<PersonChore> thisPersonsChores = await database.GetPersonChoresAsync(id);
                foreach (PersonChore personChore in thisPersonsChores)
                {
                    personChores.Add(personChore);
                    sb.Append(personChore.ToString());
                }
            }

            List<PersonHobby> personHobbies = new List<PersonHobby>();
            foreach (int id in ids)
            {
                List<PersonHobby> thisPersonsHobbies = await database.GetPersonHobbiesAsync(id);
                foreach (PersonHobby personHobby in thisPersonsHobbies)
                {
                    personHobbies.Add(personHobby);
                    sb.Append(personHobby.ToString());
                }
            }

            DummyData.Text = sb.ToString();

        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignUpPage");
        }

    }

}
