using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [SQLite.Table("personchores")]
    public class PersonChore
    {
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int PersonId { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Chore))]
        public int ChoreId { get; set; }
    }
}
