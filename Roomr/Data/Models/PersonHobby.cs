using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("personhobby")]
    public class PersonHobby
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int PersonId { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Hobby))]
        public int HobbyId { get; set; }

        public PersonHobby() { }

        public PersonHobby(int PersonId, int HobbyId)
        {
            this.PersonId = PersonId;
            this.HobbyId = HobbyId;
        }

        public override string ToString()
        {
            return "[" + PersonId + ": " + HobbyId + "]";
        }
    }
}
