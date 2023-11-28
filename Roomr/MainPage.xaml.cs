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
            await Shell.Current.GoToAsync("//LoginPage");
            //StringBuilder sb = new StringBuilder();
            //List<Person> people = await database.GetPeopleAsync();
            //foreach (Person person in people)
            //{
            //    sb.Append(person);
            //}
            //List<Hobby> hobbies = await database.GetAllHobbies();
            //foreach (Hobby h in hobbies) { sb.Append(h.ToString()); }

            //List<Chore> chores = await database.GetChoresAsync();
            //foreach (Chore chore in chores) { sb.Append(chore.ToString()); }

            //DummyData.Text = sb.ToString();

        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignUpPage");
        }

    }

}
