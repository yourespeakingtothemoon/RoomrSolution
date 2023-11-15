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
            var matchTable = await Database.CreateTableAsync<Match>();
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

        #endregion
    }
}
