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
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var personTable = await Database.CreateTableAsync<Person>();
            var prefTable = await Database.CreateTableAsync<Models.Preferences>();
            var hoursTable = await Database.CreateTableAsync<QuietHours>();
            var choreTable = await Database.CreateTableAsync<Chore>();
            var hobbyTable = await Database.CreateTableAsync<Hobby>();
            var matchTable = await Database.CreateTableAsync<Models.Match>();
            var personChoreTable = await Database.CreateTableAsync<PersonChore>();
            var personHobbyTable = await Database.CreateTableAsync<PersonHobby>();
        }

        #region Person DB Stuff
        public async Task<List<Person>> GetPeopleAsync()
        {
            await Init();
            return await Database.Table<Person>().ToListAsync();
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            await Init();
            return await Database.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Person> GetPersonLogin(string username, string password)
        {
            await Init();
            return await Database.Table<Person>().Where(i => i.Username == username && i.Password == password).FirstOrDefaultAsync();
        }

        public async Task<int> SavePersonAsync(Person person)
        {
            await Init();
            if (person.Id != 0)
                return await Database.UpdateAsync(person);
            else
                return await Database.InsertAsync(person);
        }

        public async Task<int> DeleteItemAsync(Person person)
        {
            await Init();
            return await Database.DeleteAsync(person);
        }

        public async Task<List<Person>> GetUsersInSameRegion(Person person)
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
            return Database.Table<Person>().Where(person => person.Username == username).FirstOrDefaultAsync() != null;
        }

        #endregion

        #region Preferences DB Stuff

        public async Task<int> SavePreferencesAsync(Models.Preferences preferences)
        {
            await Init();
            if (preferences.PersonId != 0)
                return await Database.UpdateAsync(preferences);
            else
                return await Database.InsertAsync(preferences);
        }

        public async Task<Models.Preferences> GetUserPreferences(int id)
        {
            await Init();
            return await Database.Table<Models.Preferences>().Where(i => i.PersonId == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeletePreferencesAsync(Models.Preferences preferences)
        {
            await Init();
            return await Database.DeleteAsync(preferences);
        }

        #endregion

        #region QuietHours DB Stuff

        public async Task<int> SaveQuietHoursAsync(QuietHours hours)
        {
            await Init();
            if (hours.PersonId != 0)
                return await Database.UpdateAsync(hours);
            else
                return await Database.InsertAsync(hours);
        }

        public async Task<QuietHours> GetUserQuietHours(int id)
        {
            await Init();
            return await Database.Table<QuietHours>().Where(i => i.PersonId == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteQuietHoursAsync(QuietHours hours)
        {
            await Init();
            return await Database.DeleteAsync(hours);
        }

        #endregion

        #region Chore DB Stuff

        public async Task<int> SaveChoreAsync(Chore chore)
        {
            await Init();
            if (chore.Id != 0)
                return await Database.UpdateAsync(chore);
            else
                return await Database.InsertAsync(chore);
        }

        public async Task<List<Chore>> GetChoresAsync()
        {
            await Init();
            return await Database.Table<Chore>().ToListAsync();
        }

        public async Task<Chore> GetChoreAsync(int id)
        {
            await Init();
            return await Database.Table<Chore>().Where(i => i.Id == id).FirstOrDefaultAsync();
        } 

        public async Task<int> DeleteChoreAsync(Chore chore)
        {
            await Init();
            return await Database.DeleteAsync(chore);
        }

        #endregion

        #region Hobby DB Stuff

        public async Task<int> SaveHobbyAsync(Hobby hobby)
        {
            await Init();
            if (hobby.Id != 0)
                return await Database.UpdateAsync(hobby);
            else
                return await Database.InsertAsync(hobby);
        }

        public async Task<List<Hobby>> GetAllHobbies()
        {
            await Init();
            return await Database.Table<Hobby>().ToListAsync();
        }

        public async Task<Hobby> GetHobbyAsync(int id)
        {
            await Init();
            return await Database.Table<Hobby>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteHobbyAsync(Hobby hobby)
        {
            await Init();
            return await Database.DeleteAsync(hobby);
        }

        #endregion

        #region Match DB Stuff

        public async Task<int> SaveMatchAsync(Models.Match match)
        {
            await Init();
            if (match.Id != 0)
                return await Database.UpdateAsync(match);
            else
                return await Database.InsertAsync(match);
        }

        public async Task<List<Models.Match>> GetMatchesAsync(int personId)
        {
            await Init();
            return await Database.Table<Models.Match>().Where(match => match.Id1 == personId).ToListAsync();
        }

        public async Task<Models.Match> GetMatchByIdAsync(int id)
        {
            await Init();
            return await Database.Table<Models.Match>().Where(match => match.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteMatchAsync(Match match)
        {
            await Init();
            return await Database.DeleteAsync(match);
        }

        #endregion

        #region PersonChore DB Stuff

        public async Task<int> SavePersonChoreAsync(PersonChore personChore)
        {
            await Init();
            if (personChore.Id != 0)
                return await Database.UpdateAsync(personChore);
            else
                return await Database.InsertAsync(personChore);
        }

        public async Task<PersonChore> GetPersonChoreAsync(int personId)
        {
            await Init();
            return await Database.Table<PersonChore>().Where(personChore => personChore.PersonId == personId).FirstOrDefaultAsync();
        }

        public async Task<int> DeletePersonChoreAsync(PersonChore personChore)
        {
            await Init();
            return await Database.DeleteAsync(personChore);
        }

        #endregion

        #region PersonHobby DB Stuff

        public async Task<int> SavePersonHobbyAsync(PersonHobby personHobby)
        {
            await Init();
            if (personHobby.Id != 0)
                return await Database.UpdateAsync(personHobby);
            else
                return await Database.InsertAsync(personHobby);
        }

        public async Task<PersonHobby> GetPersonHobbyAsync(int personId)
        {
            await Init();
            return await Database.Table<PersonHobby>().Where(personHobby => personHobby.PersonId == personId).FirstOrDefaultAsync();
        }

        public async Task<int> DeletePersonHobbyAsync(PersonHobby personHobby)
        {
            await Init();
            return await Database.DeleteAsync(personHobby);
        }

        #endregion
    }
}
