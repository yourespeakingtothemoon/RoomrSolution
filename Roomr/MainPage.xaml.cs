using Roomr.Data;
using Roomr.Data.Models;

namespace Roomr
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        PersonDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new PersonDatabase();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            List<Person> people = await database.GetPeopleAsync();
            foreach(Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            await database.SavePersonAsync(people[8]);

            people = await database.GetPeopleAsync();
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            Person person = new Person("David", "sampleUsername", "samplePass", "Phone number: 867-5309", "Salt Lake City", "Utah", "United States of America", "");
            await database.SavePersonAsync(person);
        }

    }
}