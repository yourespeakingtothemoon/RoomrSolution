using Roomr.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data
{
    public static class Globals
    {
        public static Person loggedInPerson = new Person("", "", "", "", "", "");
        public static RoomrDatabase database = new RoomrDatabase();
        public static Person ProfilePerson { get; set; }

        public static ObservableCollection<Hobby> Hobbies = new ObservableCollection<Hobby>();
        public static ObservableCollection<Chore> Chores = new ObservableCollection<Chore>();
    }
}
