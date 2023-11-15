using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("preferences")]
    public class Preferences
    {
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int PersonId { get; set; } //Foreign key to Person
        public bool InCollege { get; set; }
        public bool WillingToMove { get; set; }
        public bool HasJob { get; set; }
        public bool WantsAnimals { get; set; }

        public Preferences() { }
    }
}
