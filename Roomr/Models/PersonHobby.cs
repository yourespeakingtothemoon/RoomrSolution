﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Models
{
    [SQLite.Table("personhobby")]
    public class PersonHobby
    {
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Person))]
        public int PersonId { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Hobby))]
        public int HobbyId { get; set; }
    }
}
