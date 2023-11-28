using Roomr.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data
{
    public class RoomrDatabase
    {
        SQLiteAsyncConnection Database;

        public RoomrDatabase() { }

        async Task Init()
        {
            //if (Database is not null)
            //    return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var personTable = await Database.CreateTableAsync<Person>();
            var prefTable = await Database.CreateTableAsync<Models.Preferences>();
            var hoursTable = await Database.CreateTableAsync<QuietHours>();
            var choreTable = await Database.CreateTableAsync<Chore>();
            var hobbyTable = await Database.CreateTableAsync<Hobby>();
            var matchTable = await Database.CreateTableAsync<Models.Match>();
            var personChoreTable = await Database.CreateTableAsync<PersonChore>();
            var personHobbyTable = await Database.CreateTableAsync<PersonHobby>();

            await Database.DeleteAllAsync<Person>();
            await Database.DeleteAllAsync<Models.Preferences>();
            await Database.DeleteAllAsync<QuietHours>();
            await Database.DeleteAllAsync<Chore>();
            await Database.DeleteAllAsync<Hobby>();
            await Database.DeleteAllAsync<Models.Match>();
            await Database.DeleteAllAsync<PersonChore>();
            await Database.DeleteAllAsync<PersonHobby>();

            await AddDummyData();
        }

        async Task AddDummyData()
        {
            await Database.InsertAllAsync(new List<Object> {
                new Hobby("Cooking"),
                new Hobby("Baking"),
                new Hobby("Reading"),
                new Hobby("Fitness"),
                new Hobby("Biking"),
                new Hobby("Hiking"),
                new Hobby("Gardening"),
                new Hobby("Gaming"),
                new Hobby("Art"),
                new Hobby("Music"),

                new Chore("Vacuuming"),
                new Chore("Sweeping"),
                new Chore("Washing dishes"),
                new Chore("Taking out the Trash"),
                new Chore("Cleaning the Bathroom"),
                new Chore("Cleaning the Kitchen"),
                new Chore("Dusting"),
                new Chore("Grocery Shopping"),
                new Chore("Mopping"),
                new Chore("Mowing"),

                new Person("Tony Stark", "TStark@Avengers.org", "Salt Lake City", "Utah", "United States", "fish_candy.png"),
                new Person("Daenerys Targaryen", "Reach me via Raven", "Salt Lake City", "Utah", "United States", "wheezer.jpg"),
                new Person("Luke Skywalker", "Use the Force", "Albany", "New York", "United States", "joker.jpg"),
                new Person("Frodo Baggins", "Send a Message to the Shire", "Salt Lake City", "Utah", "United States", "tyrunt.jpg"),
            });
        }

        #region Person DB Stuff
        public async Task<List<Person>> GetPeopleAsync() //Returns all Person objects
        {
            await Init();
            return await Database.Table<Person>().ToListAsync();
        }

        public async Task<Person> GetPersonAsync(int id) //Returns a single Person by Id
        {
            await Init();
            return await Database.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Person> GetPersonLogin(string username, string password) //Returns a Person object when a user logs in
        {
            await Init();
            return await Database.Table<Person>().Where(i => i.Username == username && i.Password == password).FirstOrDefaultAsync();
        }

        public async Task<int> SavePersonAsync(Person person) //Returns an int based on whether or not a Person was saved -- can just call the function without saving result
        {
            await Init();
            if (person.Id != 0)
                return await Database.UpdateAsync(person);
            else
                return await Database.InsertAsync(person);
        }

        public async Task<int> DeleteItemAsync(Person person) //Returns an int based on whether or not a Person was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(person);
        }

        public async Task<List<Person>> GetUsersInSameRegion(Person person) //Returns a list of all Person objects that match the given user's country & region (besides themselves)
        {
            await Init();
            return await Database.Table<Person>().Where(
                i => i.Country == person.Country &&
                i.Region == person.Region &&
                i.Id != person.Id)
                .ToListAsync();
        }

        public async Task<bool> CheckIfUsernameExists(string username) //Will return true if username already exists, false if not
        {
            await Init();
            Person person = await Database.Table<Person>().Where(person => person.Username == username).FirstOrDefaultAsync();
            Console.WriteLine(person);

            return person != null;

        }

        #endregion

        #region Preferences DB Stuff

        public async Task<int> SavePreferencesAsync(Models.Preferences preferences) //Returns an int based on whether or not a Preferences object was saved -- can just call the function without saving result
        {
            await Init();
            if (preferences.PersonId != 0)
                return await Database.UpdateAsync(preferences);
            else
                return await Database.InsertAsync(preferences);
        }

        public async Task<Models.Preferences> GetUserPreferences(int id) //Returns a Preferences object for the given Person's Id
        {
            await Init();
            return await Database.Table<Models.Preferences>().Where(i => i.PersonId == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeletePreferencesAsync(Models.Preferences preferences) //Returns an int based on whether or not a Preferences object was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(preferences);
        }

        #endregion

        #region QuietHours DB Stuff

        public async Task<int> SaveQuietHoursAsync(QuietHours hours) //Returns an int based on whether or not a QuietHours object was saved -- can just call the function without saving result
        {
            await Init();
            if (hours.PersonId != 0)
                return await Database.UpdateAsync(hours);
            else
                return await Database.InsertAsync(hours);
        }

        public async Task<QuietHours> GetUserQuietHours(int id) //Returns a QuietHours object based on a Person's Id
        {
            await Init();
            return await Database.Table<QuietHours>().Where(i => i.PersonId == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteQuietHoursAsync(QuietHours hours) //Returns an int based on whether or not a QuietHours object was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(hours);
        }

        #endregion

        #region Chore DB Stuff

        public async Task<int> SaveChoreAsync(Chore chore) //Returns an int based on whether or not a Chore was saved -- can just call the function without saving result
        {
            await Init();
            if (chore.Id != 0)
                return await Database.UpdateAsync(chore);
            else
                return await Database.InsertAsync(chore);
        }

        public async Task<List<Chore>> GetChoresAsync() //Returns all Chore objects
        {
            await Init();
            return await Database.Table<Chore>().ToListAsync();
        }

        public async Task<Chore> GetChoreAsync(int id) //Returns a single Chore by Id
        {
            await Init();
            return await Database.Table<Chore>().Where(i => i.Id == id).FirstOrDefaultAsync();
        } 

        public async Task<int> DeleteChoreAsync(Chore chore) //Returns an int based on whether or not a Chore was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(chore);
        }

        #endregion

        #region Hobby DB Stuff

        public async Task<int> SaveHobbyAsync(Hobby hobby) //Returns an int based on whether or not a Hobby was saved -- can just call the function without saving result
        {
            await Init();
            if (hobby.Id != 0)
                return await Database.UpdateAsync(hobby);
            else
                return await Database.InsertAsync(hobby);
        }

        public async Task<List<Hobby>> GetAllHobbies() //Returns all Hobby objects
        {
            await Init();
            return await Database.Table<Hobby>().ToListAsync();
        }

        public async Task<Hobby> GetHobbyAsync(int id) //Returns a single Chore by Id
        {
            await Init();
            return await Database.Table<Hobby>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteHobbyAsync(Hobby hobby) //Returns an int based on whether or not a Hobby was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(hobby);
        }

        #endregion

        #region Match DB Stuff

        public async Task<int> SaveMatchAsync(Models.Match match) //Returns an int based on whether or not a Match was saved -- can just call the function without saving result
        {
            await Init();
            if (match.Id != 0)
                return await Database.UpdateAsync(match);
            else
                return await Database.InsertAsync(match);
        }

        public async Task<List<Models.Match>> GetMatchesAsync(int personId) //Returns all Match objects
        {
            await Init();
            return await Database.Table<Models.Match>().Where(match => match.Id1 == personId).ToListAsync();
        }

        public async Task<Models.Match> GetMatchByIdAsync(int id) //Returns a single Match by Id
        {
            await Init();
            return await Database.Table<Models.Match>().Where(match => match.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteMatchAsync(Match match) //Returns an int based on whether or not a Match was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(match);
        }

        #endregion

        #region PersonChore DB Stuff

        public async Task<int> SavePersonChoreAsync(PersonChore personChore) //Returns an int based on whether or not a PersonChore was saved -- can just call the function without saving result
        {
            await Init();
            if (personChore.Id != 0)
                return await Database.UpdateAsync(personChore);
            else
                return await Database.InsertAsync(personChore);
        }

        public async Task<PersonChore> GetPersonChoreAsync(int personId) //Returns a single PersonChore object based on a given Person's Id
        {
            await Init();
            return await Database.Table<PersonChore>().Where(personChore => personChore.PersonId == personId).FirstOrDefaultAsync();
        }

        public async Task<int> DeletePersonChoreAsync(PersonChore personChore) //Returns an int based on whether or not a PersonChore was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(personChore);
        }

        #endregion

        #region PersonHobby DB Stuff

        public async Task<int> SavePersonHobbyAsync(PersonHobby personHobby) //Returns an int based on whether or not a PersonHobby was saved -- can just call the function without saving result
        {
            await Init();
            if (personHobby.Id != 0)
                return await Database.UpdateAsync(personHobby);
            else
                return await Database.InsertAsync(personHobby);
        }

        public async Task<List<PersonHobby>> GetPersonHobbyAsync(int personId) //Returns a single PersonHobby object by a given Person's Id
        {
            await Init();
            return await Database.Table<PersonHobby>().Where(personHobby => personHobby.PersonId == personId).ToListAsync();
        }

        public async Task<int> DeletePersonHobbyAsync(PersonHobby personHobby) //Returns an int based on whether or not a PersonHobby was deleted -- can just call the function without saving result
        {
            await Init();
            return await Database.DeleteAsync(personHobby);
        }

        #endregion
    }
}
