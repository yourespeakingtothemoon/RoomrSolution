﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data.Models
{
    [Table("personchores")]
    public class PersonChore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int PersonId { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Chore))]
        public int ChoreId { get; set; }

        public PersonChore() { }

        public PersonChore(int PersonId, int ChoreId)
        {
            this.PersonId = PersonId;
            this.ChoreId = ChoreId;
        }

        public override string ToString()
        {
            return "[" + PersonId + ": " + ChoreId + "]";
        }
    }
}
