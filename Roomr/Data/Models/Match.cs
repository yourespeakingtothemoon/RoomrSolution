using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("matches")]
    public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int Id1 { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int Id2 { get; set; }

        public Match() { }
    }
}
